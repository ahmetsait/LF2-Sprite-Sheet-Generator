using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

		public static Point Multiply(this Point left, float right)
		{
			return new Point((int)(left.X * right), (int)(left.Y * right));
		}

		public static Point Divide(this Point left, float right)
		{
			return new Point((int)(left.X / right), (int)(left.Y / right));
		}

		public static PointF Multiply(this PointF left, float right)
		{
			return new PointF(left.X * right, left.Y * right);
		}

		public static PointF Divide(this PointF left, float right)
		{
			return new PointF(left.X / right, left.Y / right);
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

		public static double Radian2Degree(this double r) => r * 180.0 / Math.PI;

		public static double Degree2Radian(this double d) => d * Math.PI / 180.0;
	}
}
