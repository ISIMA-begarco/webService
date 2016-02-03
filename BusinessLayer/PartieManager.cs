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

        public static void startNewGame()
        {
            game = new EntitiesLayer.Partie();
        }

        public static void setCurrentGameMode(EntitiesLayer.Mode m)
        {
            game.Mode = m;
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
