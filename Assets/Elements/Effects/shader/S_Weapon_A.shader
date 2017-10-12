// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:34320,y:32709,varname:node_1,prsc:2|emission-3308-OUT;n:type:ShaderForge.SFN_Add,id:9248,x:33945,y:32785,varname:node_9248,prsc:2|A-4071-OUT,B-2064-RGB;n:type:ShaderForge.SFN_Tex2d,id:1215,x:33485,y:32944,ptovrint:False,ptlb:wenli,ptin:_wenli,varname:node_7875,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28873d4d5bcdaab458c8aef76928c04e,ntxv:0,isnm:False|UVIN-8559-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8668,x:32778,y:32743,varname:node_8668,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:829,x:32729,y:33203,ptovrint:False,ptlb:V,ptin:_V,varname:node_936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Panner,id:7351,x:33085,y:32803,varname:node_7351,prsc:2,spu:0,spv:1|UVIN-8668-UVOUT,DIST-4261-OUT;n:type:ShaderForge.SFN_Color,id:2064,x:33408,y:33156,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1216,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Time,id:520,x:32713,y:32970,varname:node_520,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4261,x:32929,y:32970,varname:node_4261,prsc:2|A-520-T,B-829-OUT;n:type:ShaderForge.SFN_Panner,id:8559,x:33298,y:32944,varname:node_8559,prsc:2,spu:1,spv:0|UVIN-7351-UVOUT,DIST-7733-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7481,x:32729,y:33338,ptovrint:False,ptlb:U,ptin:_U,varname:node_8850,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:7733,x:32974,y:33203,varname:node_7733,prsc:2|A-520-T,B-7481-OUT;n:type:ShaderForge.SFN_Multiply,id:4071,x:33691,y:32765,varname:node_4071,prsc:2|A-5133-RGB,B-1215-RGB;n:type:ShaderForge.SFN_Color,id:5133,x:33458,y:32755,ptovrint:False,ptlb:wenli_C,ptin:_wenli_C,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8906,x:33778,y:33175,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aae3275ae79f3634a89e242bf1e3b1e1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3308,x:34147,y:32848,varname:node_3308,prsc:2|A-9248-OUT,B-8906-RGB;proporder:5133-1215-2064-8906-829-7481;pass:END;sub:END;*/

Shader "Particles/S_Weapon_A" {
    Properties {
        _wenli_C ("wenli_C", Color) = (1,0.5,0.5,1)
        _wenli ("wenli", 2D) = "white" {}
        _Color ("Color", Color) = (1,0.5,0.5,1)
        _Opacity ("Opacity", 2D) = "white" {}
        _V ("V", Float ) = 0.1
        _U ("U", Float ) = 0
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
            uniform float _V;
            uniform float4 _Color;
            uniform float _U;
            uniform float4 _wenli_C;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
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
                float4 node_520 = _Time + _TimeEditor;
                float2 node_8559 = ((i.uv0+(node_520.g*_V)*float2(0,1))+(node_520.g*_U)*float2(1,0));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_8559, _wenli));
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                float3 emissive = (((_wenli_C.rgb*_wenli_var.rgb)+_Color.rgb)*_Opacity_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
