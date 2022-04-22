#version 450 core

layout (location = 0) in vec3 aPos;         // the position variable has attribute position 0
layout (location = 1) in vec3 aColor;       // the position variable has attribute position 1
layout (location = 2) in vec2 aTex;       // the position variable has attribute position 2

out vec3 color;
out vec2 texCoord;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = vec4(aPos, 1.0) * model * view * projection;
    color = aColor;
    texCoord = aTex;
}