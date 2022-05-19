﻿#version 450 core

// ================ Gloabal variables ================

// === Layouts ===
layout (points) in;
layout(triangle_strip, max_vertices = 24) out;

// === In ===
in DATA
{
    float marked;
   
    float tileType;
    float vegetationType;

    float height;
    float popByTribe;
    float countries;
    float lifeStandard;
    float urbanization;

    float ressource_coal;

    mat4 projection;
} data_in[];

// === Out ===
flat out float marked;

flat out float tileType;
flat out float vegetationType;

flat out float height;
flat out float popByTribe;
flat out float countries;
flat out float lifeStandard;
flat out float urbanization;

flat out float ressource_coal;

flat out vec3 colorShading;

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
    marked = data_in[0].marked;

    tileType = data_in[0].tileType;
    vegetationType = data_in[0].vegetationType;
    
    height = data_in[0].height;
    popByTribe = data_in[0].popByTribe;
    countries = data_in[0].countries;
    lifeStandard = data_in[0].lifeStandard;
    urbanization = data_in[0].urbanization;
    ressource_coal = data_in[0].ressource_coal;

    colorShading = vec3(1, 1, 1);
    build_tile(gl_in[0].gl_Position);
    
    colorShading = vec3(0.5, 0.5, 0.5);
    //build_front(gl_in[0].gl_Position);
    //build_left(gl_in[0].gl_Position);
    //build_right(gl_in[0].gl_Position);
}