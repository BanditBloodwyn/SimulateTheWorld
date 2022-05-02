#version 450 core

layout (points) in;
layout(points, max_vertices = 1) out;

out vec3 Normal;
out vec3 Color;
out vec2 TexCoord;

in DATA
{
    vec3 Normal;
    vec3 Color;
    vec2 TexCoord;
    mat4 projection;
} data_in[];

void main()
{
    gl_Position = gl_in[0].gl_Position * data_in[0].projection;
    EmitVertex();
    //gl_Position = (gl_in[0].gl_Position + 0.5f * vec4(0.0, 1.0, 0.0, 0.0f)) * data_in[0].projection;
    //EmitVertex();

    EndPrimitive();
}