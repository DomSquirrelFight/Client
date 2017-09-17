// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:34399,y:32926,varname:node_4795,prsc:2|emission-8912-OUT;n:type:ShaderForge.SFN_TexCoord,id:70,x:32723,y:33083,varname:node_70,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:3047,x:33488,y:32761,varname:node_3047,prsc:2|A-5909-OUT,B-70-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6585,x:33825,y:32761,ptovrint:False,ptlb:Wenli,ptin:_Wenli,varname:_node_8592_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:975b29a0cecbf8f4b9f414a97f5c7d66,ntxv:0,isnm:False|UVIN-110-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8307,x:34021,y:32909,varname:node_8307,prsc:2|A-6585-RGB,B-9413-RGB,C-6662-OUT;n:type:ShaderForge.SFN_Multiply,id:5909,x:33311,y:32761,varname:node_5909,prsc:2|A-9899-R,B-7649-OUT;n:type:ShaderForge.SFN_Panner,id:843,x:32954,y:32744,varname:node_843,prsc:2,spu:0.1,spv:0.1|UVIN-70-UVOUT;n:type:ShaderForge.SFN_Color,id:9413,x:33825,y:32936,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5304276,c2:0.5254902,c3:0.9686275,c4:1;n:type:ShaderForge.SFN_Vector1,id:7649,x:33140,y:32924,varname:node_7649,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Tex2d,id:9899,x:33140,y:32744,ptovrint:False,ptlb:node_9899,ptin:_node_9899,varname:node_9899,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:975b29a0cecbf8f4b9f414a97f5c7d66,ntxv:0,isnm:False|UVIN-843-UVOUT;n:type:ShaderForge.SFN_Panner,id:110,x:33660,y:32761,varname:node_110,prsc:2,spu:-0.1,spv:-0.1|UVIN-3047-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6662,x:33825,y:33098,ptovrint:False,ptlb:Qiangdu,ptin:_Qiangdu,varname:node_6662,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:9103,x:33663,y:33047,ptovrint:False,ptlb:node_9103,ptin:_node_9103,varname:node_9103,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6b395782af315604093ac6446a143464,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8912,x:34213,y:33026,varname:node_8912,prsc:2|A-8307-OUT,B-5125-OUT;n:type:ShaderForge.SFN_Multiply,id:5125,x:33825,y:33161,varname:node_5125,prsc:2|A-9103-RGB,B-985-OUT;n:type:ShaderForge.SFN_Vector1,id:985,x:33663,y:33276,varname:node_985,prsc:2,v1:0.7;proporder:6585-9413-9899-6662-9103;pass:END;sub:END;*/

Shader "Particles/S_Shuibo004" {
    Properties {
        _Wenli ("Wenli", 2D) = "white" {}
        _Color ("Color", Color) = (0.5304276,0.5254902,0.9686275,1)
        _node_9899 ("node_9899", 2D) = "white" {}
        _Qiangdu ("Qiangdu", Float ) = 1
        _node_9103 ("node_9103", 2D) = "white" {}
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
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Wenli; uniform float4 _Wenli_ST;
            uniform float4 _Color;
            uniform sampler2D _node_9899; uniform float4 _node_9899_ST;
            uniform float _Qiangdu;
            uniform sampler2D _node_9103; uniform float4 _node_9103_ST;
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
                float4 node_223 = _Time + _TimeEditor;
                float2 node_843 = (i.uv0+node_223.g*float2(0.1,0.1));
                float4 _node_9899_var = tex2D(_node_9899,TRANSFORM_TEX(node_843, _node_9899));
                float2 node_110 = (((_node_9899_var.r*0.1)+i.uv0)+node_223.g*float2(-0.1,-0.1));
                float4 _Wenli_var = tex2D(_Wenli,TRANSFORM_TEX(node_110, _Wenli));
                float4 _node_9103_var = tex2D(_node_9103,TRANSFORM_TEX(i.uv0, _node_9103));
                float3 emissive = ((_Wenli_var.rgb*_Color.rgb*_Qiangdu)+(_node_9103_var.rgb*0.7));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
