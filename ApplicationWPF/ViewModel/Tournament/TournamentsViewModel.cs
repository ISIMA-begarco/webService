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
        private TournamentViewModel m_selectedItem;

        private RelayCommand m_addCommand;
        private RelayCommand m_removeCommand;
        private RelayCommand m_closeCommand;
        
        public ObservableCollection<TournamentViewModel> Tournaments
        {
            get { return m_tournaments; }
            private set
            {
                m_tournaments = value;
                OnPropertyChanged("Tournaments");
            }
        }


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



        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (m_addCommand == null)
                {
                    m_addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return m_addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            EntitiesLayer.Tournoi t = new EntitiesLayer.Tournoi("");
            this.SelectedItem = new TournamentViewModel(t);
            m_tournaments.Add(this.SelectedItem);
        }

        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (m_removeCommand == null)
                {
                    m_removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return m_removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) m_tournaments.Remove(this.SelectedItem);
        }
    }
}
