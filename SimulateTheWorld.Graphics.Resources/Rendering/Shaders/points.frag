#version 450 core

out vec4 FragColor;

flat in float tileType;
flat in float terrainType;
flat in vec3 colorShading;

uniform int uFilterMode;

vec4 SampleColor(vec4[2] colors, float value)
{
    if (value > 100 || value < 0)
        return vec4(1, 1, 1, 1);

    value /= 100;

    float bk = (1 - value);
    float r = colors[0].x * bk + colors[1].x * value;
    float g = colors[0].y * bk + colors[1].y * value;
    float b = colors[0].z * bk + colors[1].z * value;

    r /= 255;
    g /= 255;
    b /= 255;

    return vec4(r, g, b, 1);
}

vec4 GetTerrainColor()
{
    if (tileType == 0)
        return vec4(0.2f, 0.2f, 1.0f, 1.0f);
    else
    {
        if (terrainType == 0)
            return vec4(0.4f, 1.0f, 0.4f, 1.0f);
        if (terrainType == 1)
            return vec4(0.0f, 0.5f, 0.0f, 1.0f);
        if (terrainType == 2)
            return vec4(0.5f, 0.5f, 0.5f, 1.0f);
    }
}

void main()
{
    if (uFilterMode == 0)
        FragColor = GetTerrainColor() * vec4(colorShading, 0);
    else
        FragColor = vec4(1, 1, 1, 1) * vec4(colorShading, 0);
}