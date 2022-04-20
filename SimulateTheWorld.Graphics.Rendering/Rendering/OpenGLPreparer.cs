﻿using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public static class OpenGLPreparer
{
    public static void PrepareOpenGL(out ShaderProgram shaderProgram, out VBO vbo, out VAO vao, out EBO ebo)
    {
        PrepareShader(out shaderProgram);
        PrepareBuffers(out vbo, out vao, out ebo);
    }

    private static void PrepareShader(out ShaderProgram shaderProgram)
    {
        shaderProgram = new ShaderProgram("Rendering/Shaders/shader.vert", "Rendering/Shaders/shader.frag");
    }

    private static void PrepareBuffers(out VBO vbo, out VAO vao, out EBO ebo)
    {
        VAO vao1 = new VAO();
        vao1.Bind();

        VBO vbo1 = new VBO(TestData.Vertices);
        EBO ebo1 = new EBO(TestData.Indices);

        vao1.LinkVBO(vbo1, 0);
        vao1.Unbind();
        vbo1.Unbind();
        ebo1.Unbind();

        vbo = vbo1;
        vao = vao1;
        ebo = ebo1;
    }

    public static void DestroyOpenGL(VBO vbo, VAO vao, EBO ebo, ShaderProgram shaderProgram)
    {
        vao.Delete();
        vbo.Delete();
        ebo.Delete();

        shaderProgram.Delete();
    }
}