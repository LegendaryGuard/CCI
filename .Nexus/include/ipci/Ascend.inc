/*
** 	CORE Ascend System Interface
**
**		(c)	Lord of Destruction2005 - 2006
**				Corona Bytes
*/
#if defined __CORE_ASCEND__
	#endinput
#endif
#define __CORE_ASCEND__

#pragma reqlib Ascend

#include <shared/ascend>

native getClassDATAc			( Class, CClassExtension:ID );
native getClassDATAv			( Class, CClassExtension:ID, Vector[], Length = sizeof Vector );

native getLevelDATAc			( Class, Level, CClassLevel:ID );
native getLevelDATAv			( Class, Level, CClassLevel:ID, Vector[], Length = sizeof Vector );

native getClientDATAc			( Client, CClient:ID );
native setClientDATAc			( Client, CClient:ID, Cell );

native getClientLEVELDATAc		( Client, CClassLevel:ID );
native getClientLEVELDATAv		( Client, CClassLevel:ID, Vector[], Length = sizeof Vector );
native setClientLEVELDATAc		( Client, CClassLevel:ID, Cell );
native setClientLEVELDATAv		( Client, CClassLevel:ID, Vector[], Length = sizeof Vector );

native restoreClientLEVELDATA	( Client );
native updateClientLEVELDATA	( Client, bool:HealthAdjust = true );

// < Events >

forward @AscendInitiated		();

forward @ClassChange 			( Client, PreClass, PostClass );
forward @LevelChange 			( Client, PreLevel, PostLevel );
forward @ClientDeath			( Client );

// < Ascend Interface >

native getClassExtensionCount	();

native forceClientCLASS			( Client, Class, Level, WeaponUpdate = true, HPAdjust = true );
native emitClientSOUND 			( Client, Channel, const Sound[] );

stock stopClientSOUND			( Client, Channel = CHAN_WEAPON )
	emit_sound( Client, Channel, "evolution/null.wav", 1.0, ATTN_NORM, 0, PITCH_NORM );


native setClientXFROZEN			( Client, bool:Enable = true );
native getClientXFROZEN			( Client );

native setClientANIMATION		( Client, Sequence, Float:FrameRate = 0.5 );

native getClientCLASS			( Client );
native getClientLEVEL			( Client );

native addArrows( Client, func[], ADV_MELEE_DIRECTION:... );

// < Icon >

native getIconINDEX				( const Source[] );
native createCustomICON			( const Source[], Order[ 2 ] );

native addIconHOOK				( const Callback[] );
/*
** public IconHook ( Client, ClientIcon, PreClientIcon )
** {
** }
*/

native getClientICON			( Client );
native getClientPICON			( Client );
native setClientICON			( Client, Icon );

native replaceClientICON		( Client, Icon, IconToReplace );
native giveClientICON			( Client, Icon, BaseOnAttack = 1 );
native removeClientICON			( Client, Icon );
native bool:hasClientICON		( Client, Icon );

// < Stocks >

stock getCXbyName ( const Name[] )
{
	static Class[ 33 ], End, ID;
	End = getClassExtensionCount();
	
	for ( ID = 0; ID < End; ID++ )
	{
		getClassDATAv( ID, cxName, Class, 32 );
	
		if ( equal( Class, Name ) )
			return ID;
	}

	return -1;
}

stock getCXbyPlugin ( Plugin )
{
	static End, ID;
	End = getClassExtensionCount();

	for ( ID = 0; ID < End; ID++ )
		if ( getClassDATAc( ID, cxPlugin ) == Plugin )
			return ID;

	return -1;
}