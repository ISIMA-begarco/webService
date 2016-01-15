using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using StubDataAccessLayer;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        private static DalManager bdd = new DalManager();

        public List<Stade> displayStades()
        {
            return bdd.getStade();
        }

        public IEnumerable<String> darkSideJedis()
        {
            IEnumerable<String> coteObscur = from x in bdd.getJedis() where x.IsSith == true select x.Nom;

            return coteObscur;
        }

        public IEnumerable<Match> getMatches200Sith()
        {
            IEnumerable<Match> matches = from x in bdd.getMatchs()
                where x.Stade.NbPlaces >= 200 && x.Jedi1.IsSith == true
                      && x.Jedi2.IsSith == true
                select x;

            return matches;

            
        }

        public static bool CheckConnexionUser(string login, string mdp)
        {
            bool isOk = false;
            Utilisateur user = bdd.GetUtilisateurByLogin(login);

            if (user != null)
            {
                if (user.Password.Equals(mdp))
                {
                    isOk = true;
                }
            }

            return isOk;
        }


    }
}
