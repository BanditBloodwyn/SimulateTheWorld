#version 450 core

// ================ Gloabal variables ================

// === Layouts ===
layout (points) in;
layout(triangle_strip, max_vertices = 24) out;

// === In ===
in DATA
{
    float marked;
   
    float tileType;
    float vegetationZone;

    float height;

    float lifeStandard;
    float urbanization;

    vec3 ressource_fossils;         // coal, oil, gas
    vec4 ressource_standardOres;    // copper, aluminum, iron, titan
    vec3 ressource_preciousOres;    // gold, silver, platin

    vec4 floraValues;               // deciduousTrees, evergreenTrees, vegetables, fruits

    mat4 projection;
} data_in[];

// === Out ===
flat out float marked;

flat out float tileType;
flat out float vegetationZone;

flat out float height;

flat out float lifeStandard;
flat out float urbanization;

//flat out float ressource_coal;
//flat out float ressource_ironOre;
//flat out float ressource_goldOre;
//flat out float ressource_oil;
//flat out float ressource_gas;

//flat out float flora_DeciduousTrees;
//flat out float flora_EvergreenTrees;
//flat out float flora_Vegetables;
//flat out float flora_Fruits;

out vec3 ressource_fossils;
out vec4 ressource_standardOres;
out vec3 ressource_preciousOres;
out vec4 floraValues;

// === Uniforms ===
uniform float uTileSize;

// ================================
void build_tile(vec4 position)
{
    gl_Position = (position + vec4(-uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    
    gl_Position = (position + vec4(-uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}

void main()
{
    marked = data_in[0].marked;

    tileType = data_in[0].tileType;
    vegetationZone = data_in[0].vegetationZone;
    
    height = data_in[0].height;
    
    lifeStandard = data_in[0].lifeStandard;
    urbanization = data_in[0].urbanization;
   
    ressource_fossils = data_in[0].ressource_fossils;
    ressource_standardOres = data_in[0].ressource_standardOres;
    ressource_preciousOres = data_in[0].ressource_preciousOres;
    floraValues = data_in[0].floraValues;

    build_tile(gl_in[0].gl_Position);
}