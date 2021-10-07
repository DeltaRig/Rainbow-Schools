using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools.Interfaces
{
    interface IMenu
    {
        /// <summary>
        /// Method <c>CanOpenMenu</c> call Class <c>ManagerDatabe</c> to get all data and check if the menu can be open.
        /// </summary>
        /// <returns>Return true if all option of menu will be working 
        /// and if something wrong to get the data will return false because somethings of menu don't work</returns>
        Boolean CanOpenMenu();

        /// <summary>
        /// Method <c>ShowMenu</c> shows the menu, receive an option from the user and will appear the result of the option.
        /// </summary>
        /// <returns>Return the option in the menu to the program knows when close.</returns>
        string ShowMenu();

    }
}
