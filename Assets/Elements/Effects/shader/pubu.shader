// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33504,y:32224,varname:node_4795,prsc:2|emission-2181-OUT,alpha-4390-OUT;n:type:ShaderForge.SFN_Color,id:797,x:32747,y:32687,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1008,x:32747,y:32191,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_1008,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7c9e0eaf78548be48afe8ac5f5084488,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7032,x:32747,y:32372,ptovrint:False,ptlb:Base Tex,ptin:_BaseTex,varname:_BaseTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:12f25aca08d248049a2ced204ff59ada,ntxv:0,isnm:False|UVIN-6308-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2181,x:33154,y:32132,varname:node_2181,prsc:2|A-7032-RGB,B-797-RGB;n:type:ShaderForge.SFN_Panner,id:6308,x:32548,y:32353,varname:node_6308,prsc:2,spu:0,spv:0.35|UVIN-5348-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5348,x:32340,y:32260,varname:node_5348,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:4390,x:33179,y:32441,varname:node_4390,prsc:2|A-1008-R,B-797-A;proporder:797-7032-1008;pass:END;sub:END;*/

Shader "Shader Forge/pubu" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _BaseTex ("Base Tex", 2D) = "white" {}
        _Alpha ("Alpha", 2D) = "white" {}
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
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform sampler2D _BaseTex; uniform float4 _BaseTex_ST;
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
                float4 node_4527 = _Time + _TimeEditor;
                float2 node_6308 = (i.uv0+node_4527.g*float2(0,0.35));
                float4 _BaseTex_var = tex2D(_BaseTex,TRANSFORM_TEX(node_6308, _BaseTex));
                float3 emissive = (_BaseTex_var.rgb*_TintColor.rgb);
                float3 finalColor = emissive;
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(i.uv0, _Alpha));
                return fixed4(finalColor,(_Alpha_var.r*_TintColor.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
