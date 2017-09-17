// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:2,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.08088237,fgcg:0.003568338,fgcb:0.003568338,fgca:1,fgde:1,fgrn:15,fgrf:60,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:35230,y:32924,varname:node_1,prsc:2|emission-5330-OUT;n:type:ShaderForge.SFN_Multiply,id:3,x:34493,y:32832,varname:node_3,prsc:2|A-57-RGB,B-92-RGB;n:type:ShaderForge.SFN_Multiply,id:4,x:34493,y:32972,varname:node_4,prsc:2|A-8292-OUT,B-6-OUT;n:type:ShaderForge.SFN_Multiply,id:6,x:34313,y:32996,varname:node_6,prsc:2|A-13-OUT,B-10-RGB;n:type:ShaderForge.SFN_Tex2d,id:10,x:34128,y:33016,ptovrint:False,ptlb:wenli,ptin:_wenli,varname:node_9131,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:970a620b895468a458d879fb1b047a63,ntxv:0,isnm:False|UVIN-8666-UVOUT;n:type:ShaderForge.SFN_Vector1,id:13,x:34128,y:32938,varname:node_13,prsc:2,v1:0.8;n:type:ShaderForge.SFN_TexCoord,id:45,x:33737,y:33016,varname:node_45,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:57,x:34128,y:32577,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_15,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d0a7f64b40f897b41961c5846ac6fa94,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:58,x:34669,y:32950,varname:node_58,prsc:2|A-3-OUT,B-4-OUT;n:type:ShaderForge.SFN_Color,id:92,x:34128,y:32770,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3134,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:268,x:34865,y:32989,varname:node_268,prsc:2|A-58-OUT,B-7375-RGB;n:type:ShaderForge.SFN_Panner,id:8666,x:33946,y:33016,varname:node_8666,prsc:2,spu:0,spv:0.1|UVIN-45-UVOUT;n:type:ShaderForge.SFN_VertexColor,id:7375,x:34493,y:33178,varname:node_7375,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5330,x:35038,y:33079,varname:node_5330,prsc:2|A-268-OUT,B-92-A,C-495-OUT;n:type:ShaderForge.SFN_Vector1,id:8292,x:34313,y:32911,varname:node_8292,prsc:2,v1:0.46;n:type:ShaderForge.SFN_ValueProperty,id:495,x:34696,y:33247,ptovrint:False,ptlb:X,ptin:_X,varname:node_495,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:57-10-92-495;pass:END;sub:END;*/

Shader "Particles/L10" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _wenli ("wenli", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _X ("X", Float ) = 0
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
            Blend SrcColor One
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
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _Color;
            uniform float _X;
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
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float4 node_7000 = _Time + _TimeEditor;
                float2 node_8666 = (i.uv0+node_7000.g*float2(0,0.1));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_8666, _wenli));
                float3 emissive = ((((_Texture_var.rgb*_Color.rgb)+(0.46*(0.8*_wenli_var.rgb)))*i.vertexColor.rgb)*_Color.a*_X);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
