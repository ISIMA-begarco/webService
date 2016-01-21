﻿using System;
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
        public enum Shifumi{ Pierre, Papier, Cizeaux };
        public int playRound(Shifumi choiceA, Shifumi choiceB)
        {
            return (choiceA == choiceB ? 0 :            // si egalite ZERO
                    (choiceA == choiceB+1 ? -1 :        // si A gagne -1
                    (choiceA == Shifumi.Pierre && choiceB == Shifumi.Cizeaux ? -1 : 1)));   // si B gagne 1
        }

        public Jedi simulateMatch(Match m)
        {
            Jedi winner = m.Jedi1;
            Random rd = new Random();
            double balance = .5;
            
            double gain1, gain2, gain3, gain4;
            gain1 = rd.NextDouble();
            gain1 = gain1 <= m.Jedi1.getPerception() / 100 ? 1 + gain1 : 1;
            gain2 = rd.NextDouble();
            gain2 = gain2 <= m.Jedi2.getPerception() / 100 ? 1 + gain2 : 1;
            gain3 = rd.NextDouble();
            gain3 = gain3 <= m.Jedi1.getPerception() / 100 ? 1 + gain3 : 1;
            gain4 = rd.NextDouble();
            gain4 = gain4 <= m.Jedi2.getPerception() / 100 ? 1 + gain4 : 1;

            balance += ((m.Jedi1.getStrength()/100*gain1-m.Jedi2.getDexterity()/100*gain2) + (m.Jedi2.getStrength() / 100 * gain4 - m.Jedi1.getDexterity() / 100 * gain3));
            
            if (rd.NextDouble() > balance)
                winner = m.Jedi2;

            return winner;
        }

        public void simulateTournament(Dictionary<EPhaseTournoi, List<Match>> championshipScheme)
        {
            Queue<Jedi> winners = new Queue<Jedi>();

            foreach (KeyValuePair<EPhaseTournoi, List<Match>> phase in championshipScheme)
            {
                if(winners.Count != 0)
                {
                    foreach (Match m in phase.Value)
                    {
                        m.Jedi1 = winners.Dequeue();
                        m.Jedi2 = winners.Dequeue();
                    }
                }
                Console.Out.WriteLine(phase.Key);
                foreach (Match m in phase.Value)
                {
                    winners.Enqueue(simulateMatch(m));
                }
            }
        }

    }
}
