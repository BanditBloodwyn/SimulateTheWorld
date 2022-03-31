using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.Rendering.Shaders;

namespace SimulateTheWorld.Rendering.Rendering;

public class OpenGLRenderer
{
    private Shader shader;

    #region Tests

    private float[] _vertices =
    {
        0.5f, 0.5f, 0.0f, // top right
        0.5f, -0.5f, 0.0f, // bottom right
        -0.5f, -0.5f, 0.0f, // bottom left
        -0.5f, 0.5f, 0.0f // top left
    };

    private uint[] _indices =
    {
        // note that we start from 0!
        0, 1, 3, // first triangle
        1, 2, 3 // second triangle
    };

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private int _elementBufferObject;

    #endregion

    public void OnLoaded()
    {
        // create vertex and fragment shaders
        shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        shader.Use();

        // generate VBO to send vertex data to the GPU
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        // generate VAO
        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);

        // set vertex attributes (how to interpret the vertex data)
        GL.VertexAttribPointer(shader.GetAttributeLocation("aPosition"), 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        // generate an EBO to reuse _vertices
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

        GL.ClearColor(new Color4(0, 0, 70, 0));
    }

    public void OnRender(TimeSpan elapsedTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        //TerrainTile[,] terrainTiles = STWWorld.Instance.Terrain.Tiles;

        if (shader == null)
            return;

        shader.Use();

        TestRendering(elapsedTime);
        
        GL.BindVertexArray(_vertexArrayObject);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);
        GL.Finish();
    }

    private void TestRendering(TimeSpan elapsedTime)
    {
        for (int i = 0; i < _vertices.Length; i++)
        {
            _vertices[i] += elapsedTime.Milliseconds / 10000f;
        }
    }

    public void OnUnLoaded()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_vertexBufferObject);

        shader.Dispose();
    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}