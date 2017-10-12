// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:35854,y:32540,varname:node_4795,prsc:2|emission-240-OUT;n:type:ShaderForge.SFN_Tex2d,id:9135,x:33864,y:32584,ptovrint:False,ptlb:node_9135,ptin:_node_9135,varname:node_9135,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87b1f9cd67cc874c97483c110978c9e,ntxv:0,isnm:False|UVIN-7045-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8891,x:34606,y:32506,ptovrint:False,ptlb:node_8891,ptin:_node_8891,varname:node_8891,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fb4cf24b14f583e49b23af9b37f2d6f7,ntxv:0,isnm:False|UVIN-8999-OUT;n:type:ShaderForge.SFN_Tex2d,id:9237,x:33864,y:32776,ptovrint:False,ptlb:node_9237,ptin:_node_9237,varname:node_9237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:22ea4cbdc9fc6bb4b8ccc4ca4d97315f,ntxv:0,isnm:False|UVIN-9943-UVOUT;n:type:ShaderForge.SFN_Rotator,id:7045,x:33682,y:32584,varname:node_7045,prsc:2|UVIN-2620-UVOUT,SPD-8540-OUT;n:type:ShaderForge.SFN_Vector1,id:8540,x:33455,y:32746,varname:node_8540,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:3012,x:33455,y:32810,varname:node_3012,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Rotator,id:9943,x:33682,y:32776,varname:node_9943,prsc:2|UVIN-2620-UVOUT,SPD-3012-OUT;n:type:ShaderForge.SFN_TexCoord,id:2620,x:33430,y:32444,varname:node_2620,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:1320,x:34073,y:32307,varname:node_1320,prsc:2,spu:1,spv:1|UVIN-2620-UVOUT,DIST-3391-OUT;n:type:ShaderForge.SFN_Vector1,id:3391,x:33880,y:32472,varname:node_3391,prsc:2,v1:-2.5;n:type:ShaderForge.SFN_Add,id:1475,x:34063,y:32668,varname:node_1475,prsc:2|A-9135-R,B-9237-R;n:type:ShaderForge.SFN_Add,id:8999,x:34436,y:32506,varname:node_8999,prsc:2|A-4352-OUT,B-2620-UVOUT;n:type:ShaderForge.SFN_Vector1,id:5194,x:34063,y:32472,varname:node_5194,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Multiply,id:4352,x:34282,y:32381,varname:node_4352,prsc:2|A-1320-UVOUT,B-5194-OUT,C-1475-OUT;n:type:ShaderForge.SFN_Tex2d,id:2845,x:33825,y:32976,ptovrint:False,ptlb:node_9135_copy,ptin:_node_9135_copy,varname:_node_9135_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87b1f9cd67cc874c97483c110978c9e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Panner,id:4279,x:34415,y:32843,varname:node_4279,prsc:2,spu:0,spv:0.1|UVIN-8147-OUT;n:type:ShaderForge.SFN_Tex2d,id:9468,x:34606,y:32843,ptovrint:False,ptlb:node_9468,ptin:_node_9468,varname:node_9468,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:982789d5cf3f1e1488ecb9dca1ec5b2a,ntxv:0,isnm:False|UVIN-4279-UVOUT;n:type:ShaderForge.SFN_Add,id:8147,x:34241,y:32843,varname:node_8147,prsc:2|A-2845-R,B-2620-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2138,x:34788,y:32646,varname:node_2138,prsc:2|A-8891-R,B-9468-RGB;n:type:ShaderForge.SFN_Power,id:9388,x:34991,y:32710,varname:node_9388,prsc:2|VAL-2138-OUT,EXP-5236-OUT;n:type:ShaderForge.SFN_Vector1,id:5236,x:34809,y:32805,varname:node_5236,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:9740,x:35161,y:32765,varname:node_9740,prsc:2|A-9388-OUT,B-3328-OUT;n:type:ShaderForge.SFN_Vector1,id:3328,x:34991,y:32849,varname:node_3328,prsc:2,v1:15;n:type:ShaderForge.SFN_Add,id:7884,x:35487,y:32686,varname:node_7884,prsc:2|A-2138-OUT,B-9740-OUT;n:type:ShaderForge.SFN_Multiply,id:240,x:35686,y:32655,varname:node_240,prsc:2|A-7884-OUT,B-3247-RGB,C-7904-OUT;n:type:ShaderForge.SFN_VertexColor,id:3247,x:35519,y:32842,varname:node_3247,prsc:2;n:type:ShaderForge.SFN_Slider,id:5327,x:34712,y:33198,ptovrint:False,ptlb:Rongjie,ptin:_Rongjie,varname:node_5327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:3568,x:34858,y:33031,ptovrint:False,ptlb:node_3568,ptin:_node_3568,varname:node_3568,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87b1f9cd67cc874c97483c110978c9e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Step,id:7904,x:35207,y:33052,varname:node_7904,prsc:2|A-3568-R,B-5327-OUT;proporder:9135-8891-9237-2845-9468-5327-3568;pass:END;sub:END;*/

Shader "Particles/S_Shuibo002" {
    Properties {
        _node_9135 ("node_9135", 2D) = "white" {}
        _node_8891 ("node_8891", 2D) = "white" {}
        _node_9237 ("node_9237", 2D) = "white" {}
        _node_9135_copy ("node_9135_copy", 2D) = "white" {}
        _node_9468 ("node_9468", 2D) = "white" {}
        _Rongjie ("Rongjie", Range(-0.1, 1)) = 1
        _node_3568 ("node_3568", 2D) = "white" {}
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
            uniform sampler2D _node_9135; uniform float4 _node_9135_ST;
            uniform sampler2D _node_8891; uniform float4 _node_8891_ST;
            uniform sampler2D _node_9237; uniform float4 _node_9237_ST;
            uniform sampler2D _node_9135_copy; uniform float4 _node_9135_copy_ST;
            uniform sampler2D _node_9468; uniform float4 _node_9468_ST;
            uniform float _Rongjie;
            uniform sampler2D _node_3568; uniform float4 _node_3568_ST;
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
                float4 node_7075 = _Time + _TimeEditor;
                float node_7045_ang = node_7075.g;
                float node_7045_spd = 0.5;
                float node_7045_cos = cos(node_7045_spd*node_7045_ang);
                float node_7045_sin = sin(node_7045_spd*node_7045_ang);
                float2 node_7045_piv = float2(0.5,0.5);
                float2 node_7045 = (mul(i.uv0-node_7045_piv,float2x2( node_7045_cos, -node_7045_sin, node_7045_sin, node_7045_cos))+node_7045_piv);
                float4 _node_9135_var = tex2D(_node_9135,TRANSFORM_TEX(node_7045, _node_9135));
                float node_9943_ang = node_7075.g;
                float node_9943_spd = (-0.5);
                float node_9943_cos = cos(node_9943_spd*node_9943_ang);
                float node_9943_sin = sin(node_9943_spd*node_9943_ang);
                float2 node_9943_piv = float2(0.5,0.5);
                float2 node_9943 = (mul(i.uv0-node_9943_piv,float2x2( node_9943_cos, -node_9943_sin, node_9943_sin, node_9943_cos))+node_9943_piv);
                float4 _node_9237_var = tex2D(_node_9237,TRANSFORM_TEX(node_9943, _node_9237));
                float2 node_8999 = (((i.uv0+(-2.5)*float2(1,1))*0.02*(_node_9135_var.r+_node_9237_var.r))+i.uv0);
                float4 _node_8891_var = tex2D(_node_8891,TRANSFORM_TEX(node_8999, _node_8891));
                float4 _node_9135_copy_var = tex2D(_node_9135_copy,TRANSFORM_TEX(i.uv0, _node_9135_copy));
                float2 node_4279 = ((_node_9135_copy_var.r+i.uv0)+node_7075.g*float2(0,0.1));
                float4 _node_9468_var = tex2D(_node_9468,TRANSFORM_TEX(node_4279, _node_9468));
                float3 node_2138 = (_node_8891_var.r*_node_9468_var.rgb);
                float4 _node_3568_var = tex2D(_node_3568,TRANSFORM_TEX(i.uv0, _node_3568));
                float3 emissive = ((node_2138+(pow(node_2138,4.0)*15.0))*i.vertexColor.rgb*step(_node_3568_var.r,_Rongjie));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
