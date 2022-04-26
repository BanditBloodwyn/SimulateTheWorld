using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.Enums;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public static class TestData
{
    public static Vertex[] Vertices => new Vertex[]
    {
        new(new Vector3(-0.5f, 0.0f,  0.5f), Vector3.Zero, new Vector3(1.0f), new Vector2(0.0f, 0.0f)),
        new(new Vector3(-0.5f, 0.0f, -0.5f), Vector3.Zero, new Vector3(1.0f), new Vector2(5.0f, 0.0f)),
        new(new Vector3( 0.5f, 0.0f, -0.5f), Vector3.Zero, new Vector3(1.0f), new Vector2(0.0f, 0.0f)),
        new(new Vector3( 0.5f, 0.0f,  0.5f), Vector3.Zero, new Vector3(1.0f), new Vector2(5.0f, 0.0f)),
        new(new Vector3( 0.0f, 0.8f,  0.0f), Vector3.Zero, new Vector3(1.0f), new Vector2(2.5f, 5.0f))
    };
    
    public static int[] Indices =
    {
        0, 1, 2,
        0, 2, 3,
        0, 1, 4,
        1, 2, 4,
        2, 3, 4,
        3, 0, 4
    };

    public static Texture[] Textures => new[]
    {
        Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Tile.jpg", TextureUnit.Texture0, TextureType.Diffuse)
    };
}