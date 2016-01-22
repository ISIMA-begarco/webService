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
using System.Windows.Shapes;

namespace ApplicationWPF
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.MainFrame.NavigationService.Navigate(new System.Uri("MainMenu.xaml", UriKind.Relative));
            MainFrame.NavigationService.LoadCompleted += FrameLoadCompleted;
        }

        void ChangeFrame (object sender, EventArgs e)
        {
            // Update de frame
            Console.WriteLine("Changement de frame Mozart Fucker.");
            this.MainFrame.NavigationService.Navigate(new System.Uri(((MainMenu)sender).nextFrame, UriKind.Relative));
        }

        void FrameLoadCompleted (object sender, EventArgs e)
        {
            MainMenu mainMenu = MainFrame.NavigationService.Content as MainMenu;
            if (mainMenu != null)
            {
                mainMenu.ChangeFrame += ChangeFrame;
            }
            else
            {
                SubMenu subMenu = MainFrame.NavigationService.Content as SubMenu;
                if (subMenu != null)
                    subMenu.ChangeFrame += ChangeFrame;
            }
            
        }
    }
}
