Shader "StudyEditor/MaterialPropertyDrawShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		
		[Space(20)]
		[Header(DIFFUSE)]
		[Toggle]_DiffuseOn ("Enable Diffuse",Float)=0
							
		[Space(10)]
		[Header(SPECULAR)]
		[Toggle]_SpecularOn("Enable Specular",Float)=0
		_SepcularColor("Specular Color",COLOR)=(0.5,0.5,0.5,1)
		[PowerSlider(1)]  _Gloss("Gloss",Range(8,256))=8
		[Space(20)]
	
		[Enum(UnityEngine.Rendering.CullMode)]_CullMode("Cull Mode",Float)=1
		[KeywordEnum(None,Black,White)]_OverLay("Color Mode",Float)=0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Cull [_CullMode]

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#pragma shader_feature	_DIFFUSEON_ON
			#pragma shader_feature	_SPECULARON_ON

			#pragma multi_compile _OVERLAY_NONE _OVERLAY_BLACK _OVERLAY_WHITE

			#include "UnityCG.cginc"
			#include "Lighting.cginc"			

			struct v2f
			{
				float2 uv : TEXCOORD0;				
				float4 vertex : SV_POSITION;
				float3 wNormal:TEXCOORD1;	
				float3 wLight:TEXCOORD2;
				float3 wView:TEXCOORD3;			
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;		
			fixed4 _SepcularColor;
			float _Gloss;
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);	
				o.wNormal=UnityObjectToWorldNormal(v.normal);	
				o.wLight=UnityWorldSpaceLightDir(v.vertex);	
				o.wView=UnityObjectToViewPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{									 
				fixed4 albedo = tex2D(_MainTex, i.uv);
								
				fixed4 diffuse=(dot(i.wNormal,i.wLight)*0.5+0.5)*_LightColor0*albedo;
				float halfD=dot(i.wNormal,i.wView);
			    fixed4 specular= _LightColor0*_SepcularColor*pow(saturate(dot(halfD,i.wNormal)),_Gloss);
												
				fixed4 finalColor=albedo;	
				#if _DIFFUSEON_ON
				 finalColor=diffuse;
				#endif
				#if _SPECULARON_ON
				 finalColor+=specular; 				
				#endif

				#if _OVERLAY_BLACK
				finalColor= fixed4(0,0,0,0)	;
				#elif _OVERLAY_WHITE
				finalColor= fixed4(1,1,1,1)	;
				#endif

				 return finalColor;							
			}
			ENDCG
		}
	}
}
