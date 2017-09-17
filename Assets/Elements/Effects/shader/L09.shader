// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.08088237,fgcg:0.003568338,fgcb:0.003568338,fgca:1,fgde:1,fgrn:15,fgrf:60,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:34239,y:32712,varname:node_1,prsc:2|emission-58-OUT;n:type:ShaderForge.SFN_Multiply,id:3,x:33834,y:32657,varname:node_3,prsc:2|A-57-RGB,B-68-RGB,C-68-A;n:type:ShaderForge.SFN_Multiply,id:4,x:33732,y:33004,varname:node_4,prsc:2|A-2573-RGB,B-6-OUT,C-2573-A;n:type:ShaderForge.SFN_Multiply,id:6,x:33498,y:33062,varname:node_6,prsc:2|A-13-OUT,B-10-RGB;n:type:ShaderForge.SFN_Tex2d,id:10,x:33294,y:33093,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:node_9066,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4a3c3617b7546364883543f803b6ecaf,ntxv:0,isnm:False|UVIN-42-UVOUT;n:type:ShaderForge.SFN_Vector1,id:13,x:33363,y:32959,varname:node_13,prsc:2,v1:4;n:type:ShaderForge.SFN_Rotator,id:42,x:33073,y:32882,varname:node_42,prsc:2|UVIN-45-UVOUT,SPD-44-OUT;n:type:ShaderForge.SFN_ValueProperty,id:44,x:32846,y:32976,ptovrint:False,ptlb:W2R,ptin:_W2R,varname:node_8148,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:45,x:32846,y:32781,varname:node_45,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:57,x:33633,y:32377,ptovrint:False,ptlb:node_57,ptin:_node_57,varname:node_2502,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1acace4de3be7c54fbcb8a03d71d7473,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:58,x:34067,y:32697,varname:node_58,prsc:2|A-3-OUT,B-4-OUT;n:type:ShaderForge.SFN_Color,id:68,x:33460,y:32532,ptovrint:False,ptlb:node_68,ptin:_node_68,varname:node_3478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:2573,x:33540,y:33241,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2573,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:10-44-57-68-2573;pass:END;sub:END;*/

Shader "Particles/L09" {
    Properties {
        _wenli02 ("wenli02", 2D) = "white" {}
        _W2R ("W2R", Float ) = 0
        _node_57 ("node_57", 2D) = "white" {}
        _node_68 ("node_68", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _node_57; uniform float4 _node_57_ST;
            uniform float4 _node_68;
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
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_57_var = tex2D(_node_57,TRANSFORM_TEX(i.uv0, _node_57));
                float4 node_4383 = _Time + _TimeEditor;
                float node_42_ang = node_4383.g;
                float node_42_spd = _W2R;
                float node_42_cos = cos(node_42_spd*node_42_ang);
                float node_42_sin = sin(node_42_spd*node_42_ang);
                float2 node_42_piv = float2(0.5,0.5);
                float2 node_42 = (mul(i.uv0-node_42_piv,float2x2( node_42_cos, -node_42_sin, node_42_sin, node_42_cos))+node_42_piv);
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_42, _wenli02));
                float3 emissive = ((_node_57_var.rgb*_node_68.rgb*_node_68.a)+(_Color.rgb*(4.0*_wenli02_var.rgb)*_Color.a));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
