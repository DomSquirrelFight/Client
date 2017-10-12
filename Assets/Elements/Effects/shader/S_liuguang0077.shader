// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33294,y:32656,varname:node_4795,prsc:2|emission-4319-OUT;n:type:ShaderForge.SFN_TexCoord,id:2815,x:31535,y:32525,varname:node_2815,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:195,x:32030,y:32471,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e4b32f0ac092a0041b2ea003a4dddbbe,ntxv:0,isnm:False|UVIN-8234-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1125,x:32010,y:32709,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ddeb6b06c9b916c4fb6a9a35680cccb3,ntxv:0,isnm:False|UVIN-4656-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1595,x:32714,y:32940,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_1595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9559f5c71ac34f54ea514c90bddda955,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9629,x:32228,y:32008,ptovrint:False,ptlb:material,ptin:_material,varname:node_9629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4adce8d41671d3e42a53075912fa5a31,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5516,x:32808,y:32702,varname:node_5516,prsc:2|A-2940-OUT,B-1595-RGB;n:type:ShaderForge.SFN_Add,id:4319,x:32924,y:32545,varname:node_4319,prsc:2|A-6908-OUT,B-5516-OUT;n:type:ShaderForge.SFN_Multiply,id:1538,x:32344,y:32541,varname:node_1538,prsc:2|A-195-RGB,B-1125-RGB,C-4681-OUT,D-1438-RGB;n:type:ShaderForge.SFN_Vector1,id:4681,x:32216,y:32760,varname:node_4681,prsc:2,v1:20;n:type:ShaderForge.SFN_Panner,id:4656,x:31781,y:32682,varname:node_4656,prsc:2,spu:-0.1,spv:0|UVIN-2815-UVOUT;n:type:ShaderForge.SFN_Panner,id:8234,x:31797,y:32471,varname:node_8234,prsc:2,spu:0.1,spv:0|UVIN-2815-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6908,x:32658,y:32345,varname:node_6908,prsc:2|A-8293-OUT,B-2811-RGB,C-2811-A;n:type:ShaderForge.SFN_VertexColor,id:2811,x:32398,y:32362,varname:node_2811,prsc:2;n:type:ShaderForge.SFN_Power,id:2940,x:32575,y:32683,varname:node_2940,prsc:2|VAL-1538-OUT,EXP-8754-OUT;n:type:ShaderForge.SFN_Vector1,id:8754,x:32419,y:32917,varname:node_8754,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:8293,x:32465,y:32154,varname:node_8293,prsc:2|A-9629-RGB,B-5615-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5615,x:32215,y:32249,ptovrint:False,ptlb:lightness,ptin:_lightness,varname:node_5615,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_Color,id:1438,x:31939,y:32958,ptovrint:False,ptlb:color,ptin:_color,varname:node_1438,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.4627451,c3:0.2196079,c4:0;proporder:195-1125-1595-9629-5615-1438;pass:END;sub:END;*/

Shader "Particles/S_liuguang0077" {
    Properties {
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _material ("material", 2D) = "white" {}
        _lightness ("lightness", Float ) = 1.2
        _color ("color", Color) = (1,0.4627451,0.2196079,0)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _wenli01; uniform float4 _wenli01_ST;
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _material; uniform float4 _material_ST;
            uniform float _lightness;
            uniform float4 _color;
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
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _material_var = tex2D(_material,TRANSFORM_TEX(i.uv0, _material));
                float4 node_6335 = _Time + _TimeEditor;
                float2 node_8234 = (i.uv0+node_6335.g*float2(0.1,0));
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_8234, _wenli01));
                float2 node_4656 = (i.uv0+node_6335.g*float2(-0.1,0));
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_4656, _wenli02));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = (((_material_var.rgb*_lightness)*i.vertexColor.rgb*i.vertexColor.a)+(pow((_wenli01_var.rgb*_wenli02_var.rgb*20.0*_color.rgb),3.0)*_Mask_var.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
