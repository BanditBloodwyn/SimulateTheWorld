using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class Texture
{
    private int ID { get; }

    public static Texture LoadFromFile(string path, TextureUnit unit)
    {
        int id = GL.GenTexture();

        GL.ActiveTexture(unit);
        GL.BindTexture(TextureTarget.Texture2D, id);

        using (var image = new Bitmap(path))
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                image.Width,
                image.Height,
                0,
                PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);
        }

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

        return new Texture(id);
    }

    public Texture(int id)
    {
        ID = id;
    }

    public void Bind()
    {
        GL.BindTexture(TextureTarget.Texture2D, ID);
    }
    public void Unbind(TextureUnit unit)
    {
        GL.BindTexture(TextureTarget.Texture2D, ID);
    }
    public void Bind(TextureUnit unit)
    {
        GL.BindTexture(TextureTarget.Texture2D, ID);
    }
}