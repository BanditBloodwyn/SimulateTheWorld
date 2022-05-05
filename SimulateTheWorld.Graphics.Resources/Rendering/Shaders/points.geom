#version 450 core

layout (points) in;
layout(points, max_vertices = 1) out;

in DATA
{
    float tileType;
    float terrainType;
    mat4 projection;
} data_in[];

flat out float tileType;
flat out float terrainType;

void main()
{
    tileType = data_in[0].tileType;
    terrainType = data_in[0].terrainType;
                
    gl_Position = gl_in[0].gl_Position * data_in[0].projection;
    EmitVertex();

    EndPrimitive();
}