/* Stocks and Legacy Support
*
* by Twilight Suzuka
*  With help by Anpheus "Aaron"
*
* This file is provided as is (no warranties).
*/

#if defined _array_stocks_included
    #endinput
#endif
#define _array_stocks_included

///////////////////////////////////////
//*	Stock support for arrays	*//
///////////////////////////////////////

#define array_clear list_clear
#define array_delete list_delete
#define array_save list_save
#define array_load list_load

#define array_count list_count
#define array_bycount list_bycount
#define array_memory list_memory

#define array_remove list_remove
#define array_set_bool list_set_bool
#define array_get_bool list_get_bool
#define array_set_int list_set_int
#define array_get_int list_get_int
#define array_set_float list_set_float
#define array_get_float list_get_float
#define array_set_string list_set_string
#define array_get_string list_get_string
#define array_set_vector list_set_vector
#define array_get_vector list_get_vector

#define array_size list_size
#define array_get_nth list_get_nth
#define array_isempty list_isempty
#define array_isfilled list_isfilled

#define array_first list_first
#define array_last list_last
#define array_next list_next
#define array_prev list_prev

#define array_firstempty list_firstempty
#define array_lastempty list_lastempty
#define array_nextempty list_nextempty
#define array_prevempty list_prevempty

///////////////////////////////////////
//*	Stock support for comboarrays	*//
///////////////////////////////////////

#define comboarray_clear list_clear
#define comboarray_delete list_delete
#define comboarray_save list_save
#define comboarray_load list_load

#define comboarray_count list_count
#define comboarray_bycount list_bycount
#define comboarray_memory list_memory

#define comboarray_remove list_remove
#define comboarray_set_bool list_set_bool
#define comboarray_get_bool list_get_bool
#define comboarray_set_int list_set_int
#define comboarray_get_int list_get_int
#define comboarray_set_float list_set_float
#define comboarray_get_float list_get_float
#define comboarray_set_string list_set_string
#define comboarray_get_string list_get_string
#define comboarray_set_vector list_set_vector
#define comboarray_get_vector list_get_vector

#define comboarray_size list_size
#define comboarray_get_nth list_get_nth
#define comboarray_isempty list_isempty
#define comboarray_isfilled list_isfilled

#define comboarray_first list_first
#define comboarray_last list_last
#define comboarray_next list_next
#define comboarray_prev list_prev

#define comboarray_firstempty list_firstempty
#define comboarray_lastempty list_lastempty
#define comboarray_nextempty list_nextempty
#define comboarray_prevempty list_prevempty

///////////////////////////////////////
//*	Stock support for keytables	*//
///////////////////////////////////////

#define keytable_clear map_clear
#define keytable_delete map_delete
#define keytable_save map_save
#define keytable_load map_load

#define keytable_count map_count
#define keytable_bycount map_bycount
#define keytable_memory map_memory

#define keytable_remove map_remove
#define keytable_set_bool map_set_bool
#define keytable_get_bool map_get_bool
#define keytable_set_int map_set_int
#define keytable_get_int map_get_int
#define keytable_set_float map_set_float
#define keytable_get_float map_get_float
#define keytable_set_string map_set_string
#define keytable_get_string map_get_string
#define keytable_set_vector map_set_vector
#define keytable_get_vector map_get_vector

#define keytable_size map_size
#define keytable_get_nth map_get_nth
#define keytable_isempty map_isempty
#define keytable_isfilled map_isfilled

#define keytable_first map_first
#define keytable_last map_last
#define keytable_next map_next
#define keytable_prev map_prev

///////////////////////////////////////
//*	Stock support for hashtables	*//
///////////////////////////////////////

#define hashtable_clear map_clear
#define hashtable_delete map_delete
#define hashtable_save map_save
#define hashtable_load map_load

#define hashtable_count map_count
#define hashtable_bycount map_bycount
#define hashtable_memory map_memory

#define hashtable_remove map_remove
#define hashtable_set_bool map_set_bool
#define hashtable_get_bool map_get_bool
#define hashtable_set_int map_set_int
#define hashtable_get_int map_get_int
#define hashtable_set_float map_set_float
#define hashtable_get_float map_get_float
#define hashtable_set_string map_set_string
#define hashtable_get_string map_get_string
#define hashtable_set_vector map_set_vector
#define hashtable_get_vector map_get_vector

#define hashtable_size map_size
#define hashtable_get_nth map_get_nth
#define hashtable_isempty map_isempty
#define hashtable_isfilled map_isfilled

///////////////////////////////////////
//*	Stock support for combotables	*//
///////////////////////////////////////

#define combotable_clear map_clear
#define combotable_delete map_delete
#define combotable_save map_save
#define combotable_load map_load

#define combotable_count map_count
#define combotable_bycount map_bycount
#define combotable_memory map_memory

#define combotable_remove map_remove
#define combotable_set_bool map_set_bool
#define combotable_get_bool map_get_bool
#define combotable_set_int map_set_int
#define combotable_get_int map_get_int
#define combotable_set_float map_set_float
#define combotable_get_float map_get_float
#define combotable_set_string map_set_string
#define combotable_get_string map_get_string
#define combotable_set_vector map_set_vector
#define combotable_get_vector map_get_vector

#define combotable_size map_size
#define combotable_get_nth map_get_nth
#define combotable_isempty map_isempty
#define combotable_isfilled map_isfilled

#define combotable_first map_first
#define combotable_last map_last
#define combotable_next map_next
#define combotable_prev map_prev

///////////////////////////////////////
//*	Legacy support for arrays	*//
///////////////////////////////////////

#define new_array       array_create
#define clear_array     list_clear
#define delete_array    list_delete

#define remove_cell list_remove

#define set_cell_int        list_set_int
#define get_cell_int        list_get_int
#define set_cell_float      list_set_float
#define get_cell_float      list_get_float
#define set_cell_string     list_set_string
#define get_cell_string     list_get_string
#define set_cell_vector     list_set_vector
#define get_cell_vector     list_get_vector