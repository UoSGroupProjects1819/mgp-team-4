// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Echolocation" {
	Properties{
		_Color("Color", Color) = (1, 1, 1, 1)
		_Center1("Center1", vector) = (0, 0, 0)
		_Center2("Center2", vector) = (0, 0, 0)
		_Center3("Center3", vector) = (0, 0, 0)
		_Radius1("Radius1", float) = 0
		_Radius2("Radius2", float) = 0
		_Radius3("Radius3", float) = 0
	}
		SubShader{
			Pass {
				Tags { "RenderType" = "Opaque" }

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				float4 _Color;
				float3 _Center1;
				float3 _Center2;
				float3 _Center3;
				float _Radius1;
				float _Radius2;
				float _Radius3;

				struct v2f {
					float4 pos : SV_POSITION;
					float3 worldPos : TEXCOORD1;
				};

				v2f vert(appdata_base v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
					return o;
				}

				fixed4 frag(v2f i) : COLOR {
					float dist1 = distance(_Center1, i.worldPos);
					float dist2 = distance(_Center2, i.worldPos);
					float dist3 = distance(_Center3, i.worldPos);

					float val1 = 1 - step(dist1, _Radius1 - 0.1) * 0.5 / _Color.a;
					val1 = step(_Radius1 - 10, dist1) * step(dist1, _Radius1) * val1;
					float val2 = 1 - step(dist2, _Radius2 - 0.1) * 0.5 / _Color.a;					
					val2 = step(_Radius2 - 10, dist2) * step(dist2, _Radius2) * val2;
					float val3 = 1 - step(dist3, _Radius3 - 0.1) * 0.5 / _Color.a;
					val3 = step(_Radius3 - 10, dist3) * step(dist3, _Radius3) * val3;
					
					float val = val1 + val2 + val3;
					return fixed4(val * _Color.r, val * _Color.g,val * _Color.b, 1.0);
				}

				ENDCG
			}
	}
		FallBack "Diffuse"
}