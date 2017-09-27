Shader "Custom/Vertices" {
	Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _Amount ("Enlarge Amount", Range(-0.015,0.03)) = 0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Tags { "Queue" = "Transparant" }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
      };
      float _Amount;
      void vert (inout appdata_full v) {
          v.vertex.xyz += v.normal * _Amount / 2;
          v.vertex.x += v.normal * _Amount * 2;
                  

      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
         o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 

}
