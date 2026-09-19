/*
** << Evolution Class Extension >> MOD:Init
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

#include <amxx/amxmodx>
#include <amxx/fakemeta>

#include <ipci/core>
#include <ipci/ascend>
#include <ipci/fxlib>

#include <xtension/class>
#include <xtension/special>

stock __MaxPlayers;
stock MSGID_CurWeapon;

#if MOD_SOUND == 1
	#include "MOD.Sound.core"
	#include <xtension/class/sound>
#endif

#if MOD_CHARGE == 1
	#include "MOD.Charge.core"
	#include <xtension/class/charge>
#endif

#if MOD_WEAPON == 1
	#include <xtension/class/weapon>
	#include "MOD.Weapon.core"
#endif

public plugin_natives ()
{
	set_module_filter( "FilterModule" );
	set_native_filter( "FilterNative" );
}

public FilterModule ( const Module[] )
{
	if ( equali( Module, "Fusion" ) )
		return 1;

	return 0;
}

public FilterNative ( const Native[], Index, Trap )
{
	if ( !Trap )
		return 1;

	return 0;
}

public plugin_init ()
{
	__MaxPlayers = get_maxplayers();
	MSGID_CurWeapon = get_user_msgid( "CurWeapon" );
	PluginInit();
}

public plugin_precache()
{
#if MOD_SOUND == 1
	MOD_Sound_PreCache();
#endif

#if MOD_CHARGE == 1
	ModChargeInit();
#endif

#if MOD_WEAPON == 1
	MOD_Weapon_PreCache();
#endif

	PluginPreCache();
}

#tryinclude "FX.core"