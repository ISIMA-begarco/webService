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

namespace ApplicationWPF.Frames
{
    /// <summary>
    /// Logique d'interaction pour PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        public event EventHandler<FrameChangedEventArgs> m_changeFrame;
        public string m_nextFrame;

        public PlayPage()
        {
            InitializeComponent();
            this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/OnePlayerPage.xaml", UriKind.Relative));

        }        

        public string NextFrame
        {
            get { return m_nextFrame; }
            set { m_nextFrame = value; }
        }

        public EventHandler<FrameChangedEventArgs> OnFrameChanged
        {
            get { return m_changeFrame; }
            set { m_changeFrame = value; }
        }



        private void ButtonBack_Event(object sender, EventArgs e)
        {
            string nextFrame = "Frames/MainMenu.xaml";
            OnFrameChanged(this, new FrameChangedEventArgs(nextFrame));
        }

        private void OnPlayChoice_Click(object sender, EventArgs e)
        {
            string nextFrame = "Frames/PlayPageFrame/OnePlayerPage.xaml";
            OnFrameChanged(this.ModeChoice, new FrameChangedEventArgs(nextFrame));
        }
    }
}
