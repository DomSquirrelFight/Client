// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33770,y:32719,varname:node_4013,prsc:2|emission-4347-OUT;n:type:ShaderForge.SFN_Tex2d,id:4253,x:32125,y:32978,ptovrint:False,ptlb:DITU,ptin:_DITU,varname:node_6434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23a3ad2adfdcc2540a70e69ba3f100f4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4171,x:32557,y:32877,varname:node_4171,prsc:2|A-4253-RGB,B-4761-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4761,x:32272,y:33138,ptovrint:False,ptlb:lightness,ptin:_lightness,varname:node_6573,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:8918,x:31391,y:33470,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:node_922,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.318224,max:5;n:type:ShaderForge.SFN_Tex2d,id:4000,x:31757,y:33228,ptovrint:False,ptlb:BIAN,ptin:_BIAN,varname:node_4542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_If,id:1725,x:32432,y:33268,varname:node_1725,prsc:2|A-2685-OUT,B-6942-OUT,GT-6942-OUT,EQ-4063-OUT,LT-4063-OUT;n:type:ShaderForge.SFN_Vector1,id:6942,x:32093,y:33414,varname:node_6942,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4063,x:32093,y:33468,varname:node_4063,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:2685,x:32106,y:33256,varname:node_2685,prsc:2|A-4000-RGB,B-8918-OUT;n:type:ShaderForge.SFN_Multiply,id:534,x:32116,y:33607,varname:node_534,prsc:2|A-4000-RGB,B-6176-OUT;n:type:ShaderForge.SFN_Add,id:6176,x:31759,y:33562,varname:node_6176,prsc:2|A-8918-OUT,B-3577-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3577,x:31413,y:33636,ptovrint:False,ptlb:bian,ptin:_bian,varname:node_5169,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_If,id:8697,x:32398,y:33503,varname:node_8697,prsc:2|A-534-OUT,B-6942-OUT,GT-6942-OUT,EQ-4063-OUT,LT-4063-OUT;n:type:ShaderForge.SFN_Subtract,id:4945,x:32657,y:33220,varname:node_4945,prsc:2|A-8697-OUT,B-1725-OUT;n:type:ShaderForge.SFN_Add,id:4347,x:33356,y:33003,varname:node_4347,prsc:2|A-340-OUT,B-1362-OUT;n:type:ShaderForge.SFN_Multiply,id:340,x:33160,y:32923,varname:node_340,prsc:2|A-7737-OUT,B-8697-OUT,C-5765-RGB,D-5765-A;n:type:ShaderForge.SFN_Tex2d,id:1617,x:32020,y:32660,ptovrint:False,ptlb:T2,ptin:_T2,varname:node_6450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f76cd653f138dfd48bf97564b0598a87,ntxv:0,isnm:False|UVIN-5931-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5931,x:31780,y:32747,varname:node_5931,prsc:2|UVIN-7705-UVOUT,SPD-3143-OUT;n:type:ShaderForge.SFN_TexCoord,id:7705,x:31415,y:32439,varname:node_7705,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:3143,x:31556,y:33076,varname:node_3143,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1362,x:33059,y:33247,varname:node_1362,prsc:2|A-4945-OUT,B-8182-RGB;n:type:ShaderForge.SFN_Tex2d,id:6458,x:32094,y:32457,ptovrint:False,ptlb:T1,ptin:_T1,varname:node_2276,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c999ae04ae551c648aa7fb32967beb3b,ntxv:0,isnm:False|UVIN-5302-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5302,x:31771,y:32432,varname:node_5302,prsc:2|UVIN-7705-UVOUT,SPD-9941-OUT;n:type:ShaderForge.SFN_Vector1,id:9941,x:31429,y:32722,varname:node_9941,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Multiply,id:4722,x:32516,y:32558,varname:node_4722,prsc:2|A-6458-RGB,B-1617-RGB,C-9860-OUT;n:type:ShaderForge.SFN_VertexColor,id:5765,x:32636,y:33009,varname:node_5765,prsc:2;n:type:ShaderForge.SFN_Add,id:7737,x:32778,y:32723,varname:node_7737,prsc:2|A-4722-OUT,B-4171-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9860,x:32281,y:32795,ptovrint:False,ptlb:grain,ptin:_grain,varname:node_8199,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Color,id:8182,x:32728,y:33468,ptovrint:False,ptlb:color_bian,ptin:_color_bian,varname:node_862,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1724138,c3:1,c4:1;proporder:4253-4761-8918-4000-3577-1617-6458-9860-8182;pass:END;sub:END;*/

Shader "Particles/S_dissolve_005" {
    Properties {
        _DITU ("DITU", 2D) = "white" {}
        _lightness ("lightness", Float ) = 1
        _Dissolve ("Dissolve", Range(0, 5)) = 1.318224
        _BIAN ("BIAN", 2D) = "white" {}
        _bian ("bian", Float ) = 0.1
        _T2 ("T2", 2D) = "white" {}
        _T1 ("T1", 2D) = "white" {}
        _grain ("grain", Float ) = 2
        _color_bian ("color_bian", Color) = (0,0.1724138,1,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _DITU; uniform float4 _DITU_ST;
            uniform float _lightness;
            uniform float _Dissolve;
            uniform sampler2D _BIAN; uniform float4 _BIAN_ST;
            uniform float _bian;
            uniform sampler2D _T2; uniform float4 _T2_ST;
            uniform sampler2D _T1; uniform float4 _T1_ST;
            uniform float _grain;
            uniform float4 _color_bian;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_2225 = _Time + _TimeEditor;
                float node_5302_ang = node_2225.g;
                float node_5302_spd = (-0.5);
                float node_5302_cos = cos(node_5302_spd*node_5302_ang);
                float node_5302_sin = sin(node_5302_spd*node_5302_ang);
                float2 node_5302_piv = float2(0.5,0.5);
                float2 node_5302 = (mul(i.uv0-node_5302_piv,float2x2( node_5302_cos, -node_5302_sin, node_5302_sin, node_5302_cos))+node_5302_piv);
                float4 _T1_var = tex2D(_T1,TRANSFORM_TEX(node_5302, _T1));
                float node_5931_ang = node_2225.g;
                float node_5931_spd = 1.0;
                float node_5931_cos = cos(node_5931_spd*node_5931_ang);
                float node_5931_sin = sin(node_5931_spd*node_5931_ang);
                float2 node_5931_piv = float2(0.5,0.5);
                float2 node_5931 = (mul(i.uv0-node_5931_piv,float2x2( node_5931_cos, -node_5931_sin, node_5931_sin, node_5931_cos))+node_5931_piv);
                float4 _T2_var = tex2D(_T2,TRANSFORM_TEX(node_5931, _T2));
                float4 _DITU_var = tex2D(_DITU,TRANSFORM_TEX(i.uv0, _DITU));
                float4 _BIAN_var = tex2D(_BIAN,TRANSFORM_TEX(i.uv0, _BIAN));
                float node_6942 = 1.0;
                float node_8697_if_leA = step((_BIAN_var.rgb*(_Dissolve+_bian)),node_6942);
                float node_8697_if_leB = step(node_6942,(_BIAN_var.rgb*(_Dissolve+_bian)));
                float node_4063 = 0.0;
                float3 node_8697 = lerp((node_8697_if_leA*node_4063)+(node_8697_if_leB*node_6942),node_4063,node_8697_if_leA*node_8697_if_leB);
                float node_1725_if_leA = step((_BIAN_var.rgb*_Dissolve),node_6942);
                float node_1725_if_leB = step(node_6942,(_BIAN_var.rgb*_Dissolve));
                float3 emissive = ((((_T1_var.rgb*_T2_var.rgb*_grain)+(_DITU_var.rgb*_lightness))*node_8697*i.vertexColor.rgb*i.vertexColor.a)+((node_8697-lerp((node_1725_if_leA*node_4063)+(node_1725_if_leB*node_6942),node_4063,node_1725_if_leA*node_1725_if_leB))*_color_bian.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
