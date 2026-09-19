#if defined __CORE__
	#endinput
#endif
#define __CORE__

#pragma reqlib Core
#if !defined AMXMODX_NOAUTOLOAD
	#pragma loadlib Core
#endif

// < Events >

forward @ClientReSpawn ( Client, bool:Valid );
forward @ClientReSpawned ( Client );
forward @silentClientKILL ( Client );

native isDeveloper ( Client );
native getGameVERSION ();

// < IPC >

/**
* c ^ cell
* s ^ string
* a ^ array
*
* plugin < 0 calls executing plugin
*
* ex. ForceCall( 0, "punishClient", "ccs", Client, Victim, "H4xx0r" );
*
**/

// Deprecated
native ForceCall ( plugin, const name[], const format[], { _,Float }:... );
native ForceCallID ( plugin, funcid, const format[], { _,Float }:... );

// < Constant >

enum
{
	TEAM_SPECTATOR = 0,
	TEAM_GOOD,
	TEAM_EVIL
};

enum SwoopDirection
{
	SWOOP_NONE = -1,
	SWOOP_UP,
	SWOOP_DOWN,
	SWOOP_LEFT,
	SWOOP_RIGHT,
	SWOOP_FORWARD,
	SWOOP_BACKWARD
};

// < ScoreBoard >

native setClientWISHCOUNT			( Client, WishCount );
native getClientWISHCOUNT			( Client );

native setClientDEATHS				( Client, Deaths );
native getClientDEATHS				( Client );

native setClientTEAM				( Client, TeamID );
native getClientTEAM				( Client );
native getClientTEAMNAME			( Client, Team[ 16 ] );

// < Model >
	// >> Model = ssj2goku >> Location = "models/player/ssj2goku/ssj2goku.mdl"
	// >> Maximum String Length of 22 Characters
native setClientMODEL				( Client, const Model[] );
native getClientMODEL				( Client, Model[ 23 ] );

// < PowerLevel >

native setClientPL 					( Client, PowerLevel );
native getClientPL 					( Client );
native setClientACPL 				( Client, ActualPowerLevel );
native getClientACPL 				( Client );
native setClientADPL 				( Client, AfterDeathPowerLevel );
native getClientADPL 				( Client );
native setClientSPL 				( Client, PowerLevel );
native setClientPLtoADPL 			( Client );

// < Ki >

	// > Ki lies between 0.0 to 1000.0
native setClientKI 					( Client, Float:Ki );
native Float:getClientKI 			( Client );

native setClientNEXTKIUPDATE 		( Client, Float:gametime );
native Float:getClientNEXTKIUPDATE 	( Client );

// < Health >

native setClientHP 					( Client, Health );
native getClientHP 					( Client );

	// >> The HUD cannot handle health >255
native setClientMHP	 				( Client, MaximumHealth );
native getClientMHP 				( Client );

// < Speed >

native setClientSPEED 				( Client, Speed );
native getClientSPEED 				( Client );

native setClientSPEEDMP 			( Client, Float:Speed );
native Float:getClientSPEEDMP 		( Client );

// < Item >

native giveClientITEM 				( Client, const Item[] );
native stripClientITEMS				( Client );

// < Misc >

	// >> Protect from Damage
native setClientGOD 				( Client, bool:Enable = true );
native getClientGOD 				( Client );

	// >> Protect from Melee
native setClientPROTECT 			( Client, bool:Enable = true );
native getClientPROTECT 			( Client );

native setClientSENSUBEANS			( Client, SensuBeans );
native getClientSENSUBEANS 			( Client );

	// >> Freeze Client Movement, Camera, +Attack, ...
native setClientFROZEN 				( Client, bool:Enable = true );
native getClientFROZEN 				( Client );

native setClientFLY 				( Client, bool:Enable = true );
native getClientFLY 				( Client );

	// >> Animation, KiGain only
native setClientHiddenTURBO 		( Client, bool:Enable = true );
native getClientTURBO 				( Client );

native getClientBLOCK 				( Client );
native getClientKIBLOCK				( Client );

native setClientHiddenPOWERUP 		( Client, bool:Enable = true );
native getClientPOWERUP 			( Client );

	// >> Selected Weapon Name
native getClientWEAPONNAME			( Client, Weapon[ 32 ] );

native getClientSWOOPING 			( Client );
native SwoopDirection:getClientSWOOPDIRECTION	( Client ); 

native setClientSWOOPTIME			( Client, Float:Value );
native Float:getClientSWOOPTIME		( Client );

native getClientATKSHOOT 			( Client );
native getClientATKCHARGE 			( Client );
native getClientATKCHARGEP			( Client );
native getClientMELEE 				( Client );
native getClientTHROWAWAY 			( Client );
native getClientTHROW	 			( Client );
native getClientWALLGND				( Client );
native getClientINFREEFALL			( Client );
native getClientBEAMJUMP			( Client );
native getClientSPECTATOR 			( Client );

native getClientRESPAWN				( Client );
native getClientRESPAWNING			( Client );

native setClientDRAGONBALL			( Client, Dragonball );
native getClientDRAGONBALL			( Client );

native silentClientKILL				( Client );

	// >> Times >> 0 .. 2
native setClientBASICMELEE			( Client, Times );
native getClientBASICMELEE			( Client );

native setClientMELEEPUSHBACK		( Client, Value );
native getClientMELEEPUSHBACK		( Client );

native getClientPREPUNCH			( Client );
native Float:getClientPLMP			( Client );

// < Game >

native getGameMODE			();
native Damage				( Client, Target, Weapon[], Float:Dmg );
native radiusDamage			( Entity, DeathMsg[], Float:MaxDamage, Float:MaxRadius, Float:MaxDamageRadius, IgnoreEntity = 0 );

// < BaseWeapon >

native getWeaponIndex			( BaseWeapon );

	// >> finalflash, kamehameha, ...
native getBeamChargeTime		( BaseWeapon );
native getBeamChargeKi			( BaseWeapon );
native getBeamSpeed				( BaseWeapon );

native setBeamChargeTime		( BaseWeapon, TimeInSeconds );
native setBeamChargeKi			( BaseWeapon, KiPerSecond );
native setBeamSpeed				( BaseWeapon, Speed );

	// >> bigbang, finishingbuster, ...
native getBlastChargeTime		( BaseWeapon );
native getBlastChargeKi			( BaseWeapon );

native setBlastChargeTime		( BaseWeapon, TimeInSeconds );
native setBlastChargeKi			( BaseWeapon, KiPerSecond );
