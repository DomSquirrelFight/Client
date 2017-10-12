// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33312,y:32616,varname:node_4795,prsc:2|emission-8462-OUT;n:type:ShaderForge.SFN_Tex2d,id:9032,x:31956,y:33108,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f4a8775589bf1db449415e82d7d731f1,ntxv:0,isnm:False|UVIN-7343-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7343,x:31741,y:33108,varname:node_7343,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:1891,x:31172,y:32610,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9232-UVOUT;n:type:ShaderForge.SFN_Panner,id:9232,x:30998,y:32598,varname:node_9232,prsc:2,spu:0.1,spv:0.1|UVIN-2815-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2815,x:30791,y:32583,varname:node_2815,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:1431,x:30998,y:32425,varname:node_1431,prsc:2,v1:-10,v2:0;n:type:ShaderForge.SFN_Multiply,id:1186,x:31395,y:32627,varname:node_1186,prsc:2|A-1431-OUT,B-1891-R;n:type:ShaderForge.SFN_Multiply,id:3741,x:31617,y:32678,varname:node_3741,prsc:2|A-1186-OUT,B-2025-OUT;n:type:ShaderForge.SFN_Vector1,id:2025,x:31205,y:32823,varname:node_2025,prsc:2,v1:0.011;n:type:ShaderForge.SFN_Add,id:556,x:31834,y:32499,varname:node_556,prsc:2|A-7114-UVOUT,B-3741-OUT;n:type:ShaderForge.SFN_TexCoord,id:7114,x:31617,y:32499,varname:node_7114,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:195,x:32228,y:32482,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:61203a7932c42f24d88474db0fa0c735,ntxv:0,isnm:False|UVIN-410-UVOUT;n:type:ShaderForge.SFN_Rotator,id:410,x:32054,y:32499,varname:node_410,prsc:2|UVIN-556-OUT,SPD-6431-OUT;n:type:ShaderForge.SFN_Vector1,id:6431,x:31804,y:32723,varname:node_6431,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3396,x:32506,y:32802,varname:node_3396,prsc:2|A-3329-OUT,B-1125-R;n:type:ShaderForge.SFN_TexCoord,id:2279,x:31601,y:32889,varname:node_2279,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:841,x:31819,y:32899,varname:node_841,prsc:2|A-2279-UVOUT,B-3741-OUT;n:type:ShaderForge.SFN_Tex2d,id:1125,x:32201,y:32909,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3426-UVOUT;n:type:ShaderForge.SFN_Panner,id:3426,x:32008,y:32899,varname:node_3426,prsc:2,spu:0.1,spv:0|UVIN-841-OUT;n:type:ShaderForge.SFN_Multiply,id:3329,x:32344,y:32682,varname:node_3329,prsc:2|A-195-RGB,B-402-RGB;n:type:ShaderForge.SFN_Slider,id:2315,x:31756,y:33319,ptovrint:False,ptlb:x,ptin:_x,varname:node_4894,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:1,max:1;n:type:ShaderForge.SFN_Step,id:7266,x:32532,y:33035,varname:node_7266,prsc:2|A-9032-R,B-2315-OUT;n:type:ShaderForge.SFN_Multiply,id:3502,x:32896,y:32739,varname:node_3502,prsc:2|A-1246-OUT,B-7266-OUT;n:type:ShaderForge.SFN_Multiply,id:1246,x:32686,y:32702,varname:node_1246,prsc:2|A-4905-OUT,B-3396-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4905,x:32432,y:32560,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Color,id:402,x:32082,y:32719,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_402,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8462,x:33111,y:32795,varname:node_8462,prsc:2|A-3502-OUT,B-402-A;n:type:ShaderForge.SFN_VertexColor,id:5833,x:32787,y:32929,varname:node_5833,prsc:2;proporder:1891-195-1125-9032-2315-4905-402;pass:END;sub:END;*/

Shader "Particles/S_liuguang001" {
    Properties {
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _x ("x", Range(-0.1, 1)) = 1
        _qiangdu ("qiangdu", Float ) = 2
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
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
            uniform float _x;
            uniform float _qiangdu;
            uniform float4 _Color;
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
                float4 node_3402 = _Time + _TimeEditor;
                float node_410_ang = node_3402.g;
                float node_410_spd = 0.5;
                float node_410_cos = cos(node_410_spd*node_410_ang);
                float node_410_sin = sin(node_410_spd*node_410_ang);
                float2 node_410_piv = float2(0.5,0.5);
                float2 node_9232 = (i.uv0+node_3402.g*float2(0.1,0.1));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_9232, _niuqu));
                float2 node_3741 = ((float2(-10,0)*_niuqu_var.r)*0.011);
                float2 node_410 = (mul((i.uv0+node_3741)-node_410_piv,float2x2( node_410_cos, -node_410_sin, node_410_sin, node_410_cos))+node_410_piv);
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_410, _wenli01));
                float2 node_3426 = ((i.uv0+node_3741)+node_3402.g*float2(0.1,0));
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_3426, _wenli02));
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (((_qiangdu*((_wenli01_var.rgb*_Color.rgb)*_wenli02_var.r))*step(_Xiaosang_var.r,_x))*_Color.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
