// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33294,y:32656,varname:node_4795,prsc:2|emission-7584-OUT;n:type:ShaderForge.SFN_Tex2d,id:9032,x:32908,y:32830,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aef2d72c5a7c0374ab5d4e3e7dfea779,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1891,x:31385,y:32578,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-9232-UVOUT;n:type:ShaderForge.SFN_Panner,id:9232,x:31216,y:32578,varname:node_9232,prsc:2,spu:0.1,spv:0.1|UVIN-2815-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2815,x:31045,y:32348,varname:node_2815,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3741,x:31555,y:32646,varname:node_3741,prsc:2|A-1891-R,B-2025-OUT;n:type:ShaderForge.SFN_Vector1,id:2025,x:31385,y:32743,varname:node_2025,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:556,x:31998,y:32533,varname:node_556,prsc:2|A-2815-UVOUT,B-3741-OUT;n:type:ShaderForge.SFN_Tex2d,id:195,x:32347,y:32533,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e4b32f0ac092a0041b2ea003a4dddbbe,ntxv:0,isnm:False|UVIN-410-UVOUT;n:type:ShaderForge.SFN_Rotator,id:410,x:32152,y:32533,varname:node_410,prsc:2|UVIN-556-OUT,SPD-6431-OUT;n:type:ShaderForge.SFN_Vector1,id:6431,x:31998,y:32663,varname:node_6431,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:841,x:31714,y:32756,varname:node_841,prsc:2|A-2815-UVOUT,B-3741-OUT;n:type:ShaderForge.SFN_Tex2d,id:1125,x:32152,y:32756,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ddeb6b06c9b916c4fb6a9a35680cccb3,ntxv:0,isnm:False|UVIN-1655-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:4905,x:32553,y:32830,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:1476,x:32553,y:32533,varname:node_1476,prsc:2|A-1730-RGB,B-195-R;n:type:ShaderForge.SFN_Multiply,id:7513,x:32746,y:32645,varname:node_7513,prsc:2|A-1476-OUT,B-4967-OUT,C-4905-OUT;n:type:ShaderForge.SFN_Multiply,id:7661,x:32347,y:32689,varname:node_7661,prsc:2|A-7910-RGB,B-1125-R;n:type:ShaderForge.SFN_Power,id:4967,x:32553,y:32689,varname:node_4967,prsc:2|VAL-7661-OUT,EXP-850-OUT;n:type:ShaderForge.SFN_Vector1,id:850,x:32347,y:32830,varname:node_850,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Panner,id:1655,x:31922,y:32756,varname:node_1655,prsc:2,spu:0.3,spv:0|UVIN-841-OUT;n:type:ShaderForge.SFN_Add,id:5459,x:32908,y:32689,varname:node_5459,prsc:2|A-7513-OUT,B-2171-OUT;n:type:ShaderForge.SFN_Tex2d,id:6958,x:32692,y:32885,ptovrint:False,ptlb:node_6958,ptin:_node_6958,varname:node_6958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0437060f55cfd7e4eab1b91fefdfc501,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:9981,x:32908,y:32561,varname:node_9981,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7584,x:33081,y:32689,varname:node_7584,prsc:2|A-9981-RGB,B-5459-OUT,C-9032-RGB;n:type:ShaderForge.SFN_Vector1,id:2663,x:32530,y:33068,varname:node_2663,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:2171,x:32884,y:32993,varname:node_2171,prsc:2|A-6958-RGB,B-2663-OUT,C-7910-RGB;n:type:ShaderForge.SFN_Color,id:1730,x:32316,y:32308,ptovrint:False,ptlb:color01,ptin:_color01,varname:node_1730,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:5,c2:4,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:7910,x:32031,y:33070,ptovrint:False,ptlb:color02,ptin:_color02,varname:_color02,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:2,c2:1.5,c3:1,c4:1;proporder:1891-195-1125-9032-4905-6958-1730-7910;pass:END;sub:END;*/

Shader "Particles/S_liuguang003" {
    Properties {
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 2
        _node_6958 ("node_6958", 2D) = "white" {}
        _color01 ("color01", Color) = (5,4,1,1)
        _color02 ("color02", Color) = (2,1.5,1,1)
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
            uniform float4 _color01;
            uniform float4 _color02;
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
                float4 node_1297 = _Time + _TimeEditor;
                float node_410_ang = node_1297.g;
                float node_410_spd = 0.5;
                float node_410_cos = cos(node_410_spd*node_410_ang);
                float node_410_sin = sin(node_410_spd*node_410_ang);
                float2 node_410_piv = float2(0.5,0.5);
                float2 node_9232 = (i.uv0+node_1297.g*float2(0.1,0.1));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_9232, _niuqu));
                float node_3741 = (_niuqu_var.r*0.2);
                float2 node_410 = (mul((i.uv0+node_3741)-node_410_piv,float2x2( node_410_cos, -node_410_sin, node_410_sin, node_410_cos))+node_410_piv);
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_410, _wenli01));
                float2 node_1655 = ((i.uv0+node_3741)+node_1297.g*float2(0.3,0));
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_1655, _wenli02));
                float4 _node_6958_var = tex2D(_node_6958,TRANSFORM_TEX(i.uv0, _node_6958));
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (i.vertexColor.rgb*(((_color01.rgb*_wenli01_var.r)*pow((_color02.rgb*_wenli02_var.r),1.5)*_qiangdu)+(_node_6958_var.rgb*0.3*_color02.rgb))*_Xiaosang_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
