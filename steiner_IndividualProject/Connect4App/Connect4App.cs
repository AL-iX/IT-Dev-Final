using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4App
{
    class Connect4App
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            admin.ConsoleSetup();             
            
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
