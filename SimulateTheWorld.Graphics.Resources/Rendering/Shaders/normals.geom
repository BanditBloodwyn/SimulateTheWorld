#version 450 core

layout (triangles) in;
layout(line_strip, max_vertices = 6) out;

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
    gl_Position = (gl_in[0].gl_Position + 0.5f * vec4(data_in[0].Normal, 0.0f)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    gl_Position = gl_in[1].gl_Position * data_in[0].projection;
    EmitVertex();
    gl_Position = (gl_in[1].gl_Position + 0.5f * vec4(data_in[1].Normal, 0.0f)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    gl_Position = gl_in[2].gl_Position * data_in[0].projection;
    EmitVertex();
    gl_Position = (gl_in[2].gl_Position + 0.5f * vec4(data_in[2].Normal, 0.0f)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}