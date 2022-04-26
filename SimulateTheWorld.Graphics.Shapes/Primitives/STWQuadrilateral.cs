using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Shapes.Primitives;

public class STWQuadrilateral : STWShape
{
    public STWQuadrilateral(long id, float length, float width, Texture texture)
        : base(id)
    {
        Vertex[] vertices = new[]
        {
            new Vertex(new Vector3(length / 2, width / 2, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.One, new Vector2(1.0f, 1.0f)),      // top right
            new Vertex(new Vector3(length / 2, -width / 2, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.One, new Vector2(1.0f, 0.0f)),     // bottom right
            new Vertex(new Vector3(-length / 2, -width / 2, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.One, new Vector2(0.0f, 0.0f)),    // bottom left
            new Vertex(new Vector3(-length / 2, width / 2, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.One, new Vector2(0.0f, 1.0f))      // top left
        };

        int[] indices = 
        {
            0, 1, 3,    // first triangle
            1, 2, 3     // second triangle
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