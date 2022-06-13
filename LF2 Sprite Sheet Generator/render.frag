#version 330 core

#extension GL_ARB_gpu_shader_fp64 : enable

in vec2 texCoordFrag;
in vec4 colorFrag;

out vec4 fragColor;

uniform vec4 highPassFilter;
uniform sampler2D tex;

#ifdef GL_ARB_gpu_shader_fp64
dvec4 boxFilter(sampler2D tex, dvec2 texCoord)
{
	ivec2 texSize = textureSize(tex, 0);
	dvec2 texelStride = 1.0 / dvec2(texSize);
	dvec4 dv = dvec4(
		abs(dFdx(float(texCoord.x * texSize.x))),
		abs(dFdx(float(texCoord.y * texSize.y))),
		abs(dFdy(float(texCoord.x * texSize.x))),
		abs(dFdy(float(texCoord.y * texSize.y)))
	);
	dvec2 texScale = dvec2(
		dv.y == 0 ? dv.x : dv.y == 0 ? dv.x : sqrt(dv.x * dv.x + dv.y * dv.y),
		dv.w == 0 ? dv.z : dv.w == 0 ? dv.z : sqrt(dv.z * dv.z + dv.w * dv.w)
	);
	
	if (texScale.x <= 1.0 && texScale.y <= 1.0)
		return texture(tex, vec2(texCoord));
	
	dvec4 area = dvec4(
		texCoord.x - texScale.x / 2 * texelStride.x,
		texCoord.y - texScale.y / 2 * texelStride.y,
		texCoord.x + texScale.x / 2 * texelStride.x,
		texCoord.y + texScale.y / 2 * texelStride.y
	);
	dvec4 colorSum = dvec4(0, 0, 0, 0);
	double weightSum = 0;
	int count = 0, maxLoop = 64 * 64;
	for (double j = area.y + texelStride.y / 2; j < area.w + texelStride.y / 2 && count < maxLoop; j += texelStride.y)
	{
		for (double i = area.x + texelStride.x / 2; i < area.z + texelStride.x / 2 && count < maxLoop; i += texelStride.x, count++)
		{
			vec4 c = textureLod(tex, vec2(i, j), 0);
			if (c.a > 0)
			{
				colorSum += c * c.a;
				weightSum += c.a;
			}
		}
	}
	return colorSum / weightSum;
}
#else
vec4 boxFilter(sampler2D tex, vec2 texCoord)
{
	ivec2 texSize = textureSize(tex, 0);
	vec2 texelStride = 1.0 / vec2(texSize);
	vec4 dv = vec4(
		abs(dFdx(texCoord.x * texSize.x)),
		abs(dFdx(texCoord.y * texSize.y)),
		abs(dFdy(texCoord.x * texSize.x)),
		abs(dFdy(texCoord.y * texSize.y))
	);
	vec2 texScale = vec2(
		dv.y == 0 ? dv.x : dv.y == 0 ? dv.x : sqrt(dv.x * dv.x + dv.y * dv.y),
		dv.w == 0 ? dv.z : dv.w == 0 ? dv.z : sqrt(dv.z * dv.z + dv.w * dv.w)
	);
	
	if (texScale.x <= 1.0 && texScale.y <= 1.0)
		return texture(tex, texCoord);
	
	vec4 area = vec4(
		texCoord.x - texScale.x / 2 * texelStride.x,
		texCoord.y - texScale.y / 2 * texelStride.y,
		texCoord.x + texScale.x / 2 * texelStride.x,
		texCoord.y + texScale.y / 2 * texelStride.y
	);
	vec4 colorSum = vec4(0, 0, 0, 0);
	float weightSum = 0;
	int count = 0, maxLoop = 64 * 64;
	for (float j = area.y + texelStride.y / 2; j < area.w + texelStride.y / 2 && count < maxLoop; j += texelStride.y)
	{
		for (float i = area.x + texelStride.x / 2; i < area.z + texelStride.x / 2 && count < maxLoop; i += texelStride.x, count++)
		{
			vec4 c = textureLod(tex, vec2(i, j), 0);
			if (c.a > 0)
			{
				colorSum += c * c.a;
				weightSum += c.a;
			}
		}
	}
	return colorSum / weightSum;
}
#endif

void main()
{
	vec4 c = vec4(boxFilter(tex, texCoordFrag)) * colorFrag;
	if (c.r <= highPassFilter.r || c.g <= highPassFilter.g || c.b <= highPassFilter.b || c.a <= highPassFilter.a)
		discard;
	fragColor = c;
}
