using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using Gr = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using NX.Graphics;

namespace NX
{
	public static class Extensions
	{
		public static Point Add(this Point left, Point right)
		{
			return new Point(left.X + right.X, left.Y + right.Y);
		}

		public static Point Substract(this Point left, Point right)
		{
			return new Point(left.X - right.X, left.Y - right.Y);
		}

		public static PointF Add(this PointF left, PointF right)
		{
			return new PointF(left.X + right.X, left.Y + right.Y);
		}

		public static PointF Substract(this PointF left, PointF right)
		{
			return new PointF(left.X - right.X, left.Y - right.Y);
		}

		public static Point Multiply(this Point point, float value)
		{
			return new Point((int)(point.X * value), (int)(point.Y * value));
		}

		public static Point Divide(this Point point, float value)
		{
			return new Point((int)(point.X / value), (int)(point.Y / value));
		}

		public static PointF Multiply(this PointF point, float value)
		{
			return new PointF(point.X * value, point.Y * value);
		}

		public static PointF Divide(this PointF point, float value)
		{
			return new PointF(point.X / value, point.Y / value);
		}

		public static PointF RotateRelativeTo(this PointF point, PointF offset, float degree)
		{
			var relative = point.Substract(offset);
			return new PointF(
				(float)(Math.Cos(degree) * relative.X -	Math.Sin(degree) * relative.Y + offset.X),
				(float)(Math.Sin(degree) * relative.X + Math.Cos(degree) * relative.Y + offset.Y)
			);
		}

		public static PointF ScaleRelativeTo(this PointF point, PointF offset, float factor)
		{
			return point.Substract(offset).Multiply(factor).Add(offset);
		}

		public static PointF ToPointF(this Point point)
		{
			return new PointF(point.X, point.Y);
		}

		public static Point ToPoint(this PointF point)
		{
			return new Point((int)point.X, (int)point.Y);
		}

		public static PointF Clamp(this PointF point, float minX, float maxX, float minY, float maxY)
		{
			return new PointF((point.X < minX ? minX : point.X > maxX ? maxX : point.X), (point.Y < minY ? minY : point.Y > maxY ? maxY : point.Y));
		}

		public static Point Clamp(this Point point, int minX, int maxX, int minY, int maxY)
		{
			return new Point((point.X < minX ? minX : point.X > maxX ? maxX : point.X), (point.Y < minY ? minY : point.Y > maxY ? maxY : point.Y));
		}

		public static T Clamp<T>(this T value, T min, T max) where T : struct, IConvertible, IComparable<T>, IEquatable<T>
		{
			return Comparer<T>.Default.Compare(value, min) < 0 ? min : Comparer<T>.Default.Compare(value, max) > 0 ? max : value;
		}

		public static Rectangle Normalized(this Rectangle rect)
		{
			return new Rectangle(rect.Width < 0 ? rect.X + rect.Width : rect.X, rect.Height < 0 ? rect.Y + rect.Height : rect.Y, Math.Abs(rect.Width), Math.Abs(rect.Height));
		}

		public static RectangleF Normalized(this RectangleF rect)
		{
			return new RectangleF(rect.Width < 0 ? rect.X + rect.Width : rect.X, rect.Height < 0 ? rect.Y + rect.Height : rect.Y, Math.Abs(rect.Width), Math.Abs(rect.Height));
		}

		public static Rectangle Multiply(this Rectangle rect, float value)
		{
			return new Rectangle((int)(rect.X * value), (int)(rect.Y * value), (int)(rect.Width * value), (int)(rect.Height * value));
		}

		public static RectangleF Multiply(this RectangleF rect, float value)
		{
			return new RectangleF(rect.X * value, rect.Y * value, rect.Width * value, rect.Height * value);
		}

		public static Rectangle Divide(this Rectangle rect, float value)
		{
			return new Rectangle((int)(rect.X / value), (int)(rect.Y / value), (int)(rect.Width / value), (int)(rect.Height / value));
		}

		public static RectangleF Divide(this RectangleF rect, float value)
		{
			return new RectangleF(rect.X / value, rect.Y / value, rect.Width / value, rect.Height / value);
		}

		public static double Mod(double value, double mod)
		{
			double result = (value % mod);
			if (result < 0)
				result += mod;
			return result;
		}

		public static double Radian2Degree(this double r) => r * 180.0 / Math.PI;

		public static double Degree2Radian(this double d) => d * Math.PI / 180.0;

		public static bool IsPointInTriangle(this PointF p, PointF tri0, PointF tri1, PointF tri2)
		{
			float s = tri0.Y * tri2.X - tri0.X * tri2.Y + (tri2.Y - tri0.Y) * p.X + (tri0.X - tri2.X) * p.Y;
			float t = tri0.X * tri1.Y - tri0.Y * tri1.X + (tri0.Y - tri1.Y) * p.X + (tri1.X - tri0.X) * p.Y;

			if ((s < 0) != (t < 0))
				return false;

			float A = -tri1.Y * tri2.X + tri0.Y * (tri2.X - tri1.X) + tri0.X * (tri1.Y - tri2.Y) + tri1.X * tri2.Y;
			if (A < 0)
			{
				s = -s;
				t = -t;
				A = -A;
			}
			return s > 0 && t > 0 && (s + t) <= A;
		}

		public static bool IsPointInPolygon(this PointF p, PointF[] poly, bool boundsCheck = true)
		{
			if (boundsCheck)
			{
				float minX = poly[0].X;
				float maxX = poly[0].X;
				float minY = poly[0].Y;
				float maxY = poly[0].Y;
				for (int i = 1; i < poly.Length; i++)
				{
					PointF q = poly[i];
					minX = Math.Min(q.X, minX);
					maxX = Math.Max(q.X, maxX);
					minY = Math.Min(q.Y, minY);
					maxY = Math.Max(q.Y, maxY);
				}
				if (p.X < minX || p.X > maxX || p.Y < minY || p.Y > maxY)
					return false;
			}

			// http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
			bool c = false;
			for (int i = 0, j = poly.Length - 1; i < poly.Length; j = i++)
			{
				if ((poly[i].Y > p.Y) != (poly[j].Y > p.Y) &&
					p.X < (poly[j].X - poly[i].X) * (p.Y - poly[i].Y) / (poly[j].Y - poly[i].Y) + poly[i].X)
					c = !c;
			}
			return c;
		}

		public static Vector4 ToVector(this Gr.Color4 color) => new Vector4(color.R, color.G, color.B, color.A);
		public static Gr.Color4 ToColor(this Vector4 vector) => new Gr.Color4(vector.X, vector.Y, vector.Z, vector.W);

		public static void CheckErrorGL()
		{
			//ErrorCode error = GL.GetError();
			//if (error != ErrorCode.NoError)
			//	throw new GraphicsException(error.ToString());
		}

		public static int LoadTextureGL(
			this Bitmap bitmap,
			int texture = 0,
			bool generateMipmaps = true,
			TextureWrapMode wrapMode = TextureWrapMode.ClampToEdge,
			TextureMinFilter minFilter = TextureMinFilter.LinearMipmapLinear,
			TextureMagFilter magFilter = TextureMagFilter.Nearest)
		{
			if (bitmap == null)
				throw new ArgumentNullException(nameof(bitmap));
			
			Rectangle rectangle;	// The Rectangle For Locking The Bitmap In Memory
			BitmapData data;	// The Bitmap's Pixel Data
			
			//bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);	// Flip The Bitmap Along The Y-Axis
			rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);	// Select The Whole Bitmap
			
			// Get The Pixel Data From The Locked Bitmap
			data = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
			int bytes = Image.GetPixelFormatSize(data.PixelFormat) / 8;
			
			try
			{
				if (texture == 0)
					GL.GenTextures(1, out texture); // Create One Texture
				
				// Typical Texture Generation Using Data From The Bitmap
				GL.BindTexture(TextureTarget.Texture2D, texture);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)wrapMode);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)wrapMode);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)minFilter);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)magFilter);
				
				// Load The Bitmap
				GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, Gr.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
				if (generateMipmaps)
					GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
			}
			finally
			{
				bitmap.UnlockBits(data); // Unlock The Pixel Data From Memory
			}
			
			return texture;
		}
		
		public static void ApplyAlphaCutFilter(this Bitmap bitmap, byte threshold)
		{
			if (!Image.IsAlphaPixelFormat(bitmap.PixelFormat))
				return;
			
			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			int bytes = Image.GetPixelFormatSize(data.PixelFormat) / 8;
			
			try
			{
				byte[] buffer = new byte[Math.Abs(data.Stride) * data.Height];
				Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
				
				for (int i = 0; i < data.Height; i++)
				{
					for (int j = 0; j < data.Width; j++)
					{
						int k = (i * data.Stride) + (j * bytes);
						byte alpha = buffer[k + 3];
						if (alpha < threshold)
						{
							buffer[k] = 0;
							buffer[k + 1] = 0;
							buffer[k + 2] = 0;
							buffer[k + 3] = 0;
						}
					}
				}
				Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
			}
			finally
			{
				bitmap.UnlockBits(data);
			}
		}
		
		public static void ApplyBlackFilter(this Bitmap bitmap, byte threshold)
		{
			if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb && bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
				throw new NotSupportedException("Unsupported pixel format: " + bitmap.PixelFormat);
			
			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			int bytes = Image.GetPixelFormatSize(data.PixelFormat) / 8;
			bool alphaChannel = Image.IsAlphaPixelFormat(data.PixelFormat);
			
			byte[] buffer = new byte[Math.Abs(data.Stride) * data.Height];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
			
			for (int i = 0; i < data.Height; i++)
			{
				for (int j = 0; j < data.Width; j++)
				{
					int k = (i * data.Stride) + (j * bytes);
					byte blue = buffer[k];
					byte red = buffer[k + 1];
					byte green = buffer[k + 2];
					byte max
						= blue > red ? blue
						: red > green ? red
						: green;
					if (max < threshold)
					{
						buffer[k] = 0;
						buffer[k + 1] = 0;
						buffer[k + 2] = 0;
						if (alphaChannel)
							buffer[k + 3] = 0;
					}
				}
			}
			
			Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
			bitmap.UnlockBits(data);
		}
	}
}
