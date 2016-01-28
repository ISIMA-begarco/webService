using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class MSSQLSFile : IBridge
    {
        String connectionString;

        public MSSQLSFile(String pConnectionString)
        {
            connectionString = pConnectionString;
        }
        List<Caracteristique> IBridge.getCaracteristiques()
        {
            throw new NotImplementedException();
        }

        List<Jedi> IBridge.getJedis()
        {
            List<Jedi> allJedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom, isSith FROM jedis;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
            }
            return allJedis;
        }

        List<Match> IBridge.getMatches()
        {
            throw new NotImplementedException();
        }

        List<Stade> IBridge.getStades()
        {
            throw new NotImplementedException();
        }

        void IBridge.setCaracteristiques()
        {
            throw new NotImplementedException();
        }

        void IBridge.setJedis()
        {
            throw new NotImplementedException();
        }

        void IBridge.setMatches()
        {
            throw new NotImplementedException();
        }

        void IBridge.setStades()
        {
            throw new NotImplementedException();
        }
    }
}
