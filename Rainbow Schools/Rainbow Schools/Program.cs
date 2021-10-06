using System;

namespace Rainbow_Schools
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Menu menu = new Menu();

            if (menu.CanOpenMenu())
            {
                string option = "";

                do
                {
                    option = menu.ShowMenu();
                } while (!option.Equals("0"));
            } else
            {
                Console.WriteLine("Something wrong with datas, this program will close in 5 seconds");
                System.Threading.Thread.Sleep(5000);
            }

            

        }

       
    }
}
