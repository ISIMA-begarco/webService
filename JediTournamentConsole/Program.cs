using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using EntitiesLayer;

namespace JediTournamentConsole
{
    class Program
    {
        /*static void Main(string[] args)
        {
            JediTournamentManager tournoi = new JediTournamentManager();
            Dictionary<EPhaseTournoi, List<Match>> championshipScheme = new Dictionary<EPhaseTournoi, List<Match>>();
            championshipScheme.Add(EPhaseTournoi.HuitiemeFinale, new List<Match>());
            championshipScheme.Add(EPhaseTournoi.QuartFinale, new List<Match>());
            championshipScheme.Add(EPhaseTournoi.DemiFinale, new List<Match>());
            championshipScheme.Add(EPhaseTournoi.Finale, new List<Match>());
            tournoi.simulateTournament(championshipScheme);
        }*/
        static void Main(string[] args)
        {
            JediTournamentManager tournoi = new JediTournamentManager();
            int option = 999;

            while (option != 0)
            {
                Console.WriteLine("Menu du progamme");
                Console.WriteLine("1 : Afficher les stades");
                Console.WriteLine("2 : Afficher les concurents Siths");
                Console.WriteLine("3 : Afficher les stades de plus de 200 personnes où se déroule un combat entre Siths");
                Console.WriteLine("4 : Tester la base");
                Console.WriteLine("0 : Pour sortir");

                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    foreach (Stade s in tournoi.getStades())
                    {
                        Console.WriteLine("Le stade de {0} dispose de {1} places.", s.Planete, s.NbPlaces);
                    }
                }
                else if (option == 2)
                {
                    foreach (String s in tournoi.getDarkSideJedisNames())
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (option == 3)
                {
                    foreach (Match m in tournoi.getMatches200Sith())
                    {
                        Console.WriteLine("Le duel entre {0} et {1} se déroulera dans le stade de {2}.", m.Jedi1.Nom, m.Jedi2.Nom, m.Stade.Planete);
                    }
                }
                Console.WriteLine();
            }
            

        }
    }
}
