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

using ApplicationWPF.Frames;

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

            this.MainFrame.NavigationService.Navigate(new System.Uri("Frames/MainMenu.xaml", UriKind.Relative));
            MainFrame.NavigationService.LoadCompleted += FrameLoadCompleted;
        }

        void ChangeFrame (object sender, EventArgs e)
        {
            // Update de frame
            Console.WriteLine("Changement de frame Mozart Fucker.");
            this.MainFrame.NavigationService.Navigate(new System.Uri(((IFrameNavigator)sender).NextFrame, UriKind.Relative));
        }

        void FrameLoadCompleted (object sender, EventArgs e)
        {
            IFrameNavigator frame = MainFrame.NavigationService.Content as IFrameNavigator;
            if (frame != null)
            {
                frame.ChangeFrame += ChangeFrame;
            }
        }
    }
}
