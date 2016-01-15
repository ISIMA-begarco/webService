using System.Collections.Generic;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        public List<Jedi> getJedis()
        {
            List<Jedi> jedis =new List<Jedi>(); 

            jedis.Add(new Jedi(null,5,false,"Revan"));
            jedis.Add(new Jedi(null,5,true,"Jacen Solo"));
            jedis.Add(new Jedi(null,3,false,"Cade Skywalker"));
            jedis.Add(new Jedi(null, 5, true, "Darth Bane"));

            return jedis;
        }

        public List<Match> getMatchs()
        {
            List<Match> matches = new List<Match>();

            matches.Add(new Match(new Jedi(null, 5, false, "Revan"), new Jedi(null, 5, true, "Jacen Solo"),EPhaseTournoi.DemiFinale, new Stade(120,"Tython",null)));
            matches.Add(new Match(new Jedi(null, 3, false, "Cade Skywalker"), new Jedi(null, 5, true, "Darth Bane"),EPhaseTournoi.DemiFinale,new Stade(120,"Nar Shaddaa",null)));
            matches.Add(new Match(new Jedi(null, 5, true, "Jacen Solo"), new Jedi(null, 5, true, "Darth Bane"), EPhaseTournoi.Finale, new Stade(250, "Coruscant", null)));

            return matches;
        }

        public List<Stade> getStade()
        {
            List<Stade> stades = new List<Stade>();

            stades.Add(new Stade(120, "Nar Shaddaa",null));
            stades.Add(new Stade(120, "Tython", null));
            stades.Add(new Stade(250, "Coruscant", null));

            return stades;
        }

        public List<Caracteristique> getCaracteristiques()
        {
            List<Caracteristique> caracteristiques = new List<Caracteristique>();

            caracteristiques.Add(new Caracteristique(EDefCaractéristique.Perception, "Perception",ETypeCaracteristique.Jedi, 2));
            caracteristiques.Add(new Caracteristique(EDefCaractéristique.Dexterity, "Dextérité", ETypeCaracteristique.Jedi, 2));
            caracteristiques.Add(new Caracteristique(EDefCaractéristique.Strengh, "Force", ETypeCaracteristique.Jedi, 2));

            return caracteristiques;
        }

        public List<Utilisateur> GetUtilisateur()
        {
            List<Utilisateur> users = new List<Utilisateur>();

            users.Add(new Utilisateur("Yoda", "Maitre", "YodaDu69", "YoloForce"));
            users.Add(new Utilisateur("Dark", "Vador", "BestForceEver", "IamGod"));
            users.Add(new Utilisateur("Skywalker", "Luck", "Luck", "leia24+"));

            return users;
        }


        public Utilisateur GetUtilisateurByLogin(string login)
        {
            Utilisateur user_found = null;

            foreach (Utilisateur user in GetUtilisateur())
            {
                if (user.Login.Equals(login))
                {
                    user_found = user;
                    break;
                }
            }

            return user_found;
        }
    }
}