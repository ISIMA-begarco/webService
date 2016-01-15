using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Tournament
{
    class TournamentsViewModel : ViewModelBase
    {
        private ObservableCollection<TournamentViewModel> m_tournaments;
        
        public ObservableCollection<TournamentViewModel> Tournaments
        {
            get { return m_tournaments; }
            private set
            {
                m_tournaments = value;
                OnPropertyChanged("Tournaments");
            }
        }

        private TournamentViewModel m_selectedItem;

        public TournamentViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public TournamentsViewModel(IList<EntitiesLayer.Tournoi> tournamentModel)
        {
            m_tournaments = new ObservableCollection<TournamentViewModel>();
            foreach (EntitiesLayer.Tournoi t in tournamentModel)
            {
                m_tournaments.Add(new TournamentViewModel(t));
            }
        }
    }
}
