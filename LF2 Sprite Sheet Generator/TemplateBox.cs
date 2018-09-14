#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

#endregion

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

	public struct Render
	{
		public string spriteName;
		public Transform transform;

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
			this.Renders = new List<Render>(128);
			this.Sprites = new Dictionary<string, Image>(16);
		}

		#endregion

		#region Fields

		public List<Render> Renders { get; private set; }
		public Dictionary<string, Image> Sprites { get; private set; }


		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool TabStop { get { return false; } }

		private ToolTip toolTip = new ToolTip();

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
				base.Invalidate();

				if (old != value && EditModeChanged != null)
				{
					EditModeChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler EditModeChanged;
		
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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

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
			set
			{
				Pen old = coordinatePen;
				coordinatePen = value;
				base.Invalidate();

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
				base.Invalidate();

				if (old != value && CoordinatePenChanged != null)
				{
					CoordinatePenChanged(this, EventArgs.Empty);
				}
			}
		}

		Image missingImage;
		[DefaultValue(null)]
		public Image MissingImage
		{
			get { return missingImage; }
			set
			{
				Image old = missingImage;
				missingImage = value;
				
				base.Invalidate();

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
				base.Invalidate();

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
				base.Invalidate();

				if (old != value && GuideImageAlphaChanged != null)
				{
					GuideImageAlphaChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler GuideImageAlphaChanged;
		
		bool showCoordinateToolTip;
		[DefaultValue(false)]
		public bool ShowCoordinateToolTip
		{
			get { return showCoordinateToolTip; }
			set
			{
				bool old = showCoordinateToolTip;
				showCoordinateToolTip = value;
				base.Invalidate();

				if (old != value && ShowCoordinateToolTipChanged != null)
				{
					ShowCoordinateToolTipChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ShowCoordinateToolTipChanged;
		#endregion

		#region Methods

		public virtual void ScaleFit()
		{
			if (guideImage != null)
			{
				Offset = new PointF(guideImage.Width / 2f, guideImage.Height / 2f);
				Zoom = ExpandToBound(guideImage.Size, this.Size).Item1;
			}
		}

		public virtual PointF GetImageCoordFromMousePosition(Point mouse)
		{
			PointF coord = mouse.toPointF();
			RectangleF imageBounds = ImageBounds, controlBounds = new RectangleF(0, 0, this.Width, this.Height);

			return coord.Substract(imageBounds.Location).Divide(zoom);
		}

		public Rectangle ImageBounds
		{
			get
			{
				return new Rectangle(
					(int)(this.Width / 2f - offset.X * zoom),
					(int)(this.Height / 2f - offset.Y * zoom),
					(int)(guideImage != null ? guideImage.Width * zoom : 0),
					(int)(guideImage != null ? guideImage.Height * zoom : 0)
				);
			}
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

		#endregion

		#region Painting

		[EditorBrowsable]
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}

		[EditorBrowsable]
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = smoothing;
			var imageBounds = ImageBounds;
			if (guideImage != null)
			{
				e.Graphics.InterpolationMode = zoom >= 1 ? InterpolationMode.NearestNeighbor : InterpolationMode.Bilinear;
				e.Graphics.DrawImage(guideImage, imageBounds, 0, 0, guideImage.Width, guideImage.Height, GraphicsUnit.Pixel, guideImageAttr);
			}
			if (showCoordinateSystem)
			{
				if (imageBounds.X > -zoom / 2 && imageBounds.X < this.Width + zoom / 2)
					e.Graphics.DrawLine(coordinatePen, imageBounds.X - zoom / 2, 0, imageBounds.X - zoom / 2, this.Height);
				if (imageBounds.Y > -zoom / 2 && imageBounds.Y < this.Height + zoom / 2)
					e.Graphics.DrawLine(coordinatePen, 0, imageBounds.Y - zoom / 2, this.Width, imageBounds.Y - zoom / 2);
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

		private bool leftMouse, rightMouse, middleMouse, controlKey, shiftKey;
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

		[Browsable(false)]
		public bool ControlKey
		{
			get
			{
				return controlKey;
			}
			set
			{
				controlKey = value;
			}
		}

		[Browsable(false)]
		public bool ShiftKey { get { return shiftKey; } set { shiftKey = value; } }

		Point mouse = Point.Empty, grabStart = new Point(-1, -1), selectionStart = new Point(-1, -1);
		PointF grabOffset;



		[EditorBrowsable]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != 0)
				leftMouse = true;
			if ((e.Button & MouseButtons.Right) != 0)
				rightMouse = true;
			if ((e.Button & MouseButtons.Middle) != 0)
				middleMouse = true;
			
			if (middleMouse && !ModifierKeys.HasFlag(Keys.Control))
			{
				grabStart = e.Location;
				grabOffset = offset;
			}
			
            base.OnMouseDown(e);
        }

		[EditorBrowsable]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Location != mouse)
			{
				base.OnMouseMove(e);
				mouse = e.Location;
				if (middleMouse)
				{
					if (!ModifierKeys.HasFlag(Keys.Control))
						Offset = grabOffset.Substract(mouse.Substract(grabStart).toPointF().Divide(zoom));
					else
					{
						grabStart = e.Location;
						grabOffset = offset;
					}
				}
				this.Refresh();
			}
		}

		[EditorBrowsable]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != 0)
				leftMouse = false;
			if ((e.Button & MouseButtons.Right) != 0)
				rightMouse = false;
			if ((e.Button & MouseButtons.Middle) != 0)
				middleMouse = false;
			
			base.OnMouseUp(e);
		}

		[EditorBrowsable]
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Invalidate();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			float factor = (Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta) * e.Delta < 0 ? (1 / 1.1f) : 1.1f;
			Zoom *= factor;
		}

		#endregion
	}
}
