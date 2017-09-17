// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:34309,y:32858,varname:node_4795,prsc:2|emission-6389-OUT,alpha-7774-OUT;n:type:ShaderForge.SFN_Tex2d,id:8575,x:33698,y:32741,ptovrint:False,ptlb:node_8575,ptin:_node_8575,varname:node_8575,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b0f3b82434a2b8747af09455c4aab9dc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4941,x:32346,y:32895,ptovrint:False,ptlb:Niuqu,ptin:_Niuqu,varname:node_4941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87b1f9cd67cc874c97483c110978c9e,ntxv:0,isnm:False|UVIN-3992-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2333,x:32925,y:32827,ptovrint:False,ptlb:Wenli,ptin:_Wenli,varname:node_2333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:25764103d2c9f0a448ac39e02cf31ed6,ntxv:0,isnm:False|UVIN-7728-OUT;n:type:ShaderForge.SFN_Panner,id:3992,x:32168,y:32895,varname:node_3992,prsc:2,spu:0,spv:1|UVIN-65-UVOUT,DIST-894-OUT;n:type:ShaderForge.SFN_TexCoord,id:65,x:31600,y:32802,varname:node_65,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3840,x:32533,y:32977,varname:node_3840,prsc:2|A-4941-R,B-9747-OUT;n:type:ShaderForge.SFN_Vector1,id:9747,x:32346,y:33068,varname:node_9747,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:7728,x:32751,y:32827,varname:node_7728,prsc:2|A-9370-UVOUT,B-3840-OUT;n:type:ShaderForge.SFN_Panner,id:9370,x:32168,y:32673,varname:node_9370,prsc:2,spu:0,spv:1|UVIN-65-UVOUT,DIST-894-OUT;n:type:ShaderForge.SFN_Multiply,id:4220,x:33653,y:32941,varname:node_4220,prsc:2|A-7034-RGB,B-2333-RGB,C-5227-OUT,D-4763-OUT;n:type:ShaderForge.SFN_Slider,id:894,x:31768,y:32802,ptovrint:False,ptlb:P,ptin:_P,varname:node_894,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:0.07948717,max:2;n:type:ShaderForge.SFN_Step,id:5227,x:33129,y:33048,varname:node_5227,prsc:2|A-6844-R,B-1941-OUT;n:type:ShaderForge.SFN_Slider,id:1941,x:32594,y:33213,ptovrint:False,ptlb:Amount,ptin:_Amount,varname:_Amount_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:0.2666667,max:1;n:type:ShaderForge.SFN_Step,id:7494,x:33129,y:33198,varname:node_7494,prsc:2|A-6844-R,B-1252-OUT;n:type:ShaderForge.SFN_Add,id:1252,x:32923,y:33259,varname:node_1252,prsc:2|A-1941-OUT,B-615-OUT;n:type:ShaderForge.SFN_Subtract,id:629,x:33399,y:33240,varname:node_629,prsc:2|A-7494-OUT,B-5227-OUT;n:type:ShaderForge.SFN_Add,id:2187,x:33921,y:33103,varname:node_2187,prsc:2|A-4220-OUT,B-8280-OUT;n:type:ShaderForge.SFN_Multiply,id:8280,x:33746,y:33328,varname:node_8280,prsc:2|A-629-OUT,B-7034-RGB,C-8600-OUT;n:type:ShaderForge.SFN_Color,id:7034,x:33417,y:33403,ptovrint:False,ptlb:Bcolor,ptin:_Bcolor,varname:node_7034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7723184,c2:0.9117647,c3:0.1340831,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:8600,x:33399,y:33560,ptovrint:False,ptlb:Bqiangdu,ptin:_Bqiangdu,varname:node_8600,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:6389,x:34115,y:32952,varname:node_6389,prsc:2|A-8575-R,B-2187-OUT;n:type:ShaderForge.SFN_ValueProperty,id:615,x:32751,y:33303,ptovrint:False,ptlb:B,ptin:_B,varname:node_615,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.05;n:type:ShaderForge.SFN_Tex2d,id:6844,x:32751,y:32977,ptovrint:False,ptlb:node_6844,ptin:_node_6844,varname:node_6844,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b14d31ac788fb94380eba7525628d33,ntxv:0,isnm:False|UVIN-9370-UVOUT;n:type:ShaderForge.SFN_Step,id:7774,x:33247,y:33356,varname:node_7774,prsc:2|A-6844-R,B-3419-OUT;n:type:ShaderForge.SFN_Add,id:3419,x:33076,y:33413,varname:node_3419,prsc:2|A-1252-OUT,B-3801-OUT;n:type:ShaderForge.SFN_Vector1,id:3801,x:32790,y:33540,varname:node_3801,prsc:2,v1:0.01;n:type:ShaderForge.SFN_ValueProperty,id:4763,x:33399,y:33099,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4763,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;proporder:8575-4941-2333-894-1941-7034-8600-615-6844-4763;pass:END;sub:END;*/

Shader "Particles/S_liuguang006" {
    Properties {
        _node_8575 ("node_8575", 2D) = "white" {}
        _Niuqu ("Niuqu", 2D) = "white" {}
        _Wenli ("Wenli", 2D) = "white" {}
        _P ("P", Range(-0.1, 2)) = 0.07948717
        _Amount ("Amount", Range(-0.1, 1)) = 0.2666667
        _Bcolor ("Bcolor", Color) = (0.7723184,0.9117647,0.1340831,1)
        _Bqiangdu ("Bqiangdu", Float ) = 2
        _B ("B", Float ) = 0.05
        _node_6844 ("node_6844", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 1.2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _node_8575; uniform float4 _node_8575_ST;
            uniform sampler2D _Niuqu; uniform float4 _Niuqu_ST;
            uniform sampler2D _Wenli; uniform float4 _Wenli_ST;
            uniform float _P;
            uniform float _Amount;
            uniform float4 _Bcolor;
            uniform float _Bqiangdu;
            uniform float _B;
            uniform sampler2D _node_6844; uniform float4 _node_6844_ST;
            uniform float _qiangdu;
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
                float4 _node_8575_var = tex2D(_node_8575,TRANSFORM_TEX(i.uv0, _node_8575));
                float2 node_9370 = (i.uv0+_P*float2(0,1));
                float2 node_3992 = (i.uv0+_P*float2(0,1));
                float4 _Niuqu_var = tex2D(_Niuqu,TRANSFORM_TEX(node_3992, _Niuqu));
                float2 node_7728 = (node_9370+(_Niuqu_var.r*0.1));
                float4 _Wenli_var = tex2D(_Wenli,TRANSFORM_TEX(node_7728, _Wenli));
                float4 _node_6844_var = tex2D(_node_6844,TRANSFORM_TEX(node_9370, _node_6844));
                float node_5227 = step(_node_6844_var.r,_Amount);
                float node_1252 = (_Amount+_B);
                float3 emissive = (_node_8575_var.r*((_Bcolor.rgb*_Wenli_var.rgb*node_5227*_qiangdu)+((step(_node_6844_var.r,node_1252)-node_5227)*_Bcolor.rgb*_Bqiangdu)));
                float3 finalColor = emissive;
                return fixed4(finalColor,step(_node_6844_var.r,(node_1252+0.01)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
