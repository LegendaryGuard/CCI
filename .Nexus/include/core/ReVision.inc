#if defined __CORE_REVISION__
  #endinput
#endif
#define __CORE_REVISION__

#include <amxx/amxmodx>

#tryinclude "ReVision.tmp"

#if !defined REVISION_AUTHOR
	#define REVISION_AUTHOR "Corona Bytes"
#endif

#if !defined REVISION_ID
	#define REVISION_ID 0
#endif

#if !defined COMPILE_DATE
	#define COMPILE_DATE "1.1.1970"
#endif

#if !defined COMPILE_TIME
	#define COMPILE_TIME "00:00:00"
#endif

// << Protected from external Code >>
static AuthentificationRevisionKey[ 64 ];
static AuthentificationRevisionVal[ 64 ];

stock initReVision ( const Auth[] )
{
	formatex( AuthentificationRevisionKey, 63, ".%s.ReVision", Auth );
	formatex( AuthentificationRevisionVal, 63, "%i %s - %s %s", REVISION_ID, REVISION_AUTHOR, COMPILE_DATE, COMPILE_TIME );
	register_cvar( AuthentificationRevisionKey, AuthentificationRevisionVal, FCVAR_SERVER );
}