Shader "Custom/Test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Texture property for the main texture
        _GridColor ("Grid Color", Color) = (1,1,1,1) // Color property for the grid lines
        _GridSize ("Grid Size", Range(0.1, 10)) = 1 // Size property for the grid spacing
        _GridLineColor ("Grid Line Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" } // Tag to indicate this shader renders opaque objects
        LOD 200 // Level of detail for the shader

        Pass
        {
            CGPROGRAM
            #pragma vertex vert // Vertex shader function declaration
            #pragma fragment frag // Fragment (pixel) shader function declaration

            #include "UnityCG.cginc" // Include Unity's CG library

            // Input structure for vertices
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // Output structure from vertex shader
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Shader properties
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _GridColor;
            float _GridSize;
            fixed4 _GridLineColor;

            // Vertex shader function
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // Transform vertex position to clip space
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // Transform texture coordinates
                return o;
            }

            // Fragment shader function
            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate grid coordinates
                float2 uv = i.uv * _GridSize;
                float2 grid = fmod(uv, 1.0);
                float2 border = fwidth(uv);

                // Calculate grid lines
                float2 gridLines = step(border, grid) * step(grid, 1.0 - border);

                // Sample main texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                // Multiply color by grid lines to create grid effect
                col.rgb *= _GridLineColor.rgb * gridLines.x * gridLines.y;
                return col;
            }
            ENDCG // End CG program
        }
    }
}
