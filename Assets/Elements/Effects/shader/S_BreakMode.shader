// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33772,y:32649,varname:node_4013,prsc:2|diff-6808-RGB,spec-4599-RGB,gloss-4599-A,emission-9904-OUT,clip-7681-R;n:type:ShaderForge.SFN_TexCoord,id:8043,x:31120,y:32929,varname:node_8043,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:7037,x:31320,y:32973,varname:node_7037,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Vector1,id:3331,x:31320,y:32816,varname:node_3331,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:5377,x:31570,y:32973,varname:node_5377,prsc:2|A-3331-OUT,B-7037-OUT,T-1618-UVOUT;n:type:ShaderForge.SFN_Slider,id:5265,x:30572,y:33272,ptovrint:False,ptlb:node_5265,ptin:_node_5265,varname:node_5265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5555556,max:1;n:type:ShaderForge.SFN_Panner,id:1618,x:31308,y:33100,varname:node_1618,prsc:2,spu:0,spv:2|UVIN-8043-UVOUT,DIST-7095-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5487,x:31570,y:32782,varname:node_5487,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:7711,x:31559,y:33183,varname:node_7711,prsc:2;n:type:ShaderForge.SFN_Add,id:134,x:31806,y:32947,varname:node_134,prsc:2|A-5487-Y,B-5377-OUT;n:type:ShaderForge.SFN_Subtract,id:3084,x:32045,y:32947,varname:node_3084,prsc:2|A-134-OUT,B-7711-Y;n:type:ShaderForge.SFN_Panner,id:3222,x:32231,y:32921,varname:node_3222,prsc:2,spu:0,spv:1|UVIN-8043-UVOUT,DIST-3084-OUT;n:type:ShaderForge.SFN_Tex2d,id:7681,x:32450,y:32921,ptovrint:False,ptlb:node_7681,ptin:_node_7681,varname:node_7681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:179f8e540b21c864f814b3be3381c7cd,ntxv:0,isnm:False|UVIN-2599-OUT;n:type:ShaderForge.SFN_Tex2d,id:6808,x:32450,y:32557,ptovrint:False,ptlb:node_6808,ptin:_node_6808,varname:node_6808,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:01734a50097d1834397a5077e165ac56,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4599,x:32450,y:32744,ptovrint:False,ptlb:node_4599,ptin:_node_4599,varname:node_4599,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:55a823e3ed198f74e98b26979fde5074,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:7746,x:30974,y:33245,varname:node_7746,prsc:2|A-5265-OUT,B-5276-OUT;n:type:ShaderForge.SFN_Vector1,id:5276,x:30803,y:33512,varname:node_5276,prsc:2,v1:0.12;n:type:ShaderForge.SFN_Multiply,id:7095,x:31151,y:33245,varname:node_7095,prsc:2|A-7746-OUT,B-796-OUT;n:type:ShaderForge.SFN_Vector1,id:796,x:30988,y:33492,varname:node_796,prsc:2,v1:1.2;n:type:ShaderForge.SFN_Power,id:7074,x:32636,y:33053,varname:node_7074,prsc:2|VAL-7681-R,EXP-8435-OUT;n:type:ShaderForge.SFN_Slider,id:8435,x:32180,y:33248,ptovrint:False,ptlb:B,ptin:_B,varname:node_8435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:8838,x:32806,y:33113,varname:node_8838,prsc:2|A-7074-OUT,B-4804-OUT;n:type:ShaderForge.SFN_Vector1,id:4804,x:32616,y:33289,varname:node_4804,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:7050,x:32994,y:33142,varname:node_7050,prsc:2|A-8838-OUT,B-5175-OUT;n:type:ShaderForge.SFN_Vector1,id:5175,x:32820,y:33310,varname:node_5175,prsc:2,v1:1;n:type:ShaderForge.SFN_Abs,id:4638,x:33166,y:33142,varname:node_4638,prsc:2|IN-7050-OUT;n:type:ShaderForge.SFN_Vector1,id:4644,x:33140,y:33032,varname:node_4644,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:9904,x:33372,y:33142,varname:node_9904,prsc:2|A-4644-OUT,B-4638-OUT;n:type:ShaderForge.SFN_Multiply,id:8845,x:31641,y:32501,varname:node_8845,prsc:2|A-2164-OUT,B-9713-R;n:type:ShaderForge.SFN_Vector1,id:9255,x:31641,y:32435,varname:node_9255,prsc:2,v1:0.011;n:type:ShaderForge.SFN_Add,id:2599,x:32025,y:32455,varname:node_2599,prsc:2|A-3222-UVOUT,B-444-OUT;n:type:ShaderForge.SFN_Tex2d,id:9713,x:31468,y:32593,ptovrint:False,ptlb:wenli,ptin:_wenli,varname:node_1055,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:33f721537ff0e1146acb1c153bf4940d,ntxv:0,isnm:False|UVIN-1743-UVOUT;n:type:ShaderForge.SFN_Panner,id:1743,x:31292,y:32593,varname:node_1743,prsc:2,spu:-0.1,spv:0.05|UVIN-2098-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2098,x:31120,y:32593,varname:node_2098,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:2164,x:31468,y:32501,varname:node_2164,prsc:2,v1:-10,v2:0;n:type:ShaderForge.SFN_Multiply,id:444,x:31821,y:32481,varname:node_444,prsc:2|A-9255-OUT,B-8845-OUT;proporder:5265-7681-6808-4599-8435-9713;pass:END;sub:END;*/

Shader "Shader Forge/S_BreakMode" {
    Properties {
        _node_5265 ("node_5265", Range(0, 1)) = 0.5555556
        _node_7681 ("node_7681", 2D) = "white" {}
        _node_6808 ("node_6808", 2D) = "white" {}
        _node_4599 ("node_4599", 2D) = "white" {}
        _B ("B", Range(0, 1)) = 1
        _wenli ("wenli", 2D) = "white" {}
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _node_5265;
            uniform sampler2D _node_7681; uniform float4 _node_7681_ST;
            uniform sampler2D _node_6808; uniform float4 _node_6808_ST;
            uniform sampler2D _node_4599; uniform float4 _node_4599_ST;
            uniform float _B;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_3331 = 0.5;
                float node_7037 = (-0.5);
                float4 node_6544 = _Time + _TimeEditor;
                float2 node_1743 = (i.uv0+node_6544.g*float2(-0.1,0.05));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_1743, _wenli));
                float2 node_2599 = ((i.uv0+((i.posWorld.g+lerp(float2(node_3331,node_3331),float2(node_7037,node_7037),(i.uv0+((_node_5265+0.12)*1.2)*float2(0,2))))-objPos.g)*float2(0,1))+(0.011*(float2(-10,0)*_wenli_var.r)));
                float4 _node_7681_var = tex2D(_node_7681,TRANSFORM_TEX(node_2599, _node_7681));
                clip(_node_7681_var.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _node_4599_var = tex2D(_node_4599,TRANSFORM_TEX(i.uv0, _node_4599));
                float gloss = _node_4599_var.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _node_4599_var.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _node_6808_var = tex2D(_node_6808,TRANSFORM_TEX(i.uv0, _node_6808));
                float3 diffuseColor = _node_6808_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_9904 = (1.0-abs(((pow(_node_7681_var.r,_B)*2.0)-1.0)));
                float3 emissive = float3(node_9904,node_9904,node_9904);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _node_5265;
            uniform sampler2D _node_7681; uniform float4 _node_7681_ST;
            uniform sampler2D _node_6808; uniform float4 _node_6808_ST;
            uniform sampler2D _node_4599; uniform float4 _node_4599_ST;
            uniform float _B;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_3331 = 0.5;
                float node_7037 = (-0.5);
                float4 node_5758 = _Time + _TimeEditor;
                float2 node_1743 = (i.uv0+node_5758.g*float2(-0.1,0.05));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_1743, _wenli));
                float2 node_2599 = ((i.uv0+((i.posWorld.g+lerp(float2(node_3331,node_3331),float2(node_7037,node_7037),(i.uv0+((_node_5265+0.12)*1.2)*float2(0,2))))-objPos.g)*float2(0,1))+(0.011*(float2(-10,0)*_wenli_var.r)));
                float4 _node_7681_var = tex2D(_node_7681,TRANSFORM_TEX(node_2599, _node_7681));
                clip(_node_7681_var.r - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _node_4599_var = tex2D(_node_4599,TRANSFORM_TEX(i.uv0, _node_4599));
                float gloss = _node_4599_var.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _node_4599_var.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_6808_var = tex2D(_node_6808,TRANSFORM_TEX(i.uv0, _node_6808));
                float3 diffuseColor = _node_6808_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _node_5265;
            uniform sampler2D _node_7681; uniform float4 _node_7681_ST;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_3331 = 0.5;
                float node_7037 = (-0.5);
                float4 node_3392 = _Time + _TimeEditor;
                float2 node_1743 = (i.uv0+node_3392.g*float2(-0.1,0.05));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_1743, _wenli));
                float2 node_2599 = ((i.uv0+((i.posWorld.g+lerp(float2(node_3331,node_3331),float2(node_7037,node_7037),(i.uv0+((_node_5265+0.12)*1.2)*float2(0,2))))-objPos.g)*float2(0,1))+(0.011*(float2(-10,0)*_wenli_var.r)));
                float4 _node_7681_var = tex2D(_node_7681,TRANSFORM_TEX(node_2599, _node_7681));
                clip(_node_7681_var.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
