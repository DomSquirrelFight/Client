// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:34700,y:32852,varname:node_4795,prsc:2|alpha-3528-OUT;n:type:ShaderForge.SFN_Tex2d,id:6150,x:33641,y:32963,ptovrint:False,ptlb:node_6150,ptin:_node_6150,varname:node_6150,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:98a04bfa423dcf3469241a3e70fb15b5,ntxv:0,isnm:False|UVIN-427-OUT;n:type:ShaderForge.SFN_Tex2d,id:2551,x:32747,y:32818,ptovrint:False,ptlb:node_2551,ptin:_node_2551,varname:node_2551,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-9379-UVOUT;n:type:ShaderForge.SFN_Add,id:427,x:33272,y:32951,varname:node_427,prsc:2|A-2712-OUT,B-2169-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2169,x:32331,y:33143,varname:node_2169,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:9379,x:32480,y:32829,varname:node_9379,prsc:2,spu:0.5,spv:0.2|UVIN-2169-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2712,x:32978,y:32875,varname:node_2712,prsc:2|A-2551-R,B-3094-OUT;n:type:ShaderForge.SFN_Vector1,id:3094,x:32747,y:33008,varname:node_3094,prsc:2,v1:0.11;n:type:ShaderForge.SFN_Power,id:7188,x:33915,y:33071,varname:node_7188,prsc:2|VAL-6150-G,EXP-3813-OUT;n:type:ShaderForge.SFN_Vector1,id:3813,x:33652,y:33141,varname:node_3813,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:3857,x:34462,y:32845,varname:node_3857,prsc:2|A-5580-RGB,B-2230-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9547,x:34161,y:33387,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_9547,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:3528,x:34462,y:33100,varname:node_3528,prsc:2|A-5580-A,B-2230-OUT,C-9547-OUT;n:type:ShaderForge.SFN_Tex2d,id:1008,x:33853,y:33294,ptovrint:False,ptlb:node_1008,ptin:_node_1008,varname:node_1008,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aef2d72c5a7c0374ab5d4e3e7dfea779,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2230,x:34128,y:33166,varname:node_2230,prsc:2|A-7188-OUT,B-1008-R;n:type:ShaderForge.SFN_VertexColor,id:5580,x:34023,y:32749,varname:node_5580,prsc:2;proporder:6150-2551-9547-1008;pass:END;sub:END;*/

Shader "Particles/S_tuowei002" {
    Properties {
        _node_6150 ("node_6150", 2D) = "white" {}
        _node_2551 ("node_2551", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 2
        _node_1008 ("node_1008", 2D) = "white" {}
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
            uniform sampler2D _node_6150; uniform float4 _node_6150_ST;
            uniform sampler2D _node_2551; uniform float4 _node_2551_ST;
            uniform float _qiangdu;
            uniform sampler2D _node_1008; uniform float4 _node_1008_ST;
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
                float3 finalColor = 0;
                float4 node_3582 = _Time + _TimeEditor;
                float2 node_9379 = (i.uv0+node_3582.g*float2(0.5,0.2));
                float4 _node_2551_var = tex2D(_node_2551,TRANSFORM_TEX(node_9379, _node_2551));
                float2 node_427 = ((_node_2551_var.r*0.11)+i.uv0);
                float4 _node_6150_var = tex2D(_node_6150,TRANSFORM_TEX(node_427, _node_6150));
                float4 _node_1008_var = tex2D(_node_1008,TRANSFORM_TEX(i.uv0, _node_1008));
                float node_2230 = (pow(_node_6150_var.g,1.5)*_node_1008_var.r);
                return fixed4(finalColor,(i.vertexColor.a*node_2230*_qiangdu));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
