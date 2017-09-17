// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33043,y:32795,varname:node_4795,prsc:2|emission-6764-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31959,y:32763,ptovrint:False,ptlb:smalltex,ptin:_smalltex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c88a85fdd259b9d4e90bdc7d01621ac8,ntxv:0,isnm:False|UVIN-4031-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9785,x:31959,y:32982,ptovrint:False,ptlb:bigtex,ptin:_bigtex,varname:node_9785,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c88a85fdd259b9d4e90bdc7d01621ac8,ntxv:0,isnm:False|UVIN-2558-UVOUT;n:type:ShaderForge.SFN_Panner,id:4031,x:31777,y:32763,varname:node_4031,prsc:2,spu:0.2,spv:-0.05|UVIN-5779-UVOUT,DIST-3566-OUT;n:type:ShaderForge.SFN_TexCoord,id:5779,x:31586,y:32873,varname:node_5779,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:2558,x:31777,y:32982,varname:node_2558,prsc:2,spu:-0.2,spv:0.05|UVIN-5779-UVOUT,DIST-3566-OUT;n:type:ShaderForge.SFN_Multiply,id:4295,x:32180,y:32841,varname:node_4295,prsc:2|A-6074-RGB,B-9785-RGB;n:type:ShaderForge.SFN_Tex2d,id:6879,x:31959,y:32559,ptovrint:False,ptlb:xiantiao,ptin:_xiantiao,varname:node_6879,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:620e7195976a9744c8ec1a9bc7fb3ffd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1633,x:32388,y:32709,varname:node_1633,prsc:2|A-4854-OUT,B-4295-OUT;n:type:ShaderForge.SFN_Multiply,id:7343,x:32626,y:32895,varname:node_7343,prsc:2|A-1633-OUT,B-3089-RGB,C-280-OUT;n:type:ShaderForge.SFN_Color,id:3089,x:32388,y:32885,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3089,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:108,x:31979,y:33197,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_108,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4c7714aa765ad684f9e2bbe936230b6c,ntxv:0,isnm:False|UVIN-7829-UVOUT;n:type:ShaderForge.SFN_Panner,id:7829,x:31777,y:33197,varname:node_7829,prsc:2,spu:-0.5,spv:0|UVIN-5779-UVOUT,DIST-3566-OUT;n:type:ShaderForge.SFN_Time,id:8730,x:31398,y:33226,varname:node_8730,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4960,x:31398,y:33394,ptovrint:False,ptlb:Rate,ptin:_Rate,varname:node_4960,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:3566,x:31602,y:33266,varname:node_3566,prsc:2|A-8730-T,B-4960-OUT;n:type:ShaderForge.SFN_Multiply,id:280,x:32190,y:33197,varname:node_280,prsc:2|A-108-RGB,B-1076-OUT;n:type:ShaderForge.SFN_Vector1,id:1076,x:31979,y:33374,varname:node_1076,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Multiply,id:6764,x:32827,y:32895,varname:node_6764,prsc:2|A-7343-OUT,B-6149-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6149,x:32615,y:33073,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_6149,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_Multiply,id:4854,x:32193,y:32653,varname:node_4854,prsc:2|A-6100-OUT,B-6879-RGB;n:type:ShaderForge.SFN_Vector1,id:6100,x:32207,y:32580,varname:node_6100,prsc:2,v1:5;proporder:3089-6879-6074-9785-108-4960-6149;pass:END;sub:END;*/

Shader "Shader Forge/S_uvliu001" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _xiantiao ("xiantiao", 2D) = "white" {}
        _smalltex ("smalltex", 2D) = "white" {}
        _bigtex ("bigtex", 2D) = "white" {}
        _niuqu ("niuqu", 2D) = "white" {}
        _Rate ("Rate", Float ) = 1
        _Power ("Power", Float ) = 20
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
            uniform sampler2D _smalltex; uniform float4 _smalltex_ST;
            uniform sampler2D _bigtex; uniform float4 _bigtex_ST;
            uniform sampler2D _xiantiao; uniform float4 _xiantiao_ST;
            uniform float4 _Color;
            uniform sampler2D _niuqu; uniform float4 _niuqu_ST;
            uniform float _Rate;
            uniform float _Power;
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
                float4 _xiantiao_var = tex2D(_xiantiao,TRANSFORM_TEX(i.uv0, _xiantiao));
                float4 node_8730 = _Time + _TimeEditor;
                float node_3566 = (node_8730.g*_Rate);
                float2 node_4031 = (i.uv0+node_3566*float2(0.2,-0.05));
                float4 _smalltex_var = tex2D(_smalltex,TRANSFORM_TEX(node_4031, _smalltex));
                float2 node_2558 = (i.uv0+node_3566*float2(-0.2,0.05));
                float4 _bigtex_var = tex2D(_bigtex,TRANSFORM_TEX(node_2558, _bigtex));
                float2 node_7829 = (i.uv0+node_3566*float2(-0.5,0));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_7829, _niuqu));
                float3 emissive = ((((5.0*_xiantiao_var.rgb)*(_smalltex_var.rgb*_bigtex_var.rgb))*_Color.rgb*(_niuqu_var.rgb*0.02))*_Power);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
