using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationWPF
{
    /// <summary>
    /// Logique d'interaction pour SubMenu.xaml
    /// </summary>
    public partial class SubMenu : Page
    {
        public event EventHandler ChangeFrame;
        public string nextFrame;

        public SubMenu()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Event(object sender, EventArgs e)
        {
            nextFrame = "ConnexionWindow.xaml";
            ChangeFrame(this, e);
        }

        private void ButtonManage_Event(object sender, EventArgs e)
        {
            nextFrame = "ConnexionWindow.xaml";
            ChangeFrame(this, e);
        }

        private void ButtonQuit_Event(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
