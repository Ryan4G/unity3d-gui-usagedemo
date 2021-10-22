Shader "Custom/My3DFont"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent"
        "IgnoreProjector" = "True"
        "Queue" = "Transparent" }

        LOD 200

        Pass{
            Material{
                Diffuse[_Color]
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Lighting Off
            Cull Off
            ZTest Always
            ZWrite Off
            Fog {Mode Off}
            SetTexture[_MainTex]{
                constantColor[_Color]
                combine texture * constant
            }
        }
    }
    FallBack "Diffuse"
}
