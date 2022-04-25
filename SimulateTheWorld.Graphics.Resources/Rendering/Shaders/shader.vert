#version 450 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec3 aColor;
layout (location = 3) in vec2 aTex;

out vec3 CurrentPos;
out vec3 Normal;
out vec3 Color;
out vec2 TexCoord;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    CurrentPos = aPos;
    Normal = aNormal;
    Color = aColor;
    TexCoord = aTex;
    
    gl_Position = vec4(CurrentPos, 1.0) * model * view * projection;
}