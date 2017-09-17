// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33186,y:33138,varname:node_4795,prsc:2|emission-8863-OUT;n:type:ShaderForge.SFN_Tex2d,id:8001,x:31932,y:33134,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f4a8775589bf1db449415e82d7d731f1,ntxv:0,isnm:False|UVIN-2424-UVOUT;n:type:ShaderForge.SFN_Panner,id:2424,x:31702,y:33123,varname:node_2424,prsc:2,spu:0.3,spv:0.2|UVIN-7802-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7802,x:31508,y:33123,varname:node_7802,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:2518,x:32180,y:33119,varname:node_2518,prsc:2|A-8001-R,B-1018-OUT;n:type:ShaderForge.SFN_Vector1,id:1018,x:31890,y:33402,varname:node_1018,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Add,id:9954,x:32403,y:33119,varname:node_9954,prsc:2|A-7802-UVOUT,B-2518-OUT;n:type:ShaderForge.SFN_Tex2d,id:7856,x:32633,y:33138,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:05e2b01a0fb59f9438938b026fb96718,ntxv:0,isnm:False|UVIN-9954-OUT;n:type:ShaderForge.SFN_Add,id:6719,x:32180,y:33333,varname:node_6719,prsc:2|A-2518-OUT,B-7802-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5076,x:32403,y:33316,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4f6959e093ca99b4c98a4dde76477bda,ntxv:0,isnm:False|UVIN-6719-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9997,x:32815,y:33551,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:6729,x:32815,y:33333,varname:node_6729,prsc:2|A-7856-RGB,B-3680-OUT,C-9997-OUT;n:type:ShaderForge.SFN_Power,id:3680,x:32633,y:33333,varname:node_3680,prsc:2|VAL-5076-R,EXP-9899-OUT;n:type:ShaderForge.SFN_Vector1,id:9899,x:32633,y:33551,varname:node_9899,prsc:2,v1:2;n:type:ShaderForge.SFN_VertexColor,id:1124,x:32815,y:33138,varname:node_1124,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8863,x:32987,y:33236,varname:node_8863,prsc:2|A-1124-RGB,B-6729-OUT;proporder:8001-7856-5076-9997;pass:END;sub:END;*/

Shader "Particles/S_Huo" {
    Properties {
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
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
            uniform sampler2D _niuqu; uniform float4 _niuqu_ST;
            uniform sampler2D _wenli01; uniform float4 _wenli01_ST;
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
                float4 node_4464 = _Time + _TimeEditor;
                float2 node_2424 = (i.uv0+node_4464.g*float2(0.3,0.2));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_2424, _niuqu));
                float node_2518 = (_niuqu_var.r*0.25);
                float2 node_9954 = (i.uv0+node_2518);
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_9954, _wenli01));
                float2 node_6719 = (node_2518+i.uv0);
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_6719, _wenli02));
                float3 emissive = (i.vertexColor.rgb*(_wenli01_var.rgb*pow(_wenli02_var.r,2.0)*_qiangdu));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
