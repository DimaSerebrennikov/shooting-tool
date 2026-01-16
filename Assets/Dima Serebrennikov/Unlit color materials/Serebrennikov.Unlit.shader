Shader "Serebrennikov/Unlit" {
	Properties {
		_BaseColor ("Base Color", Color) = (1,1,1,1)
	}

	SubShader {
		Tags {
			"RenderPipeline"="UniversalRenderPipeline"
			"RenderType"="Opaque"
			"Queue"="Geometry"
		}

		Pass {
			Name "ForwardUnlit"
			Tags {
				"LightMode"="UniversalForward"
			}

			Cull Back
			ZWrite On
			ZTest LEqual
			Blend One Zero

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			struct Attributes {
				float4 positionOS : POSITION;
			};
			struct Varyings {
				float4 positionCS : SV_POSITION;
			};
			CBUFFER_START(UnityPerMaterial)
				float4 _BaseColor;
			CBUFFER_END
			Varyings vert(Attributes IN) {
				Varyings OUT;
				OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
				return OUT;
			}
			half4 frag(Varyings IN) : SV_Target {
				return half4(_BaseColor.rgb, 1.0);
			}
			ENDHLSL
		}
	}

	Fallback Off
}