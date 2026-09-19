/**
 * (C)2003-2006 David "BAILOPAN" Anderson
 * Counter-Strike Deathmatch (CSDM) 2.00 Module Includes
 */

#if defined _csdm_included
  #endinput
#endif
#define _csdm_included

#pragma library csdm2

#define	CSDM_VERSION	"2.10"

#define	CFG_READ		0		//Line is being read normally
#define	CFG_RELOAD		1		//Section is being parsed from the start
#define	CFG_DONE		2		//Section is done being parsed

#define DEFAULT_ARMOR		100

#define MAX_WEAPONS 		32 
#define MAX_SECONDARY 		8
#define MAX_PRIMARY 		18

#define CSDM_FFA_ENABLE		3
#define CSDM_FFA_DISABLE	2
#define CSDM_ENABLE			1
#define CSDM_DISABLE		0

#define CSDM_DROP_CONTINUE	0	//continue normally
#define CSDM_DROP_REMOVE	1	//remove the dropped weapon
#define CSDM_DROP_IGNORE	2	//ignore entirely

/************
 * FORWARDS *
 ************/
 
//Called when CSDM initializes.  It passes in a version string, or a blank
// string if some load failure occurred.
//Do pre-config stuff here.
forward csdm_Init(const version[]);

//Called when CSDM is ready to accept config hooks.
forward csdm_CfgInit();

//Called right before a death message is sent.  Return value has no effect.
forward csdm_PreDeath(killer, victim, headshot, const weapon[]);

//Called right after a death message is handled.  
//return PLUGIN_HANDLED will block CSDM from doing any physical respawning.
forward csdm_PostDeath(killer, victim, headshot, const weapon[]);

//Called after a player is physically respawned,
// but before the spawn handler is called.  Returning PLUGIN_HANDLED
// will block CSDM from calling the set spawn handler.
//Note! this will only be called if CSDM internally respawns or you use
// csdm_respawn().
forward csdm_PreSpawn(player, bool:fake);

//Called after a player is physically respawned, 
// and after all spawn handling is completed.
forward csdm_PostSpawn(player, bool:fake);

//Called after the round is restarted
forward csdm_RoundRestart();

//Called right before round is restarted
//The post parameter is set to 1 if the event is post.
//If post is 0, the event is pre, and PLUGIN_HANDLED will block
// CSDM from doing round restart actions (respawning)
forward csdm_RoundRestartPre(post);

//Called when a CSDM state is set
forward csdm_StateChange(csdm_state);

//Called by the main plugin right now
//If death is true, the weapon was dropped on death
forward csdm_HandleDrop(id, weapon, death);

/***********
 * NATIVES *
 ***********/
 
//To retrieve/set angles and v_angles, pass up to two more vectors
native csdm_getpos(player, Float:origin[3], ...);

native csdm_setpos(player, const Float:origin[3], ...);

//Returns the number of registered spawn styles
native csdm_spawnstyles();

//Retrieves the name of a spawn style by index (indices start at 0)
native csdm_styleinfo(style_index, name[], maxlength);

//Adds a spawn style handler
native csdm_addstyle(const name[], const function[]);

//Sets the current spawn style handler by name.
//The handler registered to this name will be called after every spawn.
native csdm_setstyle(const name[]);

//Returns the current style id
native csdm_curstyle();

//Respawns a player correctly under the CSDM spawn system.
native csdm_respawn(player);

//Forces a "fake" respawn on the player - sort of like a ResetHUD
native csdm_fakespawn(player);

//Registers a hook on the config reader
//The forward looks like this:
//forward my_cfg_reader(read_mode, const line[], const section[])
native csdm_reg_cfg(const sectionName[], const handler[]);

//Gives an item.  Same as give_item from fun.
native csdm_give_item(player, const item_name[]);

//Forces a player to drop a weapon
native csdm_force_drop(player, const weapon[], remove=1);

//Schedules a weapon for removal.  0 seconds means immediate
//delay specifies whether it should wait 0.1 seconds or not (0 for immediate lookup)
native csdm_remove_weapon(player, const weapon[], seconds, delay);

//Reloads the config file
native csdm_reload_cfg();

//Returns whether CSDM is active
native csdm_active();
//Sets CSDM to active (do not set the cvar!)
native csdm_set_active(on_or_off);

//Returns/sets the current FFA (free for all) state
native csdm_get_ffa();
native csdm_set_ffa(on_or_off);

//Gets/sets the respawn wait time
native Float:csdm_get_spawnwait();
native csdm_set_spawnwait(Float:time);

//returns cache information into each array slot
// 0 - number of free items in spawn task cache
// 1 - number of free task in general task cache
// 2 - number of hot tasks (ones in use)
// 3 - number of cached weapon removals in table
// 4 - number of live weapon removals in table
// 5 - number of weapon find tasks in cache
// in general, 0+5+4 should about equal 1+2
// do not edit the vers parameter.
native csdm_cache(ar[6], vers=2)

//Quick hack to replace engine dependency and work around a FM bug
//returns 1 if a hull collision is found
native csdm_trace_hull(Float:origin[3], hull_no);

/**
 * Natives defined by csdm_main 
 */
 
//Returns the handle for the main CSDM menu, letting you modify it.
native csdm_main_menu();

/*** ************ ***
 *** HELPER STUFF 
 ***/
 
#define	SLOT_PRIMARY	1
#define	SLOT_SECONDARY	2
#define	SLOT_KNIFE		3
#define	SLOT_GRENADE	4
#define	SLOT_C4			5

#define	_TEAM_T			1
#define	_TEAM_CT		2

//Weapon slot lookup table
stock g_WeaponSlots[] = {
		0,
		2,	//CSW_P228
		0,
		1,	//CSW_SCOUT
		4,	//CSW_HEGRENADE
		1,	//CSW_XM1014
		5,	//CSW_C4
		1,	//CSW_MAC10
		1,	//CSW_AUG
		4,	//CSW_SMOKEGRENADE
		2,	//CSW_ELITE
		2,	//CSW_FIVESEVEN
		1,	//CSW_UMP45
		1,	//CSW_SG550
		1,	//CSW_GALIL
		1,	//CSW_FAMAS
		2,	//CSW_USP
		2,	//CSW_GLOCK18
		1,	//CSW_AWP
		1,	//CSW_MP5NAVY
		1,	//CSW_M249
		1,	//CSW_M3
		1,	//CSW_M4A1
		1,	//CSW_TMP
		1,	//CSW_G3SG1
		4,	//CSW_FLASHBANG
		2,	//CSW_DEAGLE
		1,	//CSW_SG552
		1,	//CSW_AK47
		3,	//CSW_KNIFE
		1	//CSW_P90
	};
	
//Maximum backpack ammo lookup table
stock g_MaxBPAmmo[] = {
		0,
		52,	//CSW_P228
		0,
		90,	//CSW_SCOUT
		1,	//CSW_HEGRENADE
		32,	//CSW_XM1014
		1,	//CSW_C4
		100,//CSW_MAC10
		90,	//CSW_AUG
		1,	//CSW_SMOKEGRENADE
		120,//CSW_ELITE
		100,//CSW_FIVESEVEN
		100,//CSW_UMP45
		90,	//CSW_SG550
		90,	//CSW_GALIL
		90,	//CSW_FAMAS
		100,//CSW_USP
		120,//CSW_GLOCK18
		30,	//CSW_AWP
		120,//CSW_MP5NAVY
		200,//CSW_M249
		21,	//CSW_M3
		90,	//CSW_M4A1
		120,//CSW_TMP
		90,	//CSW_G3SG1
		2,	//CSW_FLASHBANG
		35,	//CSW_DEAGLE
		90,	//CSW_SG552
		90,	//CSW_AK47
		0,	//CSW_KNIFE
		100//CSW_P90
	};
	
stock getWepId(wp[])
{
	if (equali(wp, "weapon_p228")) {
		return CSW_P228
	} else if (equali(wp, "weapon_scout")) {
		return CSW_SCOUT
	} else if (equali(wp, "weapon_hegrenade")) {
		return CSW_HEGRENADE
	} else if (equali(wp, "weapon_xm1014")) {
		return CSW_XM1014
	} else if (equali(wp, "weapon_c4")) {
		return CSW_C4
	} else if (equali(wp, "weapon_mac10")) {
		return CSW_MAC10
	} else if (equali(wp, "weapon_aug")) {
		return CSW_AUG
	} else if (equali(wp, "weapon_smokegrenade")) {
		return CSW_SMOKEGRENADE
	} else if (equali(wp, "weapon_elite")) {
		return CSW_ELITE
	} else if (equali(wp, "weapon_fiveseven")) {
		return CSW_FIVESEVEN
	} else if (equali(wp, "weapon_ump45")) {
		return CSW_UMP45
	} else if (equali(wp, "weapon_sg550")) {
		return CSW_SG550
	} else if (equali(wp, "weapon_galil")) {
		return CSW_GALIL
	} else if (equali(wp, "weapon_famas")) {
		return CSW_FAMAS
	} else if (equali(wp, "weapon_usp")) {
		return CSW_USP
	} else if (equali(wp, "weapon_glock18")) {
		return CSW_GLOCK18
	} else if (equali(wp, "weapon_awp")) {
		return CSW_AWP
	} else if (equali(wp, "weapon_mp5navy")) {
		return CSW_MP5NAVY
	} else if (equali(wp, "weapon_m249")) {
		return CSW_M249
	} else if (equali(wp, "weapon_m3")) {
		return CSW_M3
	} else if (equali(wp, "weapon_m4a1")) {
		return CSW_M4A1
	} else if (equali(wp, "weapon_tmp")) {
		return CSW_TMP
	} else if (equali(wp, "weapon_g3sg1")) {
		return CSW_G3SG1
	} else if (equali(wp, "weapon_flashbang")) {
		return CSW_FLASHBANG
	} else if (equali(wp, "weapon_deagle")) {
		return CSW_DEAGLE
	} else if (equali(wp, "weapon_sg552")) {
		return CSW_SG552
	} else if (equali(wp, "weapon_ak47")) {
		return CSW_AK47
	} else if (equali(wp, "weapon_knife")) {
		return CSW_KNIFE
	} else if (equali(wp, "weapon_p90")) {
		return CSW_P90
	}
	
	return 0
}
