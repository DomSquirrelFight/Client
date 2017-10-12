// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32806,y:34291,varname:node_4795,prsc:2|emission-2393-OUT,alpha-6074-A,clip-9976-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31463,y:34192,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b14d31ac788fb94380eba7525628d33,ntxv:0,isnm:False|UVIN-9756-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32633,y:34392,varname:node_2393,prsc:2|A-2053-RGB,B-8454-OUT,C-797-RGB,D-2849-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32406,y:34191,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32406,y:34503,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Panner,id:9756,x:30006,y:34156,varname:node_9756,prsc:2,spu:0,spv:1|UVIN-2058-UVOUT,DIST-8080-OUT;n:type:ShaderForge.SFN_TexCoord,id:2058,x:29661,y:34082,varname:node_2058,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:8080,x:29565,y:34313,ptovrint:False,ptlb:P,ptin:_P,varname:node_8080,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:-2,max:2;n:type:ShaderForge.SFN_ValueProperty,id:2849,x:32406,y:34678,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_2849,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:6762,x:30295,y:34290,ptovrint:False,ptlb:MainTex_copy,ptin:_MainTex_copy,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b14d31ac788fb94380eba7525628d33,ntxv:0,isnm:False|UVIN-9756-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4471,x:30491,y:34371,varname:node_4471,prsc:2|A-6762-R,B-6045-OUT;n:type:ShaderForge.SFN_Vector1,id:6045,x:30269,y:34518,varname:node_6045,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:5737,x:30690,y:34458,varname:node_5737,prsc:2|A-4471-OUT,B-6045-OUT;n:type:ShaderForge.SFN_Add,id:9976,x:30903,y:34523,varname:node_9976,prsc:2|A-5737-OUT,B-3568-OUT;n:type:ShaderForge.SFN_Slider,id:3568,x:30533,y:34608,ptovrint:False,ptlb:Amount,ptin:_Amount,varname:node_3568,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.357394,max:10;n:type:ShaderForge.SFN_Clamp01,id:3836,x:31088,y:34430,varname:node_3836,prsc:2|IN-9976-OUT;n:type:ShaderForge.SFN_Power,id:8048,x:31306,y:34451,varname:node_8048,prsc:2|VAL-3836-OUT,EXP-7815-OUT;n:type:ShaderForge.SFN_Slider,id:7815,x:30931,y:34682,ptovrint:False,ptlb:B,ptin:_B,varname:node_7815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:9.624148,max:20;n:type:ShaderForge.SFN_Multiply,id:9501,x:31517,y:34451,varname:node_9501,prsc:2|A-8048-OUT,B-5522-OUT;n:type:ShaderForge.SFN_Vector1,id:5522,x:31279,y:34666,varname:node_5522,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:9623,x:31697,y:34523,varname:node_9623,prsc:2|A-9501-OUT,B-7659-OUT;n:type:ShaderForge.SFN_Vector1,id:7659,x:31530,y:34700,varname:node_7659,prsc:2,v1:1;n:type:ShaderForge.SFN_Abs,id:51,x:31869,y:34523,varname:node_51,prsc:2|IN-9623-OUT;n:type:ShaderForge.SFN_Subtract,id:3920,x:32040,y:34502,varname:node_3920,prsc:2|A-8075-OUT,B-51-OUT;n:type:ShaderForge.SFN_Vector1,id:8075,x:31869,y:34458,varname:node_8075,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5836,x:32246,y:34555,varname:node_5836,prsc:2|A-3920-OUT,B-5663-RGB;n:type:ShaderForge.SFN_Color,id:5663,x:31997,y:34704,ptovrint:False,ptlb:node_5663,ptin:_node_5663,varname:node_5663,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:70,c2:100,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:8454,x:32406,y:34340,varname:node_8454,prsc:2|A-6074-RGB,B-5836-OUT;proporder:6074-797-8080-2849-6762-3568-7815-5663;pass:END;sub:END;*/

Shader "Particles/S_Rongjie001" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _P ("P", Range(-2, 2)) = -2
        _qiangdu ("qiangdu", Float ) = 1
        _MainTex_copy ("MainTex_copy", 2D) = "white" {}
        _Amount ("Amount", Range(0, 10)) = 4.357394
        _B ("B", Range(0, 20)) = 9.624148
        _node_5663 ("node_5663", Color) = (70,100,1,1)
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _P;
            uniform float _qiangdu;
            uniform sampler2D _MainTex_copy; uniform float4 _MainTex_copy_ST;
            uniform float _Amount;
            uniform float _B;
            uniform float4 _node_5663;
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
            float4 frag(VertexOutput i) : COLOR {
                float2 node_9756 = (i.uv0+_P*float2(0,1));
                float4 _MainTex_copy_var = tex2D(_MainTex_copy,TRANSFORM_TEX(node_9756, _MainTex_copy));
                float node_6045 = 8.0;
                float node_9976 = (((_MainTex_copy_var.r*node_6045)-node_6045)+_Amount);
                clip(node_9976 - 0.5);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9756, _MainTex));
                float3 emissive = (i.vertexColor.rgb*(_MainTex_var.rgb+((1.0-abs(((pow(saturate(node_9976),_B)*2.0)-1.0)))*_node_5663.rgb))*_TintColor.rgb*_qiangdu);
                float3 finalColor = emissive;
                return fixed4(finalColor,_MainTex_var.a);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _P;
            uniform sampler2D _MainTex_copy; uniform float4 _MainTex_copy_ST;
            uniform float _Amount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 node_9756 = (i.uv0+_P*float2(0,1));
                float4 _MainTex_copy_var = tex2D(_MainTex_copy,TRANSFORM_TEX(node_9756, _MainTex_copy));
                float node_6045 = 8.0;
                float node_9976 = (((_MainTex_copy_var.r*node_6045)-node_6045)+_Amount);
                clip(node_9976 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
