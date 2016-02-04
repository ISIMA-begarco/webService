using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace ApplicationWPF.ViewModel.Tournament
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

        public string MatchsString
        {
            get
            {
                string res = "";
                foreach (EntitiesLayer.Match match in m_tournament.Matchs)
                    res += match.Stade.Planete + ", ";
                return res;
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

        public string Match1
        {
            get { return m_tournament.Matchs[0].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[0] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match1");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match2
        {
            get { return m_tournament.Matchs[1].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[1] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match2");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match3
        {
            get { return m_tournament.Matchs[2].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[2] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match3");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match4
        {
            get { return m_tournament.Matchs[3].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[3] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match4");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match5
        {
            get { return m_tournament.Matchs[4].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[4] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match5");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match6
        {
            get { return m_tournament.Matchs[5].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[5] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match6");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match7
        {
            get { return m_tournament.Matchs[6].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[6] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match7");
                OnPropertyChanged("MatchsString");
            }
        }

        public string Match8
        {
            get { return m_tournament.Matchs[7].Stade.Planete; }
            set
            {
                BusinessLayer.JediTournamentManager jtm = new BusinessLayer.JediTournamentManager();
                m_tournament.Matchs[7] = (from x in jtm.getMatches()
                                          where x.Stade.Planete == value
                                          select x).FirstOrDefault();
                OnPropertyChanged("Matchs");
                OnPropertyChanged("Match8");
                OnPropertyChanged("MatchsString");
            }
        }
    }
}
