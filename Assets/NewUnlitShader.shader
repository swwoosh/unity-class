Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex("Base Layer(RGB)", 2D) = "white" {}    // 纹理    
        _ScrollX("Horizontal",Float) = 0.5   // 水平滚动速度
        _ScrollY("Vercital",Float) = 0.5   // 水平滚动速度
    }

        SubShader
        {
            Tags{ "RenderType" = "Opaque" "Queue" = "Geometry" }
            LOD 100

            Pass
            {
                Tags{ "LightMode" = "ForwardBase" }
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag


                #include "UnityCG.cginc"

                struct a2v
                {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _ScrollX;
                float _ScrollY;

                v2f vert(a2v v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex) + frac(float2 (_ScrollX, _ScrollY) * _Time.y);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 c = tex2D(_MainTex, i.uv.xy);
                    return c;
                }
                ENDCG
            }
        }
            FallBack "VertexLit"
}