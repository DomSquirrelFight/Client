// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33043,y:32795,varname:node_4795,prsc:2|emission-1771-OUT;n:type:ShaderForge.SFN_Tex2d,id:2181,x:32406,y:32885,ptovrint:False,ptlb:tuan,ptin:_tuan,varname:node_3764,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f7daee86cb5581e40b97bcb28b328c56,ntxv:0,isnm:False|UVIN-1224-OUT;n:type:ShaderForge.SFN_Tex2d,id:6957,x:31636,y:32613,ptovrint:False,ptlb:wenli,ptin:_wenli,varname:node_1969,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:22ea4cbdc9fc6bb4b8ccc4ca4d97315f,ntxv:0,isnm:False|UVIN-1652-UVOUT;n:type:ShaderForge.SFN_Vector2,id:5302,x:31704,y:32959,varname:node_5302,prsc:2,v1:-15,v2:0;n:type:ShaderForge.SFN_Multiply,id:3081,x:31979,y:32793,varname:node_3081,prsc:2|A-6957-R,B-5302-OUT,C-1705-OUT;n:type:ShaderForge.SFN_Vector1,id:1705,x:31759,y:33123,varname:node_1705,prsc:2,v1:0.011;n:type:ShaderForge.SFN_Add,id:1224,x:32196,y:32885,varname:node_1224,prsc:2|A-3081-OUT,B-4816-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1771,x:32775,y:32933,varname:node_1771,prsc:2|A-2181-RGB,B-344-RGB,C-344-A;n:type:ShaderForge.SFN_VertexColor,id:344,x:32428,y:33120,varname:node_344,prsc:2;n:type:ShaderForge.SFN_Panner,id:1652,x:31441,y:32630,varname:node_1652,prsc:2,spu:0.33,spv:0.1|UVIN-4816-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4816,x:31278,y:32839,varname:node_4816,prsc:2,uv:0;proporder:2181-6957;pass:END;sub:END;*/

Shader "Particles/S_Fire001" {
    Properties {
        _tuan ("tuan", 2D) = "white" {}
        _wenli ("wenli", 2D) = "white" {}
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
            uniform sampler2D _tuan; uniform float4 _tuan_ST;
            uniform sampler2D _wenli; uniform float4 _wenli_ST;
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
                float4 node_3938 = _Time + _TimeEditor;
                float2 node_1652 = (i.uv0+node_3938.g*float2(0.33,0.1));
                float4 _wenli_var = tex2D(_wenli,TRANSFORM_TEX(node_1652, _wenli));
                float2 node_1224 = ((_wenli_var.r*float2(-15,0)*0.011)+i.uv0);
                float4 _tuan_var = tex2D(_tuan,TRANSFORM_TEX(node_1224, _tuan));
                float3 emissive = (_tuan_var.rgb*i.vertexColor.rgb*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
