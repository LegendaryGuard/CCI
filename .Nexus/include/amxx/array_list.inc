/* List Natives
*
* by Twilight Suzuka
*  With help by Anpheus "Aaron"
*
* This file is provided as is (no warranties).
*/

#if defined _array_list_included
    #endinput
#endif
#define _array_list_included

/**\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ \**/
//   Lists by Twilight Suzuka:                           		Dynamic lists using Judy
/**\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ \**/

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Master Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Master) List Creation
/**\ =========================================================================================== \**/

// Note: 'reserve_id' forces unit into that particular index

// Creates an array.
native array_create( reserve_id = 0 );

// Creates a combo array. 
native comboarray_create( reserve_id = 0 );

/**\ =========================================================================================== \**/
//                             	(Master) Table Manipulation
/**\ =========================================================================================== \**/

// Deletes a list. Also clears it.
native list_delete ( list_id );

// Clears a list, but leaves it intact.
native list_clear  ( list_id );

/**\ =========================================================================================== \**/
//                             	(Master) Information Gathering
/**\ =========================================================================================== \**/

// Returns the nth unit in the master table
native list_bycount( n, start = 0);

// Returns the amount of units between start and stop
native list_count(	start = 0, stop = -1);

/**\ =========================================================================================== \**/
//                             	(Master) IO Functions
/**\ =========================================================================================== \**/

// Saves a unit to a file.
native list_save( list_id , filename[]);

// Loads from a file, into an already created unit.
native list_load( filename[] ,  list_id );

/////////////////////////////////////////////////////////////////////////////////////////////////////
				///*		Slave Table Functions		*///
/////////////////////////////////////////////////////////////////////////////////////////////////////

/**\ =========================================================================================== \**/
//                             	(Slave) IO Functions
/**\ =========================================================================================== \**/

// Returns the amount of units between start and stop
native list_size( 	list_id , start = 0, stop = -1);

// Returns the nth unit in the slave table
native list_get_nth( list_id , n , start = 0);

// Returns how much memory this slave table has used
native list_memory(  list_id  );

/**\ =========================================================================================== \**/
//                             	(Slave) Table Manipulation
/**\ =========================================================================================== \**/

// Returns whether a key exists or not.
native bool:list_isempty( list_id , key);
native bool:list_isfilled(list, key);

// Removes a key from the slave table
native list_remove( 	list_id , key);

/**\ =========================================================================================== \**/
//                             	(Slave) Set/Get Functions
/**\ =========================================================================================== \**/

native list_set_bool(list_id, key, bool:value );
native bool:list_get_bool(list_id, key, disable_check = 0  );

native list_set_int(list_id, key, value );
native list_get_int(list_id, key, disable_check = 0   );

native list_set_float(list_id, key, Float:value );
native Float:list_get_float(list_id, key, disable_check = 0   );

native list_set_string(list_id, key, value[] );
native list_get_string(list_id, key, ret_val[], len,disable_check = 0   );

native list_set_vector(list_id, key, Float:vector[3]);
native list_get_vector(list_id, key, Float:vector[3], disable_check = 0   );

/**\ =========================================================================================== \**/
//                             	(Slave) Search Functions
//
//*				It is recommended that success be checked for all search functions
//*				'key' parameter defines limiters for searching
/**\ =========================================================================================== \**/

// Return end keys in slave table
native list_first(list_id , key =  0, &success = 0);
native list_last( list_id , key = -1, &success = 0);

// Return neighboring keys in slave table
native list_next( list_id , key =  0, &success = 0);
native list_prev( list_id , key = -1, &success = 0);

/**\ =========================================================================================== \**/
//                             	(Slave) Search Empty Functions
//
//*				It is recommended that success be checked for all search functions
//*				'key' parameter defines limiters for searching
/**\ =========================================================================================== \**/

// Return unset end keys in slave table
native list_firstempty(list_id , key =  0, &success = 0);
native list_lastempty( list_id , key = -1, &success = 0);

// Return neighboring unset keys in slave table
native list_nextempty( list_id , key =  0, &success = 0);
native list_prevempty( list_id , key = -1, &success = 0);

