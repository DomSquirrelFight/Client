// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:33038,y:32691,varname:node_4795,prsc:2|emission-7145-OUT;n:type:ShaderForge.SFN_Color,id:750,x:31741,y:32691,ptovrint:False,ptlb:color_W,ptin:_color_W,varname:node_750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.8795882,c3:0.3455882,c4:1;n:type:ShaderForge.SFN_Multiply,id:4481,x:31945,y:32691,varname:node_4481,prsc:2|A-1298-RGB,B-750-RGB,C-1801-OUT;n:type:ShaderForge.SFN_Tex2d,id:2338,x:31741,y:32944,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_2338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:39709ea8bbce3f54a9cde6944e1d2ce1,ntxv:0,isnm:False|UVIN-3486-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1298,x:31741,y:32513,ptovrint:False,ptlb:Wenli,ptin:_Wenli,varname:node_1298,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:61203a7932c42f24d88474db0fa0c735,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6434,x:32360,y:32938,varname:node_6434,prsc:2|A-6363-OUT,B-9638-OUT;n:type:ShaderForge.SFN_Color,id:4475,x:31741,y:33124,ptovrint:False,ptlb:Color_G,ptin:_Color_G,varname:node_4475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9779412,c2:0.4926601,c3:0.05752595,c4:1;n:type:ShaderForge.SFN_TexCoord,id:3010,x:31222,y:32944,varname:node_3010,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:3486,x:31566,y:32944,varname:node_3486,prsc:2,spu:1,spv:0|UVIN-648-UVOUT;n:type:ShaderForge.SFN_Vector1,id:4081,x:31741,y:33280,varname:node_4081,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:8961,x:31961,y:33084,varname:node_8961,prsc:2|A-2338-RGB,B-4475-RGB,C-4081-OUT;n:type:ShaderForge.SFN_Multiply,id:6363,x:32118,y:32815,varname:node_6363,prsc:2|A-4481-OUT,B-8961-OUT;n:type:ShaderForge.SFN_Rotator,id:648,x:31400,y:33019,varname:node_648,prsc:2|UVIN-3010-UVOUT,ANG-7540-OUT;n:type:ShaderForge.SFN_Vector1,id:7540,x:31222,y:33175,varname:node_7540,prsc:2,v1:-0.8;n:type:ShaderForge.SFN_Add,id:593,x:32835,y:32915,varname:node_593,prsc:2|A-6434-OUT,B-3720-OUT;n:type:ShaderForge.SFN_Vector1,id:1801,x:31741,y:32840,varname:node_1801,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:5556,x:32714,y:33275,varname:node_5556,prsc:2|A-3440-RGB,B-4326-OUT,C-6015-OUT;n:type:ShaderForge.SFN_Vector3,id:4326,x:32450,y:33486,varname:node_4326,prsc:2,v1:1,v2:0.72437,v3:0.359;n:type:ShaderForge.SFN_Vector1,id:6015,x:32492,y:33634,varname:node_6015,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:9638,x:32226,y:32554,varname:node_9638,prsc:2|A-1298-RGB,B-3042-RGB,C-3703-OUT;n:type:ShaderForge.SFN_Color,id:3042,x:31930,y:32397,ptovrint:False,ptlb:color_W_copy,ptin:_color_W_copy,varname:_color_W_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9779412,c2:0.4926601,c3:0.05752595,c4:1;n:type:ShaderForge.SFN_Vector1,id:3703,x:31965,y:32599,varname:node_3703,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Tex2d,id:3440,x:32249,y:33347,ptovrint:False,ptlb:node_3440,ptin:_node_3440,varname:node_3440,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7145,x:32840,y:32755,varname:node_7145,prsc:2|A-2020-OUT,B-593-OUT;n:type:ShaderForge.SFN_Vector1,id:2020,x:32658,y:32755,varname:node_2020,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:3720,x:32897,y:33348,varname:node_3720,prsc:2|A-5556-OUT,B-4326-OUT;proporder:750-2338-1298-4475-3042-3440;pass:END;sub:END;*/

Shader "Particles/S_Hudun002" {
    Properties {
        _color_W ("color_W", Color) = (1,0.8795882,0.3455882,1)
        _Glow ("Glow", 2D) = "white" {}
        _Wenli ("Wenli", 2D) = "white" {}
        _Color_G ("Color_G", Color) = (0.9779412,0.4926601,0.05752595,1)
        _color_W_copy ("color_W_copy", Color) = (0.9779412,0.4926601,0.05752595,1)
        _node_3440 ("node_3440", 2D) = "white" {}
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
            uniform float4 _color_W;
            uniform sampler2D _Glow; uniform float4 _Glow_ST;
            uniform sampler2D _Wenli; uniform float4 _Wenli_ST;
            uniform float4 _Color_G;
            uniform float4 _color_W_copy;
            uniform sampler2D _node_3440; uniform float4 _node_3440_ST;
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
                float4 _Wenli_var = tex2D(_Wenli,TRANSFORM_TEX(i.uv0, _Wenli));
                float4 node_7930 = _Time + _TimeEditor;
                float node_648_ang = (-0.8);
                float node_648_spd = 1.0;
                float node_648_cos = cos(node_648_spd*node_648_ang);
                float node_648_sin = sin(node_648_spd*node_648_ang);
                float2 node_648_piv = float2(0.5,0.5);
                float2 node_648 = (mul(i.uv0-node_648_piv,float2x2( node_648_cos, -node_648_sin, node_648_sin, node_648_cos))+node_648_piv);
                float2 node_3486 = (node_648+node_7930.g*float2(1,0));
                float4 _Glow_var = tex2D(_Glow,TRANSFORM_TEX(node_3486, _Glow));
                float4 _node_3440_var = tex2D(_node_3440,TRANSFORM_TEX(i.uv0, _node_3440));
                float3 node_4326 = float3(1,0.72437,0.359);
                float3 emissive = (2.0*((((_Wenli_var.rgb*_color_W.rgb*3.0)*(_Glow_var.rgb*_Color_G.rgb*1.5))+(_Wenli_var.rgb*_color_W_copy.rgb*0.1))+((_node_3440_var.rgb*node_4326*0.3)*node_4326)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
