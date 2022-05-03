#version 450 core

layout (points) in;
layout(points, max_vertices = 1) out;

in DATA
{
    int tileType;
    int terrainType;
    mat4 projection;
} data_in[];

out int oTileType;
out int oTerrainType;

void main()
{
    oTileType = data_in[0].tileType;
    oTerrainType = data_in[0].terrainType;
    gl_Position = gl_in[0].gl_Position * data_in[0].projection;
    EmitVertex();

    EndPrimitive();
}