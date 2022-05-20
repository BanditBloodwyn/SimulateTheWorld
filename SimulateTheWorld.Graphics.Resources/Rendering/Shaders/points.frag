#version 450 core

// ================ Enums ================

// === TileType ===
const int TILETYPE_WATER = 0;
const int TILETYPE_LAND = 1;

// === vegetation zones ===
const int VEGETATION_WATER = 0;
const int VEGETATION_KOLLINE = 1;
const int VEGETATION_MONTANE = 2;
const int VEGETATION_SUBALPINE = 3;
const int VEGETATION_ALPINE_TREES = 4;
const int VEGETATION_ALPINE_BUSHES = 5;
const int VEGETATION_SUBNIVALE = 6;
const int VEGETATION_NIVALE = 7;


// ================ Gloabal variables ================

// === Out ===
out vec4 FragColor;

// === In ===
flat in float marked;
flat in float tileType;
flat in float vegetationZone;
flat in float height;
flat in float popByTribe;
flat in float countries;
flat in float lifeStandard;
flat in float urbanization;

flat in float ressource_coal;
flat in float ressource_ironOre;
flat in float ressource_goldOre;
flat in float ressource_oil;
flat in float ressource_gas;

flat in vec3 colorShading;

// === Uniforms ===
uniform vec4 uMarkedTileColor;

uniform int uFilterMode;
uniform vec4 uFilterColorZero;
uniform vec4 uFilterColorHundred;

// ================================
vec4 SampleColor(float value)
{
    if (value > 100 || value < 0)
        return vec4(1, 1, 1, 1);

    value /= 100;

    float bk = (1 - value);
    float r = uFilterColorZero.x * bk + uFilterColorHundred.x * value;
    float g = uFilterColorZero.y * bk + uFilterColorHundred.y * value;
    float b = uFilterColorZero.z * bk + uFilterColorHundred.z * value;

    return vec4(r, g, b, 1);
}

vec4 GetVegetationColor()
{
    if (tileType == TILETYPE_WATER)
        return vec4(0.2f, 0.2f, 1.0f, 1.0f);
    else
    {
        if (vegetationZone == VEGETATION_KOLLINE)
            return vec4(0.4f, 1.0f, 0.4f, 1.0f);
        if (vegetationZone == VEGETATION_MONTANE)
            return vec4(0.0f, 0.8f, 0.0f, 1.0f);
        if (vegetationZone == VEGETATION_SUBALPINE)
            return vec4(0.0f, 0.6f, 0.0f, 1.0f);
        if (vegetationZone == VEGETATION_ALPINE_TREES)
            return vec4(0.3f, 0.6f, 0.3f, 1.0f);
        if (vegetationZone == VEGETATION_ALPINE_BUSHES)
            return vec4(0.4f, 0.6f, 0.4f, 1.0f);
        if (vegetationZone == VEGETATION_SUBNIVALE)
            return vec4(0.5f, 0.5f, 0.5f, 1.0f);
        if (vegetationZone == VEGETATION_NIVALE)
            return vec4(1.0f, 1.0f, 1.0f, 1.0f);
    }
}

void main()
{
    if (marked == 1.0)
    {
        FragColor = uMarkedTileColor * vec4(colorShading, 0);
        return;
    }
    
    if (uFilterMode == 0)
        FragColor = GetVegetationColor() * vec4(colorShading, 0);
    else if (uFilterMode == 1)
        FragColor = SampleColor(height) * vec4(colorShading, 0);
    else if (uFilterMode == 2)
        FragColor = SampleColor(popByTribe) * vec4(colorShading, 0);
    else if (uFilterMode == 3)
        FragColor = SampleColor(countries) * vec4(colorShading, 0);
    else if (uFilterMode == 4)
        FragColor = SampleColor(lifeStandard) * vec4(colorShading, 0);
    else if (uFilterMode == 5)
        FragColor = SampleColor(urbanization) * vec4(colorShading, 0);
    else if (uFilterMode == 6)
        FragColor = SampleColor(ressource_coal) * vec4(colorShading, 0);
    else if (uFilterMode == 7)
        FragColor = SampleColor(ressource_ironOre) * vec4(colorShading, 0);
    else if (uFilterMode == 8)
        FragColor = SampleColor(ressource_goldOre) * vec4(colorShading, 0);
    else if (uFilterMode == 9)
        FragColor = SampleColor(ressource_oil) * vec4(colorShading, 0);
    else if (uFilterMode == 10)
        FragColor = SampleColor(ressource_gas) * vec4(colorShading, 0);
}