/*===============================================================================
Copyright (c) 2019-2021 PTC Inc. All Rights Reserved.

Confidential and Proprietary - Protected under copyright and other laws.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
Shader "PointClouds/PointSplat"
{
    Properties {
        _PointSize("Point Size", Float) = 0.005
        [Toggle(USE_NORMALS)] _UseNormals("Use Normals", Float) = 0.0
    }

    SubShader
    {
        Tags {"Queue" = "Geometry-11" }
        Pass
        {
            Lighting Off
            Cull Back

            CGPROGRAM

            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #include "UnityCG.cginc"
            #define CUBE_DIAGONAL 1.73

            struct VertInput
            {
                float4 position : POSITION;
                half4 color : COLOR;
                half4 normal : NORMAL;
            };

            struct VertToGeom {
                float4 position : SV_POSITION;
                half4 color : COLOR;
                float4 right : TEXCOORD0;
                float4 up : TEXCOORD1;
                float4 normal : NORMAL;
            };

            struct VertOutput
            {
                float4 position : SV_POSITION;
                half4 color : COLOR;
            };

            float _PointSize;
            float _UseNormals;

            VertToGeom vert(VertInput v) {
                VertToGeom o;
                o.position = v.position;
                o.color = v.color;
                o.normal = v.normal;

                float3 upDir = normalize(UNITY_MATRIX_IT_MV[1].xyz);
                float3 viewDir = normalize(UNITY_MATRIX_IT_MV[2].xyz);
                float3 fwDir = viewDir; 
                float3 rightDir = normalize(cross(fwDir, upDir));
                
                const float splatSize = CUBE_DIAGONAL * _PointSize;
                o.up = float4(0.5 * splatSize * upDir, 0.0);
                o.right = float4(0.5 * splatSize * rightDir, 0.0);
                return o;
            }

            [maxvertexcount(4)]
            void geom(point VertToGeom input[1], inout TriangleStream<VertOutput> outTriangles) {
                float4 splatCenter = input[0].position;
                half4 splatColor = input[0].color;
                float4 right = input[0].right;
                float4 up = input[0].up;
                float3 normal = input[0].normal.xyz;
                float3 worldPos = mul(unity_ObjectToWorld, splatCenter).xyz;
                
                // Back face culling:
                if (_UseNormals > 0.5)
                {
                    float3 worldNormal = mul(unity_ObjectToWorld, float4(normal, 0.0)).xyz;
                    float3 worldPointToCam = normalize(_WorldSpaceCameraPos.xyz - worldPos);
                    if (dot(worldPointToCam, worldNormal) < 0.0)
                    {
                        return;
                    }
                }

                const float4 objSpaceVertices[] = {
                    splatCenter - right + up,
                    splatCenter + right + up,
                    splatCenter - right - up,
                    splatCenter + right - up
                };

                for (int i = 0; i < 4; i++)
                {
                    VertOutput vo;
                    vo.position = UnityObjectToClipPos(objSpaceVertices[i]);
                    vo.color = splatColor;
                    outTriangles.Append(vo);
                }
            }

            half4 frag(VertOutput v) : COLOR 
            {
                return v.color;
            }

            ENDCG
        }
    }
    Fallback "PointClouds/PointSplatLegacy"
}
