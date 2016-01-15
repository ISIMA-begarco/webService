using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        public string Nom
        {
            get;
            set;
        }
        private string mNom;

        public string Prenom
        {
            get;
            set;
        }
        private string mPrenom;

        public string Login
        {
            get;
            set;
        }
        private string mLogin;

        public string Password
        {
            get;
            set;
        }
        private string mPassword;


        public Utilisateur()
        {
            this.Nom = "Jonas";
            this.Prenom = "Coco";
            this.Login = "JCoco";
            this.Password = "Flemme";
        }

        public Utilisateur(string nom, string prenom, string login, string password)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Login = login;
            this.Password = password;
        }

    }
}
