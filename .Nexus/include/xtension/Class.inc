#if defined __XTENSION_CLASS__
	#endinput
#endif
#define __XTENSION_CLASS__

#pragma reqlib Ascend

forward @ClassCreation 				();
forward @ClassInitiateTransformation( Client, Level, bool:Perfect );
forward @ClassFinishTransformation 	( Client, Level );
forward @ClassCancelTransformation 	( Client, Level );
forward @ClassWeaponUpdate			( Client, Level );
forward @ClassSkipLevel				( Client, Level, PowerLevel );
forward bool:@ClassCandyEat			( Client );

native createClass 					(
										const Modification[ 3 ] = { 0, 0, 0 },
										const Name[ /* 32 */ ],
										bool:DescendClass,
										bool:FusionClass,
										const Description[ /* 256 */ ],
										const IntroSound[ /* 64 */] = ""
									);

native addClassLevel 				(
										const Name[ /* 32 */ ],
										const Model[ /* 22 */ ],
								   		Float:AscendTime,
								   		Float:PerfectAscendTime,
								   		requiredPowerLevel,
								   		requiredPerfectPowerLevel,
								   		Float:PLMultiplier,
								   		Speed,
								   		Health,
								   		bool:Evolution[ 2 ],						// << NoAscend, NoDescend >>
								   		Float:KiRate,
										Teleport[ 2 ],								// << Range, Ki >>
								   		Skills[ 7 ],								// << Attacking, Swooping, Telesense, HYPERMODE, Take Aim, Melee Sense, Strong Melee >>
								   		Float:BoostSpeed = 5.0,
										const Float:Damage[ 2 ] = { 100.0, 0.0 }	// << Attack, Defense >>
								   	);

native addClassEffect 				(
										const AuraModel[ /* 64 */ ],
								   		const Float:AuraColor[ 4 ],						// << R G B Alpha >>
								   		Aura_Skin,
								   		Aura_RenderMode,								// << kRender... >>
								   		const ChargeColor[ 3 ],							// << R G B >>
										const Lightning[ 4 ] = { 0, 0, 0, 0 }, 			// << Size Head, Torso, Legs, Range >>
										const Float:Glow[ 4 ] = { 0.0, 0.0, 0.0, 0.0 }	// << R G B Width >>
									);
									
native addClassItem 				( Client, const Item[], bool:HighPriority = false );
native addClassSpecial 				( Client, const Special[], {_,Float}:Config[] = "" );