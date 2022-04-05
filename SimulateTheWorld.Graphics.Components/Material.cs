using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data;

namespace SimulateTheWorld.Graphics.Components
{
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
            SetTexture(texture, unit);
        }

        public void SetTexture(Texture texture, TextureUnit unit = TextureUnit.Texture0)
        {
            texture.Use(unit);
            Textures.Add(texture, unit);
        }
    }
}
