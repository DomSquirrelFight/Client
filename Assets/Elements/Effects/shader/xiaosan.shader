// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32931,y:32695,varname:node_3138,prsc:2|emission-5864-RGB,alpha-6988-OUT;n:type:ShaderForge.SFN_Tex2d,id:7156,x:31077,y:32531,ptovrint:False,ptlb:node_7156,ptin:_node_7156,varname:node_7156,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_If,id:6988,x:32074,y:32751,varname:node_6988,prsc:2|A-6100-OUT,B-9277-OUT,GT-9277-OUT,EQ-9277-OUT,LT-3677-OUT;n:type:ShaderForge.SFN_Vector1,id:9277,x:31613,y:32742,varname:node_9277,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:3677,x:31629,y:32871,varname:node_3677,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:4406,x:31114,y:32878,ptovrint:False,ptlb:node_4406,ptin:_node_4406,varname:node_4406,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5864,x:32234,y:32485,ptovrint:False,ptlb:node_5864,ptin:_node_5864,varname:node_5864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ef86c58aed5233f40a61c53e3e53ed56,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6100,x:31432,y:32598,varname:node_6100,prsc:2|A-7156-R,B-4406-OUT;proporder:7156-4406-5864;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _node_7156 ("node_7156", 2D) = "white" {}
        _node_4406 ("node_4406", Float ) = 0
        _node_5864 ("node_5864", 2D) = "white" {}
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _node_7156; uniform float4 _node_7156_ST;
            uniform float _node_4406;
            uniform sampler2D _node_5864; uniform float4 _node_5864_ST;
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
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_5864_var = tex2D(_node_5864,TRANSFORM_TEX(i.uv0, _node_5864));
                float3 emissive = _node_5864_var.rgb;
                float3 finalColor = emissive;
                float4 _node_7156_var = tex2D(_node_7156,TRANSFORM_TEX(i.uv0, _node_7156));
                float node_9277 = 1.0;
                float node_6988_if_leA = step((_node_7156_var.r+_node_4406),node_9277);
                float node_6988_if_leB = step(node_9277,(_node_7156_var.r+_node_4406));
                return fixed4(finalColor,lerp((node_6988_if_leA*0.0)+(node_6988_if_leB*node_9277),node_9277,node_6988_if_leA*node_6988_if_leB));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
