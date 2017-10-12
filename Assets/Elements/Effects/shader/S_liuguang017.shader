// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33385,y:32522,varname:node_4795,prsc:2|emission-5364-OUT;n:type:ShaderForge.SFN_Tex2d,id:9460,x:32459,y:32790,ptovrint:False,ptlb:Tex2,ptin:_Tex2,varname:_M_Tex70077,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86086469e17f5ea41b843636b407fa31,ntxv:0,isnm:False|UVIN-1156-UVOUT;n:type:ShaderForge.SFN_Panner,id:1156,x:32239,y:32824,varname:node_1156,prsc:2,spu:0,spv:-0.5|UVIN-1494-UVOUT,DIST-2080-OUT;n:type:ShaderForge.SFN_TexCoord,id:1494,x:32063,y:32807,varname:node_1494,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:2080,x:31806,y:33039,ptovrint:False,ptlb:grow,ptin:_grow,varname:_grow_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.753366,max:4;n:type:ShaderForge.SFN_Tex2d,id:9482,x:32402,y:32993,ptovrint:False,ptlb:Tex3,ptin:_Tex3,varname:_Tex3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dc6623120c4a2fa448d9a0358ce8abdd,ntxv:2,isnm:False|UVIN-1156-UVOUT;n:type:ShaderForge.SFN_VertexColor,id:921,x:32243,y:32343,varname:node_921,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9555,x:32638,y:32360,varname:node_9555,prsc:2|A-921-RGB,B-9581-RGB,C-9581-A;n:type:ShaderForge.SFN_Multiply,id:4613,x:33144,y:32706,varname:node_4613,prsc:2|A-921-A,B-3496-OUT;n:type:ShaderForge.SFN_Add,id:3496,x:32810,y:32779,varname:node_3496,prsc:2|A-9460-R,B-5136-OUT;n:type:ShaderForge.SFN_Multiply,id:5364,x:33085,y:32496,varname:node_5364,prsc:2|A-9555-OUT,B-3496-OUT,C-4613-OUT;n:type:ShaderForge.SFN_Multiply,id:5136,x:32626,y:33036,varname:node_5136,prsc:2|A-9482-R,B-167-OUT;n:type:ShaderForge.SFN_ValueProperty,id:167,x:32321,y:33230,ptovrint:False,ptlb:lightness,ptin:_lightness,varname:node_167,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Tex2d,id:9581,x:32288,y:32580,ptovrint:False,ptlb:wenli1,ptin:_wenli1,varname:node_9581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ccc6271d6a33e724b96d7c74c0e11ebf,ntxv:0,isnm:False;proporder:2080-9482-9460-167-9581;pass:END;sub:END;*/

Shader "Particles/S_liuguang017" {
    Properties {
        _grow ("grow", Range(0, 4)) = 3.753366
        _Tex3 ("Tex3", 2D) = "black" {}
        _Tex2 ("Tex2", 2D) = "white" {}
        _lightness ("lightness", Float ) = 2
        _wenli1 ("wenli1", 2D) = "white" {}
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
            uniform sampler2D _Tex2; uniform float4 _Tex2_ST;
            uniform float _grow;
            uniform sampler2D _Tex3; uniform float4 _Tex3_ST;
            uniform float _lightness;
            uniform sampler2D _wenli1; uniform float4 _wenli1_ST;
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
                float4 _wenli1_var = tex2D(_wenli1,TRANSFORM_TEX(i.uv0, _wenli1));
                float2 node_1156 = (i.uv0+_grow*float2(0,-0.5));
                float4 _Tex2_var = tex2D(_Tex2,TRANSFORM_TEX(node_1156, _Tex2));
                float4 _Tex3_var = tex2D(_Tex3,TRANSFORM_TEX(node_1156, _Tex3));
                float node_3496 = (_Tex2_var.r+(_Tex3_var.r*_lightness));
                float3 emissive = ((i.vertexColor.rgb*_wenli1_var.rgb*_wenli1_var.a)*node_3496*(i.vertexColor.a*node_3496));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
