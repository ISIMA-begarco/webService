using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IBridge
    {
        List<Jedi> getJedis();
        List<Stade> getStades();
        List<Match> getMatches();
        List<Caracteristique> getCaracteristiques();
        void setJedis();
        void setStades();
        void setMatches();
        void setCaracteristiques();
    }
}
