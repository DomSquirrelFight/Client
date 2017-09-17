// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.08088237,fgcg:0.003568338,fgcb:0.003568338,fgca:1,fgde:1,fgrn:15,fgrf:60,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:34239,y:32712,varname:node_1,prsc:2|emission-7637-OUT;n:type:ShaderForge.SFN_Multiply,id:4,x:33848,y:32896,varname:node_4,prsc:2|A-5004-OUT,B-68-RGB;n:type:ShaderForge.SFN_Color,id:68,x:33460,y:32532,ptovrint:False,ptlb:node_68,ptin:_node_68,varname:node_3478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Time,id:5818,x:33012,y:32999,varname:node_5818,prsc:2;n:type:ShaderForge.SFN_Sin,id:9405,x:33399,y:32948,varname:node_9405,prsc:2|IN-2396-OUT;n:type:ShaderForge.SFN_Vector1,id:7152,x:33096,y:32884,varname:node_7152,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:5004,x:33505,y:32776,varname:node_5004,prsc:2|A-7152-OUT,B-9405-OUT;n:type:ShaderForge.SFN_Clamp01,id:7637,x:34020,y:32983,varname:node_7637,prsc:2|IN-4-OUT;n:type:ShaderForge.SFN_Multiply,id:2396,x:33243,y:33092,varname:node_2396,prsc:2|A-5818-T,B-8467-OUT;n:type:ShaderForge.SFN_Vector1,id:8467,x:33054,y:33167,varname:node_8467,prsc:2,v1:6;proporder:68;pass:END;sub:END;*/

Shader "Particles/redbian" {
    Properties {
        _node_68 ("node_68", Color) = (1,0,0,1)
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
            Blend One OneMinusSrcColor
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
            uniform float4 _node_68;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_5818 = _Time + _TimeEditor;
                float3 emissive = saturate(((1.0+sin((node_5818.g*6.0)))*_node_68.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
