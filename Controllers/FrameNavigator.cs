using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chemistry_app.Controllers
{
    internal class FrameNavigator//Переключение по Page
    {
        public static Frame MainFrame { get; set; }
        public FrameNavigator()
        {
            MainFrame = new Frame();
        }
    }
}
