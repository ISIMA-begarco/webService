using System;
using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Stade
    {
        private int nbPlaces;
        private String planete;
        private List<Caracteristique> caracteristiques;

        public Stade(int nbPlaces, string planete, List<Caracteristique> caracteristiques)
        {
            this.nbPlaces = nbPlaces;
            this.planete = planete;
            this.caracteristiques = caracteristiques;
        }

        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
            set { caracteristiques = value; }
        }

        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        public string Planete
        {
            get { return planete; }
            set { planete = value; }
        }
    }
}