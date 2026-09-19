/* Map Natives
*
* by Twilight Suzuka
*  With help by Anpheus "Aaron"
*
* This file is provided as is (no warranties).
*/

#if defined _array_map_included
    #endinput
#endif
#define _array_map_included

/**\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ \**/
//   Maps by Twilight Suzuka:                           		Dynamic maps using Judy
/**\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ \**/

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Master Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Master) Map Creation
/**\ =========================================================================================== \**/

// Note: 'reserve_id' forces unit into that particular index

// Creates an keytable. 
native keytable_create( reserve_id = 0 );

// Creates a combo table.
native combotable_create( reserve_id = 0 );

// Creates a hashtable.
native hashtable_create( reserve_id = 0 );

/**\ =========================================================================================== \**/
//                             	(Master) Table Manipulation
/**\ =========================================================================================== \**/

// Deletes a map. Also clears it.
native map_delete ( map_id );

// Clears a map, but leaves it intact.
native map_clear  ( map_id );

/**\ =========================================================================================== \**/
//                             	(Master) Information Gathering
/**\ =========================================================================================== \**/

// Returns the nth unit in the master table
native map_bycount( n, start = 0);

// Returns the amount of units between start and stop
native map_count(	start = 0, stop = -1);

/**\ =========================================================================================== \**/
//                             	(Master) IO Functions
/**\ =========================================================================================== \**/

// Saves a unit to a file.
native map_save( map_id , filename[]);

// Loads from a file, into an already created unit.
native map_load( filename[] ,  map_id );

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Slave Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Slave) IO Functions
/**\ =========================================================================================== \**/

// Returns the amount of units between start and stop
native map_size( 	map_id , start = 0, stop = -1);

// Returns the nth unit in the slave table
native map_get_nth( map_id , n , start = 0);

// Returns how much memory this slave table has used
native map_memory(  map_id  );

/**\ =========================================================================================== \**/
//                             	(Slave) Table Manipulation
/**\ =========================================================================================== \**/

// Returns whether a key exists or not.
native bool:map_isempty( map_id , key[]);
native bool:map_isfilled(map, key[]);

// Removes a key from the slave table
native map_remove( 	map_id , key[]);

/**\ =========================================================================================== \**/
//                             	(Slave) Set/Get Functions
/**\ =========================================================================================== \**/

native map_set_bool(map_id, key[], bool:value );
native bool:map_get_bool(map_id, key[], disable_check = 0  );

native map_set_int(map_id, key[], value );
native map_get_int(map_id, key[], disable_check = 0   );

native map_set_float(map_id, key[], Float:value );
native Float:map_get_float(map_id, key[], disable_check = 0   );

native map_set_string(map_id, key[], value[] );
native map_get_string(map_id, key[], ret_val[], len,disable_check = 0   );

native map_set_vector(map_id, key[], Float:vector[3]);
native map_get_vector(map_id, key[], Float:vector[3], disable_check = 0   );

/**\ =========================================================================================== \**/
//                             	(Slave) Search Functions
//
//*				It is recommended that success be checked for all search functions
//*				'key' parameter defines limiters for searching
/**\ =========================================================================================== \**/

// Return end keys in slave table
native map_first(map_id , key[] = "", ret_key[], len, &success = 0);
native map_last( map_id , key[] = "", ret_key[], len,  &success = 0);

// Return neighboring keys in slave table
native map_next( map_id , key[] = "", ret_key[], len, &success = 0);
native map_prev( map_id , key[] = "", ret_key[], len, &success = 0);
