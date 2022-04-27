#version 450 core

layout (triangles) in;
layout(triangle_strip, max_vertices = 3) out;

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
    Normal = data_in[0].Normal;
    Color = data_in[0].Color;
    TexCoord = data_in[0].TexCoord;
    
    EmitVertex();

    gl_Position = gl_in[1].gl_Position * data_in[1].projection;
    Normal = data_in[1].Normal;
    Color = data_in[1].Color;
    TexCoord = data_in[1].TexCoord;
    
    EmitVertex();
    
    gl_Position = gl_in[2].gl_Position * data_in[2].projection;
    Normal = data_in[2].Normal;
    Color = data_in[2].Color;
    TexCoord = data_in[2].TexCoord;
    
    EmitVertex();

    EndPrimitive();
}