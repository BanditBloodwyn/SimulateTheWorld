using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace SimulateTheWorld.Graphics.Data.OpenGL
{
    public class ShaderProgram
    {
        private int ID { get; set; }

        private readonly Dictionary<string, int> _uniformLocations;

        public ShaderProgram(string vertexPath, string fragmentPath, string geometryPath)
        {
            _uniformLocations = new Dictionary<string, int>();

            InitializeShaderProgram(vertexPath, fragmentPath, geometryPath);
            GetUniforms();
        }

        private void InitializeShaderProgram(string vertexPath, string fragmentPath, string geometryPath)
        {
            int VertexShader = CreateVertexShader(vertexPath);
            int FragmentShader = CreateFragmentShader(fragmentPath);
            int GeometryShader = CreateGeometryShader(geometryPath);

            // link shaders together into a program running on the GPU
            ID = GL.CreateProgram();
            GL.AttachShader(ID, VertexShader);
            GL.AttachShader(ID, FragmentShader);
            GL.AttachShader(ID, GeometryShader);
            GL.LinkProgram(ID);

            GL.GetProgramInfoLog(ID, 10000, out var length, out string programInfoLog);
            if (programInfoLog != string.Empty)
                Log(ShaderType.VertexShader, programInfoLog);

            // detach and delete individual shaders (because they are copied to the final program while linking
            GL.DetachShader(ID, VertexShader);
            GL.DetachShader(ID, FragmentShader);
            GL.DetachShader(ID, GeometryShader);
            GL.DeleteShader(GeometryShader);
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
                Log(ShaderType.VertexShader, infoLogVert);

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
                Log(ShaderType.FragmentShader, infoLogFrag);

            return FragmentShader;
        }

        private int CreateGeometryShader(string geometryPath)
        {
            string GeometryShaderSource;
            using (StreamReader reader = new StreamReader(geometryPath, Encoding.UTF8))
                GeometryShaderSource = reader.ReadToEnd();

            int GeometryShader = GL.CreateShader(ShaderType.GeometryShader);
            GL.ShaderSource(GeometryShader, GeometryShaderSource);

            GL.CompileShader(GeometryShader);

            string infoLogGeom = GL.GetShaderInfoLog(GeometryShader);
            if (infoLogGeom != string.Empty)
                Log(ShaderType.GeometryShader, infoLogGeom);

            return GeometryShader;
        }

        private void Log(ShaderType source, string infoLogFrag)
        {
            Debug.WriteLine("");
            Debug.WriteLine("=== Shader Log ===");
            Debug.WriteLine("");
            Debug.WriteLine($"Source: {source}");
            Debug.WriteLine(infoLogFrag);
            Debug.WriteLine("==================");
            Debug.WriteLine("");
        }

        public void Use() => GL.UseProgram(ID);

        public void Delete() => GL.DeleteProgram(ID);

        public void SetFloat(string uniformName, float value)
        {
            GL.UseProgram(ID); 
            GL.Uniform1(_uniformLocations[uniformName], value);
        }

        public void SetVector4(string uniformName, Vector4 value)
        {
            GL.UseProgram(ID);
            GL.Uniform4(_uniformLocations[uniformName], value);
        }

        public void SetMatrix4(string uniformName, Matrix4 value)
        {
            GL.UseProgram(ID);
            GL.UniformMatrix4(_uniformLocations[uniformName], true, ref value);
        }

        public void SetInt(string uniformName, int value)
        {
            GL.UseProgram(ID);
            if(_uniformLocations.ContainsKey(uniformName)) 
                GL.Uniform1(_uniformLocations[uniformName], value);
        }
    }
}
