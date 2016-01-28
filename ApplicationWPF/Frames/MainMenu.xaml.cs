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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page, IFrameNavigator
    {
        public event EventHandler m_changeFrame;
        public string m_nextFrame;

        public MainMenu()
        {
            InitializeComponent();
        }

        public string NextFrame
        {
            get { return m_nextFrame; }
            set { m_nextFrame = value; }
        }

        public EventHandler ChangeFrame
        {
            get { return m_changeFrame; }
            set { m_changeFrame = value; }
        }

        private void ButtonPlay_Event(object sender, EventArgs e)
        {
            m_nextFrame = "Frames/PlayPage.xaml";
            ChangeFrame(this, e);
        }

        private void ButtonManage_Event(object sender, EventArgs e)
        {
            m_nextFrame = "Frames/PlayMenu.xaml";
            ChangeFrame(this, e);
        }

        private void ButtonQuit_Event(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
