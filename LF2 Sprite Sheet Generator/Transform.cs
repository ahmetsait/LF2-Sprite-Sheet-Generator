using System;
using System.Drawing;

namespace LF2.Sprite_Sheet_Generator
{
	[Serializable]
	public struct Transform
	{
		private PointF position;
		public PointF Position
		{
			get { return position; }
			set { position = value; }
		}
		public float X { get { return position.X; } set { position.X = value; } }
		public float Y { get { return position.Y; } set { position.Y = value; } }
		public float Rotation { get; set; }
		public float Scale { get; set; }

		public override string ToString()
		{
			return "Position: " + X + "," + Y + "  Rotation: " + Rotation + "  Scale: " + Scale;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Transform)) return false;
			Transform other = (Transform)obj;

			return (((Position == other.Position) && (Rotation == other.Rotation)) && (Scale == other.Scale));
		}

		public static bool operator ==(Transform left, Transform right)
		{
			return (((left.Position == right.Position) && (left.Rotation == right.Rotation)) && (left.Scale == right.Scale));
		}

		public static bool operator !=(Transform left, Transform right)
		{
			return (((left.Position != right.Position) || (left.Rotation != right.Rotation)) || (left.Scale != right.Scale));
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode() ^ Rotation.GetHashCode() ^ Scale.GetHashCode();
		}
	}
}
