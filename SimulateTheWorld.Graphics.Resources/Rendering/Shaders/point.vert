#version 450 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in float aMarked;
layout (location = 2) in float aTileType;
layout (location = 3) in float aTerrainType;
layout (location = 4) in float aHeight;
layout (location = 5) in float aPopByTribe;
layout (location = 6) in float aCountries;
layout (location = 7) in float aLifeStandard;
layout (location = 8) in float aUrbanization;

out DATA
{
    float marked;

    float tileType;
    float terrainType;
    
    float height;
    float popByTribe;
    float countries;
    float lifeStandard;
    float urbanization;
    
    mat4 projection;
} data_out;

uniform mat4 uModel;
uniform mat4 uView;
uniform mat4 uProjection;

void main()
{
    data_out.marked = aMarked;

    data_out.tileType = aTileType;
    data_out.terrainType = aTerrainType;
    
    data_out.height = aHeight;
    data_out.popByTribe = aPopByTribe;
    data_out.countries = aCountries;
    data_out.lifeStandard = aLifeStandard;
    data_out.urbanization = aUrbanization;

    data_out.projection = uView * uProjection;
    
    vec3 position = aPos;

    if (aTileType != 0)
    {
        position = position + vec3(0, 0.01, 0);
        if (aTerrainType == 2)
            position = position + vec3(0, 0.01, 0);
        if (aTerrainType == 3)
            position = position + vec3(0, 0.05, 0);
    }
    gl_Position = vec4(position, 1.0) * uModel;
}