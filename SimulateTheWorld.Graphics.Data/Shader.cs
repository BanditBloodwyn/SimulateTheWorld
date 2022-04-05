using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data
{
    public class Shader : IDisposable
    {
        public int Handle { get; }

        private bool disposedValue;
        private readonly Dictionary<string, int> _uniformLocations;

        public Shader(string vertexPath, string fragmentPath)
        {
            // read shader files
            string VertexShaderSource, FragmentShaderSource;
            using (StreamReader reader = new StreamReader(vertexPath, Encoding.UTF8))
                VertexShaderSource = reader.ReadToEnd();
            using (StreamReader reader = new StreamReader(fragmentPath, Encoding.UTF8))
                FragmentShaderSource = reader.ReadToEnd();

            // create shaders and set their source code
            int VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);

            int FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);

            // compile shaders and check for compiling errors
            GL.CompileShader(VertexShader);

            string infoLogVert = GL.GetShaderInfoLog(VertexShader);
            if (infoLogVert != string.Empty)
                Console.WriteLine(infoLogVert);

            GL.CompileShader(FragmentShader);

            string infoLogFrag = GL.GetShaderInfoLog(FragmentShader);
            if (infoLogFrag != string.Empty)
                Console.WriteLine(infoLogFrag);

            // link shaders together into a program running on the GPU
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);
            GL.LinkProgram(Handle);

            // detach and delete individual shaders (because they are copied to the final program while linking
            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);

            // The shader is now ready to go, but first, we're going to cache all the shader uniform locations.
            // Querying this from the shader is very slow, so we do it once on initialization and reuse those values
            // later.
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
            _uniformLocations = new Dictionary<string, int>();

            // Loop over all the uniforms,
            for (var i = 0; i < numberOfUniforms; i++)
            {
                // get the name of this uniform,
                var key = GL.GetActiveUniform(Handle, i, out _, out _);

                // get the location,
                var location = GL.GetUniformLocation(Handle, key);

                // and then add it to the dictionary.
                _uniformLocations.Add(key, location);
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(Handle);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void SetInt(string name, int value)
        {
            int location = GL.GetUniformLocation(Handle, name);

            GL.Uniform1(location, value);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);

                disposedValue = true;
            }
        }

        public int GetAttributeLocation(string attributeName)
        {
            return GL.GetAttribLocation(Handle, attributeName);
        }

        public void SetMatrix4(string matrixName, Matrix4 data)
        {
            GL.UseProgram(Handle);
            GL.UniformMatrix4(_uniformLocations[matrixName], true, ref data);
        }
    }
}
