using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public enum Mode { Solo, Multi, SoloPari, MultiPari};
    public class Partie
    {
        private Mode m_mode;
        private Tournoi m_tournament;

        private Joueur m_j1;
        private Joueur m_j2;

        private Jedi m_jedi_j1;
        private Jedi m_jedi_j2;

        private EShifumi m_choice_j1;
        private EShifumi m_choice_j2;


        private int m_bourse_j1;
        private int m_bourse_j2;

        private int m_pari_j1;
        private int m_par1_j2;



        public Partie()
        {

        }
    }
}
