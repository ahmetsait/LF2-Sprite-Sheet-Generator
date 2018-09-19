using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

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

	[Serializable]
	public class Render
	{
		[XmlAttribute]
		public string spriteName;
		public Transform transform;

		public Render() { }

		public Render(string spriteName, Transform transform)
		{
			this.spriteName = spriteName;
			this.transform = transform;
		}
	}
	
	public class TemplateBox : Control
	{
		#region Constructors

		public TemplateBox() : base()
		{
			guideImageAttr.SetColorMatrix(new ColorMatrix() { Matrix33 = guideImageAlpha }, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			if (guideTransparency)
			{
				imageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
				guideImageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
			}
			else
			{
				imageAttr.ClearColorKey(ColorAdjustType.Bitmap);
				guideImageAttr.ClearColorKey(ColorAdjustType.Bitmap);
			}
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);
			base.TabStop = false;
			this.renders = new List<Render>(128);
			this.Sprites = new Dictionary<string, Image>(16);
			this.selectedRenders = new HashSet<int>();
		}

		#endregion

		#region Fields

		public Dictionary<string, Image> Sprites { get; private set; }

		readonly List<Render> renders;
		public IReadOnlyList<Render> Renders { get { return renders; } }
		readonly HashSet<int> selectedRenders;
		public IReadOnlyCollection<int> SelectedRenders { get { return selectedRenders; } }

		public event EventHandler RendersChanged;
		public event EventHandler SelectionChanged;
		
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool TabStop { get { return false; } }
		
		private ImageAttributes imageAttr = new ImageAttributes(),
			guideImageAttr = new ImageAttributes();

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
				coordinatePen.Width = zoom;
				imageBoundsDirty = true;
				this.Invalidate();

				if (old != zoom && ZoomChanged != null)
				{
					ZoomChanged(this, EventArgs.Empty);
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
				imageBoundsDirty = true;
				this.Invalidate();

				if (old != offset && OffsetChanged != null)
				{
					OffsetChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler OffsetChanged;

		bool guideTransparency;
		[DefaultValue(false)]
		public bool GuideTransparency
		{
			get { return guideTransparency; }
			set
			{
				bool old = guideTransparency;
				guideTransparency = value;
				if (value)
					guideImageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
				else
					guideImageAttr.ClearColorKey(ColorAdjustType.Bitmap);
				this.Invalidate();

				if (old != value && GuideTransparencyChanged != null)
				{
					GuideTransparencyChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideTransparencyChanged;

		bool transparency;
		[DefaultValue(false)]
		public bool Transparency
		{
			get { return transparency; }
			set
			{
				bool old = transparency;
				transparency = value;
				if (value)
					imageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
				else
					imageAttr.ClearColorKey(ColorAdjustType.Bitmap);
				this.Invalidate();

				if (old != value && TrancparencyChanged != null)
				{
					TrancparencyChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TrancparencyChanged;

		Color transparencyKey = Color.Black;
		[DefaultValue(typeof(Color), "Black")]
		public Color TransparencyKey
		{
			get { return transparencyKey; }
			set
			{
				Color old = transparencyKey;
				transparencyKey = value;
				if (transparency)
					imageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
				else
					imageAttr.ClearColorKey(ColorAdjustType.Bitmap);
				if (guideTransparency)
					guideImageAttr.SetColorKey(transparencyKey, transparencyKey, ColorAdjustType.Bitmap);
				else
					guideImageAttr.ClearColorKey(ColorAdjustType.Bitmap);
				this.Invalidate();

				if (old != value && TransparencyKeyChanged != null)
				{
					TransparencyKeyChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TransparencyKeyChanged;

		InterpolationMode backgroundInterpolation;
		[DefaultValue(InterpolationMode.Default)]
		public InterpolationMode BackgroundInterpolation
		{
			get { return backgroundInterpolation; }
			set
			{
				InterpolationMode old = backgroundInterpolation;
				backgroundInterpolation = value;
				this.Invalidate();

				if (old != value && BackgroundInterpolationChanged != null)
				{
					BackgroundInterpolationChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler BackgroundInterpolationChanged;

		SmoothingMode smoothing;
		[DefaultValue(SmoothingMode.Default)]
		public SmoothingMode Smoothing
		{
			get { return smoothing; }
			set
			{
				SmoothingMode old = smoothing;
				smoothing = value;
				this.Invalidate();

				if (old != value && SmoothingChanged != null)
				{
					SmoothingChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler SmoothingChanged;

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

		Image missingImage;
		[DefaultValue(null)]
		public Image MissingImage
		{
			get { return missingImage; }
			set
			{
				Image old = missingImage;
				missingImage = value;
				
				this.Invalidate();

				if (!Object.ReferenceEquals(old, value) && MissingImageChanged != null)
				{
					MissingImageChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler MissingImageChanged;

		Image guideImage;
		[DefaultValue(null)]
		public Image GuideImage
		{
			get { return guideImage; }
			set
			{
				Image old = guideImage;
				guideImage = value;
				Offset = offset;
				imageBoundsDirty = true;
				this.Invalidate();

				if (!Object.ReferenceEquals(old, value) && GuideImageChanged != null)
				{
					GuideImageChanged(this, EventArgs.Empty);
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
				guideImageAlpha = value;
				guideImageAttr.SetColorMatrix(new ColorMatrix() { Matrix33 = guideImageAlpha }, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				this.Invalidate();

				if (old != value && GuideImageAlphaChanged != null)
				{
					GuideImageAlphaChanged(this, EventArgs.Empty);
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

		#endregion

		#region Methods
		
		public virtual Bitmap RenderFinalImage(int alphaCut, int transparencyRange, bool onGuide, bool alphaChannel)
		{
			Bitmap result = new Bitmap(guideImage.Width, guideImage.Height, alphaChannel ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
			Bitmap canvas = new Bitmap(guideImage.Width, guideImage.Height, PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(canvas))
			{
				g.Clear(Color.FromArgb(0, Color.Black));
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				foreach (Render render in renders)
				{
					if (render.transform.Scale == 0f)
						continue;
					Image sprite;
					if (TryGetImageFromSpriteName(render.spriteName, out sprite, false))
					{
						using (sprite = ((Image)sprite.Clone()))
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
			return render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
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
				int[] indices = selectedRenders.ToArray();
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

		public virtual bool TryGetImageFromSpriteName(string spriteName, out Image image, bool missingSafe = true)
		{
			if (!Sprites.TryGetValue(spriteName, out image) || image == null)
			{
				if (missingImage != null && missingSafe)
				{
					image = missingImage;
					return true;
				}
				else
					return false;
			}
			else
				return true;
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
				Image image;
				if (TryGetImageFromSpriteName(renders[i].spriteName, out image))
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
			renders.AddRange(selection.Reverse());
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
			renders.InsertRange(0, selection.Reverse());
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
			this.Invalidate();
		}

		#endregion

		#region Painting

		[EditorBrowsable]
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = smoothing;
			if (guideImage != null)
			{
				if (guideInterpolation == InterpolationMode.Default)
					e.Graphics.InterpolationMode = zoom >= 1 ? InterpolationMode.NearestNeighbor : InterpolationMode.Bilinear;
				else
					e.Graphics.InterpolationMode = guideInterpolation;
				e.Graphics.DrawImage(guideImage, ImageBounds, 0, 0, guideImage.Width, guideImage.Height, GraphicsUnit.Pixel, guideImageAttr);
			}
			if (showCoordinateSystem)
			{
				if (ImageBounds.X > -zoom / 2 && ImageBounds.X < this.Width + zoom / 2)
					e.Graphics.DrawLine(coordinatePen, ImageBounds.X - zoom / 2, 0, ImageBounds.X - zoom / 2, this.Height);
				if (ImageBounds.Y > -zoom / 2 && ImageBounds.Y < this.Height + zoom / 2)
					e.Graphics.DrawLine(coordinatePen, 0, ImageBounds.Y - zoom / 2, this.Width, ImageBounds.Y - zoom / 2);
			}
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			Image sprite;
			foreach (Render render in renders)
			{
				if (render.transform.Scale == 0f)
					continue;
				if (TryGetImageFromSpriteName(render.spriteName, out sprite))
				{
					e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
					e.Graphics.ScaleTransform(zoom, zoom);
					e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
					e.Graphics.RotateTransform(render.transform.Rotation);
					e.Graphics.ScaleTransform(render.transform.Scale, render.transform.Scale);
					Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
					e.Graphics.DrawImage(
						sprite,
						spriteBounds,
						0, 0, sprite.Width, sprite.Height,
						GraphicsUnit.Pixel,
						imageAttr
					);
					e.Graphics.ResetTransform();
				}
			}
			if (!rightMouse && !middleMouse)
			{
				foreach (int select in selectedRenders)
				{
					Render render = renders[select];
					if (render.transform.Scale == 0f)
						continue;
					if (TryGetImageFromSpriteName(render.spriteName, out sprite))
					{
						long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
						Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
						e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);
						e.Graphics.FillEllipse(selectionBrush, p.X - radius, p.Y - radius, radius * 2, radius * 2);

						e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
						e.Graphics.ScaleTransform(zoom, zoom);
						e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
						e.Graphics.RotateTransform(render.transform.Rotation);
						Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
						e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
						e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
						e.Graphics.ResetTransform();
					}
				}
			}
			if (selecting)
			{
				var selectionArea = this.selectionArea.Normalized();
				e.Graphics.DrawRectangle(selectionPen, selectionArea);
				e.Graphics.FillRectangle(selectionBrush, selectionArea);
				List<Render> renders = GetRendersInArea(selectionArea);
				foreach (Render render in renders)
				{
					if (render.transform.Scale == 0f)
						continue;
					if (TryGetImageFromSpriteName(render.spriteName, out sprite))
					{
						long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
						Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
						e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);

						e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
						e.Graphics.ScaleTransform(zoom, zoom);
						e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
						e.Graphics.RotateTransform(render.transform.Rotation);
						Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
						e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
						e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
						e.Graphics.ResetTransform();
					}
				}
			}
			else if (!rightMouse && !middleMouse)
			{
				Render render;
				if (TrySelectRenderFromLocation(mouse, out render))
				{
					if (render.transform.Scale != 0f && TryGetImageFromSpriteName(render.spriteName, out sprite))
					{
						long radius = (long)(Math.Min(sprite.Width, sprite.Height) * render.transform.Scale * zoom / 2);
						Point p = render.transform.Location.Multiply(zoom).Add(ImageBounds.Location).toPoint();
						e.Graphics.DrawEllipse(selectionPen, p.X - radius, p.Y - radius, radius * 2, radius * 2);

						e.Graphics.TranslateTransform(ImageBounds.X, ImageBounds.Y);
						e.Graphics.ScaleTransform(zoom, zoom);
						e.Graphics.TranslateTransform(render.transform.X, render.transform.Y);
						e.Graphics.RotateTransform(render.transform.Rotation);
						Rectangle spriteBounds = new Rectangle(-sprite.Width / 2, -sprite.Height / 2, sprite.Width, sprite.Height);
						e.Graphics.ScaleTransform(1f / zoom, 1f / zoom);
						e.Graphics.DrawRectangle(selectionPen, spriteBounds.Multiply(zoom * render.transform.Scale));
						e.Graphics.ResetTransform();
					}
				}
			}

			base.OnPaint(e);
		}

		[EditorBrowsable]
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = backgroundInterpolation;
			base.OnPaintBackground(e);
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

			if (leftMouse)
			{
				if (!ModifierKeys.HasFlag(Keys.Control))
					selectedRenders.Clear();
				if (ModifierKeys.HasFlag(Keys.Shift))
				{
					selectionArea.Location = mouse;
					selectionArea.Size = Size.Empty;
					selecting = true;
				}
				else
				{
					int i;
					if (TrySelectRenderIndexFromLocation(mouse, out i))
					{
						if (selectedRenders.Contains(i))
							selectedRenders.Remove(i);
						else
							selectedRenders.Add(i);
					}
				}
				SelectionChanged?.Invoke(this, EventArgs.Empty);
			}
			else if (rightMouse)
			{
				editStart = GetImageCoordFromMousePosition(mouse);
			}
			else if (middleMouse)
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

				if (leftMouse)
				{
					if (selecting)
					{
						selectionArea.Size = new Size(mouse.Substract(selectionArea.Location));
					}
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
							Debug.WriteLine(scaleDiff);
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
				else if (middleMouse)
				{
					Offset = grabOffset.Substract(mouse.Substract(grabStart).toPointF().Divide(zoom));
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
			Form form = this.FindForm();
			Control c = form.ActiveControl;
			while (c is ContainerControl)
				c = ((ContainerControl)c).ActiveControl;
			oldActive = c;
			this.Select();
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Form form = this.FindForm();
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			switch (e.KeyCode)
			{
				case Keys.G:
					this.EditMode = EditMode.Move;
					break;
				case Keys.R:
					this.EditMode = EditMode.Rotate;
					break;
				case Keys.S:
					this.EditMode = EditMode.Scale;
					break;
			}
		}

		#endregion
	}
}
