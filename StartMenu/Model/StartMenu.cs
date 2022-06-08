using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static StartMenu.Model.WindowList;

namespace StartMenu.Model
{
    public class StartMenu  
    {
        public WindowInformation _StartMenu;
        public string Name { get; set; } = "Пуск";
        public bool Debug
        {
            get; set;
        } = true;
        public StartMenu()
        {
            List<WindowInformation> windowListExtended = WindowList.GetAllWindowsExtendedInfo();
            WindowInformation windowInformationTree = WindowList.GetAllWindowsTree();
            _StartMenu = (from w in windowListExtended.AsEnumerable() where w.Caption.StartsWith(this.Name) select w).First();

           
        }
        public void SayDebug()
        {
            if (!IsValidWindow && Debug == false)
                return;
            Console.WriteLine($"=====================");
            Console.WriteLine($"Find name: {Name}");
            Console.WriteLine($"Handle: {_StartMenu.Handle}");
            Console.WriteLine($"Size: {WinApi.GetWindowSize(_StartMenu.Handle)}");
            Console.WriteLine($"Pos: {WinApi.GetWindowPos(_StartMenu.Handle)}");
            Console.WriteLine($"IsValidWindow: {this.IsValidWindow} IsVisible: {this.IsVisible}");
           
        }
        public void ShowWindow(STARTUPINFO s)
        {
            if (!IsValidWindow)
                return;
            WinApi.ShowWindowA(this._StartMenu.Handle, s);
        }
        public WINDOWPLACEMENT Placement
        {
            get
            {


                return WinApi.GetPlacement(_StartMenu.Handle);
            }
        }
        public bool IsOpenMenu
        {
            get
            {
                return WinApi.GetWindowText().ToLower() == "поиск";
            }
        }
        public bool IsVisible
        {
            get
            {
                if (!IsValidWindow)
                    return false;
                return WinApi.IsWindowVisible(this._StartMenu.Handle);
            }
        }
        public void SetPos(int x , int y)
        {
            if (!IsValidWindow)
                return;
            Size s = WinApi.GetWindowSize(this._StartMenu.Handle);
            WinApi.MoveWindow(this._StartMenu.Handle, x, y, (int)s.Width, (int)s.Height, true);
        }
        public void SetSize(int w, int h)
        {
            if (!IsValidWindow)
                return;
            Point p = WinApi.GetWindowPos(this._StartMenu.Handle);
            WinApi.MoveWindow(this._StartMenu.Handle, (int)p.X, (int)p.Y, w, h, true);
        }

        public bool IsValidWindow
        {
            get
            {
                return this._StartMenu != null && this._StartMenu.Handle != IntPtr.Zero;
            }
        }
    }
}
