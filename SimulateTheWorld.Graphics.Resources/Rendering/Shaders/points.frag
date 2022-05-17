#version 450 core

out vec4 FragColor;

flat in float marked;
flat in float tileType;
flat in float terrainType;
flat in float height;
flat in float popByTribe;
flat in float countries;
flat in float lifeStandard;
flat in float urbanization;

flat in vec3 colorShading;

uniform vec4 uMarkedTileColor;

uniform int uFilterMode;
uniform vec4 uFilterColorZero;
uniform vec4 uFilterColorHundred;

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

vec4 GetTerrainColor()
{
    if (tileType == 0)
        return vec4(0.2f, 0.2f, 1.0f, 1.0f);
    else
    {
        if (terrainType == 1)
            return vec4(0.4f, 1.0f, 0.4f, 1.0f);
        if (terrainType == 2)
            return vec4(0.0f, 0.5f, 0.0f, 1.0f);
        if (terrainType == 3)
            return vec4(0.5f, 0.5f, 0.5f, 1.0f);
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
        FragColor = GetTerrainColor() * vec4(colorShading, 0);
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
}