// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.08088237,fgcg:0.003568338,fgcb:0.003568338,fgca:1,fgde:1,fgrn:15,fgrf:60,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:35370,y:32975,varname:node_1,prsc:2|emission-268-OUT;n:type:ShaderForge.SFN_Multiply,id:3,x:34361,y:32680,varname:node_3,prsc:2|A-57-RGB,B-92-RGB;n:type:ShaderForge.SFN_Multiply,id:4,x:34493,y:32972,varname:node_4,prsc:2|A-92-A,B-6-OUT;n:type:ShaderForge.SFN_Multiply,id:6,x:34322,y:33009,varname:node_6,prsc:2|A-13-OUT,B-10-RGB;n:type:ShaderForge.SFN_Tex2d,id:10,x:34128,y:32979,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:node_9131,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4a3c3617b7546364883543f803b6ecaf,ntxv:0,isnm:False|UVIN-42-UVOUT;n:type:ShaderForge.SFN_Vector1,id:13,x:34128,y:32850,varname:node_13,prsc:2,v1:4;n:type:ShaderForge.SFN_Rotator,id:42,x:33957,y:32884,varname:node_42,prsc:2|UVIN-45-UVOUT,SPD-44-OUT;n:type:ShaderForge.SFN_ValueProperty,id:44,x:33737,y:32964,ptovrint:False,ptlb:W2R,ptin:_W2R,varname:node_6267,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:45,x:33729,y:32772,varname:node_45,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:57,x:34128,y:32421,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_15,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1acace4de3be7c54fbcb8a03d71d7473,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:58,x:34661,y:32949,varname:node_58,prsc:2|A-3-OUT,B-4-OUT;n:type:ShaderForge.SFN_If,id:68,x:33966,y:33141,varname:node_68,prsc:2|A-75-OUT,B-71-OUT,GT-73-OUT,EQ-73-OUT,LT-72-OUT;n:type:ShaderForge.SFN_Clamp01,id:71,x:33737,y:33046,varname:node_71,prsc:2|IN-74-OUT;n:type:ShaderForge.SFN_Vector1,id:72,x:33737,y:33297,varname:node_72,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:73,x:33727,y:33204,varname:node_73,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:74,x:33490,y:33006,varname:node_74,prsc:2|A-78-RGB,B-280-OUT;n:type:ShaderForge.SFN_Add,id:75,x:33387,y:32801,varname:node_75,prsc:2|A-77-OUT,B-76-OUT;n:type:ShaderForge.SFN_Multiply,id:76,x:33216,y:32878,varname:node_76,prsc:2|A-77-OUT,B-79-OUT;n:type:ShaderForge.SFN_Vector1,id:77,x:33111,y:32754,varname:node_77,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:78,x:33290,y:33070,ptovrint:False,ptlb:wenli03,ptin:_wenli03,varname:node_5543,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:79,x:33043,y:32998,ptovrint:False,ptlb:san,ptin:_san,varname:node_1586,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.5;n:type:ShaderForge.SFN_Multiply,id:81,x:34844,y:33003,varname:node_81,prsc:2|A-58-OUT,B-68-OUT;n:type:ShaderForge.SFN_Color,id:92,x:34128,y:32630,ptovrint:False,ptlb:color,ptin:_color,varname:node_3134,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_If,id:103,x:33966,y:33362,varname:node_103,prsc:2|A-75-OUT,B-105-OUT,GT-73-OUT,EQ-73-OUT,LT-72-OUT;n:type:ShaderForge.SFN_Clamp01,id:105,x:33737,y:33431,varname:node_105,prsc:2|IN-106-OUT;n:type:ShaderForge.SFN_Multiply,id:106,x:33523,y:33395,varname:node_106,prsc:2|A-78-RGB,B-107-OUT;n:type:ShaderForge.SFN_Vector1,id:107,x:33313,y:33420,varname:node_107,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:111,x:35055,y:33122,varname:node_111,prsc:2|A-81-OUT,B-216-OUT;n:type:ShaderForge.SFN_Subtract,id:195,x:34128,y:33242,varname:node_195,prsc:2|A-68-OUT,B-103-OUT;n:type:ShaderForge.SFN_Multiply,id:216,x:34466,y:33349,varname:node_216,prsc:2|A-195-OUT,B-242-OUT;n:type:ShaderForge.SFN_Vector1,id:242,x:34172,y:33552,varname:node_242,prsc:2,v1:200;n:type:ShaderForge.SFN_Multiply,id:268,x:35088,y:33347,varname:node_268,prsc:2|A-111-OUT,B-269-OUT;n:type:ShaderForge.SFN_ValueProperty,id:269,x:34880,y:33444,ptovrint:False,ptlb:qiang,ptin:_qiang,varname:node_4374,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:280,x:33336,y:33567,ptovrint:False,ptlb:bian,ptin:_bian,varname:node_7536,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:57-10-78-44-79-92-269-280;pass:END;sub:END;*/

Shader "Particles/L08" {
    Properties {
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _wenli03 ("wenli03", 2D) = "white" {}
        _W2R ("W2R", Float ) = 0
        _san ("san", Float ) = -0.5
        _color ("color", Color) = (0.5,0.5,0.5,1)
        _qiang ("qiang", Float ) = 1
        _bian ("bian", Float ) = 1
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
            Blend One OneMinusSrcColor
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
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform float _W2R;
            uniform sampler2D _wenli01; uniform float4 _wenli01_ST;
            uniform sampler2D _wenli03; uniform float4 _wenli03_ST;
            uniform float _san;
            uniform float4 _color;
            uniform float _qiang;
            uniform float _bian;
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
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(i.uv0, _wenli01));
                float4 node_1105 = _Time + _TimeEditor;
                float node_42_ang = node_1105.g;
                float node_42_spd = _W2R;
                float node_42_cos = cos(node_42_spd*node_42_ang);
                float node_42_sin = sin(node_42_spd*node_42_ang);
                float2 node_42_piv = float2(0.5,0.5);
                float2 node_42 = (mul(i.uv0-node_42_piv,float2x2( node_42_cos, -node_42_sin, node_42_sin, node_42_cos))+node_42_piv);
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_42, _wenli02));
                float node_77 = 0.5;
                float node_75 = (node_77+(node_77*_san));
                float4 _wenli03_var = tex2D(_wenli03,TRANSFORM_TEX(i.uv0, _wenli03));
                float node_68_if_leA = step(node_75,saturate((_wenli03_var.rgb*_bian)));
                float node_68_if_leB = step(saturate((_wenli03_var.rgb*_bian)),node_75);
                float node_72 = 0.0;
                float node_73 = 1.0;
                float3 node_68 = lerp((node_68_if_leA*node_72)+(node_68_if_leB*node_73),node_73,node_68_if_leA*node_68_if_leB);
                float node_103_if_leA = step(node_75,saturate((_wenli03_var.rgb*1.0)));
                float node_103_if_leB = step(saturate((_wenli03_var.rgb*1.0)),node_75);
                float3 emissive = (((((_wenli01_var.rgb*_color.rgb)+(_color.a*(4.0*_wenli02_var.rgb)))*node_68)+((node_68-lerp((node_103_if_leA*node_72)+(node_103_if_leB*node_73),node_73,node_103_if_leA*node_103_if_leB))*200.0))*_qiang);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
