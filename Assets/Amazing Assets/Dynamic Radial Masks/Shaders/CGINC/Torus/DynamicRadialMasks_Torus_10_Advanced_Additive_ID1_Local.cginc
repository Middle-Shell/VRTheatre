#ifndef DYNAMIC_RADIAL_MASKS_TORUS_10_ADVANCED_ADDITIVE_ID1_LOCAL
#define DYNAMIC_RADIAL_MASKS_TORUS_10_ADVANCED_ADDITIVE_ID1_LOCAL


float4 DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Position[10];	
float  DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Radius[10];
float  DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Intensity[10];
float  DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_NoiseStrength[10];
float  DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_EdgeSize[10];
float  DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Smooth[10];


#include "../../Core/Core.cginc"



////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                Main Method                                 //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
float DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local(float3 positionWS, float noise)
{
    float retValue = 0; 

	int i = 0;
[unroll]	for(i = 0; i < 10; i++)
	{
		retValue += ShaderExtensions_DynamicRadialMasks_Torus_Advanced(positionWS,
																	noise,
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Position[i].xyz, 
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Radius[i],         
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Intensity[i],
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_NoiseStrength[i],  
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_EdgeSize[i],		
																	DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_Smooth[i]);
	}		

    return retValue;
}

////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                               Helper Methods                               //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
void DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_float(float3 positionWS, float noise, out float retValue)
{
    retValue = DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local(positionWS, noise); 		
}

void DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local_half(half3 positionWS, half noise, out half retValue)
{
    retValue = DynamicRadialMasks_Torus_10_Advanced_Additive_ID1_Local(positionWS, noise); 		
}

#endif
