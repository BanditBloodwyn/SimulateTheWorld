using System;
using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data.Enums;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class Mesh
{
    public Vertex[] Vertices { get; set; }
    public int[] Indices { get; set; }
    public Texture[] Textures { get; set; }

    public VAO VAO { get; set; }

    public unsafe Mesh(Vertex[] vertices, int[] indices, Texture[] textures)
    {
        Vertices = vertices;
        Indices = indices;
        Textures = textures;

        VAO = new VAO();
        VAO.Bind();

        VBO vbo1 = new VBO(Vertices);
        EBO ebo1 = new EBO(Indices);
        
        VAO.LinkAttrib(vbo1, 0, 3, VertexAttribPointerType.Float, sizeof(Vertex), 0);
        VAO.LinkAttrib(vbo1, 1, 3, VertexAttribPointerType.Float, sizeof(Vertex), 3 * sizeof(float));
        VAO.LinkAttrib(vbo1, 2, 3, VertexAttribPointerType.Float, sizeof(Vertex), 6 * sizeof(float));
        VAO.LinkAttrib(vbo1, 3, 2, VertexAttribPointerType.Float, sizeof(Vertex), 9 * sizeof(float));

        VAO.Unbind();
        vbo1.Unbind();
        ebo1.Unbind();
    }

    public void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        shaderProgram.Use();
        VAO.Bind();

        BindTextures(shaderProgram);

        camera.Matrix(45.0f, 0.01f, 1000.0f, shaderProgram);
        GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
    }

    private void BindTextures(ShaderProgram shaderProgram)
    {
        if(Textures.Length == 0)
            return;

        int numDiffuse = 0,
            numSpecular = 0;

        for (int index = 0; index < Textures.Length; index++)
        {
            Texture texture = Textures[index];
            string num = "";

            TextureType type = texture.Type;
            switch (type)
            {
                case TextureType.Diffuse:
                    num = numDiffuse++.ToString();
                    break;
                case TextureType.NormalMap:
                    break;
                case TextureType.SpecularMap:
                    num = numSpecular++.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            texture.SetTextureUnit(shaderProgram, $"{type.ToString().ToLower()}{num}", index);
            texture.Bind();
        }
    }
}