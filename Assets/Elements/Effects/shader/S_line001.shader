// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:34477,y:32999,varname:node_4795,prsc:2|emission-9257-OUT;n:type:ShaderForge.SFN_Tex2d,id:6041,x:33523,y:32760,ptovrint:False,ptlb:node_6041,ptin:_node_6041,varname:node_6041,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5ab63d85bcba5aa4ea1822828e981909,ntxv:0,isnm:False|UVIN-7536-OUT;n:type:ShaderForge.SFN_TexCoord,id:8637,x:32900,y:32760,varname:node_8637,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:2664,x:33056,y:32760,varname:node_2664,prsc:2,spu:-2.4,spv:0|UVIN-8637-UVOUT;n:type:ShaderForge.SFN_Sin,id:7491,x:33212,y:32760,varname:node_7491,prsc:2|IN-2664-UVOUT;n:type:ShaderForge.SFN_Abs,id:7536,x:33368,y:32760,varname:node_7536,prsc:2|IN-7491-OUT;n:type:ShaderForge.SFN_Tex2d,id:5032,x:33523,y:32952,ptovrint:False,ptlb:node_5032,ptin:_node_5032,varname:node_5032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f3b4796741611b34c9a83a2c85bf57aa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:3494,x:33905,y:32806,varname:node_3494,prsc:2|A-6041-RGB,B-3103-OUT;n:type:ShaderForge.SFN_Multiply,id:3103,x:33708,y:32857,varname:node_3103,prsc:2|A-6041-RGB,B-5032-RGB;n:type:ShaderForge.SFN_Panner,id:6430,x:33523,y:33120,varname:node_6430,prsc:2,spu:-1,spv:0|UVIN-8637-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6762,x:33709,y:33120,ptovrint:False,ptlb:node_6041_copy,ptin:_node_6041_copy,varname:_node_6041_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5ab63d85bcba5aa4ea1822828e981909,ntxv:0,isnm:False|UVIN-6430-UVOUT;n:type:ShaderForge.SFN_Lerp,id:3881,x:34100,y:33093,varname:node_3881,prsc:2|A-3494-OUT,B-6762-R,T-5049-OUT;n:type:ShaderForge.SFN_Vector1,id:5049,x:33709,y:33297,varname:node_5049,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:9257,x:34306,y:33129,varname:node_9257,prsc:2|A-3881-OUT,B-1523-RGB;n:type:ShaderForge.SFN_Color,id:1523,x:34009,y:33368,ptovrint:False,ptlb:node_1523,ptin:_node_1523,varname:node_1523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6443757,c3:0.2867647,c4:1;proporder:6041-5032-6762-1523;pass:END;sub:END;*/

Shader "Particles/S_line001" {
    Properties {
        _node_6041 ("node_6041", 2D) = "white" {}
        _node_5032 ("node_5032", 2D) = "white" {}
        _node_6041_copy ("node_6041_copy", 2D) = "white" {}
        _node_1523 ("node_1523", Color) = (1,0.6443757,0.2867647,1)
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
            uniform sampler2D _node_6041; uniform float4 _node_6041_ST;
            uniform sampler2D _node_5032; uniform float4 _node_5032_ST;
            uniform sampler2D _node_6041_copy; uniform float4 _node_6041_copy_ST;
            uniform float4 _node_1523;
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
                float4 node_6479 = _Time + _TimeEditor;
                float2 node_7536 = abs(sin((i.uv0+node_6479.g*float2(-2.4,0))));
                float4 _node_6041_var = tex2D(_node_6041,TRANSFORM_TEX(node_7536, _node_6041));
                float4 _node_5032_var = tex2D(_node_5032,TRANSFORM_TEX(i.uv0, _node_5032));
                float2 node_6430 = (i.uv0+node_6479.g*float2(-1,0));
                float4 _node_6041_copy_var = tex2D(_node_6041_copy,TRANSFORM_TEX(node_6430, _node_6041_copy));
                float3 emissive = (lerp((_node_6041_var.rgb+(_node_6041_var.rgb*_node_5032_var.rgb)),float3(_node_6041_copy_var.r,_node_6041_copy_var.r,_node_6041_copy_var.r),0.3)*_node_1523.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
