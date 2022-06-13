using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;

using OpenTK;
using Gr = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using NX;
using NX.Graphics;

namespace LF2.Sprite_Sheet_Generator
{
	[Serializable]
	public class Render
	{
		[XmlAttribute]
		public string symbolName;
		public Transform transform;
		public Mesh mesh;

		public Render() { }

		public Render(string symbolName, Transform transform)
		{
			this.symbolName = symbolName;
			this.transform = transform;
		}

		public Render(string symbolName, float x, float y)
		{
			this.symbolName = symbolName;
			this.transform = new Transform() { X = x, Y = y };
		}

		public Render Clone() => (Render)this.MemberwiseClone();
	}
}
