#if defined __CORE_DEVEL__
  #endinput
#endif
#define __CORE_DEVEL__

#include <amxx/amxmodx>

stock uniqueTaskID( ClientID, Core )
	return ( ClientID + ( Core * 32 ) );

stock MSGID( const String[] )
	return get_user_msgid( String );

stock DevMsg ( Client, Message[], {_,Float}:... )
{
	static FormatedMessage[ 1024 ];
	vformat( FormatedMessage, 1023, Message, 3 );
	
	client_print( Client, print_chat, "%s", FormatedMessage );
}

public plugin_pause ()
{
	unpause( "a" );

	return 1;
}