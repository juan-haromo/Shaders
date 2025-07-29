void SimpleMultiply_float(float a, float4 b, out float4 result){
    result = a * b;
}

//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"


void GetMainLight_float(out float3 lightDir, out float3 color){
    #ifdef SHADERGRAPH_PREVIEW
    lightDir = float3(0.5,0.5,0.5);
    color = float3(1,1,0.9);
    #else
    Light mainLight = GetMainLight();
    lightDir = mainLight.direction;
    color = mainLight.color;
    #endif
 }   
    