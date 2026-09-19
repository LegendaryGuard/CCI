#include <sqlx>
#include <file>

static Handle:___Tuple;
static ___ErrorCode, ___Error[ 256 ];
static ___Database[ 256 ];

// < Generic >

stock ___PutHeader ( File )
{
	static Time[ 32 ];
	get_time( "< %m/%d/%Y - %H:%M:%S > ", Time, 31 );
	fputs( File, Time );
	fputs( File, ___Database );
}

stock ___ConnectError ( ErrorCode, const Error[] )
{
	new File = fopen( "core/Connect.log", "a" );
		
	if ( !File )
		return;
		
	static Log[ 512 ];
	formatex( Log, 511, "^n   > %i > $s^n^n", ErrorCode, Error );
	
	___PutHeader( File );
	fputs( File, Log );
	
	fclose( File );
}

stock Handle:SQLA_Initiate ( const Database[], const Host[] = "", const User[] = "", const Password[] = "" )
{
	copy( ___Database, 255, Database );

	return ___Tuple = SQL_MakeDbTuple( Host, User, Password, Database );
}

stock Handle:SQLA_Tuple ()
	return ___Tuple;
	
stock SQLA_Query ( const Query[], ... )
{
	static sQuery[ 1024 ];
	vformat( sQuery, 1023, Query, 2 )

	new Handle:DB = SQL_Connect( ___Tuple, ___ErrorCode, ___Error, 255 );
	
	if ( !DB )
	{
		___ConnectError( ___ErrorCode, ___Error );
	
		return false;
	}
	
	new Handle:Query = SQL_PrepareQuery( DB, sQuery );
					
	if ( !SQL_Execute( Query ) || !SQL_NumResults( Query ) )
	{
		SQL_FreeHandle( Query );
		SQL_FreeHandle( DB );
		
		new File = fopen( "core/Query.log", "a" );
		
		if ( !File )
			return false;
			
		___ErrorCode = SQL_QueryError( Query, ___Error, 255 );
		
		static Log[ 512 ];
		formatex( Log, 511, "^n   > %i > $s^n^n", ___ErrorCode, ___Error );
	
		___PutHeader( File );
		fputs( File, Log );
		
		fclose( File );
		
		return false;
	}
	
	SQL_FreeHandle( Query );
	SQL_FreeHandle( DB );
}	
	
stock SQLA_ThreadedQuery ( const Query[], ... )
{
	static sQuery[ 1025 ];
	vformat( sQuery, 1024, Query, 2 )

	return SQL_ThreadQuery( ___Tuple, "___ThreadedQueryHandle", sQuery );
}

public ___ThreadedQueryHandle ( FailState, Handle:Query, Error[], ErrorCode, QueryString[], QueryStringLength )
{
	if ( FailState == TQUERY_CONNECT_FAILED )
	{
		___ConnectError ( ErrorCode, Error );
	}
	
	else if ( FailState == TQUERY_QUERY_FAILED )
	{
		new File = fopen( "core/ThreadedQuery.log", "a" );
		
		if ( !File )
			return;
		
		___PutHeader( File );
		fputs( File, "^n   > " );
		fputs( File, Error );
		fputs( File, "^n^n" );
		
		fclose( File );
	}
}
	
stock bool:SQLA_SetAffinity ( const driver[] )
{
	static active_driver[ 16 ];

	SQL_GetAffinity( active_driver, 15 );
	
	if ( !equali( active_driver, driver ) )
		return bool:SQL_SetAffinity( driver );
		
	return true;
}

// < SQLite >

stock bool:SQLite_ValidEntity ( const entity[] )
{
	new Handle:DB = SQL_Connect( ___Tuple, ___ErrorCode, ___Error, 255 );
	
	if ( !DB )
		return false;
	
	new Handle:Query = SQL_PrepareQuery( DB, "SELECT name FROM sqlite_master WHERE type = 'table' AND name = '%s' LIMIT 1;", entity );
					
	if ( !SQL_Execute( Query ) || !SQL_NumResults( Query ) )
	{
		SQL_FreeHandle( Query );
		
		return false;
	}
	
	SQL_FreeHandle( Query );
	SQL_FreeHandle( DB );

	return true;
}

stock bool:SQLite_CheckIntegrity ()
{
	new Handle:DB = SQL_Connect( ___Tuple, ___ErrorCode, ___Error, 255 );
	
	if ( !DB )
		return false;
		
	new Handle:Query = SQL_PrepareQuery( DB, "PRAGMA integrity_check" );
	
	if ( !SQL_Execute( Query ) || !SQL_NumResults( Query ) )
	{
		SQL_FreeHandle( Query );
		SQL_FreeHandle( DB );
		
		new File = fopen( "core/IntegrityCheck.log", "a" );
		
		if ( !File )
			return false;
		
		___PutHeader( File );
		fputs( File, "^n   > Query failed^n^n" );
		fclose( File );
		
		return false;
	}
	
	static Value[ 512 ];
	SQL_ReadResult( Query, 0, Value, 511 );
	SQL_FreeHandle( Query );
	SQL_FreeHandle( DB );
	
	if ( !equali( Value, "ok" ) )
	{
		new File = fopen( "core/Integrity.log", "a" );
			
		if ( File )
			return false;	
				
		___PutHeader( File );
		fputs( File, "^n   > " );
		fputs( File, Value );
		fputs( File, "^n^n" );
		fclose( File );
		
		return false;
	}
	
	return true;
}
