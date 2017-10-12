// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32962,y:32749,varname:node_4013,prsc:2|emission-912-OUT,alpha-6221-OUT;n:type:ShaderForge.SFN_Tex2d,id:2945,x:32053,y:33041,ptovrint:False,ptlb:M_Tex70076,ptin:_M_Tex70076,varname:node_2945,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86086469e17f5ea41b843636b407fa31,ntxv:0,isnm:False|UVIN-7355-UVOUT;n:type:ShaderForge.SFN_Panner,id:7355,x:31866,y:33069,varname:node_7355,prsc:2,spu:0,spv:-0.5|UVIN-6658-UVOUT,DIST-5411-OUT;n:type:ShaderForge.SFN_TexCoord,id:6658,x:31688,y:33069,varname:node_6658,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:6434,x:32000,y:32837,ptovrint:False,ptlb:Tex1,ptin:_Tex1,varname:node_6434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3234b58e362b8e64d97af136d7f3ca9c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5411,x:31531,y:33295,ptovrint:False,ptlb:grow,ptin:_grow,varname:node_5411,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5470085,max:4;n:type:ShaderForge.SFN_Tex2d,id:2897,x:32053,y:33253,ptovrint:False,ptlb:Tex2,ptin:_Tex2,varname:node_2897,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dc6623120c4a2fa448d9a0358ce8abdd,ntxv:2,isnm:False|UVIN-7355-UVOUT;n:type:ShaderForge.SFN_Add,id:912,x:32684,y:32850,varname:node_912,prsc:2|A-3841-OUT,B-2897-R;n:type:ShaderForge.SFN_VertexColor,id:1827,x:32129,y:32653,varname:node_1827,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3841,x:32456,y:32754,varname:node_3841,prsc:2|A-1827-RGB,B-6434-RGB;n:type:ShaderForge.SFN_Multiply,id:6221,x:32684,y:33008,varname:node_6221,prsc:2|A-1827-A,B-2945-R;n:type:ShaderForge.SFN_Add,id:6841,x:32409,y:33026,varname:node_6841,prsc:2|A-2945-R,B-2897-R;proporder:2945-6434-5411-2897;pass:END;sub:END;*/

Shader "Shader Forge/S_plant001" {
    Properties {
        _M_Tex70076 ("M_Tex70076", 2D) = "white" {}
        _Tex1 ("Tex1", 2D) = "white" {}
        _grow ("grow", Range(0, 4)) = 0.5470085
        _Tex2 ("Tex2", 2D) = "black" {}
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
            uniform sampler2D _M_Tex70076; uniform float4 _M_Tex70076_ST;
            uniform sampler2D _Tex1; uniform float4 _Tex1_ST;
            uniform float _grow;
            uniform sampler2D _Tex2; uniform float4 _Tex2_ST;
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
                float4 _Tex1_var = tex2D(_Tex1,TRANSFORM_TEX(i.uv0, _Tex1));
                float2 node_7355 = (i.uv0+_grow*float2(0,-0.5));
                float4 _Tex2_var = tex2D(_Tex2,TRANSFORM_TEX(node_7355, _Tex2));
                float3 emissive = ((i.vertexColor.rgb*_Tex1_var.rgb)+_Tex2_var.r);
                float3 finalColor = emissive;
                float4 _M_Tex70076_var = tex2D(_M_Tex70076,TRANSFORM_TEX(node_7355, _M_Tex70076));
                return fixed4(finalColor,(i.vertexColor.a*_M_Tex70076_var.r));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
