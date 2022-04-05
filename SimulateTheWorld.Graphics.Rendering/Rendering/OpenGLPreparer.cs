using System;
using System.Collections.Generic;
using OpenTK.Graphics.ES30;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.Graphics.Shapes;
using TextureUnit = OpenTK.Graphics.OpenGL4.TextureUnit;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public static class OpenGLPreparer
{
    public static void PrepareOpenGL(STWShape[] shapes, out int vertexBufferObject, out Shader shader)
    {
        GenerateVBO(shapes, out vertexBufferObject);
        GenerateVAO(shapes);
        SetupShader(out shader);
        SetVertexAttributes();
        GenerateEBO(shapes);
        SetupTextures(shapes, shader);
    }

    private static void GenerateVBO(STWShape[] shapes, out int vertexBufferObject)
    {
        vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, ShapeHandler.GetShapesVertexBufferSize(shapes), IntPtr.Zero, BufferUsageHint.StaticDraw);

        for (int i = 0; i < shapes.Length; i++)
        {
            if (shapes[i].Vertices == null)
                return;

            GL.BufferSubData(
                BufferTarget.ArrayBuffer,
                i == 0
                    ? IntPtr.Zero
                    : new IntPtr(i * shapes[i - 1].Vertices!.Length * sizeof(float)),
                shapes[i].Vertices!.Length * sizeof(float),
                shapes[i].Vertices);
        }
    }

    private static void GenerateVAO(STWShape[] shapes)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            int vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);
        }
    }

    private static void SetupShader(out Shader shader)
    {
        shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        shader.Use();
    }

    private static void SetVertexAttributes()
    {
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
    }

    private static void GenerateEBO(STWShape[] shapes)
    {
        int elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, ShapeHandler.GetShapesIndexBufferSize(shapes), IntPtr.Zero, BufferUsageHint.StaticDraw);

        for (int i = 0; i < shapes.Length; i++)
        {
            if (shapes[i].Indices == null)
                return;

            GL.BufferSubData(
                BufferTarget.ElementArrayBuffer,
                i == 0
                    ? IntPtr.Zero
                    : new IntPtr(i * shapes[i - 1].Indices!.Length * sizeof(float)),
                shapes[i].Indices!.Length * sizeof(float),
                shapes[i].Indices);
        }
    }

    private static void SetupTextures(STWShape[] shapes, Shader shader)
    {
        foreach (STWShape shape in shapes)
        {
            foreach (KeyValuePair<Texture, TextureUnit> texture in shape.Material.Textures)
            {
                texture.Key.Use(texture.Value);
                shader?.SetInt("texture0", 0);
            }
        }
    }
}