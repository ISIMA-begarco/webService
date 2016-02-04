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

            game.Choice_j1 = EntitiesLayer.EShifumi.Aucun;
            game.Choice_j2 = EntitiesLayer.EShifumi.Aucun;

            game.Pari_j1 = 0;
            game.Pari_j2 = 0;

            Affiche1.NavigationService.Navigate(null);
            Affiche2.NavigationService.Navigate(null);
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
            if (BusinessLayer.PartieManager.getCurrentGame().J1 != null && (BusinessLayer.PartieManager.getCurrentGame().Mode.Equals(EntitiesLayer.Mode.Solo) || BusinessLayer.PartieManager.getCurrentGame().Mode.Equals(EntitiesLayer.Mode.Multi)) && BusinessLayer.PartieManager.getCurrentGame().Current_match.Jedi1.Nom == BusinessLayer.PartieManager.getCurrentGame().Jedi_j1.Nom)
            {
                Affiche1.NavigationService.Navigate(new System.Uri("Frames/GamePadFrame/ShifumiPageJ1.xaml", UriKind.Relative));
            }
            else
            {
                Random rd = new Random();
                int rand = rd.Next();
                if (rand % 3 == 0)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Ciseau;
                }
                if (rand % 3 == 1)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Papier;
                }
                if (rand % 3 == 2)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j1 = EntitiesLayer.EShifumi.Pierre;
                }
            }

            if (BusinessLayer.PartieManager.getCurrentGame().J2 != null && (BusinessLayer.PartieManager.getCurrentGame().Mode.Equals(EntitiesLayer.Mode.Solo) || BusinessLayer.PartieManager.getCurrentGame().Mode.Equals(EntitiesLayer.Mode.Multi)))
            {
                Affiche2.NavigationService.Navigate(new System.Uri("Frames/GamePadFrame/ShifumiPageJ2.xaml", UriKind.Relative));
            }
            else
            {
                Random rd = new Random();
                int rand  = rd.Next();
                if (rand % 3 == 0)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j2 = EntitiesLayer.EShifumi.Ciseau;
                }
                if (rand % 3 == 1)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j2 = EntitiesLayer.EShifumi.Papier;
                }
                if (rand % 3 == 2)
                {
                    BusinessLayer.PartieManager.getCurrentGame().Choice_j2 = EntitiesLayer.EShifumi.Pierre;
                }
            }
        }

        private void ButtonNext_Event(object sender, EventArgs e)
        {
            if(BusinessLayer.PartieManager.getCurrentGame().Current_match.JediVainqueur != null) {
                string nextFrame = "Frames/FightPage.xaml";
                BusinessLayer.PartieManager.nextMatch();
                OnFrameChanged(this, new FrameChangedEventArgs(nextFrame));
            }
        }
            

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
