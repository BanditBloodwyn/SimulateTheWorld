namespace SimulateTheWorld.Rendering.Rendering.Classes.Shapes;

public class STWQuadrilateral : STWShape
{
    public STWQuadrilateral(float length, float width)
    {
        Vertices = new[]
        {
            //Position                     Texture coordinates
            length / 2, width / 2, 0.0f,   1.0f, 1.0f, // top right
            length / 2, -width / 2, 0.0f,  1.0f, 0.0f, // bottom right
            -length / 2, -width / 2, 0.0f, 0.0f, 0.0f, // bottom left
            -length / 2, width / 2, 0.0f,  0.0f, 1.0f // top left
        };

        Indices = new[]
        {
            // note that we start from 0!
            0, 1, 3, // first triangle
            1, 2, 3 // second triangle
        };
    }
}