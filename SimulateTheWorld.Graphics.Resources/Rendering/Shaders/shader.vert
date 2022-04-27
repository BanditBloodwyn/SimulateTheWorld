#version 450 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec3 aColor;
layout (location = 3) in vec2 aTex;

out DATA
{
    vec3 Normal;
    vec3 Color;
    vec2 TexCoord;
    mat4 projection;
} data_out;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{   
    gl_Position = vec4(aPos, 1.0) * model;
    
    data_out.Normal = aNormal;
    data_out.Color = aColor;
    data_out.TexCoord = aTex;
    data_out.projection = view * projection;
}