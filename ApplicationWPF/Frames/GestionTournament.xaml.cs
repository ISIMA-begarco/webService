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

using ApplicationWPF.ViewModel;

namespace ApplicationWPF.Frames
{
    /// <summary>
    /// Interaction logic for GestionTournament.xaml
    /// </summary>
    public partial class GestionTournament : Page, IFrameNavigator
    {
        public event EventHandler<FrameChangedEventArgs> m_changeFrame;

        public EventHandler<FrameChangedEventArgs> OnFrameChanged
        {
            get { return m_changeFrame; }
            set { m_changeFrame = value; }
        }

        public GestionTournament()
        {
            InitializeComponent();
        }

        private void WindowLoaded (object sender, EventArgs e)
        {
            BusinessLayer.JediTournamentManager tm = new BusinessLayer.JediTournamentManager();

            // Initialisation des Jedis
            IList<EntitiesLayer.Jedi> jedis = tm.getJedis();
            ViewModel.Jedi.JedisModelView jvm = new ViewModel.Jedi.JedisModelView(jedis);
            ucJedis.DataContext = jvm;

            // Initialisation des Stade
            IList<EntitiesLayer.Stade> stades = tm.getStades();
            ViewModel.Stade.StadesViewModel svm = new ViewModel.Stade.StadesViewModel(stades);
            ucStade.DataContext = svm;

            // Initialisation des Matchs
            IList<EntitiesLayer.Match> matchs = tm.getMatches();
            ViewModel.Match.MatchsViewModel mvm = new ViewModel.Match.MatchsViewModel(matchs);
            ucMatchs.DataContext = mvm;

            // Initialisation des Tournois
            IList<EntitiesLayer.Tournoi> tournois = tm.getTournois();
            ViewModel.Tournament.TournamentsViewModel tvm = new ViewModel.Tournament.TournamentsViewModel(tournois);
            ucTournoi.DataContext = tvm;
        }

        private void ButtonSoft_Loaded(object sender, RoutedEventArgs e)
        {
            //passage à la page newJedi depuis le boutton Ajouter
            Uri uri = new Uri("Frames/NewJediPagexaml.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ButtonBak_Event(object sender, EventArgs e)
        {
            string nextFrame = "Frames/MainMenu.xaml";
            OnFrameChanged(this, new FrameChangedEventArgs(nextFrame));
        }
    }
}
