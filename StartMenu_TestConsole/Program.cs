using StartMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartMenu_TestConsole
{
    
    internal class Program
    {
        static Random R = new Random();
        static void Main(string[] args)
        {
            StartMenu.Model.StartMenu startMenu = new StartMenu.Model.StartMenu();
            startMenu.ShowWindow(StartMenu.Model.WindowList.STARTUPINFO.SW_SHOW);
            while (true)
            {
                //startMenu.SayDebug();

                //Console.WriteLine($"{startMenu.Placement.rcNormalPosition}");
                //Console.WriteLine($"{startMenu.Placement.ptMinPosition}");
                //Console.WriteLine($"{WinApi.GetForegroundWindow() == startMenu._StartMenu.Handle}");
                //Console.WriteLine($"{startMenu.IsOpenMenu}");
                //Console.WriteLine($"{WinApi.GetWindowText()}");
                //startMenu.SetPos()
                //startMenu.SetPos(0, 0);
                //startMenu.SetSize(1200, 1200);

                Thread.Sleep(10);
            }
            Console.ReadLine();
        }

    }
}
