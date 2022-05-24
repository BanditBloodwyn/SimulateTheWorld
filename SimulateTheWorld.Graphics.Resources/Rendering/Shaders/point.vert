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
layout (location = 5) in float aPopByTribe;
layout (location = 6) in float aCountries;
layout (location = 7) in float aLifeStandard;
layout (location = 8) in float aUrbanization;

layout (location = 9) in float aRessource_coal;
layout (location = 10) in float aRessource_ironOre;
layout (location = 11) in float aRessource_goldOre;
layout (location = 12) in float aRessource_oil;
layout (location = 13) in float aRessource_gas;

layout (location = 14) in vec4 aFloraValues;
//layout (location = 15) in float aFlora_EvergreenTrees;
//layout (location = 16) in float aFlora_Vegetables;
//layout (location = 17) in float aFlora_Fruits;

// === Out ===
out DATA
{
    float marked;

    float tileType;
    float vegetationZone;
    
    float height;
    float popByTribe;
    float countries;
    float lifeStandard;
    float urbanization;
    
    float ressource_coal;
    float ressource_ironOre;
    float ressource_goldOre;
    float ressource_oil;
    float ressource_gas;

    float flora_DeciduousTrees;
    float flora_EvergreenTrees;
    float flora_Vegetables;
    float flora_Fruits;

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
    data_out.popByTribe = aPopByTribe;
    data_out.countries = aCountries;
    data_out.lifeStandard = aLifeStandard;
    data_out.urbanization = aUrbanization;
    
    data_out.ressource_coal = aRessource_coal;
    data_out.ressource_ironOre = aRessource_ironOre;
    data_out.ressource_goldOre = aRessource_goldOre;
    data_out.ressource_oil = aRessource_oil;
    data_out.ressource_gas = aRessource_gas;
    
    data_out.flora_DeciduousTrees = aFloraValues.x;
    data_out.flora_EvergreenTrees = aFloraValues.y;
    data_out.flora_Vegetables = aFloraValues.z;
    data_out.flora_Fruits = aFloraValues.w;

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