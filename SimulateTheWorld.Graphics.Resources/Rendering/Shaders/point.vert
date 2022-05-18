﻿#version 450 core

// ================ Enums ================

// === TileType ===
const int TILETYPE_WATER = 0;
const int TILETYPE_LAND = 1;

// === VegetationType ===
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
layout (location = 3) in float aVegetationType;
layout (location = 4) in float aHeight;
layout (location = 5) in float aPopByTribe;
layout (location = 6) in float aCountries;
layout (location = 7) in float aLifeStandard;
layout (location = 8) in float aUrbanization;

// === Out ===
out DATA
{
    float marked;

    float tileType;
    float vegetationType;
    
    float height;
    float popByTribe;
    float countries;
    float lifeStandard;
    float urbanization;
    
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
    data_out.vegetationType = aVegetationType;
    
    data_out.height = aHeight;
    data_out.popByTribe = aPopByTribe;
    data_out.countries = aCountries;
    data_out.lifeStandard = aLifeStandard;
    data_out.urbanization = aUrbanization;

    data_out.projection = uView * uProjection;
    
    vec3 position = aPos;

    if (aTileType != TILETYPE_WATER)
    {
        position = position + vec3(0, 0.01, 0);
       
        if (aVegetationType == VEGETATION_MONTANE)
            position = position + vec3(0, 0.01, 0);
        if (aVegetationType == VEGETATION_SUBALPINE)
            position = position + vec3(0, 0.02, 0);
        if (aVegetationType == VEGETATION_ALPINE_TREES)
            position = position + vec3(0, 0.03, 0);
        if (aVegetationType == VEGETATION_ALPINE_BUSHES)
            position = position + vec3(0, 0.04, 0);
        if (aVegetationType == VEGETATION_SUBNIVALE)
            position = position + vec3(0, 0.06, 0);
        if (aVegetationType == VEGETATION_NIVALE)
            position = position + vec3(0, 0.08, 0);
    }
    gl_Position = vec4(position, 1.0) * uModel;
}