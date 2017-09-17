// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33023,y:32651,varname:node_4795,prsc:2|emission-1675-OUT,clip-798-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32051,y:32559,ptovrint:False,ptlb:tex_001,ptin:_tex_001,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3c1c7689be35dcf42a60d59902c4cea6,ntxv:0,isnm:False|UVIN-9720-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32484,y:32647,varname:node_2393,prsc:2|A-1803-RGB,B-4015-RGB,C-6074-RGB;n:type:ShaderForge.SFN_Multiply,id:798,x:32395,y:32902,varname:node_798,prsc:2|A-5202-A,B-4845-OUT;n:type:ShaderForge.SFN_Slider,id:4845,x:31943,y:33048,ptovrint:False,ptlb:dissolve,ptin:_dissolve,varname:node_4845,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.911957,max:6;n:type:ShaderForge.SFN_Tex2d,id:5202,x:31981,y:32793,ptovrint:False,ptlb:tex_002,ptin:_tex_002,varname:node_5202,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7115ddc487b846d4d8e443b823efc373,ntxv:0,isnm:False|UVIN-9720-UVOUT;n:type:ShaderForge.SFN_Color,id:4015,x:31975,y:32332,ptovrint:False,ptlb:color,ptin:_color,varname:node_4015,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7058823,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1803,x:32096,y:32026,ptovrint:False,ptlb:tex_003,ptin:_tex_003,varname:node_1803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7115ddc487b846d4d8e443b823efc373,ntxv:0,isnm:False|UVIN-9720-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1675,x:32786,y:32724,varname:node_1675,prsc:2|A-8637-RGB,B-2393-OUT,C-8637-A;n:type:ShaderForge.SFN_VertexColor,id:8637,x:32459,y:32471,varname:node_8637,prsc:2;n:type:ShaderForge.SFN_Slider,id:1306,x:31283,y:32429,ptovrint:False,ptlb:move_001,ptin:_move_001,varname:node_1306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6.043879,max:10;n:type:ShaderForge.SFN_TexCoord,id:9607,x:31350,y:32146,varname:node_9607,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:9720,x:31631,y:32156,varname:node_9720,prsc:2,spu:0.5,spv:0|UVIN-9607-UVOUT,DIST-1306-OUT;proporder:6074-4845-5202-4015-1803-1306;pass:END;sub:END;*/

Shader "Shader Forge/S_dissolve001" {
    Properties {
        _tex_001 ("tex_001", 2D) = "white" {}
        _dissolve ("dissolve", Range(0, 6)) = 1.911957
        _tex_002 ("tex_002", 2D) = "white" {}
        _color ("color", Color) = (0.7058823,0,0,1)
        _tex_003 ("tex_003", 2D) = "white" {}
        _move_001 ("move_001", Range(0, 10)) = 6.043879
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _tex_001; uniform float4 _tex_001_ST;
            uniform float _dissolve;
            uniform sampler2D _tex_002; uniform float4 _tex_002_ST;
            uniform float4 _color;
            uniform sampler2D _tex_003; uniform float4 _tex_003_ST;
            uniform float _move_001;
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
                float2 node_9720 = (i.uv0+_move_001*float2(0.5,0));
                float4 _tex_002_var = tex2D(_tex_002,TRANSFORM_TEX(node_9720, _tex_002));
                clip((_tex_002_var.a*_dissolve) - 0.5);
////// Lighting:
////// Emissive:
                float4 _tex_003_var = tex2D(_tex_003,TRANSFORM_TEX(node_9720, _tex_003));
                float4 _tex_001_var = tex2D(_tex_001,TRANSFORM_TEX(node_9720, _tex_001));
                float3 emissive = (i.vertexColor.rgb*(_tex_003_var.rgb*_color.rgb*_tex_001_var.rgb)*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
            uniform float _dissolve;
            uniform sampler2D _tex_002; uniform float4 _tex_002_ST;
            uniform float _move_001;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 node_9720 = (i.uv0+_move_001*float2(0.5,0));
                float4 _tex_002_var = tex2D(_tex_002,TRANSFORM_TEX(node_9720, _tex_002));
                clip((_tex_002_var.a*_dissolve) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
