using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data.Components;

public class PointCloud : IDrawable
{
    public DataVertex[] Vertices { get; set; }

    public VAO VAO { get; set; }

    public PointCloud(DataVertex[] vertices)
    {
        Vertices = vertices;
        VAO = new VAO();

        UpdateVertexData();
    }

    public void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        shaderProgram.Use();
        VAO.Bind();

        camera.Matrix(45.0f, 0.01f, 1000.0f, shaderProgram);

        GL.PointSize(6);
        GL.DrawArrays(PrimitiveType.Points, 0, Vertices.Length);
    }

    public unsafe void UpdateVertexData()
    {
        VAO.Bind();

        VBO vbo1 = new VBO(Vertices);

        VAO.LinkAttrib(vbo1, 0, 3, VertexAttribPointerType.Float, sizeof(DataVertex), 0);                                       // Position

        VAO.LinkAttrib(vbo1, 1, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float));                       // TileType
        VAO.LinkAttrib(vbo1, 2, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 1 * sizeof(float));   // TerrainType

        VAO.LinkAttrib(vbo1, 3, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 2 * sizeof(float));   // PopByTribe
        VAO.LinkAttrib(vbo1, 4, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 3 * sizeof(float));   // Countries
        VAO.LinkAttrib(vbo1, 5, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 4 * sizeof(float));   // LifeStandard
        VAO.LinkAttrib(vbo1, 6, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 5 * sizeof(float));   // Urbanization

        VAO.Unbind();
        vbo1.Unbind();
    }
}