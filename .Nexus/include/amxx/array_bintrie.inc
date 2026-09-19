/* Bintrie Natives
*
* by Twilight Suzuka
*  With help by Anpheus "Aaron"
*
* This file is provided as is (no warranties).
*/

#if defined _array_bintrie_included
    #endinput
#endif
#define _array_bintrie_included

/**\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ \**/
//	BinTries by Twilight Suzuka:                           Dynamic boolean arrays using Judy
/**\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ \**/

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Master Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Master) Map Creation
/**\ =========================================================================================== \**/

// Note: 'reserve_id' forces unit into that particular index

// Creates a bintrie. 
native bintrie_create ( reserve_id = 0);

/**\ =========================================================================================== \**/
//                             	(Master) Table Manipulation
/**\ =========================================================================================== \**/

// Deletes a bintrie. Also clears it.
native bintrie_delete ( bintrie_id );

// Clears a bintrie, but leaves it intact.
native bintrie_clear  ( bintrie_id );

/**\ =========================================================================================== \**/
//                             	(Master) Information Gathering
/**\ =========================================================================================== \**/

// Returns the nth unit in the master table
native bintrie_bycount( n, start = 0);

// Returns the amount of units between start and stop
native bintrie_count(	start = 0, stop = -1);

/**\ =========================================================================================== \**/
//                             	(Master) IO Functions
/**\ =========================================================================================== \**/

// Saves a unit to a file.
native bintrie_save( bintrie_id , filename[]);

// Loads from a file, into an already created unit.
native bintrie_load( filename[] ,  bintrie_id );

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Slave Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Slave) IO Functions
/**\ =========================================================================================== \**/

// Returns the amount of units between start and stop
native bintrie_size( 	bintrie_id , start = 0, stop = -1);

// Returns the nth unit in the slave table
native bintrie_get_nth( bintrie_id , n , start = 0);

// Returns how much memory this slave table has used
native bintrie_memory(  bintrie_id  );

/**\ =========================================================================================== \**/
//                             	(Slave) Table Manipulation
/**\ =========================================================================================== \**/

// Returns whether a key exists or not.
native bool:bintrie_isempty( bintrie_id , key);
native bool:bintrie_isfilled(bintrie, key);

// Removes a key from the slave table
native bintrie_remove( 	bintrie_id , key);

/**\ =========================================================================================== \**/
//                             	(Slave) Set/Get Functions
/**\ =========================================================================================== \**/

// Sets a key to a value in the slave table
native bintrie_set( 	bintrie_id , key, bool:value);

// Gets a value back from the slave table
native bool:bintrie_get(bintrie_id , key);

/**\ =========================================================================================== \**/
//                             	(Slave) Search Functions
//
//*				It is recommended that success be checked for all search functions
//*				'key' parameter defines limiters for searching
/**\ =========================================================================================== \**/

// Return end keys in slave table
native bintrie_first(bintrie_id , key =  0, &success = 0);
native bintrie_last( bintrie_id , key = -1, &success = 0);

// Return neighboring keys in slave table
native bintrie_next( bintrie_id , key =  0, &success = 0);
native bintrie_prev( bintrie_id , key = -1, &success = 0);

/**\ =========================================================================================== \**/
//                             	(Slave) Search Empty Functions
//
//*				It is recommended that success be checked for all search functions
//*				'key' parameter defines limiters for searching
/**\ =========================================================================================== \**/

// Return unset end keys in slave table
native bintrie_firstempty(bintrie_id , key =  0, &success = 0);
native bintrie_lastempty( bintrie_id , key = -1, &success = 0);

// Return neighboring unset keys in slave table
native bintrie_nextempty( bintrie_id , key =  0, &success = 0);
native bintrie_prevempty( bintrie_id , key = -1, &success = 0);

