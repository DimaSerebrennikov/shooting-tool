Shader "URP/TriplanarCheckerboard_PointLight" {
	Properties {
		_ColorA ("Color A", Color) = (1,1,1,1)
		_ColorB ("Color B", Color) = (0,0,0,1)
		_Scale ("Scale", Float) = 1.0
		_LightPositionWS ("Light Position (WS)", Vector) = (0,0,0,1)
		_LightColor ("Light Color", Color) = (1,1,1,1)
		_LightIntensity("Light Intensity", Float) = 1.0
		_LightRange ("Light Range", Float) = 10.0
	}
	SubShader {
		Tags {
			"RenderPipeline" = "UniversalRenderPipeline"
			"RenderType" = "Opaque"
		}
		Pass {
			Name "Forward"
			Tags {
				"LightMode" = "UniversalForward"
			}
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			struct Attributes {
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
			};
			struct Varyings {
				float4 positionHCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float3 normalWS : TEXCOORD1;
			};
			float4   _ColorA;
			float4   _ColorB;
			float    _Scale;
			float4  _LightPositionWS;
			float4   _LightColor;
			float    _LightIntensity;
			float    _LightRange;
			Varyings vert(Attributes input) {
				Varyings             output;
				VertexPositionInputs pos = GetVertexPositionInputs(input.positionOS.xyz);
				VertexNormalInputs   nor = GetVertexNormalInputs(input.normalOS);
				output.positionHCS = pos.positionCS;
				output.positionWS = pos.positionWS;
				output.normalWS = nor.normalWS;
				
				return output;
				
			}
			float Checker(float2 uv) {
				uv = floor(uv);
				return fmod(abs(uv.x + uv.y), 2.0);
			}
			float4 SampleChecker(float2 uv) {
				float checker = Checker(uv);
				return lerp(_ColorA, _ColorB, checker);
			}
			float4 frag(Varyings input) : SV_Target {
				float3 positionWS = input.positionWS * _Scale;
				float3 normalWS = normalize(input.normalWS);
				float3 weight = abs(normalWS); /*triplanar weights*/
				weight /= (weight.x + weight.y + weight.z);
				float4 colorX = SampleChecker(positionWS.yz);
				float4 colorY = SampleChecker(positionWS.xz);
				float4 colorZ = SampleChecker(positionWS.xy);
				float4 baseColor =
				colorX * weight.x +
				colorY * weight.y +
				colorZ * weight.z;
				float3 toLight = _LightPositionWS.xyz - input.positionWS; /*custom point light*/
				float  distance = length(toLight);
				float3 lightDir = toLight / max(distance, 0.0001);
				float  NdotL = saturate(dot(normalWS, lightDir));
				float  attenuation = saturate(1.0 - distance / _LightRange);
				attenuation *= attenuation; /*smoother falloff*/
				float3 diffuse =
				baseColor.rgb *
				_LightColor.rgb *
				(NdotL * attenuation * _LightIntensity);
				return float4(diffuse, baseColor.a);
			}
			ENDHLSL
		}
	}
}