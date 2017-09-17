// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33038,y:32691,varname:node_4795,prsc:2|emission-6747-OUT;n:type:ShaderForge.SFN_Tex2d,id:703,x:31617,y:32582,ptovrint:False,ptlb:Fengwo,ptin:_Fengwo,varname:node_703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:536788ef0ab79ac438982dbf1fb738da,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Color,id:750,x:32134,y:32483,ptovrint:False,ptlb:color_W,ptin:_color_W,varname:node_750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.37,c2:0.3,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4481,x:32440,y:32567,varname:node_4481,prsc:2|A-7591-OUT,B-750-RGB,C-2435-OUT;n:type:ShaderForge.SFN_Tex2d,id:2338,x:31844,y:33042,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_2338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5cc9b46c85cb11f4098a953ce23742b0,ntxv:0,isnm:False|UVIN-5526-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1298,x:31969,y:32265,ptovrint:False,ptlb:Wenli,ptin:_Wenli,varname:node_1298,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:105eea34bd918da43a3e6be4b95417af,ntxv:0,isnm:False|UVIN-4400-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7591,x:32268,y:32350,varname:node_7591,prsc:2|A-1298-RGB,B-703-RGB;n:type:ShaderForge.SFN_Multiply,id:9309,x:32274,y:33137,varname:node_9309,prsc:2|A-703-A,B-2338-R,C-4475-RGB;n:type:ShaderForge.SFN_Add,id:6434,x:32593,y:32791,varname:node_6434,prsc:2|A-4481-OUT,B-703-R;n:type:ShaderForge.SFN_Color,id:4475,x:31844,y:33259,ptovrint:False,ptlb:Color_G,ptin:_Color_G,varname:node_4475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6747,x:32852,y:32875,varname:node_6747,prsc:2|A-6434-OUT,B-9051-OUT,C-9309-OUT;n:type:ShaderForge.SFN_Vector1,id:9051,x:32298,y:32921,varname:node_9051,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:2435,x:32224,y:32717,varname:node_2435,prsc:2,v1:3;n:type:ShaderForge.SFN_Panner,id:4400,x:31699,y:32274,varname:node_4400,prsc:2,spu:-0.2,spv:0|UVIN-593-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:593,x:31404,y:32302,varname:node_593,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:3010,x:31162,y:32887,varname:node_3010,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:5526,x:31415,y:32952,varname:node_5526,prsc:2,spu:-1,spv:0|UVIN-3010-UVOUT,DIST-4661-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4661,x:31162,y:33072,ptovrint:False,ptlb:P,ptin:_P,varname:node_4661,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:703-750-2338-1298-4475-4661;pass:END;sub:END;*/

Shader "Particles/S_Hudun003" {
    Properties {
        _Fengwo ("Fengwo", 2D) = "black" {}
        _color_W ("color_W", Color) = (0.37,0.3,1,1)
        _Glow ("Glow", 2D) = "white" {}
        _Wenli ("Wenli", 2D) = "white" {}
        _Color_G ("Color_G", Color) = (0.5,0.5,0.5,1)
        _P ("P", Float ) = 0
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
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Fengwo; uniform float4 _Fengwo_ST;
            uniform float4 _color_W;
            uniform sampler2D _Glow; uniform float4 _Glow_ST;
            uniform sampler2D _Wenli; uniform float4 _Wenli_ST;
            uniform float4 _Color_G;
            uniform float _P;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_1215 = _Time + _TimeEditor;
                float2 node_4400 = (i.uv0+node_1215.g*float2(-0.2,0));
                float4 _Wenli_var = tex2D(_Wenli,TRANSFORM_TEX(node_4400, _Wenli));
                float4 _Fengwo_var = tex2D(_Fengwo,TRANSFORM_TEX(i.uv0, _Fengwo));
                float2 node_5526 = (i.uv0+_P*float2(-1,0));
                float4 _Glow_var = tex2D(_Glow,TRANSFORM_TEX(node_5526, _Glow));
                float3 emissive = ((((_Wenli_var.rgb*_Fengwo_var.rgb)*_color_W.rgb*3.0)+_Fengwo_var.r)*3.0*(_Fengwo_var.a*_Glow_var.r*_Color_G.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
