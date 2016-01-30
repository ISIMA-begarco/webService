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
            string root = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Split(new string[] { "JediTournamentConsole" }, StringSplitOptions.None)[0] + "Database\\JediTournament.mdf;Integrated Security=True;Connect Timeout=30";//"Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\alnoel4\\Source\\Repos\\webService\\Database\\JediTournament.mdf;Integrated Security=True;Connect Timeout=30";
            /// AVANT VISUAL STUDIO 15          "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Environment.CurrentDirectory.Split(new string[] { "JediTournamentConsole" }, StringSplitOptions.None)[0] + "Database\\JediTournament.mdf;Integrated Security=True;Connect Timeout=30";//"Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\alnoel4\\Source\\Repos\\webService\\Database\\JediTournament.mdf;Integrated Security=True;Connect Timeout=30";

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
        public int updateJedis(List<Jedi> l)
        {
            return bdd.updateJedis(l);
        }
        public int updateStades(List<Stade> l)
        {
            return bdd.updateStades(l);
        }
        public int updateMatches(List<Match> l)
        {
            return bdd.updateMatches(l);
        }
        public int updateCaracteristiques(List<Caracteristique> l)
        {
            return updateCaracteristiques(l);
        }

        public Utilisateur GetUtilisateurByLogin(string login)
        {
            return bdd.getUtilisateurByLogin(login);
        }
    }
}
