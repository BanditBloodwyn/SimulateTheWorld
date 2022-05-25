#version 450 core

// ================ Enums ================

// === TileType ===
const int TILETYPE_WATER = 0;
const int TILETYPE_LAND = 1;

// === Vegetation zones ===
const int VEGETATION_WATER = 0;
const int VEGETATION_KOLLINE = 1;
const int VEGETATION_MONTANE = 2;
const int VEGETATION_SUBALPINE = 3;
const int VEGETATION_ALPINE_TREES = 4;
const int VEGETATION_ALPINE_BUSHES = 5;
const int VEGETATION_SUBNIVALE = 6;
const int VEGETATION_NIVALE = 7;


// ================ Gloabal variables ================

// === Layouts ===
layout (location = 0) in vec3 aPos;

layout (location = 1) in float aMarked;

layout (location = 2) in float aTileType;
layout (location = 3) in float aVegetationZone;

layout (location = 4) in float aHeight;

layout (location = 5) in float aLifeStandard;
layout (location = 6) in float aUrbanization;

layout (location = 7) in vec3 aRessource_fossils;       // coal, oil, gas
layout (location = 8) in vec4 aRessource_standardOres;  // copper, aluminum, iron, titan
layout (location = 9) in vec3 aRessource_preciousOres;  // gold, silver, platin

layout (location = 10) in vec4 aFloraValues;             // deciduousTrees, evergreenTrees, vegetables, fruits

// === Out ===
out DATA
{
    float marked;

    float tileType;
    float vegetationZone;
    float height;

    float lifeStandard;
    float urbanization;
    
    vec3 ressource_fossils;
    vec4 ressource_standardOres;
    vec3 ressource_preciousOres;

    vec4 floraValues;

    mat4 projection;
} data_out;

// === Uniforms ===
uniform mat4 uModel;
uniform mat4 uView;
uniform mat4 uProjection;

void main()
{
    data_out.marked = aMarked;

    data_out.tileType = aTileType;
    data_out.vegetationZone = aVegetationZone;
    
    data_out.height = aHeight;
    
    data_out.lifeStandard = aLifeStandard;
    data_out.urbanization = aUrbanization;
    
    data_out.ressource_fossils = aRessource_fossils;
    data_out.ressource_standardOres = aRessource_standardOres;
    data_out.ressource_preciousOres = aRessource_preciousOres;
    
    data_out.floraValues = aFloraValues;

    data_out.projection = uView * uProjection;
    
    vec3 position = aPos;

    if (aTileType != TILETYPE_WATER)
    {
        position = position + vec3(0, 0.01, 0);
       
        if (aVegetationZone == VEGETATION_MONTANE)
            position = position + vec3(0, 0.01, 0);
        if (aVegetationZone == VEGETATION_SUBALPINE)
            position = position + vec3(0, 0.02, 0);
        if (aVegetationZone == VEGETATION_ALPINE_TREES)
            position = position + vec3(0, 0.03, 0);
        if (aVegetationZone == VEGETATION_ALPINE_BUSHES)
            position = position + vec3(0, 0.04, 0);
        if (aVegetationZone == VEGETATION_SUBNIVALE)
            position = position + vec3(0, 0.06, 0);
        if (aVegetationZone == VEGETATION_NIVALE)
            position = position + vec3(0, 0.08, 0);
    }
    gl_Position = vec4(position, 1.0) * uModel;
}