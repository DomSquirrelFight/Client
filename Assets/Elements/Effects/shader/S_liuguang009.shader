// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-4442-OUT;n:type:ShaderForge.SFN_Tex2d,id:917,x:32464,y:33064,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aef2d72c5a7c0374ab5d4e3e7dfea779,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4225,x:31102,y:32640,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-6712-UVOUT;n:type:ShaderForge.SFN_Panner,id:6712,x:30851,y:32982,varname:node_6712,prsc:2,spu:0.2,spv:0.2|UVIN-1276-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1276,x:30557,y:32504,varname:node_1276,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1179,x:31353,y:32705,varname:node_1179,prsc:2|A-4225-R,B-9358-OUT;n:type:ShaderForge.SFN_Vector1,id:9358,x:31114,y:32893,varname:node_9358,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:9856,x:31353,y:32489,varname:node_9856,prsc:2|A-1276-UVOUT,B-1179-OUT;n:type:ShaderForge.SFN_Tex2d,id:3775,x:31792,y:32598,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2bb830885e4d9d54c90aacab4eaafa42,ntxv:0,isnm:False|UVIN-2173-UVOUT;n:type:ShaderForge.SFN_Rotator,id:2173,x:31617,y:32484,varname:node_2173,prsc:2|UVIN-9856-OUT,SPD-1081-OUT;n:type:ShaderForge.SFN_Vector1,id:1081,x:31592,y:32705,varname:node_1081,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:635,x:31351,y:33020,varname:node_635,prsc:2|A-1276-UVOUT,B-1179-OUT;n:type:ShaderForge.SFN_Tex2d,id:7805,x:31598,y:32970,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9a40b3d7946254a4b97c2ca7c5cfeac0,ntxv:0,isnm:False|UVIN-635-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7897,x:31944,y:32927,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector3,id:6324,x:31817,y:32484,varname:node_6324,prsc:2,v1:5,v2:4,v3:1;n:type:ShaderForge.SFN_Multiply,id:8783,x:31944,y:32647,varname:node_8783,prsc:2|A-6324-OUT,B-3775-R;n:type:ShaderForge.SFN_Multiply,id:1538,x:32180,y:32630,varname:node_1538,prsc:2|A-8783-OUT,B-9097-OUT,C-7897-OUT;n:type:ShaderForge.SFN_Multiply,id:4114,x:31782,y:32784,varname:node_4114,prsc:2|A-3192-OUT,B-7805-R;n:type:ShaderForge.SFN_Vector3,id:3192,x:31617,y:32753,varname:node_3192,prsc:2,v1:1,v2:0.5,v3:0.5;n:type:ShaderForge.SFN_Power,id:9097,x:31965,y:32772,varname:node_9097,prsc:2|VAL-4114-OUT,EXP-1345-OUT;n:type:ShaderForge.SFN_Vector1,id:1345,x:31793,y:33077,varname:node_1345,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Add,id:997,x:32228,y:32827,varname:node_997,prsc:2|A-1538-OUT,B-1124-OUT;n:type:ShaderForge.SFN_Tex2d,id:9559,x:32007,y:33026,ptovrint:False,ptlb:node_6958,ptin:_node_6958,varname:node_6958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:880ba9b32ea617c43ba3a36af392bd3f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7802,x:32365,y:32630,varname:node_7802,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4442,x:32390,y:32793,varname:node_4442,prsc:2|A-7802-RGB,B-997-OUT,C-917-RGB;n:type:ShaderForge.SFN_Vector1,id:4733,x:31839,y:33172,varname:node_4733,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:1124,x:32271,y:33156,varname:node_1124,prsc:2|A-9559-RGB,B-4733-OUT,C-92-OUT;n:type:ShaderForge.SFN_Vector3,id:92,x:32059,y:33273,varname:node_92,prsc:2,v1:2,v2:1.5,v3:1;proporder:917-4225-3775-7805-7897-9559;pass:END;sub:END;*/

Shader "Particles/S_liuguang009" {
    Properties {
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 1
        _node_6958 ("node_6958", 2D) = "white" {}
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
            uniform sampler2D _Xiaosang; uniform float4 _Xiaosang_ST;
            uniform sampler2D _niuqu; uniform float4 _niuqu_ST;
            uniform sampler2D _wenli01; uniform float4 _wenli01_ST;
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform float _qiangdu;
            uniform sampler2D _node_6958; uniform float4 _node_6958_ST;
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
                float4 node_2894 = _Time + _TimeEditor;
                float node_2173_ang = node_2894.g;
                float node_2173_spd = 0.1;
                float node_2173_cos = cos(node_2173_spd*node_2173_ang);
                float node_2173_sin = sin(node_2173_spd*node_2173_ang);
                float2 node_2173_piv = float2(0.5,0.5);
                float2 node_6712 = (i.uv0+node_2894.g*float2(0.2,0.2));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_6712, _niuqu));
                float node_1179 = (_niuqu_var.r*0.2);
                float2 node_2173 = (mul((i.uv0+node_1179)-node_2173_piv,float2x2( node_2173_cos, -node_2173_sin, node_2173_sin, node_2173_cos))+node_2173_piv);
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_2173, _wenli01));
                float2 node_635 = (i.uv0+node_1179);
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_635, _wenli02));
                float4 _node_6958_var = tex2D(_node_6958,TRANSFORM_TEX(i.uv0, _node_6958));
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (i.vertexColor.rgb*(((float3(5,4,1)*_wenli01_var.r)*pow((float3(1,0.5,0.5)*_wenli02_var.r),1.5)*_qiangdu)+(_node_6958_var.rgb*0.3*float3(2,1.5,1)))*_Xiaosang_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
