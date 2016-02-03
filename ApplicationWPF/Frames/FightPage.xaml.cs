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
    /// Logique d'interaction pour FightPage.xaml
    /// </summary>
    public partial class FightPage : Page, IFrameNavigator
    {

        public event EventHandler<FrameChangedEventArgs> m_changeFrame;
        public string m_nextFrame;

        public FightPage()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, EventArgs args)
        {
            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();

            // Gestion de la Partie
            EntitiesLayer.Partie game = BusinessLayer.PartieManager.getCurrentGame();
            ViewModel.Partie.PartieViewModel gvm = new ViewModel.Partie.PartieViewModel(game);
            Concurent1Img.DataContext = gvm.Current_match.Jedi1;
            Concurent2Img.DataContext = gvm.Current_match.Jedi2;
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
    }
}
