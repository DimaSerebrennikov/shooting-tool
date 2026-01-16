Shader "Serebrennikov/URP_BillboardFill" {
	Properties {
		_ColorA("Left Color", Color) = (0, 1, 0, 1)
		_ColorB("Right Color", Color) = (1, 0, 0, 1)
		_FillAmount("Fill Amount", Range(0, 1)) = 0.5
		_Size("Billboard Size (Width, Height)", Vector) = (1, 0.25, 0, 0)
	}

	SubShader {
		Tags {
			"RenderType" = "Opaque"
			"Queue" = "Geometry"
		}

		Pass {
			Name "Unlit"
			Tags {
				"LightMode" = "UniversalForward"
			}

			Blend One Zero
			ZWrite On
			Cull Back

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			struct Attributes {
				float4 positionOS : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct Varyings {
				float4 positionHCS : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			float4   _ColorA;
			float4   _ColorB;
			float    _FillAmount;
			float4   _Size; // xy = width, height
			Varyings vert(Attributes IN) {
				Varyings OUT;
				float3   objPos = mul(unity_ObjectToWorld, float4(0, 0, 0, 1)).xyz;
				float3   toCam = normalize(objPos - _WorldSpaceCameraPos.xyz);
				float3   worldUp = float3(0, 1, 0);
				float3   right = normalize(cross(worldUp, toCam));
				float3   up = normalize(cross(toCam, right));
				// Apply custom width and height scaling
				float3 localPos = IN.positionOS.xyz;
				localPos.x *= _Size.x;
				localPos.y *= _Size.y;
				float3 worldPos = objPos + right * localPos.x + up * localPos.y;
				OUT.positionHCS = TransformWorldToHClip(worldPos);
				OUT.uv = IN.uv;
				return OUT;
			}
			half4 frag(Varyings IN) : SV_Target {
				// Step threshold between the two colors
				float t = step(_FillAmount, IN.uv.x);
				return lerp(_ColorA, _ColorB, t);
			}
			ENDHLSL
		}
	}

	FallBack Off
}