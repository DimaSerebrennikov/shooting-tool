Shader "Serebrennikov/Generate testing material for a texture sample" {
	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			v2f vert(uint id : SV_VertexID) {
				v2f o;
				o.uv = float2((id << 1) & 2, id & 2);
				o.pos = float4(o.uv * 2 - 1, 0, 1);
				return o;
			}
			float4 frag(v2f i) : SV_Target {
				return float4(i.uv.x, i.uv.y, 0, 1);
			}
			ENDHLSL
		}
	}
}