﻿Shader "Cody/UI/FollowCameraWithStencil"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_ScaleX("Width", float) = 1
		_ScaleY("Height", float) = 1
		_Scale("Scale", float) = 1
		_StencilRef("Stencil Ref", int) = 1
	}
	SubShader
	{
		Tags { "Queue"="Transparent+1" "RenderType"="Transparent" }

		Stencil 
        {
            Ref [_StencilRef]
            Comp equal
            Pass keep
        }

		Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag		
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _ScaleX, _ScaleY, _Scale;
			fixed4 _Color;
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_P, mul(UNITY_MATRIX_MV, float4(0, 0, 0, 1)) + float4(v.vertex.x, v.vertex.y, 0, 0)) ;
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.pos.x *= _ScaleX;
				o.pos.y *= _ScaleY;
				o.pos.xy *= _Scale;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
//            	col.Albedo = c.rgb;
//            	col.Alpha = c.a;
				return col;
			}
			ENDCG
		}
	}
}