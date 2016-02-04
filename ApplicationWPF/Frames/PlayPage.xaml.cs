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
    public partial class PlayPage : Page,IFrameNavigator
    {
        public event EventHandler<FrameChangedEventArgs> m_changeFrame;
        public string m_nextFrame;

        public PlayPage()
        {
            InitializeComponent();
            this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/OnePlayerPage.xaml", UriKind.Relative));

        }

        private void WindowLoaded(object sender, EventArgs args)
        {
            BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();

            // Gestion des Tournois
            IList<EntitiesLayer.Tournoi> tournaments = jtm.getTournois();
            ViewModel.Tournament.TournamentsViewModel tvm = new ViewModel.Tournament.TournamentsViewModel(tournaments);
            usrCtrlTournoiCombo.DataContext = tvm;

            BusinessLayer.PartieManager.startNewGame();
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

        private void ButtonStart_Event(object sender, EventArgs e)
        {

            if(this.usrCtrlTournoiCombo.cbTournoi.SelectedItem != null && BusinessLayer.PartieManager.getCurrentGame().Jedi_j1 != null )
            {
                string nextFrame = "Frames/FightPage.xaml";

                ViewModel.Tournament.TournamentViewModel t = this.usrCtrlTournoiCombo.cbTournoi.SelectedItem as ViewModel.Tournament.TournamentViewModel;
                BusinessLayer.PartieManager.setCurrentGameTournament(t.Tournament);

                switch (BusinessLayer.PartieManager.getCurrentGame().Mode)

                {
                    case EntitiesLayer.Mode.Solo:
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(0, "J1", 0), 1);
                        break;
                    case EntitiesLayer.Mode.Multi:
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(0, "J1", 0), 1);
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(1, "J2", 0), 2);
                        break;
                    case EntitiesLayer.Mode.MultiPari:
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(0, "J1", 0), 1);
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(1, "J2", 0), 2);
                        break;
                    case EntitiesLayer.Mode.SoloPari:
                        BusinessLayer.PartieManager.setCurrentPlayer(new EntitiesLayer.Joueur(0, "J1", 0), 1);
                        break;
                }

                OnFrameChanged(this, new FrameChangedEventArgs(nextFrame));
            }
            
        }

        private void OnPlayChoiceOnePlayer_Click(object sender, EventArgs e)
        {
            this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/OnePlayerPage.xaml", UriKind.Relative));
            BusinessLayer.PartieManager.setCurrentGameMode(EntitiesLayer.Mode.Solo);
        }

        private void OnPlayChoiceMultiplayer_Click(object sender, EventArgs e)
        {
           this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/MultiplayerPage.xaml", UriKind.Relative));
            BusinessLayer.PartieManager.setCurrentGameMode(EntitiesLayer.Mode.Multi);
        }

        private void OnPlayChoiceMultiplayerPari_Click(object sender, EventArgs e)
        {
            this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/PariMultiplayer.xaml", UriKind.Relative));
            BusinessLayer.PartieManager.setCurrentGameMode(EntitiesLayer.Mode.MultiPari);
        }

        private void OnPlayChoiceSoloPari_Click(object sender, EventArgs e)
        {
            this.ModeChoice.NavigationService.Navigate(new System.Uri("Frames/PlayPageFrame/PariOnePlayer.xaml", UriKind.Relative));
            BusinessLayer.PartieManager.setCurrentGameMode(EntitiesLayer.Mode.SoloPari);
        }
    }
}
