using System;

namespace Rainbow_Schools
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Menu menu = new Menu();

            string option = "";

            do
            {
                option = menu.ShowMenu();
            } while (!option.Equals("0"));

        }

       
    }
}
