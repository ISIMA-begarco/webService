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
                Console.WriteLine("4 : Afficher les caractéristiques");
                Console.WriteLine("5 : Afficher les jedis");
                Console.WriteLine("6 : Tester la base");
                Console.WriteLine("0 : Quitter");
                string answer = Console.ReadLine();
                option = answer.Length > 0 ? int.Parse(answer) : 999;

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
                else if (option == 4)
                {
                    List<Caracteristique> l = tournoi.getCaracteristiques();
                    foreach (Caracteristique c in l)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", c.Id, c.Nom, c.Type, c.Definition, c.Valeur);
                    }
                }
                else if (option == 5)
                {
                    List<Jedi> l = tournoi.getJedis();
                    foreach (Jedi c in l)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.Id, c.Nom, c.IsSith, c.Image);
                    }
                }
                else if (option == 6)
                {
                    List<Stade> l = tournoi.getStades();
                    foreach (Stade c in l)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.Id, c.Planete, c.NbPlaces, c.Image);
                    }
                    Console.WriteLine("------------------------------------------------");
                    //l.Add(new Stade(0, 111, "Noob Planet", null));
                    foreach (Stade c in l)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.Id, c.Planete, c.NbPlaces, c.Image);
                    }
                    Console.WriteLine("------------------------------------------------");
                    tournoi.updateStades(l);
                    l.Remove(l.Last());
                    tournoi.updateStades(l);
                    foreach (Stade c in tournoi.getStades())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.Id, c.Planete, c.NbPlaces, c.Image);
                    }
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine();
            }
            

        }
    }
}
