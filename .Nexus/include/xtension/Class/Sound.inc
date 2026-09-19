/*
** << Evolution Class Extension >> MOD:Sound
**
** 	Copyright (C) 2005 - 2007 Corona Bytes .NET
**
** This program is free software; you can redistribute it and/or
** modify it under the terms of the GNU General Public License
** as published by the Free Software Foundation; either version 2
** of the License, or (at your option) any later version.
**
** This program is distributed in the hope that it will be useful,
** but WITHOUT ANY WARRANTY; without even the implied warranty of
** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
** GNU General Public License for more details.
**
** You should have received a copy of the GNU General Public License
** along with this program; if not, write to the Free Software
** Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

#if defined __MOD_SOUND__
	#endinput
#endif
#define __MOD_SOUND__

Float:getEntityRange( Q, P )
{
	static Float:vecQ[ 3 ], Float:vecP[ 3 ];
	
	pev( Q, pev_origin, vecQ );
	pev( P, pev_origin, vecP );
	
	return get_distance_f( vecQ, vecP );
}

public @ClassEmitSound ( Client, Channel, const Sound[] )
{
	static Player, Level, CTR, Command[ 128 ];
	
	Level = clamp( getClientLEVEL( Client ), 0, sizeof MOD_SOUND_CORE[] ) + 1;

	for ( CTR = 0; CTR < sizeof MOD_SOUND_CORE; CTR++ )
	{
		if ( equali( MOD_SOUND_CORE[ CTR ][ 0 ], Sound ) )
		{
			if ( contain( MOD_SOUND_CORE[ CTR ][ Level ], "/p_" ) >= 0 )
			{
				formatex( Command, 127, "spk ^"%s^"", MOD_SOUND_CORE[ CTR ][ Level ] );
				
				for ( Player = 1; Player <= __MaxPlayers; Player++ )
					if ( is_user_connected( Player ) )
						if ( getEntityRange( Client, Player ) <= 200.0 )
							client_cmd( Player, Command );
			}
			
			else if ( MOD_SOUND_CORE[ CTR ][ Level ][ 0 ] )
				emit_sound( Client, Channel, MOD_SOUND_CORE[ CTR ][ Level ], 1.0, ATTN_NORM, 0, PITCH_NORM );

			return FMRES_SUPERCEDE;
		}
	}

	return FMRES_IGNORED;
}

stock MOD_Sound_PreCache ()
{
	static o, i;

	for ( o = 0; o < sizeof MOD_SOUND_CORE; o++ )
		for ( i = 1; i < sizeof MOD_SOUND_CORE[]; i++ )
			if ( MOD_SOUND_CORE[ o ][ i ][ 0 ] && contain( MOD_SOUND_CORE[ o ][ i ], "/p_" ) == -1 )
				precache_sound( MOD_SOUND_CORE[ o ][ i ] );
}