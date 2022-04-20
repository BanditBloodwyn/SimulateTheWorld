using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL
{
    public class ShaderProgram
    {
        private int ID { get; set; }

        private Dictionary<string, int> _uniformLocations;

        public ShaderProgram(string vertexPath, string fragmentPath)
        {
            _uniformLocations = new Dictionary<string, int>();

            InitializeShaderProgram(vertexPath, fragmentPath);
            GetUniforms();
        }

        private void InitializeShaderProgram(string vertexPath, string fragmentPath)
        {
            int VertexShader = CreateVertexShader(vertexPath);
            int FragmentShader = CreateFragmentShader(fragmentPath);

            // link shaders together into a program running on the GPU
            ID = GL.CreateProgram();
            GL.AttachShader(ID, VertexShader);
            GL.AttachShader(ID, FragmentShader);
            GL.LinkProgram(ID);

            // detach and delete individual shaders (because they are copied to the final program while linking
            GL.DetachShader(ID, VertexShader);
            GL.DetachShader(ID, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);
        }

        private void GetUniforms()
        {
            // The shader is now ready to go, but first, we're going to cache all the shader uniform locations.
            // Querying this from the shader is very slow, so we do it once on initialization and reuse those values
            // later.
            GL.GetProgram(ID, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            // Loop over all the uniforms,
            for (var i = 0; i < numberOfUniforms; i++)
            {
                // get the name of this uniform,
                var key = GL.GetActiveUniform(ID, i, out _, out _);

                // get the location,
                var location = GL.GetUniformLocation(ID, key);

                // and then add it to the dictionary.
                _uniformLocations.Add(key, location);
            }
        }

        private int CreateVertexShader(string vertexPath)
        {
            string VertexShaderSource;
            using(StreamReader reader = new StreamReader(vertexPath, Encoding.UTF8))
                VertexShaderSource = reader.ReadToEnd();

            int VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);
            
            GL.CompileShader(VertexShader);

            string infoLogVert = GL.GetShaderInfoLog(VertexShader);
            if (infoLogVert != string.Empty)
                Console.WriteLine(infoLogVert);

            return VertexShader;
        }

        private int CreateFragmentShader(string fragmentPath)
        {
            string FragmentShaderSource;
            using (StreamReader reader = new StreamReader(fragmentPath, Encoding.UTF8))
                FragmentShaderSource = reader.ReadToEnd();

            int FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);
           
            GL.CompileShader(FragmentShader);

            string infoLogFrag = GL.GetShaderInfoLog(FragmentShader);
            if (infoLogFrag != string.Empty)
                Console.WriteLine(infoLogFrag);
           
            return FragmentShader;
        }

        public void Use() => GL.UseProgram(ID);

        public void Delete() => GL.DeleteProgram(ID);
    }
}
