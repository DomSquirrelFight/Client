// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33619,y:32728,varname:node_4013,prsc:2|emission-9521-OUT;n:type:ShaderForge.SFN_Tex2d,id:6434,x:31993,y:32579,ptovrint:False,ptlb:DITU,ptin:_DITU,varname:node_6434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23a3ad2adfdcc2540a70e69ba3f100f4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3841,x:32425,y:32478,varname:node_3841,prsc:2|A-6434-RGB,B-6573-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6573,x:32140,y:32739,ptovrint:False,ptlb:lightness,ptin:_lightness,varname:node_6573,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:922,x:31259,y:33071,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:node_922,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.318224,max:5;n:type:ShaderForge.SFN_Tex2d,id:4542,x:31625,y:32829,ptovrint:False,ptlb:BIAN,ptin:_BIAN,varname:node_4542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_If,id:2327,x:32300,y:32869,varname:node_2327,prsc:2|A-9712-OUT,B-3439-OUT,GT-3439-OUT,EQ-9397-OUT,LT-9397-OUT;n:type:ShaderForge.SFN_Vector1,id:3439,x:31961,y:33015,varname:node_3439,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9397,x:31961,y:33069,varname:node_9397,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:9712,x:31974,y:32857,varname:node_9712,prsc:2|A-4542-RGB,B-922-OUT;n:type:ShaderForge.SFN_Multiply,id:7470,x:31984,y:33208,varname:node_7470,prsc:2|A-4542-RGB,B-7720-OUT;n:type:ShaderForge.SFN_Add,id:7720,x:31627,y:33163,varname:node_7720,prsc:2|A-922-OUT,B-5169-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5169,x:31281,y:33237,ptovrint:False,ptlb:bian,ptin:_bian,varname:node_5169,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_If,id:8317,x:32266,y:33104,varname:node_8317,prsc:2|A-7470-OUT,B-3439-OUT,GT-3439-OUT,EQ-9397-OUT,LT-9397-OUT;n:type:ShaderForge.SFN_Subtract,id:1481,x:32525,y:32821,varname:node_1481,prsc:2|A-8317-OUT,B-2327-OUT;n:type:ShaderForge.SFN_Add,id:9521,x:33224,y:32604,varname:node_9521,prsc:2|A-1227-OUT,B-8535-OUT;n:type:ShaderForge.SFN_Multiply,id:1227,x:33028,y:32524,varname:node_1227,prsc:2|A-9881-OUT,B-8317-OUT,C-4355-RGB,D-4355-A;n:type:ShaderForge.SFN_Tex2d,id:6450,x:31888,y:32261,ptovrint:False,ptlb:T2,ptin:_T2,varname:node_6450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f76cd653f138dfd48bf97564b0598a87,ntxv:0,isnm:False|UVIN-5268-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5268,x:31648,y:32348,varname:node_5268,prsc:2|UVIN-4279-UVOUT,SPD-823-OUT;n:type:ShaderForge.SFN_TexCoord,id:4279,x:31283,y:32040,varname:node_4279,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:823,x:31424,y:32677,varname:node_823,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:8535,x:32927,y:32848,varname:node_8535,prsc:2|A-1481-OUT,B-862-RGB;n:type:ShaderForge.SFN_Tex2d,id:2276,x:31931,y:32048,ptovrint:False,ptlb:T1,ptin:_T1,varname:node_2276,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c999ae04ae551c648aa7fb32967beb3b,ntxv:0,isnm:False|UVIN-6316-UVOUT;n:type:ShaderForge.SFN_Rotator,id:6316,x:31639,y:32033,varname:node_6316,prsc:2|UVIN-4279-UVOUT,SPD-4906-OUT;n:type:ShaderForge.SFN_Vector1,id:4906,x:31297,y:32323,varname:node_4906,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Multiply,id:1606,x:32384,y:32159,varname:node_1606,prsc:2|A-2276-RGB,B-6450-RGB,C-8199-OUT;n:type:ShaderForge.SFN_VertexColor,id:4355,x:32504,y:32610,varname:node_4355,prsc:2;n:type:ShaderForge.SFN_Add,id:9881,x:32646,y:32324,varname:node_9881,prsc:2|A-1606-OUT,B-3841-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8199,x:32149,y:32396,ptovrint:False,ptlb:grain,ptin:_grain,varname:node_8199,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Color,id:862,x:32596,y:33069,ptovrint:False,ptlb:color_bian,ptin:_color_bian,varname:node_862,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1724138,c3:1,c4:1;proporder:6434-6573-922-4542-5169-6450-2276-8199-862;pass:END;sub:END;*/

Shader "Particles/S_dissolve_004" {
    Properties {
        _DITU ("DITU", 2D) = "white" {}
        _lightness ("lightness", Float ) = 1
        _Dissolve ("Dissolve", Range(0, 5)) = 1.318224
        _BIAN ("BIAN", 2D) = "white" {}
        _bian ("bian", Float ) = 0.1
        _T2 ("T2", 2D) = "white" {}
        _T1 ("T1", 2D) = "white" {}
        _grain ("grain", Float ) = 2
        _color_bian ("color_bian", Color) = (0,0.1724138,1,1)
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _DITU; uniform float4 _DITU_ST;
            uniform float _lightness;
            uniform float _Dissolve;
            uniform sampler2D _BIAN; uniform float4 _BIAN_ST;
            uniform float _bian;
            uniform sampler2D _T2; uniform float4 _T2_ST;
            uniform sampler2D _T1; uniform float4 _T1_ST;
            uniform float _grain;
            uniform float4 _color_bian;
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
                float4 node_3791 = _Time + _TimeEditor;
                float node_6316_ang = node_3791.g;
                float node_6316_spd = (-0.5);
                float node_6316_cos = cos(node_6316_spd*node_6316_ang);
                float node_6316_sin = sin(node_6316_spd*node_6316_ang);
                float2 node_6316_piv = float2(0.5,0.5);
                float2 node_6316 = (mul(i.uv0-node_6316_piv,float2x2( node_6316_cos, -node_6316_sin, node_6316_sin, node_6316_cos))+node_6316_piv);
                float4 _T1_var = tex2D(_T1,TRANSFORM_TEX(node_6316, _T1));
                float node_5268_ang = node_3791.g;
                float node_5268_spd = 1.0;
                float node_5268_cos = cos(node_5268_spd*node_5268_ang);
                float node_5268_sin = sin(node_5268_spd*node_5268_ang);
                float2 node_5268_piv = float2(0.5,0.5);
                float2 node_5268 = (mul(i.uv0-node_5268_piv,float2x2( node_5268_cos, -node_5268_sin, node_5268_sin, node_5268_cos))+node_5268_piv);
                float4 _T2_var = tex2D(_T2,TRANSFORM_TEX(node_5268, _T2));
                float4 _DITU_var = tex2D(_DITU,TRANSFORM_TEX(i.uv0, _DITU));
                float4 _BIAN_var = tex2D(_BIAN,TRANSFORM_TEX(i.uv0, _BIAN));
                float node_3439 = 1.0;
                float node_8317_if_leA = step((_BIAN_var.rgb*(_Dissolve+_bian)),node_3439);
                float node_8317_if_leB = step(node_3439,(_BIAN_var.rgb*(_Dissolve+_bian)));
                float node_9397 = 0.0;
                float3 node_8317 = lerp((node_8317_if_leA*node_9397)+(node_8317_if_leB*node_3439),node_9397,node_8317_if_leA*node_8317_if_leB);
                float node_2327_if_leA = step((_BIAN_var.rgb*_Dissolve),node_3439);
                float node_2327_if_leB = step(node_3439,(_BIAN_var.rgb*_Dissolve));
                float3 emissive = ((((_T1_var.rgb*_T2_var.rgb*_grain)+(_DITU_var.rgb*_lightness))*node_8317*i.vertexColor.rgb*i.vertexColor.a)+((node_8317-lerp((node_2327_if_leA*node_9397)+(node_2327_if_leB*node_3439),node_9397,node_2327_if_leA*node_2327_if_leB))*_color_bian.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
