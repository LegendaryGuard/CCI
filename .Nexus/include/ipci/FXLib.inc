#if defined __CORE_FXLIB__
	#endinput
#endif
#define __CORE_FXLIB__

#pragma reqlib FxLibrary
#if !defined AMXMODX_NOAUTOLOAD
	#pragma loadlib FxLibrary
#endif

// << Maximum 3 Instances for each Effect for the Moment >>

// << returns Instance of this Effect >>
native AddFx ( Client, const Effect[], {_,Float}:... );

// << RemFx( Client, "ParticleSphere", 3 ); to remove specified Instance - leave blank to remove all Instances >>
native RemFx ( Client, const Effect[], {_,Float}:... );


