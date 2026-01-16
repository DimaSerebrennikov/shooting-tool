Shader "Serebrennikov/NormalZGradient" {
	Properties {
		_ColorA ("Color A (Z -1)", Color) = (0,0,0,1)
		_ColorB ("Color B (Z +1)", Color) = (1,1,1,1)
		_ColorVignetting ("Color _ColorVignetting", Color) = (0,0,0,1)
		_Power ("Power", Float) = 1
	}

	SubShader {
		Tags {
			"RenderPipeline"="UniversalPipeline"
			"RenderType"="Opaque"
		}

		Pass {
			Name "Unlit"
			Tags {
				"LightMode"="UniversalForward"
			}

			HLSLPROGRAM
			#pragma vertex Vert
			#pragma fragment Frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			struct Attributes {
				float3 positionOS : POSITION;
				float3 normalOS : NORMAL;
			};
			struct Varyings {
				float4 positionCS : SV_POSITION;
				float3 normalWS : TEXCOORD0;
				float3 normalVS : TEXCOORD1; // camera-relative direction
			};
			CBUFFER_START(UnityPerMaterial)
				float4 _ColorA;
				float4 _ColorB;
				float  _Power;
				float4 _ColorVignetting;
			CBUFFER_END
			Varyings Vert(Attributes input) {
				Varyings output;
				float3   positionWS = TransformObjectToWorld(input.positionOS);
				output.positionCS = TransformWorldToHClip(positionWS);
				float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
				output.normalWS = normalWS;
				output.normalVS = TransformWorldToViewDir(normalWS);
				return output;
			}
			half4 Frag(Varyings input) : SV_Target {
				// ---- World-space gradient ----
				float3 normalWS = normalize(input.normalWS);
				float  value = normalWS.z; // [-1, 1]
				value = value * 0.5 + 0.5; // [0, 1]
				value = pow(value, _Power);
				half3 gradientColor =
				lerp(_ColorA.rgb, _ColorB.rgb, value);
				return half4(gradientColor, 1.0);
			}
			ENDHLSL
		}
	}
}