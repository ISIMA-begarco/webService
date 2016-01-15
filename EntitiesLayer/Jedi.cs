using System;
using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Jedi: EntityObject
    {
        private List<Caracteristique> caracteristiques;
        private int coteObscur;
        private bool isSith;
        private String nom;
        private int niveauBlessure;

       

        public Jedi(List<Caracteristique> caracteristiques, int coteObscur, bool isSith, string nom)
        {
            this.caracteristiques = caracteristiques;
            this.coteObscur = coteObscur;
            this.isSith = isSith;
            this.nom = nom;
            niveauBlessure = 0;
        }

        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
            set { caracteristiques = value; }
        }

        public int CoteObscur
        {
            get { return coteObscur; }
            set { coteObscur = value; }
        }

        public bool IsSith
        {
            get { return isSith; }
            set { isSith = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public static int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public int NiveauBlessure
        {
            get { return niveauBlessure; }
            set { niveauBlessure = value; }
        }
    }
}