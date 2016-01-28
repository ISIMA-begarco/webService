﻿using System;

namespace EntitiesLayer
{
    public class Caracteristique : EntityObject
    {
        private EDefCaracteristique definition;
        private String               nom;
        private ETypeCaracteristique type;
        private int valeur;

        public Caracteristique(EDefCaracteristique definition, string nom, ETypeCaracteristique type, int valeur)
        {
            this.definition = definition;
            this.nom = nom;
            this.type = type;
            this.valeur = valeur;
        }

        public EDefCaracteristique Definition
        {
            get { return definition; }
            set { definition = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public ETypeCaracteristique Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public static int Id
        {
            get { return ID; }
            set { ID = value; }
        }



    }
}