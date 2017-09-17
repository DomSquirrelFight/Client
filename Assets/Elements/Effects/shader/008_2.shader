// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33178,y:32486,varname:node_4795,prsc:2|emission-2393-OUT,alpha-798-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32743,y:32509,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bc9eb44229865cd47a6edf4d6bde594a,ntxv:0,isnm:False|UVIN-4979-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32978,y:32609,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-8245-RGB;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32743,y:32675,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Multiply,id:798,x:32978,y:32780,varname:node_798,prsc:2|A-6074-A,B-2053-A,C-8245-A;n:type:ShaderForge.SFN_Panner,id:9461,x:32384,y:32599,varname:node_9461,prsc:2,spu:-1,spv:0|UVIN-1554-UVOUT,DIST-8002-OUT;n:type:ShaderForge.SFN_Add,id:4979,x:32562,y:32599,varname:node_4979,prsc:2|A-9461-UVOUT,B-5052-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1554,x:32086,y:32668,varname:node_1554,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:5052,x:32384,y:32762,varname:node_5052,prsc:2,spu:0,spv:1|UVIN-1554-UVOUT,DIST-7861-OUT;n:type:ShaderForge.SFN_Slider,id:7861,x:32037,y:32846,ptovrint:False,ptlb:y,ptin:_y,varname:node_7861,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:8002,x:32018,y:32570,ptovrint:False,ptlb:x,ptin:_x,varname:node_8002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:8245,x:32743,y:32852,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_8245,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:6074-8002-7861-8245;pass:END;sub:END;*/

Shader "Shader Forge/UV_bulianxu" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _x ("x", Range(0, 1)) = 0
        _y ("y", Range(0, 1)) = 0
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _y;
            uniform float _x;
            uniform float4 _Color;
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
                float2 node_4979 = ((i.uv0+_x*float2(-1,0))+(i.uv0+_y*float2(0,1)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4979, _Texture));
                float3 emissive = (_Texture_var.rgb*i.vertexColor.rgb*_Color.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Texture_var.a*i.vertexColor.a*_Color.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
