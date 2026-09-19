/*
** << Evolution Class Extension >> MOD:Charge
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

#if defined __MOD_CHARGE__
	#endinput
#endif
#define __MOD_CHARGE__

#define CXMAXCHARGES 24

enum CMODCharge
{
	cmcLevel,
	cmcAttack[ 33 ],
	cmcSprite[ 33 ],
	Float:cmcScale
};

enum CMODClientCharge
{
	cmccPreEdict,
	Float:cmccScale[ 2 ]
};

static __CMODCharges[ CXMAXCHARGES ][ CMODCharge ];
static __CMODChargeCTR;
static __CMODClient[ 33 ][ CMODClientCharge ];

stock alterCharge ( Level, const Attack[], const Sprite[], Float:Scale = 1.0 )
{
	if ( __CMODChargeCTR >= CXMAXCHARGES )
		return;
		
	__CMODCharges[ __CMODChargeCTR ][ cmcLevel ] = Level;
	__CMODCharges[ __CMODChargeCTR ][ cmcScale ] = _:Scale;
	
	copy( __CMODCharges[ __CMODChargeCTR ][ cmcAttack ], 32, Attack );
	copy( __CMODCharges[ __CMODChargeCTR ][ cmcSprite ], 32, Sprite );
	
	precache_model( Sprite );
	
	++__CMODChargeCTR;
}

public @ClassCharge ( Client )
{
	static ChargeWEAPON[ 32 ], Entity, Charge;
	getClientWEAPONNAME( Client, ChargeWEAPON );
	
	if ( read_data( 1 ) )
	{
		Entity = 0;
	
		while ( ( Entity = engfunc(EngFunc_FindEntityByString, Entity, "classname", "env_sprite" ) ) )
		{		
			if ( !pev_valid( Entity ) )
				continue;

			if ( pev( Entity, pev_iuser2 ) )
				continue;

			if ( pev( Entity, pev_aiment ) != Client )
				continue;
			
			for ( Charge = 0; Charge < __CMODChargeCTR; Charge++ )
			{
				if ( getClientLEVEL( Client ) == __CMODCharges[ Charge ][ cmcLevel ]
					&& equal( ChargeWEAPON, __CMODCharges[ Charge ][ cmcAttack ] )
				   )
				{
					set_pev( Entity, pev_iuser2, 1 );

					__CMODClient[ Client ][ cmccPreEdict ] = Entity;

					engfunc( EngFunc_SetModel, Entity, __CMODCharges[ Charge ][ cmcSprite ] );

					__CMODClient[ Client ][ cmccScale ][ 0 ] = _:__CMODCharges[ Charge ][ cmcScale ];

					break;
				}
			}
		}
			
		if ( pev_valid( __CMODClient[ Client ][ cmccPreEdict ] ) )
		{
			static Float:Scale;
			pev( __CMODClient[ Client ][ cmccPreEdict ], pev_scale, Scale );
		
			if ( __CMODClient[ Client ][ cmccScale ][ 1 ] !=  Scale)
			{	
				__CMODClient[ Client ][ cmccScale ][ 1 ] = _:(Scale * Float:__CMODClient[ Client ][ cmccScale ][ 0 ]);
			
				set_pev(__CMODClient[ Client ][ cmccPreEdict ], pev_scale, __CMODClient[ Client ][ cmccScale ][ 1 ] );
			}
		}
	}

	if ( !read_data( 1 ) && pev_valid( __CMODClient[ Client ][ cmccPreEdict ] ) )
	{
		__CMODClient[ Client ][ cmccScale ][ 1 ] = _:0.0;

		set_pev( __CMODClient[ Client ][ cmccPreEdict ], pev_iuser2, 0 );
	}
}