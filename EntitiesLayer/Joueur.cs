using System;

namespace EntitiesLayer
{
    public class Joueur : EntityObject
    {
        private String nom;
        private int score;

        public Joueur(string nom, int score)
        {
            this.nom = nom;
            this.score = score;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public static int Id
        {
            get { return ID; }
            set { ID = value; }
        }
    }
}