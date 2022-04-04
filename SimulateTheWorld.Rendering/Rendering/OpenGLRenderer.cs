using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.Rendering.Classes;
using TextureUnit = OpenTK.Graphics.OpenGL4.TextureUnit;

namespace SimulateTheWorld.Rendering.Rendering;

public class OpenGLRenderer
{
    private Shader? _shader;
    private readonly Texture _texture1;
    private readonly Texture _texture2;

    public CircularCamera Camera { get; }

    private float _angle;

    #region Tests

    private readonly float[] _vertices =
    {
        // positions        Texture coordinates
        0.5f, 0.5f, 0.0f,   1.0f, 1.0f, // top right
        0.5f, -0.5f, 0.0f,  1.0f, 0.0f, // bottom right
        -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
        -0.5f, 0.5f, 0.0f,  0.0f, 1.0f  // top left
    };

    private readonly uint[] _indices =
    {
        // note that we start from 0!
        0, 1, 3, // first triangle
        1, 2, 3 // second triangle
    };

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private int _elementBufferObject;

    #endregion

    public OpenGLRenderer()
    {
        _texture1 = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Grass.png");
        _texture2 = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Rock.png");

        Camera = new CircularCamera(Vector3.UnitZ * 3);
    }

    public void OnLoaded()
    {
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
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
    }

    private void GenerateVAO()
    {
        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
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
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
    }

    private void SetupTextures()
    {
        _texture1.Use(TextureUnit.Texture0);
        _texture2.Use(TextureUnit.Texture1);
        
        _shader?.SetInt("texture0", 0);
        _shader?.SetInt("texture1", 1);
    }

    public void OnRender(TimeSpan elapsedTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        //TerrainTile[,] terrainTiles = STWWorld.Instance.Terrain.Tiles;

        if (_shader == null)
            return;

        TestRendering(elapsedTime);
    }

    private void TestRendering(TimeSpan elapsedTime)
    {
        GL.BindVertexArray(_vertexArrayObject);

        _texture1.Use(TextureUnit.Texture0);
        _texture2.Use(TextureUnit.Texture1);
        _shader.Use();
        _shader.SetMatrix4("model", CreateTransformationMatrix(elapsedTime));
        _shader.SetMatrix4("view", Camera.GetViewMatrix());
        _shader.SetMatrix4("projection", Camera.GetProjectionMatrix());

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);
    }

    private Matrix4 CreateTransformationMatrix(TimeSpan elapsedTime)
    {
        Matrix4 scale = Matrix4.CreateScale(1f, 1f, 1f);
        _angle += elapsedTime.Milliseconds / 10f;
        Matrix4 rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_angle));
        return scale * rotation;
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