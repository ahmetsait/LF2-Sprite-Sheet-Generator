using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

using OpenTK;
using Gr = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using NX;
using NX.Graphics;
using System.Text;
using System.IO;

namespace LF2.Sprite_Sheet_Generator
{
	#region Enums
	public enum EditMode : byte
	{
		Move,
		Rotate,
		Scale
	}
	#endregion
	
	public class TemplateBox : GLControl
	{
		#region Constructors

		#if DEBUG
		public TemplateBox() : base(Gr.GraphicsMode.Default, 3, 3, Gr.GraphicsContextFlags.ForwardCompatible | Gr.GraphicsContextFlags.Debug)
		#else
		public TemplateBox() : base(Gr.GraphicsMode.Default, 3, 3, Gr.GraphicsContextFlags.ForwardCompatible)
		#endif
		{
			MakeCurrent();
			VSync = false;
			
			openGLVersionMajor = GL.GetInteger(GetPName.MajorVersion);
			openGLVersionMinor = GL.GetInteger(GetPName.MinorVersion);

			extensions = new HashSet<string>();
			int extensionCount = GL.GetInteger(GetPName.NumExtensions);
			for (int i = 0; i < extensionCount; i++)
				extensions.Add(GL.GetString(StringNameIndexed.Extensions, i));
			
			#if DEBUG
			lock (logLock)
			{
				if (logger == null)
					logger = File.AppendText("opengl_debug_log.txt");
				logger.WriteLine("========================================");
				logger.WriteLine("Renderer: {0}", GL.GetString(StringName.Renderer));
				logger.WriteLine("OpenGL Version: {0}", GL.GetString(StringName.Version));
				logger.WriteLine("GLSL Version: {0}", GL.GetString(StringName.ShadingLanguageVersion));
				logger.WriteLine("Vendor: {0}", GL.GetString(StringName.Vendor));
				logger.WriteLine("Time: {0}", DateTime.Now.ToString());
				logger.WriteLine("----------------------------------------");
				logger.Flush(); 
			}

			bool debugSupported = true;
			if (openGLVersionMajor >= 4 && openGLVersionMinor >= 3)
				GL.DebugMessageCallback(
						(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam) =>
						{
							lock (logLock)
							{
								logger.WriteLine($"[{id} - {source}, {type}, {severity}]: {Marshal.PtrToStringAnsi(message, length)}");
								var trace = new StackTrace(1, true);
								logger.WriteLine(trace.ToString());
								logger.Flush();
							}
						},
						IntPtr.Zero
					);
			else if (extensions.Contains("GL_KHR_debug"))
				GL.Khr.DebugMessageCallback(
						(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam) =>
						{
							lock (logLock)
							{
								logger.WriteLine($"[{id} - {source}, {type}, {severity}]: {Marshal.PtrToStringAnsi(message, length)}");
								var trace = new StackTrace(1, true);
								logger.WriteLine(trace.ToString());
								logger.Flush();
							}
						},
						IntPtr.Zero
					);
			else if (extensions.Contains("GL_ARB_debug_output"))
				GL.Arb.DebugMessageCallback(
						(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam) =>
						{
							lock (logLock)
							{
								logger.WriteLine($"[{id} - {source}, {type}, {severity}]: {Marshal.PtrToStringAnsi(message, length)}");
								var trace = new StackTrace(1, true);
								logger.WriteLine(trace.ToString());
								logger.Flush();
							}
						},
						IntPtr.Zero
					);
			else
				debugSupported = false;
			if (debugSupported)
				GL.Enable(EnableCap.DebugOutput);
			#endif
			
			GL.Disable(EnableCap.CullFace);
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);
			GL.Enable(EnableCap.LineSmooth);
			GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
				
			guideImageMesh = new Mesh();
			guideImageMesh.vertices = new Vertex[4];
			guideImageMesh.vertices[0] = new Vertex()
			{
				position = new Vector2(-1, -1),
				texCoord = new Vector2(0, 0),
				color = new Vector4(1, 1, 1, guideImageAlpha)
			};
			guideImageMesh.vertices[1] = new Vertex()
			{
				position = new Vector2(1, -1),
				texCoord = new Vector2(1, 0),
				color = new Vector4(1, 1, 1, guideImageAlpha)
			};
			guideImageMesh.vertices[2] = new Vertex()
			{
				position = new Vector2(1, 1),
				texCoord = new Vector2(1, 1),
				color = new Vector4(1, 1, 1, guideImageAlpha)
			};
			guideImageMesh.vertices[3] = new Vertex()
			{
				position = new Vector2(-1, 1),
				texCoord = new Vector2(0, 1),
				color = new Vector4(1, 1, 1, guideImageAlpha)
			};

			if (guideImageMesh.indices == null)
				guideImageMesh.indices = new uint[4] { 0, 1, 2, 3 };

			if (!guideImageMesh.CheckBufferIntegration())
				throw new ApplicationException("Guide image mesh not integrated.");

			guideImageMesh.Reload(BufferUsageHint.StaticDraw);

			renderShader = new Shader(mainVert, renderFrag = File.ReadAllText("render.frag"));
			guideShader = new Shader(guideVert, guideFrag);
			mainShader = new Shader(mainVert, renderFrag);
			tileShader = new Shader(tileVert, tileFrag);

			var quad = new Vector2[4] { new Vector2(-1, -1), new Vector2(1, -1), new Vector2(1, 1), new Vector2(-1, 1) };

			GL.GenVertexArrays(1, out chessBoardVao);
			GL.GenBuffers(1, out chessBoardVbo);

			GL.BindVertexArray(chessBoardVao);
			{
				GL.BindBuffer(BufferTarget.ArrayBuffer, chessBoardVbo);
				GL.BufferData(BufferTarget.ArrayBuffer, quad.Length * Vector2.SizeInBytes, quad, BufferUsageHint.StaticDraw);

				GL.EnableVertexAttribArray(0);
				GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, Vector2.SizeInBytes, 0);
			}
			GL.BindVertexArray(0);

			base.TabStop = false;
			this.renders = new List<Render>(128);
			this.Sprites = new Dictionary<string, Tuple<Bitmap,  int>>(16);
			this.selectedRenders = new HashSet<int>();
		}

		#endregion

		#region Fields

		HashSet<string> extensions;
		int openGLVersionMajor, openGLVersionMinor;

		#if DEBUG
		protected static StreamWriter logger;
		protected static object logLock = new object();
		#endif

		private const string guideVert = @"#version 330 core

layout (location = 0) in vec2 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec4 color;

out vec2 texCoordFrag;
out vec4 colorFrag;

uniform int width;
uniform int height;
uniform vec2 offset;
uniform float zoom;

uniform sampler2D tex;

float map(float value, float min1, float max1, float min2, float max2)
{
	return (value - min1) * (max2 - min2) / (max1 - min1) + min2;
}

void main()
{
	vec2 texSize = textureSize(tex, 0);
	vec2 pos = vec2(
		map(position.x, -1, 1, 0, texSize.x),
		map(position.y, -1, 1, 0, texSize.y)
	);
	pos = (pos - offset) * zoom;
	gl_Position = vec4(vec2(map(pos.x, 0, width, 0, 2), map(pos.y, 0, height, 0, -2)), 0.0, 1.0);
	texCoordFrag = texCoord;
	colorFrag = color;
}";
		private const string guideFrag = @"#version 330 core

in vec2 texCoordFrag;
in vec4 colorFrag;

out vec4 fragColor;

uniform vec4 highPassFilter;
uniform sampler2D tex;

void main()
{
	vec4 c = texture(tex, texCoordFrag) * colorFrag;
	if (c.r <= highPassFilter.r || c.g <= highPassFilter.g || c.b <= highPassFilter.b || c.a <= highPassFilter.a)
		discard;
	fragColor = c;
}";
		private const string mainVert = @"#version 330 core

layout (location = 0) in vec2 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec4 color;

out vec2 texCoordFrag;
out vec4 colorFrag;

uniform int width;
uniform int height;
uniform vec2 offset;
uniform float zoom;

uniform sampler2D tex;
uniform vec2 location;
uniform float rotation;
uniform float scale;

float map(float value, float min1, float max1, float min2, float max2)
{
	return (value - min1) * (max2 - min2) / (max1 - min1) + min2;
}

vec2 rotate(vec2 v, float a)
{
	float s = sin(a);
	float c = cos(a);
	mat2 m = mat2(c, s, -s, c);
	return m * v;
}

void main()
{
	vec2 texSize = textureSize(tex, 0);
	vec2 pos = rotate(position * texSize / 2 * scale, rotation);
	pos = (pos + location - offset) * zoom;
	gl_Position = vec4(vec2(map(pos.x, 0, width, 0, 2), map(pos.y, 0, height, 0, -2)), 0.0, 1.0);
	texCoordFrag = texCoord;
	colorFrag = color;
}";
		private const string mainFrag = @"#version 330 core

in vec2 texCoordFrag;
in vec4 colorFrag;

out vec4 fragColor;

uniform vec4 highPassFilter;
uniform sampler2D tex;

void main()
{
	vec4 c = texture(tex, texCoordFrag) * colorFrag;
	if (c.r <= highPassFilter.r || c.g <= highPassFilter.g || c.b <= highPassFilter.b || c.a <= highPassFilter.a)
		discard;
	fragColor = c;
}";
		private const string tileVert = @"#version 330 core

layout (location = 0) in vec2 position;

void main()
{
	gl_Position = vec4(position, 0.0, 1.0);
}";
		private const string tileFrag = @"#version 330 core

layout (origin_upper_left) in vec4 gl_FragCoord;
out vec4 fragColor;

void main()
{
	vec2 pos = mod(gl_FragCoord.xy, 16.0);
	if ((pos.x < 8) != (pos.y < 8))
		fragColor = vec4(1.0, 1.0, 1.0, 1.0);
	else
		fragColor = vec4(0.75, 0.75, 0.75, 1.0);
}";

		private string renderFrag;
		private Shader? mainShader, guideShader, tileShader, renderShader;

		public Dictionary<string, Tuple<Bitmap, int>> Sprites { get; private set; }

		readonly List<Render> renders;
		public IReadOnlyList<Render> Renders { get { return renders; } }
		readonly HashSet<int> selectedRenders;
		public IReadOnlyCollection<int> SelectedRenders { get { return selectedRenders; } }

		public event EventHandler RendersChanged;
		public event EventHandler SelectionChanged;
		
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool TabStop { get { return false; } }
		
		EditMode editMode;
		[DefaultValue(EditMode.Move)]
		public EditMode EditMode
		{
			get { return editMode; }
			set
			{
				EditMode old = editMode;
				editMode = value;
				this.Invalidate();

				if (old != value && EditModeChanged != null)
				{
					EditModeChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler EditModeChanged;

		bool imageBoundsDirty = true;
		Rectangle _imageBounds;
		public Rectangle ImageBounds
		{
			get
			{
				if (imageBoundsDirty)
					_imageBounds = new Rectangle(
						(int)(this.Width / 2f - offset.X * zoom),
						(int)(this.Height / 2f - offset.Y * zoom),
						(int)(guideImage != null ? guideImage.Width * zoom : 0),
						(int)(guideImage != null ? guideImage.Height * zoom : 0)
					);
				return _imageBounds;
			}
		}

		float zoom = 1f;
		[DefaultValue(1f)]
		public float Zoom
		{
			get { return zoom; }
			set
			{
				float old = zoom;
				zoom = Math.Max(0.1f, value);
				if (old != zoom)
				{
					coordinatePen.Width = zoom;
					imageBoundsDirty = true;
					this.Invalidate();

					ZoomChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ZoomChanged;

		PointF offset;
		public PointF Offset
		{
			get { return offset; }
			set
			{
				PointF old = offset;
				offset = guideImage != null ? value.Clamp(0, guideImage.Width, 0, guideImage.Height) : value;
				if (old != offset)
				{
					imageBoundsDirty = true;
					this.Invalidate();

					OffsetChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler OffsetChanged;

		bool autoFocus;
		[DefaultValue(false)]
		public bool AutoFocus
		{
			get { return autoFocus; }
			set
			{
				bool old = autoFocus;
				autoFocus = value;

				this.Invalidate();

				if (old != value && AutoFocusChanged != null)
				{
					AutoFocusChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler AutoFocusChanged;

		bool guideTransparency;
		[DefaultValue(false)]
		public bool GuideTransparency
		{
			get { return guideTransparency; }
			set
			{
				bool old = guideTransparency;
				if (old != value)
				{
					guideTransparency = value;
					this.Invalidate();
					GuideTransparencyChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideTransparencyChanged;

		Gr.Color4 highPassFilter = new Gr.Color4(-1f, -1f, -1f, -1f);
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public Gr.Color4 HighPassFilter
		{
			get { return highPassFilter; }
			set
			{
				var old = highPassFilter;
				if (old != value)
				{
					highPassFilter = value;
					this.Invalidate();
					TransparencyKeyChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TransparencyKeyChanged;
		
		bool showCoordinateSystem;
		[DefaultValue(false)]
		public bool ShowCoordinateSystem
		{
			get { return showCoordinateSystem; }
			set
			{
				bool old = showCoordinateSystem;
				showCoordinateSystem = value;
				this.Invalidate();

				if (old != value && ShowCoordinateSystemChanged != null)
				{
					ShowCoordinateSystemChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ShowCoordinateSystemChanged;

		Pen coordinatePen = new Pen(Color.Red) { DashStyle = DashStyle.Dash };
		[Browsable(false)]
		public Pen CoordinatePen
		{
			get { return coordinatePen; }
			private set
			{
				Pen old = coordinatePen;
				coordinatePen = value;
				this.Invalidate();

				if (old != value && CoordinatePenChanged != null)
				{
					CoordinatePenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler CoordinatePenChanged;

		[DefaultValue(typeof(Color), "Red")]
		public Color CoordinatePenColor
		{
			get { return coordinatePen.Color; }
			set
			{
				Color old = coordinatePen.Color;
				coordinatePen.Color = value;
				this.Invalidate();

				if (old != value && CoordinatePenChanged != null)
				{
					CoordinatePenChanged(this, EventArgs.Empty);
				}
			}
		}

		Pen selectionPen = new Pen(Color.Orange) { Width = 2 };
		SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(64, Color.Orange));

		Color selectionColor = Color.Orange;
		[DefaultValue(typeof(Color), "Orange")]
		public Color SelectionColor
		{
			get { return selectionPen.Color; }
			set
			{
				var old = selectionColor;
				selectionPen.Color = value;
				selectionBrush.Color = Color.FromArgb(64, value);
				this.Invalidate();

				if (old != value && SelectionColorChanged != null)
				{
					SelectionColorChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler SelectionColorChanged;

		int missingImageTex;
		Bitmap missingImage;
		[DefaultValue(null)]
		public Bitmap MissingImage
		{
			get { return missingImage; }
			set
			{
				Bitmap old = missingImage;
				if (!Object.ReferenceEquals(old, value))
				{
					missingImage = value;
					if (missingImage != null)
						missingImageTex = missingImage.LoadTextureGL(missingImageTex);
					else
						missingImageTex = 0;
					this.Invalidate();

					MissingImageChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler MissingImageChanged;

		Mesh guideImageMesh;

		int guideImageTex;
		Bitmap guideImage;
		[DefaultValue(null)]
		public Bitmap GuideImage
		{
			get { return guideImage; }
			set
			{
				Bitmap old = guideImage;
				if (!Object.ReferenceEquals(old, value))
				{
					guideImage = value;
					if (guideImage != null)
						guideImageTex = guideImage.LoadTextureGL(guideImageTex);
					else
						guideImageTex = 0;
					Offset = offset;
					imageBoundsDirty = true;
					this.Invalidate();

					GuideImageChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideImageChanged;

		float guideImageAlpha = 0.5f;
		[DefaultValue(0.5f)]
		public float GuideImageAlpha
		{
			get { return guideImageAlpha; }
			set
			{
				float old = guideImageAlpha;
				if (old != value)
				{
					guideImageAlpha = value;
					if (guideImageMesh.OverwriteColor(new Gr.Color4(1, 1, 1, guideImageAlpha)))
						guideImageMesh.Reload(index:false);
					this.Invalidate();
					GuideImageAlphaChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideImageAlphaChanged;

		InterpolationMode guideInterpolation;
		[DefaultValue(InterpolationMode.Default)]
		public InterpolationMode GuideInterpolation
		{
			get { return guideInterpolation; }
			set
			{
				InterpolationMode old = guideInterpolation;
				guideInterpolation = value;
				this.Invalidate();

				if (old != value && GuideInterpolationChanged != null)
				{
					GuideInterpolationChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideInterpolationChanged;
		
		private int chessBoardVao;
		private int chessBoardVbo;
		bool backgroundChessBoard = true;
		[DefaultValue(true)]
		public bool BackgroundChessBoard
		{
			get { return backgroundChessBoard; }
			set
			{
				bool old = backgroundChessBoard;
				backgroundChessBoard = value;

				this.Invalidate();

				if (old != value && BackgroundChessBoardChanged != null)
				{
					BackgroundChessBoardChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler BackgroundChessBoardChanged;

#endregion

		#region Methods

		public virtual Bitmap RenderFinalImage(int alphaCut, int transparencyRange, bool onGuide, bool alphaChannel)
		{
			Bitmap result = new Bitmap(
				guideImage.Width, guideImage.Height, alphaChannel ?
				System.Drawing.Imaging.PixelFormat.Format32bppArgb : System.Drawing.Imaging.PixelFormat.Format24bppRgb
			);
			Bitmap canvas = new Bitmap(guideImage.Width, guideImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(canvas))
			{
				g.Clear(Color.FromArgb(0, Color.Black));
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				foreach (Render render in renders)
				{
					if (render.transform.Scale == 0f)
						continue;
					Bitmap sprite;
					if (TryGetImageFromSpriteName(render.symbolName, out sprite, false))
					{
						using (sprite = ((Bitmap)sprite.Clone()))
						{
							((Bitmap)sprite).ApplyBlackFilter((byte)transparencyRange.Clamp(0, 255));
							g.TranslateTransform(render.transform.X, render.transform.Y);
							g.RotateTransform(render.transform.Rotation);
							g.ScaleTransform(render.transform.Scale, render.transform.Scale);
							Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
							g.DrawImage(
								sprite,
								spriteBounds,
								0, 0, sprite.Width, sprite.Height,
								GraphicsUnit.Pixel
							);
							g.ResetTransform();
						}
					}
				}
			}
			canvas.ApplyAlphaCutFilter((byte)alphaCut.Clamp(0, 255));
			using (Graphics g = Graphics.FromImage(result))
			{
				if (!alphaChannel)
					g.Clear(Color.Black);
				else
					g.Clear(Color.FromArgb(0, Color.Black));
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				if (onGuide)
				{
					g.DrawImage(
						guideImage,
						new Rectangle(0, 0, result.Width, result.Height),
						0, 0, canvas.Width, canvas.Height,
						GraphicsUnit.Pixel
					);
				}
				g.DrawImage(
					canvas,
					new Rectangle(0, 0, result.Width, result.Height),
					0, 0, canvas.Width, canvas.Height,
					GraphicsUnit.Pixel
				);
			}
			if(alphaChannel)
				result.ApplyAlphaCutFilter((byte)alphaCut.Clamp(0, 255));
			result.ApplyBlackFilter((byte)transparencyRange.Clamp(0, 255));
			return result;
		}

		public virtual void ScaleFit()
		{
			if (guideImage != null)
			{
				Offset = new PointF(guideImage.Width / 2f, guideImage.Height / 2f);
				Zoom = ExpandToBound(guideImage.Size, this.Size).Item1;
			}
		}

		public virtual void AddRender(string spriteName, Transform transform)
		{
			renders.Add(new Render(spriteName, transform));
			RendersChanged?.Invoke(this, EventArgs.Empty);
		}

		public virtual void LoadTemplate(IEnumerable<Render> template)
		{
			this.selectedRenders.Clear();
			this.renders.Clear();
			this.renders.AddRange(template);
			SelectionChanged?.Invoke(this, EventArgs.Empty);
			RendersChanged?.Invoke(this, EventArgs.Empty);
		}

		public virtual Point GetRenderLocation(Render render)
		{
			return render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).ToPoint();
		}

		public virtual PointF GetMidPointOfSelection()
		{
			PointF result = new PointF(0, 0);
			int count = 0;
			foreach (int index in selectedRenders)
			{
				result = result.Add(renders[index].transform.Location);
				count++;
			}
			return result.Divide(count);
		}

		public virtual void DeleteSelection()
		{
			if (selectedRenders.Count > 0)
			{
				int[] indices = new int[selectedRenders.Count];
				selectedRenders.CopyTo(indices);
				Array.Sort(indices);
				for (int i = indices.Length - 1; i >= 0; i--)
				{
					renders.RemoveAt(indices[i]);
					selectedRenders.Remove(indices[i]);
				}
				RendersChanged?.Invoke(this, EventArgs.Empty);
				SelectionChanged?.Invoke(this, EventArgs.Empty);
				this.Invalidate();
			}
		}

		public virtual void DuplicateSelection()
		{
			if (selectedRenders.Count > 0)
			{
				int[] indices = new int[selectedRenders.Count];
				selectedRenders.CopyTo(indices);
				Array.Sort(indices);
				for (int i = 0; i < indices.Length; i++)
				{
					renders.Add(renders[indices[i]].Clone());
					selectedRenders.Remove(indices[i]);
					selectedRenders.Add(renders.Count - 1);
				}
				RendersChanged?.Invoke(this, EventArgs.Empty);
				SelectionChanged?.Invoke(this, EventArgs.Empty);
				this.Invalidate();
			}
		}

		public virtual bool TryGetImageFromSpriteName(string spriteName, out Bitmap image, bool missingSafe = true)
		{
			Tuple<Bitmap, int> sprite;
			if (spriteName == null || !Sprites.TryGetValue(spriteName, out sprite) || sprite == null)
			{
				if (missingImage != null && missingSafe)
				{
					image = missingImage;
					return true;
				}
				else
				{
					image = null;
					return false;
				}
			}
			else
			{
				image = sprite.Item1;
				return true;
			}
		}

		public virtual bool TryGetImageFromSpriteName(string spriteName, out Bitmap image, out int tex, bool missingSafe = true)
		{
			Tuple<Bitmap, int> sprite;
			if (spriteName == null || !Sprites.TryGetValue(spriteName, out sprite) || sprite == null)
			{
				if (missingImage != null && missingSafe)
				{
					image = missingImage;
					tex = missingImageTex;
					return true;
				}
				else
				{
					image = null;
					tex = 0;
					return false;
				}
			}
			else
			{
				image = sprite.Item1;
				tex = sprite.Item2;
				return true;
			}
		}

		public virtual bool TrySelectRenderIndexFromLocation(Point location, out int index)
		{
			int? selection = null;
			long selectedSquareDistance = long.MaxValue;
			for (int i = 0; i < renders.Count; i++)
			{
				Point p = GetRenderLocation(renders[i]);
				Point diff = location.Substract(p).Divide(zoom);
				long squareDistance = (long)diff.X * diff.X + (long)diff.Y * diff.Y;
				Bitmap image;
				if (TryGetImageFromSpriteName(renders[i].symbolName, out image))
				{
					long radius = (long)(Math.Min(image.Width, image.Height) * renders[i].transform.Scale / 2);
					if (squareDistance <= radius * radius)
					{
						if (!selection.HasValue || squareDistance <= selectedSquareDistance)
						{
							selection = i;
							selectedSquareDistance = squareDistance;
						}
					}
				}
			}
			if (selection.HasValue)
				index = selection.Value;
			else
				index = -1;
			return selection.HasValue;
		}

		public virtual bool TrySelectRenderFromLocation(Point location, out Render render)
		{
			int index;
			bool success = TrySelectRenderIndexFromLocation(location, out index);
			if (success)
				render = renders[index];
			else
				render = null;
			return success;
		}

		public virtual List<Render> GetRendersInArea(Rectangle area)
		{
			List<Render> result = new List<Render>();
			for (int i = 0; i < renders.Count; i++)
			{
				Point p = GetRenderLocation(renders[i]);
				if (area.Contains(p))
					result.Add(renders[i]);
			}
			return result;
		}

		public virtual HashSet<int> GetRenderIndicesInArea(Rectangle area)
		{
			HashSet<int> result = new HashSet<int>();
			for (int i = 0; i < renders.Count; i++)
			{
				Point p = GetRenderLocation(renders[i]);
				if (area.Contains(p))
					result.Add(i);
			}
			return result;
		}

		public virtual PointF GetImageCoordFromMousePosition(Point mouse)
		{
			PointF coord = mouse;
			RectangleF imageBounds = ImageBounds, controlBounds = new RectangleF(0, 0, this.Width, this.Height);

			return coord.Substract(imageBounds.Location).Divide(zoom);
		}

		public virtual void BringSelectionToFront()
		{
			Render[] selection = new Render[selectedRenders.Count];
			int[] indices = new int[selectedRenders.Count];
			selectedRenders.CopyTo(indices);
			Array.Sort(indices);
			for (int i = indices.Length - 1; i >= 0; i--)
			{
				int index = indices[i];
				selection[i] = renders[index];
				renders.RemoveAt(index);
			}
			int start = renders.Count;
			renders.AddRange(selection);
			selectedRenders.Clear();
			for (int i = start; i < renders.Count; i++)
				selectedRenders.Add(i);
			this.Invalidate();
			RendersChanged?.Invoke(this, EventArgs.Empty);
		}

		public virtual void SendSelectionToBack()
		{
			Render[] selection = new Render[selectedRenders.Count];
			int[] indices = new int[selectedRenders.Count];
			selectedRenders.CopyTo(indices);
			Array.Sort(indices);
			for (int i = indices.Length - 1; i >= 0; i--)
			{
				int index = indices[i];
				selection[i] = renders[index];
				renders.RemoveAt(index);
			}
			renders.InsertRange(0, selection);
			selectedRenders.Clear();
			for (int i = 0; i < selection.Length; i++)
				selectedRenders.Add(i);
			this.Invalidate();
			RendersChanged?.Invoke(this, EventArgs.Empty);
		}

		private static Tuple<float, Rectangle> ExpandToBound(Size size, Size box, bool fill = false)
		{
			double widthScale = 0, heightScale = 0;
			
			if (size.Width != 0)
				widthScale = (double)box.Width / (double)size.Width;
			if (size.Height != 0)
				heightScale = (double)box.Height / (double)size.Height;

			double scale = fill ? Math.Max(widthScale, heightScale) : Math.Min(widthScale, heightScale);
			
			Size result = new Size((int)(size.Width * scale), (int)(size.Height * scale));
			return Tuple.Create((float)scale, new Rectangle(new Point((box.Width - result.Width) / 2, (box.Height - result.Height) / 2), result));
		}
		
		[EditorBrowsable]
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			imageBoundsDirty = true;

			MakeCurrent();
			GL.Viewport(this.ClientRectangle);

			this.Invalidate();
		}

		#endregion

		#region Painting

		[EditorBrowsable]
		protected override void OnPaint(PaintEventArgs e)
		{
			//MakeCurrent();
			if (backgroundChessBoard)
			{
				tileShader?.Use();
				GL.BindVertexArray(chessBoardVao);
				GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
				GL.BindVertexArray(0);
			}
			else
			{
				GL.ClearColor(BackColor);
				GL.Clear(ClearBufferMask.ColorBufferBit);
			}
			if (guideShader.HasValue)
			{
				var shader = guideShader.Value;
				shader.Use();
				shader.SetUniform("width", ClientSize.Width);
				shader.SetUniform("height", ClientSize.Height);
				shader.SetUniform("offset", new Vector2(offset.X, offset.Y));
				shader.SetUniform("zoom", zoom);
				if (guideImageTex != 0)
				{
					shader.SetUniform("highPassFilter", guideTransparency ? Vector4.Zero : -Vector4.One);
					GL.BindTexture(TextureTarget.Texture2D, guideImageTex);
					guideImageMesh.Draw(PrimitiveType.TriangleFan);
					GL.BindTexture(TextureTarget.Texture2D, 0);
				}
			}
			if (showCoordinateSystem)
			{
				//TODO
			}
			if (mainShader.HasValue)
			{
				var shader = mainShader.Value;
				shader.Use();
				shader.SetUniform("width", ClientSize.Width);
				shader.SetUniform("height", ClientSize.Height);
				shader.SetUniform("offset", new Vector2(offset.X, offset.Y));
				shader.SetUniform("zoom", zoom);
				foreach (Render render in renders)
				{
					if (render.transform.Scale == 0f)
						continue;
					Bitmap sprite;
					int tex;
					if (TryGetImageFromSpriteName(render.symbolName, out sprite, out tex))
					{
						shader.SetUniform("highPassFilter", highPassFilter.ToVector());
						shader.SetUniform("location", new Vector2(render.transform.Location.X, render.transform.Location.Y));
						shader.SetUniform("rotation", (float)Extensions.Degree2Radian(render.transform.Rotation));
						shader.SetUniform("scale", render.transform.Scale);
						GL.BindTexture(TextureTarget.Texture2D, tex);
						guideImageMesh.Draw(PrimitiveType.TriangleFan);
						GL.BindTexture(TextureTarget.Texture2D, 0);
					}
				}
			}
			SwapBuffers();
			//{
			//	e.Graphics.InterpolationMode = backgroundInterpolation;
			//	base.OnPaintBackground(e);

			//	e.Graphics.SmoothingMode = smoothing;
			//	if (guideImage != null)
			//	{
			//		if (guideInterpolation == InterpolationMode.Default)
			//			e.Graphics.InterpolationMode = zoom >= 1 ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBilinear;
			//		else
			//			e.Graphics.InterpolationMode = guideInterpolation;
			//		e.Graphics.DrawImage(guideImage, ImageBounds, 0, 0, guideImage.Width, guideImage.Height, GraphicsUnit.Pixel, guideImageAttr);
			//	}
			//	if (showCoordinateSystem)
			//	{
			//		if (ImageBounds.X > -zoom / 2 && ImageBounds.X < this.Width + zoom / 2)
			//			e.Graphics.DrawLine(coordinatePen, ImageBounds.X - zoom / 2, 0, ImageBounds.X - zoom / 2, this.Height);
			//		if (ImageBounds.Y > -zoom / 2 && ImageBounds.Y < this.Height + zoom / 2)
			//			e.Graphics.DrawLine(coordinatePen, 0, ImageBounds.Y - zoom / 2, this.Width, ImageBounds.Y - zoom / 2);
			//	}
			//	var interpolation = e.Graphics.InterpolationMode;
			//	e.Graphics.InterpolationMode = zoom >= 1 ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBilinear;
			//	Bitmap sprite;
			//	foreach (Render render in renders)
			//	{
			//		if (render.transform.Scale == 0f)
			//			continue;
			//		if (TryGetImageFromSpriteName(render.symbolName, out sprite))
			//		{
			//			e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
			//			e.Graphics.ScaleTransform(zoom, zoom);
			//			e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
			//			e.Graphics.RotateTransform(render.transform.Rotation);
			//			e.Graphics.ScaleTransform(render.transform.Scale, render.transform.Scale);
			//			Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
			//			e.Graphics.DrawImage(
			//				sprite,
			//				spriteBounds,
			//				0, 0, sprite.Width, sprite.Height,
			//				GraphicsUnit.Pixel,
			//				imageAttr
			//			);
			//			e.Graphics.ResetTransform();
			//		}
			//	}
			//	e.Graphics.InterpolationMode = interpolation;
			//	if (!rightMouse && !middleMouse)
			//	{
			//		foreach (int select in selectedRenders)
			//		{
			//			Render render = renders[select];
			//			if (render.transform.Scale == 0f)
			//				continue;
			//			if (TryGetImageFromSpriteName(render.symbolName, out sprite))
			//			{
			//				long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
			//				Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
			//				e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);
			//				e.Graphics.FillEllipse(selectionBrush, p.X - radius, p.Y - radius, radius * 2, radius * 2);

			//				e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
			//				e.Graphics.ScaleTransform(zoom, zoom);
			//				e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
			//				e.Graphics.RotateTransform(render.transform.Rotation);
			//				Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
			//				e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
			//				e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
			//				e.Graphics.ResetTransform();
			//			}
			//		}
			//	}
			//	if (selecting)
			//	{
			//		var selectionArea = this.selectionArea.Normalized();
			//		e.Graphics.DrawRectangle(selectionPen, selectionArea);
			//		e.Graphics.FillRectangle(selectionBrush, selectionArea);
			//		List<Render> renders = GetRendersInArea(selectionArea);
			//		foreach (Render render in renders)
			//		{
			//			if (render.transform.Scale == 0f)
			//				continue;
			//			if (TryGetImageFromSpriteName(render.symbolName, out sprite))
			//			{
			//				long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
			//				Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
			//				e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);

			//				e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
			//				e.Graphics.ScaleTransform(zoom, zoom);
			//				e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
			//				e.Graphics.RotateTransform(render.transform.Rotation);
			//				Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
			//				e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
			//				e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
			//				e.Graphics.ResetTransform();
			//			}
			//		}
			//	}
			//	else if (!rightMouse && !middleMouse)
			//	{
			//		Render render;
			//		if (TrySelectRenderFromLocation(mouse, out render))
			//		{
			//			if (render.transform.Scale != 0f && TryGetImageFromSpriteName(render.symbolName, out sprite))
			//			{
			//				long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
			//				Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
			//				e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);

			//				e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
			//				e.Graphics.ScaleTransform(zoom, zoom);
			//				e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
			//				e.Graphics.RotateTransform(render.transform.Rotation);
			//				Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
			//				e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
			//				e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
			//				e.Graphics.ResetTransform();
			//			}
			//		}
			//	}

			//	base.OnPaint(e);
			//}
		}
		
		#endregion

		#region Mouse Handlers

		private bool leftMouse, rightMouse, middleMouse;
		[Browsable(false)]
		public bool LeftMouse { get { return leftMouse; } }
		[Browsable(false)]
		public bool RightMouse { get { return rightMouse; } }
		[Browsable(false)]
		public bool MiddleMouse { get { return middleMouse; } }
		[Browsable(false)]
		public bool LeftOrRightMouse { get { return leftMouse | rightMouse; } }
		[Browsable(false)]
		public bool LeftAndRightMouse { get { return leftMouse & rightMouse; } }
		[Browsable(false)]
		public bool AnyMouse { get { return leftMouse | rightMouse | middleMouse; } }

		bool selecting = false;
		Point mouse, grabStart;
		PointF grabOffset, editStart;
		Rectangle selectionArea;

		public event EventHandler TransformEdit;
		public event EventHandler TransformEdited;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			mouse = e.Location;
			if ((e.Button & MouseButtons.Left) != 0)
				leftMouse = true;
			if ((e.Button & MouseButtons.Right) != 0)
				rightMouse = true;
			if ((e.Button & MouseButtons.Middle) != 0)
				middleMouse = true;

			if (leftMouse && !ModifierKeys.HasFlag(Keys.Alt))
			{
				if (!ModifierKeys.HasFlag(Keys.Shift))
					selectedRenders.Clear();

				selectionArea.Location = mouse;
				selectionArea.Size = Size.Empty;

				int i;
				if (TrySelectRenderIndexFromLocation(mouse, out i))
				{
					if (selectedRenders.Contains(i))
						selectedRenders.Remove(i);
					else
						selectedRenders.Add(i);
				}

				SelectionChanged?.Invoke(this, EventArgs.Empty);
			}
			else if (rightMouse)
			{
				editStart = GetImageCoordFromMousePosition(mouse);
			}
			else if (middleMouse || leftMouse && ModifierKeys.HasFlag(Keys.Alt))
			{
				grabStart = e.Location;
				grabOffset = offset;
			}
			
            base.OnMouseDown(e);
			this.Invalidate();
        }

		[EditorBrowsable]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Location != mouse)
			{
				base.OnMouseMove(e);
				mouse = e.Location;

				if (leftMouse && !ModifierKeys.HasFlag(Keys.Alt))
				{
					Size size = new Size(mouse.Substract(selectionArea.Location));
					if (!selecting && !size.IsEmpty)
					{
						if (!ModifierKeys.HasFlag(Keys.Shift))
							selectedRenders.Clear();
						selecting = true;
						selectionArea.Size = size;
					}
					else if (selecting)
						selectionArea.Size = size;
				}
				else if (rightMouse)
				{
					PointF p = GetImageCoordFromMousePosition(mouse);
					switch (editMode)
					{
						case EditMode.Move:
							foreach (int i in selectedRenders)
								renders[i].transform.Location = renders[i].transform.Location.Add(p.Substract(editStart));
							break;
						case EditMode.Rotate:
							PointF midpoint = GetMidPointOfSelection(), 
								mid2mouse = p.Substract(midpoint),
								mid2before = editStart.Substract(midpoint);
							double radianDiff = Math.Atan2(mid2mouse.Y, mid2mouse.X) - Math.Atan2(mid2before.Y, mid2before.X);
							float degreeDiff = (float)radianDiff.Radian2Degree();
							foreach (int i in selectedRenders)
							{
								renders[i].transform.Location = renders[i].transform.Location.RotateRelativeTo(midpoint, (float)radianDiff);
								renders[i].transform.Rotation += degreeDiff;
							}
							break;
						case EditMode.Scale:
							PointF midpoint2 = GetMidPointOfSelection(), 
								mid2mouse2 = p.Substract(midpoint2),
								mid2before2 = editStart.Substract(midpoint2);
							float scaleDiff = (float)(Math.Sqrt(mid2mouse2.X * mid2mouse2.X + mid2mouse2.Y * mid2mouse2.Y) / Math.Sqrt(mid2before2.X * mid2before2.X + mid2before2.Y * mid2before2.Y));
							foreach (int i in selectedRenders)
							{
								renders[i].transform.Location = renders[i].transform.Location.ScaleRelativeTo(midpoint2, scaleDiff);
								renders[i].transform.Scale *= scaleDiff;
							}
							break;
					}
					editStart = GetImageCoordFromMousePosition(mouse);
					TransformEdit?.Invoke(this, EventArgs.Empty);
				}
				else if (middleMouse || leftMouse && ModifierKeys.HasFlag(Keys.Alt))
				{
					Offset = grabOffset.Substract(mouse.Substract(grabStart).ToPointF().Divide(zoom));
				}
			}
			this.Refresh();
		}
		
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selecting)
				{
					var renders = GetRenderIndicesInArea(selectionArea.Normalized());
					foreach (int index in renders)
						selectedRenders.Add(index);
					SelectionChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				TransformEdited?.Invoke(this, EventArgs.Empty);
			}
			selecting = false;
			
			if (e.Button.HasFlag(MouseButtons.Left))
				leftMouse = false;
			if (e.Button.HasFlag(MouseButtons.Right))
				rightMouse = false;
			if (e.Button.HasFlag(MouseButtons.Middle))
				middleMouse = false;

			base.OnMouseUp(e);
			this.Invalidate();
		}

		Control oldActive;
		
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			if (autoFocus)
			{
				Form form = this.FindForm();
				Control c = form.ActiveControl;
				while (c is ContainerControl)
					c = ((ContainerControl)c).ActiveControl;
				oldActive = c;
				this.Select();
			}
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (autoFocus)
				oldActive?.Select();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			float factor = (float)Math.Pow(e.Delta < 0 ? (1 / 1.1f) : 1.1f, (Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta));
			Zoom *= factor;
		}

		#endregion

		#region Keyboard Handlers

		// This doesn't make sense to implement here
		//protected override void OnKeyDown(KeyEventArgs e)
		//{
		//	switch (e.KeyCode)
		//	{
		//		case Keys.G:
		//			this.EditMode = EditMode.Move;
		//			break;
		//		case Keys.R:
		//			this.EditMode = EditMode.Rotate;
		//			break;
		//		case Keys.S:
		//			this.EditMode = EditMode.Scale;
		//			break;
		//		case Keys.Delete:
		//			DeleteSelection();
		//			break;
		//	}
		//	base.OnKeyDown(e);
		//}

		#endregion
	}
}
