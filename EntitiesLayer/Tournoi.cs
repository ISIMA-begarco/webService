using System;
using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Tournoi
    {
        private List<Match> matchs;
        private String nom;

        public Tournoi(string nom)
        {
            this.nom = nom;
        }

        public List<Match> Matchs
        {
            get { return matchs; }
            set { matchs = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}