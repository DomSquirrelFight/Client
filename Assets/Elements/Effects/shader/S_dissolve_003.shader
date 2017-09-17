// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33935,y:32545,varname:node_4013,prsc:2|emission-1510-OUT;n:type:ShaderForge.SFN_Tex2d,id:7038,x:33107,y:33060,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5598d59be0a8ed74693e5b3a3f77453e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8094,x:32196,y:32577,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-2790-UVOUT;n:type:ShaderForge.SFN_Panner,id:2790,x:32023,y:32577,varname:node_2790,prsc:2,spu:0,spv:0.2|UVIN-4878-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4878,x:31724,y:32482,varname:node_4878,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:4068,x:32417,y:32618,varname:node_4068,prsc:2|A-8094-R,B-6226-OUT;n:type:ShaderForge.SFN_Vector1,id:6226,x:32184,y:32770,varname:node_6226,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Add,id:3969,x:32569,y:32525,varname:node_3969,prsc:2|A-4878-UVOUT,B-4068-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7234,x:33243,y:32912,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:5661,x:33429,y:32707,varname:node_5661,prsc:2|A-9615-OUT,B-9615-OUT,C-7234-OUT;n:type:ShaderForge.SFN_Multiply,id:9615,x:33226,y:32678,varname:node_9615,prsc:2|A-2914-R,B-9743-OUT;n:type:ShaderForge.SFN_Panner,id:888,x:32766,y:32586,varname:node_888,prsc:2,spu:0,spv:-0.3|UVIN-3969-OUT;n:type:ShaderForge.SFN_VertexColor,id:3517,x:33414,y:32457,varname:node_3517,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1510,x:33681,y:32651,varname:node_1510,prsc:2|A-3517-RGB,B-3517-A,C-5661-OUT,D-4644-OUT;n:type:ShaderForge.SFN_Power,id:4644,x:33489,y:32935,varname:node_4644,prsc:2|VAL-7038-RGB,EXP-8971-OUT;n:type:ShaderForge.SFN_Tex2d,id:2914,x:33042,y:32449,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:node_2914,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1acace4de3be7c54fbcb8a03d71d7473,ntxv:0,isnm:False|UVIN-888-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9743,x:33010,y:32803,varname:node_9743,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8971,x:33310,y:33214,ptovrint:False,ptlb:duibudu,ptin:_duibudu,varname:node_8971,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Tex2d,id:3733,x:32404,y:32531,ptovrint:False,ptlb:node_5122_copy,ptin:_node_5122_copy,varname:_node_5122_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:970a620b895468a458d879fb1b047a63,ntxv:0,isnm:False;proporder:7038-8094-7234-2914-8971;pass:END;sub:END;*/

Shader "Particles/S_dissolve_003" {
    Properties {
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _niuqu ("niuqu", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 3
        _wenli02 ("wenli02", 2D) = "white" {}
        _duibudu ("duibudu", Float ) = 8
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
            uniform float _qiangdu;
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform float _duibudu;
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
                float4 node_5885 = _Time + _TimeEditor;
                float2 node_2790 = (i.uv0+node_5885.g*float2(0,0.2));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_2790, _niuqu));
                float2 node_888 = ((i.uv0+(_niuqu_var.r*0.3))+node_5885.g*float2(0,-0.3));
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_888, _wenli02));
                float node_9615 = (_wenli02_var.r*1.0);
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (i.vertexColor.rgb*i.vertexColor.a*(node_9615*node_9615*_qiangdu)*pow(_Xiaosang_var.rgb,_duibudu));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
