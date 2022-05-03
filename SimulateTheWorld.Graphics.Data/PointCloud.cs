using System;
using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data.Enums;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class PointCloud
{
    public Vertex[] Vertices { get; set; }

    public VAO VAO { get; set; }

    public unsafe PointCloud(Vertex[] vertices)
    {
        Vertices = vertices;

        VAO = new VAO();
        VAO.Bind();

        VBO vbo1 = new VBO(Vertices);
       
        VAO.LinkAttrib(vbo1, 0, 3, VertexAttribPointerType.Float, sizeof(Vertex), 0);
        VAO.LinkAttrib(vbo1, 1, 3, VertexAttribPointerType.Float, sizeof(Vertex), 3 * sizeof(float));
        VAO.LinkAttrib(vbo1, 2, 3, VertexAttribPointerType.Float, sizeof(Vertex), 6 * sizeof(float));
        VAO.LinkAttrib(vbo1, 3, 2, VertexAttribPointerType.Float, sizeof(Vertex), 9 * sizeof(float));

        VAO.Unbind();
        vbo1.Unbind();
    }

    public void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        shaderProgram.Use();
        VAO.Bind();

        camera.Matrix(45.0f, 0.01f, 1000.0f, shaderProgram);

        GL.PointSize(10);
        GL.DrawArrays(PrimitiveType.Points, 0, Vertices.Length);
    }
}