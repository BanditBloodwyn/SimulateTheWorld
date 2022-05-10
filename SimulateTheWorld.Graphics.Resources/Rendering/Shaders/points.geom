#version 450 core

layout (points) in;
layout(triangle_strip, max_vertices = 6) out;

in DATA
{
    float tileType;
    float terrainType;
    mat4 projection;
} data_in[];

flat out float tileType;
flat out float terrainType;

uniform float uTileSize;

void build_tile(vec4 position)
{
    gl_Position = (position + vec4(-uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    
    gl_Position = (position + vec4(-uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}

void main()
{
    tileType = data_in[0].tileType;
    terrainType = data_in[0].terrainType;
    
    build_tile(gl_in[0].gl_Position);
}