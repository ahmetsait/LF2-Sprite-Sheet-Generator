using System;
using System.Drawing;
using System.Xml.Serialization;

namespace LF2.Sprite_Sheet_Generator
{
	[Serializable]
	public struct Transform
	{
		private PointF location;
		[XmlIgnore]
		public PointF Location
		{
			get { return location; }
			set { location = value; }
		}
		[XmlAttribute]
		public float X { get { return location.X; } set { location.X = value; } }
		[XmlAttribute]
		public float Y { get { return location.Y; } set { location.Y = value; } }
		private float rotation;
		[XmlAttribute]
		public float Rotation
		{
			get { return rotation; }
			set
			{
				rotation = (float)Extensions.Mod(value, 360);
			}
		}
		private float scale;
		[XmlAttribute]
		public float Scale
		{
			get { return scale; }
			set
			{
				if (!float.IsInfinity(value) && !float.IsNaN(value))
					scale = value;
			}
		}

		public override string ToString()
		{
			return "Location: " + X + "," + Y + "  Rotation: " + Rotation + "  Scale: " + Scale;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Transform)) return false;
			Transform other = (Transform)obj;

			return (((Location == other.Location) && (Rotation == other.Rotation)) && (Scale == other.Scale));
		}

		public static bool operator ==(Transform left, Transform right)
		{
			return (((left.Location == right.Location) && (left.Rotation == right.Rotation)) && (left.Scale == right.Scale));
		}

		public static bool operator !=(Transform left, Transform right)
		{
			return (((left.Location != right.Location) || (left.Rotation != right.Rotation)) || (left.Scale != right.Scale));
		}

		public override int GetHashCode()
		{
			return Location.GetHashCode() ^ Rotation.GetHashCode() ^ Scale.GetHashCode();
		}
	}
}
