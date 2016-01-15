using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Match : EntityObject
    {
        private int idJediVainqueur;
        private Jedi jedi1;
        private Jedi jedi2;
        private EPhaseTournoi phaseTournoi;
        private Stade stade;

        public Match(List<Caracteristique> caracteristiques, int idJediVainqueur, Jedi jedi1, Jedi jedi2, EPhaseTournoi phaseTournoi, Stade stade)
        {
            this.idJediVainqueur = idJediVainqueur;
            this.jedi1 = jedi1;
            this.jedi2 = jedi2;
            this.phaseTournoi = phaseTournoi;
            this.stade = stade;
        }

        public Match(Jedi jedi1, Jedi jedi2, EPhaseTournoi phaseTournoi, Stade stade)
        {
            this.jedi1 = jedi1;
            this.jedi2 = jedi2;
            this.phaseTournoi = phaseTournoi;
            this.stade = stade;
        }

       
        public int IdJediVainqueur
        {
            get { return idJediVainqueur; }
            set { idJediVainqueur = value; }
        }

        public Jedi Jedi1
        {
            get { return jedi1; }
            set { jedi1 = value; }
        }

        public Jedi Jedi2
        {
            get { return jedi2; }
            set { jedi2 = value; }
        }

        public EPhaseTournoi PhaseTournoi
        {
            get { return phaseTournoi; }
            set { phaseTournoi = value; }
        }

        public Stade Stade
        {
            get { return stade; }
            set { stade = value; }
        }

        public static int Id
        {
            get { return ID; }
            set { ID = value; }
        }
    }
}