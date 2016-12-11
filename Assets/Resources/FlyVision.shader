

Shader "Hidden/FlyVision"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#define R .05
			#define SQRT3 1.732050807
			#define PI 3.141592653

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			float2 hexCenter(float2 id, int odd)
			{
				return float2(
					SQRT3 * R * (id.x +.5*odd),
					1.5 * id.y * R
					);
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				i.uv += 1;
				int2 grid;

				//Estimate hex coordinate
				grid.y = i.uv.y / (1.5*R);
				uint odd = grid.y%2;
				grid.x = i.uv.x / (SQRT3 * R) - odd*.5;

				//Find possible centers of hexagons
				float2 h1 = hexCenter(grid, odd);
				float2 h2 = hexCenter(grid + int2(1,0), odd);
				float2 h3 = hexCenter(grid + int2(odd, 1), 1-odd);

				//Find closest center
				float d1 = (h1.x - i.uv.x)*(h1.x - i.uv.x) + (h1.y - i.uv.y)*(h1.y - i.uv.y);
				float d2 = (h2.x - i.uv.x)*(h2.x - i.uv.x) + (h2.y - i.uv.y)*(h2.y - i.uv.y);
				float d3 = (h3.x - i.uv.x)*(h3.x - i.uv.x) + (h3.y - i.uv.y)*(h3.y - i.uv.y);
				//fixed4 col = fixed4(d3/R , 0, 0, 1);
				float d = d1;
				if (d2 < d1)
				{
					d1 = d2;
					h1 = h2;
				}
				if (d3 < d1)
				{
					d1 = d3;
					h1 = h3;
				}
				
				float2 uv = i.uv - h1;
				//uv.x += .5 * SQRT3*R;
				//uv.y += R;
				float2 coords = uv;
				coords = (coords - 0.5*R) * 2.0;

				float2 realCoordOffs;
				realCoordOffs.x = (1 - coords.y * coords.y) * 1 * (coords.x);
				realCoordOffs.y = (1 - coords.x * coords.x) * 1 * (coords.y);
				uv -= realCoordOffs*R;

				uv += (i.uv - 1);


				//fixed4 col = fixed4(odd, 0, 0, 1);
				fixed4 col = tex2D(_MainTex, uv) - length(2*uv-1)*.6;

				//Reduce Reb chanel
				col.x = sqrt( 16 * col.x)/12;
				return col;
			}
			ENDCG
		}
	}
}
