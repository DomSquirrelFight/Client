// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32470,y:32808,varname:node_4795,prsc:2|emission-67-OUT;n:type:ShaderForge.SFN_Tex2d,id:945,x:31851,y:33019,ptovrint:False,ptlb:Main,ptin:_Main,varname:node_945,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6a6cca3a6a092734895cb6574b52e52d,ntxv:0,isnm:False|UVIN-7331-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3506,x:31655,y:32738,ptovrint:False,ptlb:Wenli,ptin:_Wenli,varname:node_3506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7d1ec91c34ed2064483b76cfe2851d1a,ntxv:0,isnm:False|UVIN-1934-OUT;n:type:ShaderForge.SFN_Rotator,id:7331,x:31651,y:33019,varname:node_7331,prsc:2|UVIN-8412-UVOUT,SPD-7624-OUT;n:type:ShaderForge.SFN_TexCoord,id:8412,x:30638,y:32708,varname:node_8412,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:2456,x:32064,y:32921,varname:node_2456,prsc:2|A-534-OUT,B-945-R;n:type:ShaderForge.SFN_Multiply,id:67,x:32260,y:32921,varname:node_67,prsc:2|A-2456-OUT,B-192-RGB,C-2195-OUT,D-2124-OUT;n:type:ShaderForge.SFN_VertexColor,id:192,x:32064,y:33046,varname:node_192,prsc:2;n:type:ShaderForge.SFN_Vector1,id:7624,x:31494,y:33080,varname:node_7624,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:4166,x:31126,y:32836,ptovrint:False,ptlb:Rongjie,ptin:_Rongjie,varname:node_4166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87b1f9cd67cc874c97483c110978c9e,ntxv:0,isnm:False|UVIN-5021-UVOUT;n:type:ShaderForge.SFN_Panner,id:5021,x:30964,y:32836,varname:node_5021,prsc:2,spu:0.025,spv:-0.05|UVIN-8412-UVOUT;n:type:ShaderForge.SFN_Add,id:1934,x:31494,y:32738,varname:node_1934,prsc:2|A-8412-UVOUT,B-9164-OUT;n:type:ShaderForge.SFN_Power,id:534,x:31869,y:32805,varname:node_534,prsc:2|VAL-3506-G,EXP-8181-OUT;n:type:ShaderForge.SFN_Multiply,id:9164,x:31308,y:32836,varname:node_9164,prsc:2|A-4166-R,B-5160-OUT;n:type:ShaderForge.SFN_Vector1,id:5160,x:31126,y:32989,varname:node_5160,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:2195,x:32064,y:33195,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_2195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Slider,id:8181,x:31465,y:32924,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_8181,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Step,id:2124,x:31750,y:33242,varname:node_2124,prsc:2|A-4166-R,B-192-A;proporder:945-3506-4166-2195-8181;pass:END;sub:END;*/

Shader "Particles/S_Fire003" {
    Properties {
        _Main ("Main", 2D) = "white" {}
        _Wenli ("Wenli", 2D) = "white" {}
        _Rongjie ("Rongjie", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 2
        _Power ("Power", Range(0, 1)) = 0
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
            uniform sampler2D _Main; uniform float4 _Main_ST;
            uniform sampler2D _Wenli; uniform float4 _Wenli_ST;
            uniform sampler2D _Rongjie; uniform float4 _Rongjie_ST;
            uniform float _qiangdu;
            uniform float _Power;
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
                float4 node_4281 = _Time + _TimeEditor;
                float2 node_5021 = (i.uv0+node_4281.g*float2(0.025,-0.05));
                float4 _Rongjie_var = tex2D(_Rongjie,TRANSFORM_TEX(node_5021, _Rongjie));
                float2 node_1934 = (i.uv0+(_Rongjie_var.r*0.1));
                float4 _Wenli_var = tex2D(_Wenli,TRANSFORM_TEX(node_1934, _Wenli));
                float node_7331_ang = node_4281.g;
                float node_7331_spd = 0.2;
                float node_7331_cos = cos(node_7331_spd*node_7331_ang);
                float node_7331_sin = sin(node_7331_spd*node_7331_ang);
                float2 node_7331_piv = float2(0.5,0.5);
                float2 node_7331 = (mul(i.uv0-node_7331_piv,float2x2( node_7331_cos, -node_7331_sin, node_7331_sin, node_7331_cos))+node_7331_piv);
                float4 _Main_var = tex2D(_Main,TRANSFORM_TEX(node_7331, _Main));
                float3 emissive = ((pow(_Wenli_var.g,_Power)*_Main_var.r)*i.vertexColor.rgb*_qiangdu*step(_Rongjie_var.r,i.vertexColor.a));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
