using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data.Interfaces;

public interface IDrawable
{
    public void Draw(ShaderProgram shaderProgram, Camera camera);
}