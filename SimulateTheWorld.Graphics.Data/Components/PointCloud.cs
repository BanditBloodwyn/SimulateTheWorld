using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data.Components;

public class PointCloud : IDrawable
{
    public DataVertex[] Vertices { get; }

    private VAO VAO { get; }
    private VBO VBO { get; }

    public PointCloud(DataVertex[] vertices)
    {
        Vertices = vertices;
        VAO = new VAO();
        VBO = new VBO(Vertices);

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
        VBO.Update(Vertices);

        VAO.LinkAttrib(VBO, 0, 3, VertexAttribPointerType.Float, sizeof(DataVertex), 0);                                       // Position
        VAO.LinkAttrib(VBO, 1, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float));                       // Marked

        VAO.LinkAttrib(VBO, 2, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 1 * sizeof(float));   // TileType
        VAO.LinkAttrib(VBO, 3, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 2 * sizeof(float));   // VegetationType

        VAO.LinkAttrib(VBO, 4, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 3 * sizeof(float));   // Height
        VAO.LinkAttrib(VBO, 5, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 4 * sizeof(float));   // LifeStandard
        VAO.LinkAttrib(VBO, 6, 1, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 5 * sizeof(float));   // Urbanization

        VAO.LinkAttrib(VBO, 7, 3, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 6 * sizeof(float));   // ressource_fossils
        VAO.LinkAttrib(VBO, 8, 4, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 9 * sizeof(float));  // ressource_standardOres
        VAO.LinkAttrib(VBO, 9, 3, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 13 * sizeof(float)); // ressource_preciousOres

        VAO.LinkAttrib(VBO, 10, 4, VertexAttribPointerType.Float, sizeof(DataVertex), 3 * sizeof(float) + 16 * sizeof(float));  // floraValues

        VAO.Unbind();
        VBO.Unbind();
    }
}