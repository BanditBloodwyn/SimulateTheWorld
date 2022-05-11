#version 450 core

layout (points) in;
layout(triangle_strip, max_vertices = 24) out;

in DATA
{
    float tileType;
    float terrainType;

    float popByTribe;
    float countries;
    float lifeStandard;
    float urbanization;

    mat4 projection;
} data_in[];

flat out float tileType;
flat out float terrainType;

flat out float popByTribe;
flat out float countries;
flat out float lifeStandard;
flat out float urbanization;

flat out vec3 colorShading;

uniform float uTileSize;

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

void build_front(vec4 position)
{
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, -uTileSize, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, -uTileSize, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, -uTileSize, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}

void build_left(vec4 position)
{
    gl_Position = (position + vec4(-uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, -uTileSize, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    gl_Position = (position + vec4(-uTileSize / 2, -uTileSize, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(-uTileSize / 2, -uTileSize, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}

void build_right(vec4 position)
{
    gl_Position = (position + vec4(uTileSize / 2, -uTileSize, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();

    gl_Position = (position + vec4(uTileSize / 2, -uTileSize, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, 0, uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    gl_Position = (position + vec4(uTileSize / 2, -uTileSize, -uTileSize / 2, 0)) * data_in[0].projection;
    EmitVertex();
    EndPrimitive();
}

void main()
{
    tileType = data_in[0].tileType;
    terrainType = data_in[0].terrainType;
    
    popByTribe = data_in[0].popByTribe;
    countries = data_in[0].countries;
    lifeStandard = data_in[0].lifeStandard;
    urbanization = data_in[0].urbanization;

    colorShading = vec3(1, 1, 1);
    build_tile(gl_in[0].gl_Position);
    
    colorShading = vec3(0.5, 0.5, 0.5);
    build_front(gl_in[0].gl_Position);
    build_left(gl_in[0].gl_Position);
    build_right(gl_in[0].gl_Position);
}