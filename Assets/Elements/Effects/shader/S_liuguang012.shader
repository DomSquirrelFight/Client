// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33294,y:32656,varname:node_4795,prsc:2|emission-7584-OUT;n:type:ShaderForge.SFN_Tex2d,id:9032,x:32908,y:32830,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aef2d72c5a7c0374ab5d4e3e7dfea779,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1891,x:31343,y:32569,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-9232-UVOUT;n:type:ShaderForge.SFN_Panner,id:9232,x:31154,y:32515,varname:node_9232,prsc:2,spu:0.1,spv:0.1|UVIN-2815-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2815,x:30984,y:32343,varname:node_2815,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3741,x:31555,y:32646,varname:node_3741,prsc:2|A-1891-R,B-2025-OUT;n:type:ShaderForge.SFN_Vector1,id:2025,x:31409,y:32785,varname:node_2025,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:841,x:31714,y:32756,varname:node_841,prsc:2|A-2815-UVOUT,B-3741-OUT;n:type:ShaderForge.SFN_Tex2d,id:1125,x:32152,y:32756,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ddeb6b06c9b916c4fb6a9a35680cccb3,ntxv:0,isnm:False|UVIN-1655-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:4905,x:32585,y:32890,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Power,id:4967,x:32553,y:32689,varname:node_4967,prsc:2|VAL-1125-R,EXP-850-OUT;n:type:ShaderForge.SFN_Vector1,id:850,x:32347,y:32830,varname:node_850,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Panner,id:1655,x:31922,y:32756,varname:node_1655,prsc:2,spu:-0.3,spv:0|UVIN-841-OUT;n:type:ShaderForge.SFN_VertexColor,id:9981,x:32824,y:32561,varname:node_9981,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7584,x:33081,y:32689,varname:node_7584,prsc:2|A-9981-RGB,B-4967-OUT,C-9032-RGB,D-4905-OUT,E-9981-A;proporder:1891-1125-9032-4905;pass:END;sub:END;*/

Shader "Particles/S_liuguang012" {
    Properties {
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 2
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Xiaosang; uniform float4 _Xiaosang_ST;
            uniform sampler2D _niuqu; uniform float4 _niuqu_ST;
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform float _qiangdu;
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
                float4 node_148 = _Time + _TimeEditor;
                float2 node_9232 = (i.uv0+node_148.g*float2(0.1,0.1));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_9232, _niuqu));
                float2 node_1655 = ((i.uv0+(_niuqu_var.r*0.2))+node_148.g*float2(-0.3,0));
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_1655, _wenli02));
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (i.vertexColor.rgb*pow(_wenli02_var.r,1.5)*_Xiaosang_var.rgb*_qiangdu*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
