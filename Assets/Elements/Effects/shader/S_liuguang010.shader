// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-6523-OUT;n:type:ShaderForge.SFN_Tex2d,id:5059,x:32597,y:33114,ptovrint:False,ptlb:Xiaosang,ptin:_Xiaosang,varname:node_521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aef2d72c5a7c0374ab5d4e3e7dfea779,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4804,x:31235,y:32690,ptovrint:False,ptlb:niuqu,ptin:_niuqu,varname:node_2728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26cca6af0bec8a94eaefe7a317622d3c,ntxv:0,isnm:False|UVIN-3840-UVOUT;n:type:ShaderForge.SFN_Panner,id:3840,x:30984,y:33032,varname:node_3840,prsc:2,spu:0.2,spv:0.2|UVIN-4684-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4684,x:30690,y:32554,varname:node_4684,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1859,x:31486,y:32755,varname:node_1859,prsc:2|A-4804-R,B-889-OUT;n:type:ShaderForge.SFN_Vector1,id:889,x:31247,y:32943,varname:node_889,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:2420,x:31486,y:32539,varname:node_2420,prsc:2|A-4684-UVOUT,B-1859-OUT;n:type:ShaderForge.SFN_Tex2d,id:5353,x:31925,y:32648,ptovrint:False,ptlb:wenli01,ptin:_wenli01,varname:node_494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2bb830885e4d9d54c90aacab4eaafa42,ntxv:0,isnm:False|UVIN-3547-UVOUT;n:type:ShaderForge.SFN_Rotator,id:3547,x:31750,y:32534,varname:node_3547,prsc:2|UVIN-2420-OUT,SPD-3368-OUT;n:type:ShaderForge.SFN_Vector1,id:3368,x:31725,y:32755,varname:node_3368,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:2051,x:31484,y:33070,varname:node_2051,prsc:2|A-4684-UVOUT,B-1859-OUT;n:type:ShaderForge.SFN_Tex2d,id:5335,x:31731,y:33020,ptovrint:False,ptlb:wenli02,ptin:_wenli02,varname:_node_494_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9a40b3d7946254a4b97c2ca7c5cfeac0,ntxv:0,isnm:False|UVIN-2051-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5441,x:32077,y:32977,ptovrint:False,ptlb:qiangdu,ptin:_qiangdu,varname:node_4905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector3,id:548,x:31950,y:32534,varname:node_548,prsc:2,v1:5,v2:4,v3:1;n:type:ShaderForge.SFN_Multiply,id:685,x:32077,y:32697,varname:node_685,prsc:2|A-548-OUT,B-5353-R;n:type:ShaderForge.SFN_Multiply,id:3854,x:32313,y:32680,varname:node_3854,prsc:2|A-685-OUT,B-8762-OUT,C-5441-OUT;n:type:ShaderForge.SFN_Multiply,id:5698,x:31915,y:32834,varname:node_5698,prsc:2|A-8739-OUT,B-5335-R;n:type:ShaderForge.SFN_Vector3,id:8739,x:31750,y:32803,varname:node_8739,prsc:2,v1:1,v2:0.6102941,v3:0.6102941;n:type:ShaderForge.SFN_Power,id:8762,x:32098,y:32822,varname:node_8762,prsc:2|VAL-5698-OUT,EXP-3201-OUT;n:type:ShaderForge.SFN_Vector1,id:3201,x:31926,y:33127,varname:node_3201,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Add,id:3451,x:32361,y:32877,varname:node_3451,prsc:2|A-3854-OUT,B-1182-OUT;n:type:ShaderForge.SFN_Tex2d,id:7193,x:32140,y:33076,ptovrint:False,ptlb:node_6958,ptin:_node_6958,varname:node_6958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:880ba9b32ea617c43ba3a36af392bd3f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:4589,x:32498,y:32680,varname:node_4589,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6523,x:32523,y:32843,varname:node_6523,prsc:2|A-4589-RGB,B-3451-OUT,C-5059-RGB;n:type:ShaderForge.SFN_Vector1,id:59,x:31972,y:33222,varname:node_59,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:1182,x:32404,y:33206,varname:node_1182,prsc:2|A-7193-RGB,B-59-OUT,C-9909-OUT;n:type:ShaderForge.SFN_Vector3,id:9909,x:32192,y:33323,varname:node_9909,prsc:2,v1:2,v2:1.5,v3:1;proporder:5059-4804-5353-5335-5441-7193;pass:END;sub:END;*/

Shader "Particles/S_liuguang010" {
    Properties {
        _Xiaosang ("Xiaosang", 2D) = "white" {}
        _niuqu ("niuqu", 2D) = "white" {}
        _wenli01 ("wenli01", 2D) = "white" {}
        _wenli02 ("wenli02", 2D) = "white" {}
        _qiangdu ("qiangdu", Float ) = 1
        _node_6958 ("node_6958", 2D) = "white" {}
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
            uniform sampler2D _Xiaosang; uniform float4 _Xiaosang_ST;
            uniform sampler2D _niuqu; uniform float4 _niuqu_ST;
            uniform sampler2D _wenli01; uniform float4 _wenli01_ST;
            uniform sampler2D _wenli02; uniform float4 _wenli02_ST;
            uniform float _qiangdu;
            uniform sampler2D _node_6958; uniform float4 _node_6958_ST;
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
                float4 node_9879 = _Time + _TimeEditor;
                float node_3547_ang = node_9879.g;
                float node_3547_spd = 0.1;
                float node_3547_cos = cos(node_3547_spd*node_3547_ang);
                float node_3547_sin = sin(node_3547_spd*node_3547_ang);
                float2 node_3547_piv = float2(0.5,0.5);
                float2 node_3840 = (i.uv0+node_9879.g*float2(0.2,0.2));
                float4 _niuqu_var = tex2D(_niuqu,TRANSFORM_TEX(node_3840, _niuqu));
                float node_1859 = (_niuqu_var.r*0.2);
                float2 node_3547 = (mul((i.uv0+node_1859)-node_3547_piv,float2x2( node_3547_cos, -node_3547_sin, node_3547_sin, node_3547_cos))+node_3547_piv);
                float4 _wenli01_var = tex2D(_wenli01,TRANSFORM_TEX(node_3547, _wenli01));
                float2 node_2051 = (i.uv0+node_1859);
                float4 _wenli02_var = tex2D(_wenli02,TRANSFORM_TEX(node_2051, _wenli02));
                float4 _node_6958_var = tex2D(_node_6958,TRANSFORM_TEX(i.uv0, _node_6958));
                float4 _Xiaosang_var = tex2D(_Xiaosang,TRANSFORM_TEX(i.uv0, _Xiaosang));
                float3 emissive = (i.vertexColor.rgb*(((float3(5,4,1)*_wenli01_var.r)*pow((float3(1,0.6102941,0.6102941)*_wenli02_var.r),1.5)*_qiangdu)+(_node_6958_var.rgb*0.3*float3(2,1.5,1)))*_Xiaosang_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
