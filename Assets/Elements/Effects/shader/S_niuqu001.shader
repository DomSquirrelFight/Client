// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32846,y:32810,varname:node_4795,prsc:2|emission-8846-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32604,y:32720,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8050-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32072,y:32806,varname:node_2393,prsc:2|A-6092-OUT,B-1055-R;n:type:ShaderForge.SFN_Vector1,id:9248,x:32072,y:32740,varname:node_9248,prsc:2,v1:0.011;n:type:ShaderForge.SFN_Add,id:8050,x:32431,y:32766,varname:node_8050,prsc:2|A-4816-UVOUT,B-9412-OUT;n:type:ShaderForge.SFN_Tex2d,id:1055,x:31899,y:32898,ptovrint:False,ptlb:wenli,ptin:_wenli,varname:node_1055,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f68d2fafbf3cb1545b66361833481ce0,ntxv:0,isnm:False|UVIN-1724-UVOUT;n:type:ShaderForge.SFN_Panner,id:1724,x:31723,y:32898,varname:node_1724,prsc:2,spu:-0.3,spv:0.1|UVIN-3233-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3233,x:31551,y:32898,varname:node_3233,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:6092,x:31899,y:32806,varname:node_6092,prsc:2,v1:-10,v2:0;n:type:ShaderForge.SFN_Multiply,id:9412,x:32252,y:32786,varname:node_9412,prsc:2|A-9248-OUT,B-2393-OUT;n:type:ShaderForge.SFN_TexCoord,id:6114,x:32072,y:32586,varname:node_6114,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:4816,x:32300,y:32616,varname:node_4816,prsc:2,spu:-1.5,spv:0|UVIN-6114-UVOUT,DIST-9072-OUT;n:type:ShaderForge.SFN_VertexColor,id:2785,x:32395,y:32930,varname:node_2785,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8846,x:32604,y:32910,varname:node_8846,prsc:2|A-6074-RGB,B-2785-RGB;n:type:ShaderForge.SFN_Time,id:2401,x:31413,y:32726,varname:node_2401,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9072,x:31788,y:32609,varname:node_9072,prsc:2|A-7427-OUT,B-2401-T;n:type:ShaderForge.SFN_ValueProperty,id:7427,x:31424,y:32624,ptovrint:False,ptlb:Rate,ptin:_Rate,varname:node_7427,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;proporder:6074-1055-7427;pass:END;sub:END;*/

Shader "Shader Forge/S_niuqu001" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _wenli ("wenli", 2D) = "white" {}
        _Rate ("Rate", Float ) = 0.1
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
            uniform float _Rate;
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
                float4 node_2401 = _Time + _TimeEditor;
                float4 node_5610 = _Time + _TimeEditor;
                float2 node_1724 = (i.uv0+node_5610.g*float2(-0.3,0.1));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_1724, _wenli));
                float2 node_8050 = ((i.uv0+(_Rate*node_2401.g)*float2(-1.5,0))+(0.011*(float2(-10,0)*_wenli_var.r)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_8050, _Texture));
                float3 emissive = (_Texture_var.rgb*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
