/*
** 	CORE Util Interface
**
**		(c)	Greenberet 2005 - 2006
**				Corona Bytes
*/
#if defined __CORE_UTIL_STOCKS__
	#endinput
#endif
#define __CORE_UTIL_STOCKS__

#include <amxmodx> //trace natives
#include <fakemeta>
#include <fakemeta_util>

/* calculates the percentage
* (amount / total) × 100 = percentage
* total must be != 0
*/ 
stock Float:UTIL_Percentage_Percentage( Float:Amount, Float:Total )
{
	return (Amount / Total) * 100;
}

/* calculates the amount
* amount = (percentage / 100) * total
*/ 
stock Float:UTIL_Percentage_Amount( Float:Percentage, Float:Total )
{
	return (Percentage / 100) * Total;
}

/* calculates the total
* total = ( 100 * amount ) / percentage
* Percentage must be != 0
*/ 
stock Float:UTIL_Percentage_Total( Float:Amount, Float:Percentage )
{
	return ( 100 * Amount ) / Percentage;
}


/*
*	returns position of the value in the array.
*	-1 if the value could't be found
*/
stock UTIL_IsInArray( Val, arr[], Count )
{
	for( new i = 0; i < Count; i++ )
	{
		if( Val == arr[ i ] )
			return i;
	}
	return -1;
}

#define UTIL_PrintFunction(%1,%2) server_print( "[AMXX] Function call %s::%s", %1, %2 );

stock UTIL_PrintFunction2()
{
#if debug != 0		
	static trace,line;
	trace = dbg_trace_begin();
	static function[64], file[64];
	trace = dbg_trace_next( trace );
	if( !trace )
		return;
	dbg_trace_info( trace, line, function, 63, file, 63 );
	
	server_print( "[AMXX] Function got called: ^"%s::%s^"", file, function );
#endif
}

stock UTIL_GetAimOrigin(index, Float:origin[3], Float:scalar = 9999.9) 
{
    new Float:start[3], Float:view_ofs[3]
    pev(index, pev_origin, start)
    pev(index, pev_view_ofs, view_ofs)
    xs_vec_add(start, view_ofs, start)

    new Float:dest[3]
    pev(index, pev_v_angle, dest)
    engfunc(EngFunc_MakeVectors, dest)
    global_get(glb_v_forward, dest)
    xs_vec_mul_scalar(dest, scalar, dest)
    xs_vec_add(start, dest, dest)

    engfunc(EngFunc_TraceLine, start, dest, 0, index)
    global_get(glb_trace_endpos, origin)
}

stock vecangl_distance(const Float:ptStart[3], const Float:angles[3], Float:length, Float:ptOut[3])
{
    // sin (s) and cos (c) for yaw (y) and pitch (p)
    new Float:sp, Float:sy, Float:cp, Float:cy

    // PITCH
    sp = floatsin(angles[0], degrees)
    cp = floatcos(angles[0], degrees)
    // YAW
    sy = floatsin(angles[1], degrees)
    cy = floatcos(angles[1], degrees)

    ptOut[0] = cp*cy
    ptOut[1] = cp*sy
    ptOut[2] = sp*-1.0

    // ptOut now holds a normalised forward vector pointing to the direction of angles, so let's multiply it by length and add to the start point
    ptOut[0] *= length
    ptOut[1] *= length
    ptOut[2] *= length

    ptOut[0] += ptStart[0]
    ptOut[1] += ptStart[1]
    ptOut[2] += ptStart[2]
}

stock UTIL_Damage( Client, dmg, attack[] = "World" )
{
	new hp = getClientHP( Client ) - dmg;
	
	if( hp > 0 )
		setClientHP( Client, hp );
	else
	{
		message_begin( MSG_ALL, get_user_msgid("DeathMsg") );
		write_byte	( Client );
		write_byte	( Client );
		write_string( attack );
		message_end	();
		
		silentClientKILL( Client );
	}
	
}