using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PartieManager
    {
        private static EntitiesLayer.Partie game;
        private static BusinessLayer.JediTournamentManager jtm;

        public static void startNewGame()
        {
            jtm = new BusinessLayer.JediTournamentManager();
            game = new EntitiesLayer.Partie();
        }

        public static void nextMatch()
        {

            List<EntitiesLayer.Match> matchRestant = game.Tournament.Matchs.Where(m => m.JediVainqueur == null).ToList();
            if(matchRestant.Count > 0)
            {
                game.Current_match = matchRestant.First();
            }
            else
            {
                for(int i = 0; i < game.Tournament.Matchs.Count; i+=2){
                    //EntitiesLayer.Match new_match = new EntitiesLayer.Match(0,game.Tournament.Matchs.ElementAt(i).JediVainqueur, game.Tournament.Matchs.ElementAt(i).JediVainqueur);

                }
            }

            
        }

        public static void resolve()
        {
            if(game.Choice_j1 != EntitiesLayer.EShifumi.Aucun && game.Choice_j2 != EntitiesLayer.EShifumi.Aucun)
            {
                int res = jtm.playRound(game.Choice_j1, game.Choice_j2);
                if(res == 0)
                {
                    Random rd = new Random();
                    if(rd.NextDouble()%2 == 1)
                    {
                        game.Current_match.JediVainqueur = game.Current_match.Jedi1;
                    }
                    else
                    {
                        game.Current_match.JediVainqueur = game.Current_match.Jedi2;
                    }
                }
                if(res == -1)
                {
                    game.Current_match.JediVainqueur = game.Current_match.Jedi1;
                }
                if(res == 1)
                {
                    game.Current_match.JediVainqueur = game.Current_match.Jedi2;
                }
            }
        }

        public static void setCurrentPlayer(EntitiesLayer.Joueur j,int num_j)
        {
            if(num_j == 1)
                game.J1 = j;
            if(num_j == 2)
                game.J2 = j;
        }
        
        public static void setCurrentGameMode(EntitiesLayer.Mode m)
        {
            game.Mode = m;
        }

        public static void setCurrentGameTournament(EntitiesLayer.Tournoi t)
        {
            game.Tournament = t;
            game.Current_match = t.Matchs.First();
        }

        public static void setCurrentGameOptions()
        {

        }

        public static EntitiesLayer.Partie getCurrentGame()
        {
            return game;
        }
    }
}
