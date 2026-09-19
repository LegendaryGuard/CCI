/*
** 	CORE Dragonball Extension Interface
**
**		(c)	Greenberet 2005 - 2006
**				Corona Bytes
*/
#if defined __CORE_DRAGONBALL__
	#endinput
#endif
#define __CORE_DRAGONBALL__

#if AMXX_VERSION_NUM >= 175
 #pragma reqlib EvolutionDragonball
 #if !defined AMXMODX_NOAUTOLOAD
  #pragma loadlib EvolutionDragonball
 #endif
#else
 #pragma library EvolutionDragonball
#endif

// << Events >> >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

forward @CanWish( Client );

forward @CloseWishList( Client );

forward @InitWishList( Client, Wishlevel );

forward @SpawnDragonballs();

forward @CanGetDragonball( DragonballID, Client );

forward @PlayerGotDragonball( DragonballID, Client );

forward @CanThrowDragonball( Client );

forward @CanCallDragon( Client );

forward @AddDBSpawnPoints();

// << Dragonball Interface >> >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

/* only possible in @InitWishList
* Handler should be in this form:
* public Handler( Client, Wishlevel )
* {
* ...
* }
*/
native addWish( const Wish[], const Handler[] );

native GetWishList();

native ShowWishList( Client, Position );

// DragonballID = 0 - 6
// DragonballID > 6 = Stone aka fakedragonball
// returns EntID
native CreateDragonball( DragonballID );
native RemoveDragonball( DragonballID );


// only possible in @AddDBSpawnPoints
native AddDBSpawnPoint( Float:Point[3] );

native SpawnDragonballs();

native CanGetDragonball( DragonballID, Client );


// returns -1 on failure
// else DragonballID
// if FakeAsError is true then a Fakedragonball will return -1
native IsDragonball( EntID , bool:FakeAsError = false );

native GetDragonball( DragonballID, Client );
native ThrowDragonball( Client, Velocity = 1000 );

// returns Entity Index of DBID or Player Index if a player is holding it
native FindDragonball( DBID );

native SetStone( bool:State );
native GetStone( );
native CanThrowDragonball( Client );

// only checks that are used: is_valid_ent( Client ) && is_valid_ent( Dragonball )
// it doesn't call the @CanThrowDragonball forward
native ThrowDragonballFast( Client );

native CreateDragon( );

native CanCallDragon( Client );

native CanWish( Client );

native InitDragonFX();