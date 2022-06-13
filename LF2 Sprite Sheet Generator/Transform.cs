using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace NX.Graphics
{
	[StructLayout(LayoutKind.Sequential), Serializable]
	public struct Transform : IEquatable<Transform>
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
		[XmlAttribute, DefaultValue(0f)]
		public float Rotation
		{
			get { return rotation; }
			set
			{
				if (!float.IsInfinity(value) && !float.IsNaN(value))
					rotation = (float)Extensions.Mod(value, 360);
			}
		}
		private float scale;
		[XmlAttribute, DefaultValue(1f)]
		public float Scale
		{
			get { return scale; }
			set
			{
				if (!float.IsInfinity(value) && !float.IsNaN(value))
					scale = value;
			}
		}

		public override string ToString() => "Location: " + X + "," + Y + "  Rotation: " + rotation + "  Scale: " + scale;

		public bool Equals(Transform obj) => ((Location == obj.Location) && (rotation == obj.rotation) && (Scale == obj.Scale));

		public override bool Equals(object obj)
		{
			if (obj is Transform)
				return this.Equals((Transform)obj);
			else
				return false;
		}

		public static bool operator ==(Transform left, Transform right) => left.Equals(right);

		public static bool operator !=(Transform left, Transform right) => !left.Equals(right);

		public override int GetHashCode() => Location.GetHashCode() ^ rotation.GetHashCode() ^ scale.GetHashCode();
	}
}
