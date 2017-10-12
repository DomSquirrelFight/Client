// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.08088237,fgcg:0.003568338,fgcb:0.003568338,fgca:1,fgde:1,fgrn:15,fgrf:60,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:34493,y:32712,varname:node_1,prsc:2|emission-9719-OUT;n:type:ShaderForge.SFN_Tex2d,id:7,x:33180,y:32975,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f4a8775589bf1db449415e82d7d731f1,ntxv:0,isnm:False|UVIN-3974-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:413,x:33989,y:32820,ptovrint:False,ptlb:node_413,ptin:_node_413,varname:node_3925,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-499-UVOUT;n:type:ShaderForge.SFN_Panner,id:499,x:33749,y:32877,varname:node_499,prsc:2,spu:0,spv:-0.5|UVIN-7176-OUT,DIST-38-OUT;n:type:ShaderForge.SFN_Slider,id:38,x:33400,y:33157,ptovrint:False,ptlb:uuuuuuuuu,ptin:_uuuuuuuuu,varname:node_38,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:2,max:2;n:type:ShaderForge.SFN_TexCoord,id:3974,x:32974,y:32982,varname:node_3974,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:7176,x:33438,y:32904,varname:node_7176,prsc:2|A-6235-OUT,B-7-R;n:type:ShaderForge.SFN_Vector1,id:6235,x:33066,y:32826,varname:node_6235,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9719,x:34300,y:32865,varname:node_9719,prsc:2|A-413-RGB,B-3347-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3347,x:34063,y:33100,ptovrint:False,ptlb:node_3347,ptin:_node_3347,varname:node_3347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7-413-38-3347;pass:END;sub:END;*/

Shader "Particles/L05" {
    Properties {
        _wenli02 ("wenli02", 2D) = "white" {}
        _node_413 ("node_413", 2D) = "black" {}
        _uuuuuuuuu ("uuuuuuuuu", Range(-1, 2)) = 2
        _node_3347 ("node_3347", Float ) = 1
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
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform sampler2D _node_413; uniform float4 _node_413_ST;
            uniform float _uuuuuuuuu;
            uniform float _node_3347;
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
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(i.uv0, _wenli02));
                float2 node_499 = ((1.0*_wenli02_var.r)+_uuuuuuuuu*float2(0,-0.5));
                float4 _node_413_var = tex2D(_node_413,TRANSFORM_TEX(node_499, _node_413));
                float3 emissive = (_node_413_var.rgb*_node_3347);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
