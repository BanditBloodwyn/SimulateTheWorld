#version 450 core

out vec4 FragColor;

flat in float tileType;
flat in float terrainType;
flat in vec3 colorShading;

void main()
{
    if (tileType == 0)
    {
        FragColor = vec4(0.2f, 0.2f, 1.0f, 1.0f) * vec4(colorShading, 0);
        return;
    }
    else
    {
        if (terrainType == 0)
        {
            FragColor = vec4(0.4f, 1.0f, 0.4f, 1.0f) * vec4(colorShading, 0);
            return;
        }
        if (terrainType == 1)
        {
            FragColor = vec4(0.0f, 0.5f, 0.0f, 1.0f) * vec4(colorShading, 0);
            return;
        }
        if (terrainType == 2)
        {
            FragColor = vec4(0.5f, 0.5f, 0.5f, 1.0f) * vec4(colorShading, 0);
            return;
        }
    }
 }