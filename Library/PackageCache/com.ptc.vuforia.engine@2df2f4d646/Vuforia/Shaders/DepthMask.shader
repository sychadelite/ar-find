//===============================================================================
//Copyright (c) 2015 PTC Inc. All Rights Reserved.
//
//Confidential and Proprietary - Protected under copyright and other laws.
//Vuforia is a trademark of PTC Inc., registered in the United States and other
//countries.
//===============================================================================
//===============================================================================
//Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
//All Rights Reserved.
//Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
//===============================================================================

Shader "DepthMask" {
    SubShader {
        // Render the mask after regular geometry, but before masked geometry and
        // transparent things.
        Tags {"Queue"="Geometry-10"}
        
        Lighting Off        

        // Don't draw anything into the RGBA channels. This is an undocumented
        // argument to ColorMask which lets us avoid writing to anything except
        // the depth buffer.
        ColorMask 0

        Pass {
            Stencil {
                Ref 1
                Comp Greater
                Pass Replace
            }
        }
    }
}
