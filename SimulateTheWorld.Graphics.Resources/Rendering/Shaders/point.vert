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

uniform mat4 uModel;
uniform mat4 uView;
uniform mat4 uProjection;

void main()
{   
    data_out.tileType = aTileType;
    data_out.terrainType = aTerrainType;
    data_out.projection = uView * uProjection;
   
    gl_Position = vec4(aPos, 1.0) * uModel;
}