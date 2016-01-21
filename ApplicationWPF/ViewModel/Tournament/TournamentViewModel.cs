using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel
{
    class TournamentViewModel : ViewModelBase
    {
        private EntitiesLayer.Tournoi m_tournament;

        public EntitiesLayer.Tournoi Tournament
        {
            get { return m_tournament; }
            set
            {
                m_tournament = value;
                OnPropertyChanged("Tournament");
            }
        }

        public TournamentViewModel (EntitiesLayer.Tournoi tournament)
        {
            m_tournament = tournament;
        }

        public string Name
        {
            get { return m_tournament.Nom; }
            set 
            { 
                m_tournament.Nom = value;
                OnPropertyChanged("Name");
            }
        }

        public List<EntitiesLayer.Match> Matchs
        {
            get { return m_tournament.Matchs; }
            set
            {
                m_tournament.Matchs = value;
                OnPropertyChanged("Matchs");
            }
        }
    }
}
