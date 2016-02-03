using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Match
{
    class MatchViewModel : ViewModelBase
    {
        private EntitiesLayer.Match m_match;

        public MatchViewModel(EntitiesLayer.Match match)
        {
            m_match = match;
        }

        public string Jedi1
        {
            get
            {
                string res = "New";
                if (m_match.Jedi1 != null)
                    res = m_match.Jedi1.Nom;
                return res;
            }
            set
            {
                //m_match.Jedi1 = value;
                OnPropertyChanged("Jedi1");
            }
        }

        public string Jedi2
        {
            get
            {
                string res = "New";
                if (m_match.Jedi2 != null)
                    res = m_match.Jedi2.Nom;
                return res;
            }
            set
            {
                //m_match.Jedi2 = value;
                OnPropertyChanged("Jedi2");
            }
        }

        public string Stade
        {
            get
            {
                string res = "New";
                if (m_match.Stade != null)
                    res = m_match.Stade.Planete;
                return res;
            }
            set
            {
                //m_match.Stade = value;
                OnPropertyChanged("Stade");
            }
        }

        public EntitiesLayer.EPhaseTournoi PhaseTournoi
        {
            get
            {
                return m_match.PhaseTournoi;
            }
            set
            {
                m_match.PhaseTournoi = value;
                OnPropertyChanged("Tournoi");
            }
        }

        public string Vainqueur
        {
            get
            {
                string res = "Inconnu";
                if (m_match.JediVainqueur != null)
                    res = m_match.JediVainqueur.Nom;
                return res;
            }
            set
            {
                m_match.JediVainqueur = m_match.Jedi1;
                if (value == m_match.Jedi2.Nom)
                    m_match.JediVainqueur = m_match.Jedi2;
                OnPropertyChanged("Vainqueur");
            }
        }
    }
}
