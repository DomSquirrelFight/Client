// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:34617,y:32712,varname:node_1,prsc:2|diff-4-RGB,emission-2-OUT,clip-4-A;n:type:ShaderForge.SFN_Multiply,id:2,x:34429,y:32644,varname:node_2,prsc:2|A-162-OUT,B-3-OUT;n:type:ShaderForge.SFN_Multiply,id:3,x:34260,y:32696,varname:node_3,prsc:2|A-10-OUT,B-4-RGB;n:type:ShaderForge.SFN_Tex2d,id:4,x:34250,y:32860,ptovrint:False,ptlb:cao,ptin:_cao,varname:node_4896,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f2502f3d2cb259d44a0bd65ec01be5bb,ntxv:0,isnm:False|UVIN-9-OUT;n:type:ShaderForge.SFN_Append,id:9,x:34088,y:33033,varname:node_9,prsc:2|A-11-OUT,B-114-V;n:type:ShaderForge.SFN_Add,id:10,x:34049,y:32711,varname:node_10,prsc:2|A-13-OUT,B-39-RGB;n:type:ShaderForge.SFN_Add,id:11,x:33995,y:32860,varname:node_11,prsc:2|A-32-OUT,B-114-U;n:type:ShaderForge.SFN_Vector3,id:13,x:33890,y:32581,varname:node_13,prsc:2,v1:0.2,v2:0.2,v3:0.2;n:type:ShaderForge.SFN_Multiply,id:32,x:33826,y:32810,varname:node_32,prsc:2|A-410-OUT,B-33-OUT;n:type:ShaderForge.SFN_Multiply,id:33,x:33628,y:32683,varname:node_33,prsc:2|A-319-OUT,B-39-R;n:type:ShaderForge.SFN_Tex2d,id:39,x:33368,y:32884,ptovrint:False,ptlb:zhezhao,ptin:_zhezhao,varname:node_6635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Sin,id:42,x:33284,y:32683,varname:node_42,prsc:2|IN-47-OUT;n:type:ShaderForge.SFN_Multiply,id:47,x:33099,y:32654,varname:node_47,prsc:2|A-134-OUT,B-439-OUT;n:type:ShaderForge.SFN_Time,id:50,x:32753,y:32776,varname:node_50,prsc:2;n:type:ShaderForge.SFN_Color,id:90,x:33988,y:32461,ptovrint:False,ptlb:node_90,ptin:_node_90,varname:node_1734,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:114,x:33785,y:32990,varname:node_114,prsc:2,uv:0;n:type:ShaderForge.SFN_Pi,id:134,x:32965,y:32554,varname:node_134,prsc:2;n:type:ShaderForge.SFN_Multiply,id:162,x:34277,y:32493,varname:node_162,prsc:2|A-90-RGB,B-164-OUT;n:type:ShaderForge.SFN_ValueProperty,id:164,x:34110,y:32614,ptovrint:False,ptlb:liangdu,ptin:_liangdu,varname:node_4445,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:319,x:33502,y:32478,varname:node_319,prsc:2|A-320-OUT,B-42-OUT;n:type:ShaderForge.SFN_ValueProperty,id:320,x:33314,y:32360,ptovrint:False,ptlb:pinlv,ptin:_pinlv,varname:node_4895,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:384,x:32753,y:32554,ptovrint:False,ptlb:boxing,ptin:_boxing,varname:node_1521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:410,x:33675,y:32465,varname:node_410,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Add,id:439,x:32932,y:32701,varname:node_439,prsc:2|A-384-OUT,B-50-T;proporder:4-39-90-164-320-384;pass:END;sub:END;*/

Shader "Shader Forge/L06" {
    Properties {
        _cao ("cao", 2D) = "white" {}
        _zhezhao ("zhezhao", 2D) = "white" {}
        _node_90 ("node_90", Color) = (0,0,0,1)
        _liangdu ("liangdu", Float ) = 2
        _pinlv ("pinlv", Float ) = 1
        _boxing ("boxing", Float ) = 0.5
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _cao; uniform float4 _cao_ST;
            uniform sampler2D _zhezhao; uniform float4 _zhezhao_ST;
            uniform float4 _node_90;
            uniform float _liangdu;
            uniform float _pinlv;
            uniform float _boxing;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_50 = _Time + _TimeEditor;
                float4 _zhezhao_var = tex2D(_zhezhao,TRANSFORM_TEX(i.uv0, _zhezhao));
                float2 node_9 = float2(((0.02*((_pinlv*sin((3.141592654*(_boxing+node_50.g))))*_zhezhao_var.r))+i.uv0.r),i.uv0.g);
                float4 _cao_var = tex2D(_cao,TRANSFORM_TEX(node_9, _cao));
                clip(_cao_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _cao_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
////// Emissive:
                float3 emissive = ((_node_90.rgb*_liangdu)*((float3(0.2,0.2,0.2)+_zhezhao_var.rgb)*_cao_var.rgb));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _cao; uniform float4 _cao_ST;
            uniform sampler2D _zhezhao; uniform float4 _zhezhao_ST;
            uniform float4 _node_90;
            uniform float _liangdu;
            uniform float _pinlv;
            uniform float _boxing;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_50 = _Time + _TimeEditor;
                float4 _zhezhao_var = tex2D(_zhezhao,TRANSFORM_TEX(i.uv0, _zhezhao));
                float2 node_9 = float2(((0.02*((_pinlv*sin((3.141592654*(_boxing+node_50.g))))*_zhezhao_var.r))+i.uv0.r),i.uv0.g);
                float4 _cao_var = tex2D(_cao,TRANSFORM_TEX(node_9, _cao));
                clip(_cao_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _cao_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _cao; uniform float4 _cao_ST;
            uniform sampler2D _zhezhao; uniform float4 _zhezhao_ST;
            uniform float _pinlv;
            uniform float _boxing;
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
                float4 node_50 = _Time + _TimeEditor;
                float4 _zhezhao_var = tex2D(_zhezhao,TRANSFORM_TEX(i.uv0, _zhezhao));
                float2 node_9 = float2(((0.02*((_pinlv*sin((3.141592654*(_boxing+node_50.g))))*_zhezhao_var.r))+i.uv0.r),i.uv0.g);
                float4 _cao_var = tex2D(_cao,TRANSFORM_TEX(node_9, _cao));
                clip(_cao_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
