using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.IO;

namespace DataAccessLayer
{
    public class DalManager
    {
        IBridge bdd;

        public DalManager()
        {
            string root = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Environment.CurrentDirectory.Split(new string[] { "JediTournamentConsole" }, StringSplitOptions.None)[0] + "Database\\JediTournament.mdf;Integrated Security=True;Connect Timeout=30";
            bdd = new MSSQLSFile(root);
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
