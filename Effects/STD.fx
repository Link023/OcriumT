sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;

float disp(float r)
{
	//return -1.0*sinh(r) / (cosh(2.0*r)+1);
	if(r < 0.002) { return 0.0; }
	if(r > 0.018) { return 0.0; }
	float q = (r - 0.002) / 0.016;
	return 0.01 * q * sin(q * 2 * 3.14159268);
}

float4 FilterSpaceTimeDisplacement(float2 coords : TEXCOORD0) : COLOR0
{
	// Theoretical position of the player
	float2 player = float2(0.5, 0.5);
	// Calculate a vector from the player
	float2 p = coords - player;
	float r = dot(p,p);
	// If we're within radius, push outward
	float2 uv = coords + disp(dot(p,p)) * normalize(p);
	
	float4 color = tex2D(uImage0, uv);
    return color;
}

technique Technique1
{
    pass FilterSTD
    {
        PixelShader = compile ps_2_0 FilterSpaceTimeDisplacement();
    }
}