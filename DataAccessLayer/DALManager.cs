using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalManager
    {
        IBridge bdd;

        public DalManager()
        {
            bdd = new MSSQLSFile("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:/Users/Kami/Source/Repos/webService/Database/JediTournament.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public List<Jedi> getJedis()
        {
            return bdd.getJedis();
        }
        public List<Stade> getStades()
        {
            return bdd.getStades();
        }
        public List<Match> getMatches()
        {
            return bdd.getMatches();
        }
        public List<Caracteristique> getCaracteristiques()
        {
            return bdd.getCaracteristiques();
        }
        public void setJedis()
        {
            
        }
        public void setStades()
        {

        }
        public void setMatches()
        {

        }
        public void setCaracteristiques()
        {

        }

        public Utilisateur GetUtilisateurByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
