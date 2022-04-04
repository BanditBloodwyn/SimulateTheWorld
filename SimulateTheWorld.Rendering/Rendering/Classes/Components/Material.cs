using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Rendering.Rendering.Classes.Components;

public class Material
{
    public Dictionary<Texture, TextureUnit> Textures { get; }

    public Material()
    {
        Textures = new Dictionary<Texture, TextureUnit>();
    }

    public void SetTexture(string path, TextureUnit unit = TextureUnit.Texture0)
    {
        Texture texture = Texture.LoadFromFile(path);
        texture.Use(unit);

        Textures.Add(texture, unit);
    }
}