using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel
{
    class MatchViewModel : ViewModelBase
    {
        private EntitiesLayer.Match m_match;

        public MatchViewModel(EntitiesLayer.Match match)
        {
            m_match = match;
        }

        public EntitiesLayer.Jedi Jedi1
        {
            get { return m_match.Jedi1; }
            set
            {
                m_match.Jedi1 = value;
                OnPropertyChanged("Jedi1");
            }
        }

        public EntitiesLayer.Jedi Jedi2
        {
            get { return m_match.Jedi2; }
            set
            {
                m_match.Jedi2 = value;
                OnPropertyChanged("Jedi2");
            }
        }

        public EntitiesLayer.Stade Stade
        {
            get { return m_match.Stade; }
            set
            {
                m_match.Stade = value;
                OnPropertyChanged("Stade");
            }
        }

        public EntitiesLayer.EPhaseTournoi Tournoi
        {
            get { return m_match.PhaseTournoi; }
            set
            {
                m_match.PhaseTournoi = value;
                OnPropertyChanged("Tournoi");
            }
        }

        /*public EntitiesLayer.Jedi Vainqueur
        {
            get 
            {
                
            }
            set { }
        }*/
    }
}
