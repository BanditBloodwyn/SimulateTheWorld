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


// ================ Colors ================
const vec4 COLOR_WATER = vec4(0.2f, 0.2f, 1.0f, 1.0f);
const vec4 COLOR_WATER_FILTERED = vec4(0.55f, 0.55f, 1.0f, 1.0f);


// ================ Gloabal variables ================

// === Out ===
out vec4 FragColor;

// === In ===
flat in float marked;

flat in float tileType;
flat in float vegetationZone;
flat in float height;

flat in float lifeStandard;
flat in float urbanization;

in vec3 ressource_fossils;          // coal, oil, gas
in vec4 ressource_standardOres;     // copper, aluminum, iron, titan
in vec3 ressource_preciousOres;     // gold, silver, platin

in vec4 floraValues;                // deciduousTrees, evergreenTrees, vegetables, fruits

// === Uniforms ===
uniform vec4 uMarkedTileColor;

uniform int uFilterMode;
uniform vec4 uFilterColorZero;
uniform vec4 uFilterColorHundred;

// ================================
vec4 SampleColor(float value, vec4 colorZero, vec4 colorHundred)
{
    if (tileType == TILETYPE_WATER && uFilterMode != 0 && uFilterMode != 7 && uFilterMode != 8)
        return COLOR_WATER_FILTERED;

    if (value > 100.01f || value < 0)
        return vec4(1, 1, 1, 1);

    value /= 100;

    float bk = (1 - value);
    float r = colorZero.x * bk + colorHundred.x * value;
    float g = colorZero.y * bk + colorHundred.y * value;
    float b = colorZero.z * bk + colorHundred.z * value;

    return vec4(r, g, b, 1);
}

vec4 SampleColor(float value)
{
    return SampleColor(value, uFilterColorZero, uFilterColorHundred);
}

vec4 GetVegetationColor()
{
    if (tileType == TILETYPE_WATER)
        return COLOR_WATER;
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
        FragColor = uMarkedTileColor;
        return;
    }
    
    if (uFilterMode == 0)
        FragColor = SampleColor(urbanization, GetVegetationColor(), vec4(0.5f, 0.5f, 0.5f, 1.0f));
    else if (uFilterMode == 1)
        FragColor = SampleColor(height);
    else if (uFilterMode == 2)
        FragColor = SampleColor(lifeStandard);
    else if (uFilterMode == 3)
        FragColor = SampleColor(urbanization);
   
    else if (uFilterMode == 4)
        FragColor = SampleColor(ressource_fossils.x);
    else if (uFilterMode == 5)
        FragColor = SampleColor(ressource_standardOres.z);
    else if (uFilterMode == 6)
        FragColor = SampleColor(ressource_preciousOres.x);
    else if (uFilterMode == 7)
        FragColor = SampleColor(ressource_fossils.y);
    else if (uFilterMode == 8)
        FragColor = SampleColor(ressource_fossils.z);
    
    else if (uFilterMode == 9)
        FragColor = SampleColor(floraValues.x);
    else if (uFilterMode == 10)
        FragColor = SampleColor(floraValues.y);
    else if (uFilterMode == 11)
        FragColor = SampleColor(floraValues.z);
    else if (uFilterMode == 12)
        FragColor = SampleColor(floraValues.w);
}