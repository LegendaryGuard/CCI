#if defined __XTENSION_SPECIAL__
	#endinput
#endif
#define __XTENSION_SPECIAL__

#include <amxmodx>
#include <fakemeta>
#include <engine>

#include <core/devel>

#include <ipci/core>

#pragma reqlib Ascend

enum SpecialXtension
{
   sxEmptyHandle
};

enum CSpecialState
{
	ssCharge,
	ssChargeReleased,
	ssChargeAborted,
	ssControlInvocation,
	ssForceAbort
};

enum CSpecialHook
{
	sxhDeathMessage,
	sxhDummy
};

forward @SpecialCreation 			();

/**
	Ex. WFF_HooK ( Client = 1, SpecialState:State = ssBeginCharge, AttackButton = IN_ATTACK, Float:Charge = 0.5 ) )
*/
native beginSpecialCreation			( Name[ /* 64 */ ], Desc[ /* 256 */ ], Hook[ /* 64 */ ], Icon[ /* 16 */ ], BaseOnAttack = 1 );

native addSpecialCharge				( ControlSequence, Float:SecsForFullCharge, Float:KiPerStep, bool:CanMove = false );
native addSpecialControl			( ControlSequence );
native addSpecialHook				( CSpecialHook:Hook, const Method[] );

native SpecialXtension:endSpecialCreation();

/**
	@returns r >= 1 if Valid Special
	@returns r = -1 if Invalid Special
*/
native SpecialXtension:getSpecialID	( Name[ /* 64 */ ] );

native bool:getClientSPECIALSTATE	( Client, SpecialXtension:sx );
native setClientSPECIALSTATE		( Client, SpecialXtension:sx, bool:Active );

native setClientSPECIALCOOLDOWN		( Client, SpecialXtension:sx, Float:Time );
native getClientSPECIALCFG			( Client, SpecialXtension:sx, Index );

//native bool:giveClientSPECIAL		( Client, SpecialXtension:sx );

native bool:hasClientSPECIAL		( Client, SpecialXtension:sx );