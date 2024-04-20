Shader "Custom/GridShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _GridColor;
        float _GridSpacing;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 mainTexColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = mainTexColor.rgb; // Set the surface color to the main texture color
            o.Alpha = mainTexColor.a; // Set the surface alpha to the main texture alpha

            // Calculate UV coordinates for grid lines
            float2 gridUV = IN.uv_MainTex / _GridSpacing;

            // Calculate distance to nearest grid line in both directions
            float2 gridLines = fmod(abs(frac(gridUV) - 0.5), 1.0);

            // Calculate the distance to the nearest grid line
            float gridLine = min(gridLines.x, gridLines.y);

            // Calculate the grid color based on the grid line distance using smoothstep for smooth transitions
            fixed4 gridColor = _GridColor * (1.0 - smoothstep(0.48, 0.52, gridLine));

            // Add grid color to the surface color
            o.Albedo += gridColor.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
