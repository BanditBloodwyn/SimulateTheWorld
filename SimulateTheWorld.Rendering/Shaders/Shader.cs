using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.ES30;

namespace SimulateTheWorld.Rendering.Shaders;

public sealed class Shader : IDisposable
{
    public readonly int Handle;
    private bool disposedValue;

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
    }

    ~Shader()
    {
        GL.DeleteProgram(Handle);
    }

    public void Use()
    {
        GL.UseProgram(Handle);
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
}