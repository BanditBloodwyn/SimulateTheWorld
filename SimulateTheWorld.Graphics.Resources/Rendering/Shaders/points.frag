#version 450 core

out vec4 FragColor;

flat in int tileType;
flat in int terrainType;

void main()
{
    if (tileType == 0)
    {
        FragColor = vec4(0.2f, 0.2f, 1.0f, 1.0f);
        return;
    }
    else
    {
        if (terrainType == 0)
        {
            FragColor = vec4(0.4f, 1.0f, 0.4f, 1.0f);
        }
        if (terrainType == 1)
        {
            FragColor = vec4(0.2f, 1.0f, 0.2f, 1.0f);
        }
        if (terrainType == 2)
        {
            FragColor = vec4(0.8f, 0.8f, 0.8f, 1.0f);
        }
        return;
    }
 }