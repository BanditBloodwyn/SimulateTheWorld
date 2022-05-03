using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Shapes.Primitives;

public class STWQuadrilateral : STWShape
{
    public Mesh? Mesh { get; set; }

    public STWQuadrilateral(long id, float length, float width, Texture texture)
        : base(id)
    {
        Vertex[] vertices = new[]
        {
            new Vertex(new Vector3(length / 2, 0.0f, width / 2), new Vector3(0.0f, 1.0f, 0.0f), Vector3.One, new Vector2(1.0f, 1.0f)),      // top right
            new Vertex(new Vector3(length / 2, 0.0f, -width / 2), new Vector3(0.0f, 1.0f, 0.0f), Vector3.One, new Vector2(1.0f, 0.0f)),     // bottom right
            new Vertex(new Vector3(-length / 2, 0.0f, -width / 2), new Vector3(0.0f, 1.0f, 0.0f), Vector3.One, new Vector2(0.0f, 0.0f)),    // bottom left
            new Vertex(new Vector3(-length / 2, 0.0f, width / 2), new Vector3(0.0f, 1.0f, 0.0f), Vector3.One, new Vector2(0.0f, 1.0f))      // top left
        };

        int[] indices = 
        {
            2, 1, 0,    // first triangle
            0, 3, 2     // second triangle
        };

        Texture[] textures = { texture };

        Mesh = new Mesh(vertices, indices, textures);
    }

    public override void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        base.Draw(shaderProgram, camera);
        Mesh?.Draw(shaderProgram, camera);
    }
}