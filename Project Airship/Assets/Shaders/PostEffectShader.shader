Shader "Custom/PostEffectShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NoiseTex("Noise Texture", 2D) = "white" {}
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
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _NoiseTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                //Add Noise
                fixed4 noi = tex2D(_NoiseTex, i.uv);
                col.rgb *= noi.rgb;

                //Move to Greyscale                
                col.rgb = (0.3f * col.r) + (0.59f * col.g) + (0.11f * col.b);

                //Push from center
                col.rgb = col.rgb - 0.5f;
                col.rgb *= 1.1f;
                col.rgb += 0.5f;
                                
                return col;
            }
            ENDCG
        }
    }
}
