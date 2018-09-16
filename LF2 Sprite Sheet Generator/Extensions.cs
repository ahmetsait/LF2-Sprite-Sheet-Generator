using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LF2.Sprite_Sheet_Generator
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

		public static PointF toPointF(this Point point)
		{
			return new PointF(point.X, point.Y);
		}

		public static Point toPoint(this PointF point)
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

		public static T Clamp<T>(this T value, T min, T max)
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

		public static void ApplyAlphaCutFilter(this Bitmap bitmap, byte threshold)
		{
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
				throw new ArgumentException("Format32bppArgb required.", "bitmap");

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

			byte[] buffer = new byte[data.Stride * data.Height];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int k = 0; k < buffer.Length; k += 4)
			{
				byte alpha = buffer[k + 3];
				if (alpha < threshold)
				{
					buffer[k] = 0;
					buffer[k + 1] = 0;
					buffer[k + 2] = 0;
					buffer[k + 3] = 0;
				}
			}

			Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
			bitmap.UnlockBits(data);
		}

		public static void ApplyBlackFilter(this Bitmap bitmap, byte threshold)
		{
			if (bitmap.PixelFormat != PixelFormat.Format24bppRgb && bitmap.PixelFormat != PixelFormat.Format32bppArgb)
				throw new ArgumentException("Format24bppRgb or Format32bppArgb required.", "bitmap");

			bool alphaChannel = bitmap.PixelFormat == PixelFormat.Format32bppArgb;
			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			
			byte[] buffer = new byte[data.Stride * data.Height];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int i = 0; i < buffer.Length; i += alphaChannel ? 4 : 3)
			{
				byte blue = buffer[i];
				byte red = buffer[i + 1];
				byte green = buffer[i + 2];
				byte max
					= blue > red ? blue
					: red > green ? red
					: green;
				if (max < threshold)
				{
					buffer[i] = 0;
					buffer[i + 1] = 0;
					buffer[i + 2] = 0;
					if (alphaChannel)
						buffer[i + 3] = 0;
				}
			}

			Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
			bitmap.UnlockBits(data);
		}
	}
}
