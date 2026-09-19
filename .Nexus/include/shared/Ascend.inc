#if defined __SHARED_ASCEND__
	#endinput
#endif
#define __SHARED_ASCEND__

enum CClassExtension
{
	cxPlugin,
	cxName[ 33 ],
	cxDescription[ 257 ],
	cxIntro[ 65 ],
	cxLevels,
	bool:cxDescend,
	bool:cxFusion,
	bool:cxMods[ 3 ], // Sound Charge Weapon
	
	// < Forward Handles >
	
	cxWeaponUpdate,
	cxInitiateTransformation,
	cxFinishTransformation,
	cxCancelTransformation,
	
	cxWeaponCreation,
	cxWeaponAdjust,
	cxWeaponBeam,
	cxWeaponBlast,
	cxWeaponBall,
	cxWeaponSBC,
	cxWeaponDeath,
	cxIconUpdate,
	
	cxCharge,
	cxEmitSound,
	cxItemTouch,
	cxSkipLevel
};

enum CClassLevel
{
	// Level
	
	cxlName[ 33 ],
	cxlModel[ 23 ],
	cxlModelIndex,
	Float:cxlAscendTime,
	Float:cxlPerfectAscendTime,
	cxlRequiredPL,
	cxlPerfectPL,
	cxlPLMulti,
	cxlSpeed,
	cxlHealth,
	bool:cxlEvolution[ 2 ], // No Ascend / No Descend
	cxlKiRate,
	Float:cxlAttack,
	Float:cxlDefense,
	Float:cxlBoostSpeed,
	cxlTeleportRange,
	cxlTeleportKiCost,
	cxlSkills[ 7 ], // Attack Mov / Swoop / Sense / HYPERMODE / SwoopSense / MeleeSense / Strong Melee
	
	// FX
	Float:cxlAura[ 4 ], // R / G / B / Alpha
	cxlAuraSkin,
	cxlAuraRenderMode,
	cxlAuraModel[ 65 ],
	cxlAuraModelIndex,
	cxlPowerUp[ 3 ], 
	cxlLightning[ 4 ], // Head Torso Legs Range
	Float:cxlGlow[ 4 ] // R G B Range
};

enum CClient
{
	cliClass,
	cliPreClass,
	cliAfterDeathClass,
	cliLevel,
	cliPreLevel,
	cliAfterDeathLevel,
	Float:cliNextAscend,
	Float:cliNextDescend,
	Float:cliNextTeleport,
	Float:cliNextBoost,
	Float:cliNextAim,
	bool:cliTransform,
	bool:cliAllowAscend,
	bool:cliAllowDescend,
	bool:cliAllowChange,
	bool:cliAllowCharge,
	bool:cliAllowPush,
	bool:cliAllowTeleport,
	bool:cliAllowBoost,
	bool:cliAllowDatabaseUpdate,
	cliSpawn,
	cliFirstSpawn,
	cliOverridePL,
	cliOverrideADPL,
	cliOverrideHP,
	bool:cliPowerStruggle,
	bool:cliFrozen,
	bool:cliDead,
	
	cliPrePunch,
	cliAdvancedMelee,
	cliHealth,
	cliComboHit,
	
	cliChargeID, // CSpecialExtensionCharge
	cliChargeSteps,
	cliSelectedSpecial,
	cliActiveSpecial // CSpecialExtension
};

enum ADV_MELEE_DIRECTION
{	
	PUNCH_UP = 0,
	PUNCH_UPPERLEFT,
	PUNCH_LEFT,
	PUNCH_LOWERLEFT,
	PUNCH_DOWN,
	PUNCH_LOWERRIGHT,
	PUNCH_RIGHT,
	PUNCH_UPPERRIGHT,
	KICK_UP, // = 8
	KICK_UPPERLEFT,
	KICK_LEFT,
	KICK_LOWERLEFT,
	KICK_DOWN,
	KICK_LOWERRIGHT,
	KICK_RIGHT,
	KICK_UPPERRIGHT,
	PUNCH_NODIR, // Random direction
	KICK_NODIR // All arrows
};