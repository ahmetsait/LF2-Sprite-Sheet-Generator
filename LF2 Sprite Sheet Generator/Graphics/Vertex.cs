using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

using OpenTK;
using Gr = OpenTK.Graphics;

namespace NX.Graphics
{
	[StructLayout(LayoutKind.Sequential), Serializable]
	public struct Vertex
	{
		[XmlIgnore] public Vector2 position;
		[XmlIgnore] public Vector2 texCoord;
		[XmlIgnore] public Vector4 color;
		[XmlAttribute] public float X { get { return position.X; } set { position.X = value; } }
		[XmlAttribute] public float Y { get { return position.Y; } set { position.Y = value; } }
		[XmlAttribute] public float U { get { return texCoord.X; } set { texCoord.X = value; } }
		[XmlAttribute] public float V { get { return texCoord.Y; } set { texCoord.Y = value; } }
		[XmlAttribute] public float R { get { return color.X; } set { color.X = value; } }
		[XmlAttribute] public float G { get { return color.Y; } set { color.Y = value; } }
		[XmlAttribute] public float B { get { return color.Z; } set { color.Z = value; } }
		[XmlAttribute] public float A { get { return color.W; } set { color.W = value; } }
	}
}
