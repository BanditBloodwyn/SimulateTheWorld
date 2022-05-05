#version 450 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in float aTileType;
layout (location = 2) in float aTerrainType;

out DATA
{
    float tileType;
    float terrainType;
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
    
    vec3 position = aPos;

    if (aTileType != 0)
    {
        position = position + vec3(0, 0.01, 0);
        if (aTerrainType == 1)
            position = position + vec3(0, 0.01, 0);
        if (aTerrainType == 2)
            position = position + vec3(0, 0.02, 0);
    }
    gl_Position = vec4(position, 1.0) * uModel;
}