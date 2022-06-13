using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using Gr = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace NX.Graphics
{
	public class Mesh
	{
		private int vao, vbo, ebo;
		private long loadedVertexBufferSize, loadedIndexBufferSize;
		public Vertex[] vertices;
		public uint[] indices;

		public Mesh()
		{
			GL.GenVertexArrays(1, out vao);
			GL.GenBuffers(1, out vbo);
			GL.GenBuffers(1, out ebo);

			int stride = BlittableValueType<Vertex>.Stride;
			GL.BindVertexArray(vao);
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
			GL.EnableVertexAttribArray(0);
			GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, stride, 0);
			GL.EnableVertexAttribArray(1);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, stride, 2 * sizeof(float));
			GL.EnableVertexAttribArray(2);
			GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, stride, 4 * sizeof(float));
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
			GL.BindVertexArray(0);
		}

		public Mesh(Vertex[] vertices, uint[] indices, BufferUsageHint hint = BufferUsageHint.StaticDraw) : this()
		{
			this.vertices = vertices;
			this.indices = indices;
			Reload(hint);
		}

		public bool OverwriteColor(Gr.Color4 color)
		{
			if (vertices != null)
			{
				for (int i = 0; i < vertices.Length; i++)
					vertices[i].color = color.ToVector();
				return true;
			}
			else
				return false;
		}

		public void OverwriteColor(Color color)
		{
			OverwriteColor((Gr.Color4)color);
		}

		public void Reload(BufferUsageHint hint = BufferUsageHint.StaticDraw, bool vertex = true, bool index = true)
		{
			int stride = BlittableValueType<Vertex>.Stride;

			GL.BindVertexArray(vao);
			if (vertex)
			{
				if (vertices == null)
					throw new InvalidOperationException("Vertex array (vertices) cannot be null.");
				GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
				GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * stride), vertices, hint);
				GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out loadedVertexBufferSize);
				if (vertices.Length * BlittableValueType.StrideOf(vertices) != loadedVertexBufferSize)
					throw new GraphicsException("Vertex buffer not uploaded correctly");
			}

			if (index)
			{
				if (vertices == null)
					throw new InvalidOperationException("Index array (indices) cannot be null.");
				GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
				GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(uint)), indices, hint);
				GL.GetBufferParameter(BufferTarget.ElementArrayBuffer, BufferParameterName.BufferSize, out loadedIndexBufferSize);
				if (indices.Length * sizeof(uint) != loadedIndexBufferSize)
					throw new GraphicsException("Index buffer not uploaded correctly");
			}
			GL.BindVertexArray(0);
		}

		public bool CheckBufferIntegration()
		{
			foreach (uint index in indices)
				if (index >= vertices.Length)
					return false;
			return true;
		}

		public void Draw(PrimitiveType primitive)
		{
			GL.BindVertexArray(vao);
			GL.DrawElements(primitive, indices.Length, DrawElementsType.UnsignedInt, 0);
			GL.BindVertexArray(0);
		}
	}
}
