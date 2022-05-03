#version 450 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in int aTileType;
layout (location = 2) in int aTerrainType;

out DATA
{
    int tileType;
    int terrainType;
    mat4 projection;
} data_out;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{   
    gl_Position = vec4(aPos, 1.0) * model;
    
    data_out.tileType = aTileType;
    data_out.terrainType = aTerrainType;
    data_out.projection = view * projection;
}