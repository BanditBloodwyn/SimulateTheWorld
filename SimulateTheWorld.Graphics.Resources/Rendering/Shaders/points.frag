#version 450 core

out vec4 FragColor;

in int oTileType;
in int oTerrainType;

void main()
{
    //if (oTileType == 0)
    //    FragColor = vec4(0.0f, 0.0f, 1.0f, 1.00f);
    //else if (oTileType == 1)
    //    FragColor = vec4(0.0f, 1.0f, 0.0f, 1.00f);
    
    //else if (oTerrainType == 2)
        FragColor = vec4(1.0f, 1.0f, 0.0f, 1.00f);
}