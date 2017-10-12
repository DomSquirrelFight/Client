// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-7585-OUT,clip-2345-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32147,y:32535,varname:node_2393,prsc:2|A-3027-R,B-5148-RGB,C-3027-A,D-9095-RGB,E-9095-A;n:type:ShaderForge.SFN_Tex2d,id:3027,x:31461,y:32408,ptovrint:False,ptlb:T1,ptin:_T1,varname:node_3027,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4f880ddc8b7f8764a829254962faeb1d,ntxv:0,isnm:False|UVIN-2998-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6374,x:31556,y:32765,ptovrint:False,ptlb:T2,ptin:_T2,varname:node_6374,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4f880ddc8b7f8764a829254962faeb1d,ntxv:0,isnm:False|UVIN-2998-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2345,x:32334,y:32974,varname:node_2345,prsc:2|A-6931-OUT,B-5796-OUT;n:type:ShaderForge.SFN_Slider,id:5796,x:31910,y:33112,ptovrint:False,ptlb:fade,ptin:_fade,varname:node_5796,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:7.487907,max:10;n:type:ShaderForge.SFN_Tex2d,id:3072,x:31528,y:32976,ptovrint:False,ptlb:T3,ptin:_T3,varname:node_3072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:141399644fc1f3d4c92c51e7c13c1925,ntxv:0,isnm:False|UVIN-2998-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6931,x:32019,y:32877,varname:node_6931,prsc:2|A-6374-R,B-3072-R;n:type:ShaderForge.SFN_Color,id:5148,x:31751,y:32322,ptovrint:False,ptlb:node_5148,ptin:_node_5148,varname:node_5148,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.03592453,c3:0,c4:1;n:type:ShaderForge.SFN_VertexColor,id:9095,x:31641,y:32586,varname:node_9095,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7585,x:32424,y:32688,varname:node_7585,prsc:2|A-2393-OUT,B-9591-OUT,C-2345-OUT;n:type:ShaderForge.SFN_Slider,id:9591,x:31879,y:32738,ptovrint:False,ptlb:brightness,ptin:_brightness,varname:node_9591,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.603493,max:5;n:type:ShaderForge.SFN_Panner,id:2998,x:31210,y:32678,varname:node_2998,prsc:2,spu:0.1,spv:0|UVIN-2503-UVOUT,DIST-7684-OUT;n:type:ShaderForge.SFN_TexCoord,id:2503,x:30961,y:32654,varname:node_2503,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:7684,x:30835,y:32961,ptovrint:False,ptlb:move,ptin:_move,varname:node_7684,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6.160941,max:20;proporder:3027-6374-5796-3072-5148-9591-7684;pass:END;sub:END;*/

Shader "Shader Forge/S_dissolve_bright" {
    Properties {
        _T1 ("T1", 2D) = "white" {}
        _T2 ("T2", 2D) = "white" {}
        _fade ("fade", Range(0, 10)) = 7.487907
        _T3 ("T3", 2D) = "white" {}
        _node_5148 ("node_5148", Color) = (1,0.03592453,0,1)
        _brightness ("brightness", Range(0, 5)) = 1.603493
        _move ("move", Range(0, 20)) = 6.160941
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _T1; uniform float4 _T1_ST;
            uniform sampler2D _T2; uniform float4 _T2_ST;
            uniform float _fade;
            uniform sampler2D _T3; uniform float4 _T3_ST;
            uniform float4 _node_5148;
            uniform float _brightness;
            uniform float _move;
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
                float2 node_2998 = (i.uv0+_move*float2(0.1,0));
                float4 _T2_var = tex2D(_T2,TRANSFORM_TEX(node_2998, _T2));
                float4 _T3_var = tex2D(_T3,TRANSFORM_TEX(node_2998, _T3));
                float node_2345 = ((_T2_var.r*_T3_var.r)*_fade);
                clip(node_2345 - 0.5);
////// Lighting:
////// Emissive:
                float4 _T1_var = tex2D(_T1,TRANSFORM_TEX(node_2998, _T1));
                float3 emissive = ((_T1_var.r*_node_5148.rgb*_T1_var.a*i.vertexColor.rgb*i.vertexColor.a)*_brightness*node_2345);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _T2; uniform float4 _T2_ST;
            uniform float _fade;
            uniform sampler2D _T3; uniform float4 _T3_ST;
            uniform float _move;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 node_2998 = (i.uv0+_move*float2(0.1,0));
                float4 _T2_var = tex2D(_T2,TRANSFORM_TEX(node_2998, _T2));
                float4 _T3_var = tex2D(_T3,TRANSFORM_TEX(node_2998, _T3));
                float node_2345 = ((_T2_var.r*_T3_var.r)*_fade);
                clip(node_2345 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
