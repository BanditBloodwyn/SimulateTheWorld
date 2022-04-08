﻿#version 330 core

out vec4 FragColor;

in vec2 texCoord;

uniform sampler2D texture0;
uniform sampler2D texture1;

uniform vec4 filterColor;

void main()
{
    FragColor = texture(texture0, texCoord) * filterColor;
}