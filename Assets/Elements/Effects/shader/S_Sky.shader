// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5074-RGB;n:type:ShaderForge.SFN_Tex2d,id:5074,x:32378,y:32758,ptovrint:False,ptlb:node_5074,ptin:_node_5074,varname:node_5074,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b2b1b7f4f7a39d945bb91583294102b1,ntxv:0,isnm:False|UVIN-7806-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3504,x:31936,y:32820,varname:node_3504,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:7806,x:32140,y:32919,varname:node_7806,prsc:2,spu:1,spv:0|UVIN-3504-UVOUT,DIST-6749-OUT;n:type:ShaderForge.SFN_Time,id:3120,x:31681,y:33071,varname:node_3120,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6749,x:31987,y:33124,varname:node_6749,prsc:2|A-3120-T,B-7040-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7040,x:31751,y:33327,ptovrint:False,ptlb:S,ptin:_S,varname:node_7040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;proporder:5074-7040;pass:END;sub:END;*/

Shader "Shader Forge/S_Sky" {
    Properties {
        _node_5074 ("node_5074", 2D) = "white" {}
        _S ("S", Float ) = 0.1
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_5074; uniform float4 _node_5074_ST;
            uniform float _S;
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
                float4 node_3120 = _Time + _TimeEditor;
                float2 node_7806 = (i.uv0+(node_3120.g*_S)*float2(1,0));
                float4 _node_5074_var = tex2D(_node_5074,TRANSFORM_TEX(node_7806, _node_5074));
                float3 emissive = _node_5074_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
