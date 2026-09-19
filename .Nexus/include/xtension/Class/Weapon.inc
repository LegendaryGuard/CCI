#if defined __MOD_WEAPON__
	#endinput
#endif
#define __MOD_WEAPON__

	// >> Adjust custom WeaponDamage here
forward @WeaponAdjust 		( Client, Weapon, const Class[], PowerLevel, Charge );
	// >> Sets Explosion Color
native setWeaponXPC			( Color );
native setWeaponXPM			( Float:Multiplier );
	// >> Makes use of our own Damage Formula
	// >> Alternative : entity_set_float( Weapon, EV_FL_dmg, Pl * (Charge / 100.0) );
native setWeaponDMG			( Float:Base, Float:Max, Float:Const );

native setBallSTYLE			( Sprite, Size );

native setWeaponHOMING 		( Entity, Float:Speed, SearchBegin, SearchFlags );
	
native attachWeaponHEAD		( Weapon, const Model[], RenderMode, Float:RenderAmp, Float:Size = 1.0, Float:FrameRate = 1.0 );


	// >> SpiritBomb, DeathBall but not ShieldAttack
forward @WeaponBall 		( Client, Weapon, const Class[], Sprite, Size );

	// >> KiBlast, BigBang, ...
forward @WeaponBlast 		( Client, Weapon, const Class[], Size );

	// >> KameHameHa, FinalFlash, ...
forward @WeaponBeam 		( Client, Weapon, const Class[], Size );

	// >> Special Beam Cannon
forward @WeaponSBC 			( Client, Weapon, const Class[] );

	// >> Adjust Death Messages
forward @WeaponDeath ( Client, Killer, const Weapon[] );
