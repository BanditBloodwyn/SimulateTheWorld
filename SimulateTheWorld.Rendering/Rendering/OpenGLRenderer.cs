using System;
using System.Collections.Generic;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.Rendering.Rendering.Classes;
using SimulateTheWorld.Rendering.Rendering.Classes.Shapes;
using SimulateTheWorld.Rendering.Utilities;
using TextureUnit = OpenTK.Graphics.OpenGL4.TextureUnit;

namespace SimulateTheWorld.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly STWShape[] _shapes = ShapeHandler.CreateShapes();

    private Shader? _shader;
    private int _vertexBufferObject;
    private int _elementBufferObject;
    
    public CircularCamera Camera { get; }

    public OpenGLRenderer()
    {
        Camera = new CircularCamera(Vector3.UnitZ * 10);
    }

    #region Initialize

    public void OnLoaded()
    {
        GL.Enable(EnableCap.DepthTest);

        GenerateVBO();
        GenerateVAO();
        SetupShader();
        SetVertexAttributes();
        GenerateEBO();
        SetupTextures();
        
        GL.ClearColor(new Color4(0, 0, 70, 0));
    }

    /// <summary>
    /// Generate VBO to send vertex data to the GPU
    /// </summary>
    private void GenerateVBO()
    {
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, ShapeHandler.GetShapesVertexBufferSize(_shapes), IntPtr.Zero, BufferUsageHint.StaticDraw);
        
        for (int i = 0; i < _shapes.Length; i++)
        {
            if (_shapes[i].Vertices == null)
                return;

            GL.BufferSubData(
                BufferTarget.ArrayBuffer,
                i == 0 
                    ? IntPtr.Zero 
                    : new IntPtr(i * _shapes[i - 1].Vertices!.Length * sizeof(float)), 
                _shapes[i].Vertices!.Length * sizeof(float), 
                _shapes[i].Vertices);
        }
    }

    private void GenerateVAO()
    {
        for (int i = 0; i < _shapes.Length; i++)
        {
            int vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);
        }
    }

    /// <summary>
    /// Create vertex and fragment shaders
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void SetupShader()
    {
        _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        _shader.Use();
    }

    /// <summary>
    /// Set vertex attributes (how to interpret the vertex data)
    /// </summary>
    private void SetVertexAttributes()
    {
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
    }

    /// <summary>
    /// Generate an EBO to reuse _vertices
    /// </summary>
    private void GenerateEBO()
    {
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, ShapeHandler.GetShapesIndexBufferSize(_shapes), IntPtr.Zero, BufferUsageHint.StaticDraw);
        
        for (int i = 0; i < _shapes.Length; i++)
        {
            if (_shapes[i].Indices == null)
                return;

            GL.BufferSubData(
                BufferTarget.ElementArrayBuffer,
                i == 0 
                    ? IntPtr.Zero 
                    : new IntPtr(i * _shapes[i - 1].Indices!.Length * sizeof(float)),
                _shapes[i].Indices!.Length * sizeof(float), 
                _shapes[i].Indices);
        }
    }

    private void SetupTextures()
    {
        foreach (STWShape shape in _shapes)
        {
            foreach (KeyValuePair<Texture, TextureUnit> texture in shape.Material.Textures)
            {
                texture.Key.Use(texture.Value);
                _shader?.SetInt("texture0", 0);
            }
        }
    }

    #endregion


    public void OnRender(TimeSpan elapsedTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        TestRendering(elapsedTime);
    }

    private void TestRendering(TimeSpan elapsedTime)
    {
        foreach (STWShape shape in _shapes)
        {
            foreach (var texture in shape.Material.Textures)
            {
                texture.Key.Use(texture.Value);
            }

            Matrix4 model = ApplyModelTransforms(shape);
            
            if (_shader == null)
                return;

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", Camera.GetViewMatrix());
            _shader.SetMatrix4("projection", Camera.GetProjectionMatrix());
            _shader.Use();

            if (shape.Indices == null)
                return;

            GL.DrawElements(PrimitiveType.Triangles, shape.Indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);
        }
    }

    private Matrix4 ApplyModelTransforms(STWShape shape)
    {
        Matrix4 model = Matrix4.Identity;
        model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(shape.Transform.AngleX));
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(shape.Transform.AngleY));
        model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(shape.Transform.AngleZ));
        model *= Matrix4.CreateTranslation(shape.Transform.PositionX, shape.Transform.PositionY, shape.Transform.PositionZ);

        return model;
    }

    public void OnUnLoaded()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_vertexBufferObject);

        _shader?.Dispose();
    }

    public void UpdateViewPort(double width, double height)
    {
        Camera.AspectRatio = (float)(width / height);
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}