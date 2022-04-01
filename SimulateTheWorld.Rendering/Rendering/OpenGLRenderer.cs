﻿using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.Rendering.Classes;
using TextureUnit = OpenTK.Graphics.OpenGL4.TextureUnit;

namespace SimulateTheWorld.Rendering.Rendering;

public class OpenGLRenderer
{
    private Shader? _shader;
    private Texture _texture;

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

    }

    public void OnLoaded()
    {
        // generate VBO to send vertex data to the GPU
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        // generate VAO
        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
        
        // create vertex and fragment shaders
        _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        _shader.Use();

        // set vertex attributes (how to interpret the vertex data)
        int vertexLocation = _shader.GetAttributeLocation("aPos");
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        int texCoordLocation = _shader.GetAttributeLocation("aTexCoord");
        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);

        // generate an EBO to reuse _vertices
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        
        _texture = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Grass.png");
        _texture.Use(TextureUnit.Texture0);

        GL.ClearColor(new Color4(0, 0, 70, 0));
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

        _texture.Use(TextureUnit.Texture0);
        _shader.Use();

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);
    }

    public void OnUnLoaded()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_vertexBufferObject);

        _shader?.Dispose();
    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}