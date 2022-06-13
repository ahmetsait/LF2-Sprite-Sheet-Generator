using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NX.Graphics
{
	public struct Shader
	{
		private readonly int id;
		private Dictionary<string, int> uniformTable;

		public Shader(string vertSource, string fragSource)
		{
			int vert = CompileShader(vertSource, ShaderType.VertexShader);
			int frag = CompileShader(fragSource, ShaderType.FragmentShader);
			
			int prog = GL.CreateProgram();
			GL.AttachShader(prog, vert);
			GL.AttachShader(prog, frag);
			GL.LinkProgram(prog);
			GL.DeleteShader(vert);
			GL.DeleteShader(frag);
			int success;
			GL.GetProgram(prog, GetProgramParameterName.LinkStatus, out success);
			if (success == 0)
			{
				string error = GL.GetShaderInfoLog(prog);
				throw new GraphicsException(error);
			}
			id = prog;
			uniformTable = new Dictionary<string, int>(8);
		}

		private static int CompileShader(string source, ShaderType type)
		{
			int shader = GL.CreateShader(type), success;
			GL.ShaderSource(shader, source);
			GL.CompileShader(shader);
			GL.GetShader(shader, ShaderParameter.CompileStatus, out success);
			if (success == 0)
			{
				string error = GL.GetShaderInfoLog(shader);
				throw new GraphicsException(error);
			}
			return shader;
		}

		public void Use()
		{
			GL.UseProgram(id);
		}

		public void SetUniform(string name, int value)
		{
			if (uniformTable.TryGetValue(name, out int location))
				GL.Uniform1(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform1(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, uint value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform1(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform1(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, float value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform1(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform1(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, double value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform1(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform1(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, Vector2 value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform2(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform2(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, Vector3 value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform3(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform3(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, Vector4 value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.Uniform4(location, value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.Uniform4(uniformTable[name] = location, value);
			}
		}

		public void SetUniform(string name, Matrix4 value)
		{
			int location;
			if (uniformTable.TryGetValue(name, out location))
				GL.UniformMatrix4(location, false, ref value);
			else
			{
				location = GL.GetUniformLocation(id, name);
				if (location == -1)
					throw new GraphicsException(string.Format("Uniform ({0}) location could not be retrieved.", name));
				GL.UniformMatrix4(uniformTable[name] = location, false, ref value);
				// FIXME: Chances are high that OpenTK.Matrix4 has row-col mixed up
			}
		}
	}
}
