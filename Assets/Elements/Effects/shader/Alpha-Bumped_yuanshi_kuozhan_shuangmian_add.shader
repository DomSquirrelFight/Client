Shader "Transparent/Bumped Diffuse_kuozhanshuangmian_add" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	jialiang  ("jialiang", range (0,10)) = 1
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	//_BumpMap ("Normalmap", 2D) = "bump" {}
	_MainTex1 ("MainTex1", 2D) = "white" {}
	_MainTex2 ("MainTex2", 2D) = "white" {}
	_HeatForce  ("Heat Force", range (0,3)) = 0.1
	_HeatTime1x  ("Heat Time1x", range (-50,50)) = 1
	_HeatTime1y  ("Heat Time1y", range (-50,50)) = 1
	_HeatTime2x  ("Heat Time2x", range (-50,50)) = 1
	_HeatTime2y  ("Heat Time2y", range (-50,50)) = 1
	_Alpha ("Alpha", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 0
//Blend SrcAlpha One
	cull off
	
CGPROGRAM
#pragma surface surf Lambert alpha 
//#pragma surface surf Lambert decal:add
#pragma target 3.0



sampler2D _MainTex;
sampler2D _MainTex1;
sampler2D _MainTex2;
//sampler2D _BumpMap;
sampler2D _Alpha;
fixed4 _Color;
float _HeatForce;
//float2 uv_BumpMap1;
//float2 uv_BumpMap;
float2 uv_Alpha;
float _HeatTime1x;
float _HeatTime1y;
float _HeatTime2x;
float _HeatTime2y;
float jialiang;

struct Input {
	float2 uv_MainTex;
	//float2 uv_BumpMap;
	float2 uv_MainTex1;
	float2 uv_MainTex2;
	float2 uv_Alpha;
	float4 color : COLOR;
	
};

void surf (Input IN, inout SurfaceOutput o) {
    IN.uv_MainTex1.x += _Time.xz*_HeatTime1x;
    IN.uv_MainTex1.y += _Time.xz*_HeatTime1y;
    IN.uv_MainTex2.x += _Time.xz*_HeatTime2x;
    IN.uv_MainTex2.y += _Time.xz*_HeatTime2y;
    fixed4 c3 = tex2D(_MainTex1, IN.uv_MainTex1);
    fixed4 c4 = tex2D(_MainTex2, IN.uv_MainTex2);
    fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex);
    float x = _HeatForce*((c3.r + c4.r) - 1);
    float y = _HeatForce*((c3.g + c4.g) - 1);
	IN.uv_MainTex.x += ((c1.r + c1.r) - 1) * x;
	IN.uv_MainTex.y += ((c1.g + c1.g) - 1) * y;
	fixed4 v = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = v.rgb*jialiang;
	fixed4 al = tex2D(_Alpha, IN.uv_Alpha);
	float4 Multiply1=_Color * IN.color;
	float4 Split0=Multiply1;
	float4 Multiply4= al * float4( Split0.w, Split0.w, Split0.w, Split0.w);
	o.Alpha = Multiply4;
	//fixed4 n = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	//IN.uv_BumpMap.x += ((c1.r + c1.r) - 1) * _HeatForce;
	//IN.uv_BumpMap.y += ((c1.g + c1.g) - 1) * _HeatForce;
	//uv_BumpMap1 = uv_BumpMap;
	//float2 uv_BumpMap1 = float2(uv_BumpMap.xy)
	//o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}

FallBack "Transparent/Diffuse"
}