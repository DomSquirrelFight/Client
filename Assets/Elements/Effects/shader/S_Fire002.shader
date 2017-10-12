// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32998,y:32665,varname:node_4795,prsc:2|emission-6148-OUT;n:type:ShaderForge.SFN_Tex2d,id:6222,x:31997,y:32581,ptovrint:False,ptlb:node_6222,ptin:_node_6222,varname:node_6222,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5ce2971b23a6c4a4a85ee2ed53cd3531,ntxv:0,isnm:False|UVIN-5952-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9074,x:31888,y:32794,ptovrint:False,ptlb:node_9074,ptin:_node_9074,varname:node_9074,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cc9148460717d5a4ab78b463f9bd5488,ntxv:0,isnm:False|UVIN-519-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5952,x:31699,y:32568,varname:node_5952,prsc:2|UVIN-4200-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4200,x:31384,y:32588,varname:node_4200,prsc:2,uv:0;n:type:ShaderForge.SFN_Rotator,id:519,x:31655,y:32794,varname:node_519,prsc:2|UVIN-4200-UVOUT,SPD-5503-OUT;n:type:ShaderForge.SFN_Vector1,id:5503,x:31482,y:32904,varname:node_5503,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:9428,x:32212,y:32795,varname:node_9428,prsc:2|A-6222-R,B-9074-R;n:type:ShaderForge.SFN_Add,id:2090,x:32417,y:32764,varname:node_2090,prsc:2|A-4200-UVOUT,B-9428-OUT;n:type:ShaderForge.SFN_VertexColor,id:7167,x:32579,y:32994,varname:node_7167,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:4193,x:32579,y:32764,ptovrint:False,ptlb:node_4193,ptin:_node_4193,varname:node_4193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2952f90643783b0459d12324a876407c,ntxv:0,isnm:False|UVIN-2090-OUT;n:type:ShaderForge.SFN_Tex2d,id:6442,x:32579,y:32589,ptovrint:False,ptlb:zhezhao,ptin:_zhezhao,varname:node_6442,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:50a3f02278c69494eb81bb309cd43bfc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6148,x:32811,y:32764,varname:node_6148,prsc:2|A-6442-RGB,B-4193-RGB,C-8604-OUT,D-7167-RGB;n:type:ShaderForge.SFN_ValueProperty,id:8604,x:32579,y:32939,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_8604,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;proporder:6222-9074-4193-6442-8604;pass:END;sub:END;*/

Shader "Particles/S_Fire002" {
    Properties {
        _node_6222 ("node_6222", 2D) = "white" {}
        _node_9074 ("node_9074", 2D) = "white" {}
        _node_4193 ("node_4193", 2D) = "white" {}
        _zhezhao ("zhezhao", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 3
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
            uniform sampler2D _node_6222; uniform float4 _node_6222_ST;
            uniform sampler2D _node_9074; uniform float4 _node_9074_ST;
            uniform sampler2D _node_4193; uniform float4 _node_4193_ST;
            uniform sampler2D _zhezhao; uniform float4 _zhezhao_ST;
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
                float4 _zhezhao_var = tex2D(_zhezhao,TRANSFORM_TEX(i.uv0, _zhezhao));
                float4 node_9206 = _Time + _TimeEditor;
                float node_5952_ang = node_9206.g;
                float node_5952_spd = 1.0;
                float node_5952_cos = cos(node_5952_spd*node_5952_ang);
                float node_5952_sin = sin(node_5952_spd*node_5952_ang);
                float2 node_5952_piv = float2(0.5,0.5);
                float2 node_5952 = (mul(i.uv0-node_5952_piv,float2x2( node_5952_cos, -node_5952_sin, node_5952_sin, node_5952_cos))+node_5952_piv);
                float4 _node_6222_var = tex2D(_node_6222,TRANSFORM_TEX(node_5952, _node_6222));
                float node_519_ang = node_9206.g;
                float node_519_spd = (-1.0);
                float node_519_cos = cos(node_519_spd*node_519_ang);
                float node_519_sin = sin(node_519_spd*node_519_ang);
                float2 node_519_piv = float2(0.5,0.5);
                float2 node_519 = (mul(i.uv0-node_519_piv,float2x2( node_519_cos, -node_519_sin, node_519_sin, node_519_cos))+node_519_piv);
                float4 _node_9074_var = tex2D(_node_9074,TRANSFORM_TEX(node_519, _node_9074));
                float2 node_2090 = (i.uv0+(_node_6222_var.r+_node_9074_var.r));
                float4 _node_4193_var = tex2D(_node_4193,TRANSFORM_TEX(node_2090, _node_4193));
                float3 emissive = (_zhezhao_var.rgb*_node_4193_var.rgb*_qiangdu*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
