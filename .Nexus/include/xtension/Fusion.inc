#if defined __XTENSION_FUSION__
	#endinput
#endif
#define __XTENSION_FUSION__

#pragma reqlib Fusion

enum FusionStyle
{
	FUSION_POTARA = 1,
	FUSION_DANCE
	//FUSION_NAMEKIAN
};

forward @FusionClassCreation ();

native addFusion 	(
						const ClassNameQ[],
						const ClassNameT[],
						FusionStyle:Style,
						Levels[ 3 ],
						RequiredPowerLevel,
						Float:PowerLevelMultiplier = 2.0,
						Float:Animation[ 4 ] = { 0.0, 0.0, 0.0, 0.0 }, // << 2x Framerate 2x Sequence >>
						Float:Modifier[ 4 ] = { 0.0, 0.0, 0.0, 0.0 }, // << F:POT PitchAngle | F:DAN L/R | F:NAM ? >>
						Float:DanceTime = 0.0
					);