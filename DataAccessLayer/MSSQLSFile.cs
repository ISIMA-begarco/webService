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
        public enum JediField
        {
            ID = 0,
            NOM = 1,
            ISSITH = 2,
            IMAGE = 3
        }
        public enum CaracField
        {
            ID = 0,
            NOM = 1,
            DEF = 2,
            TYPE = 3,
            VALEUR = 4
        }

        List<Jedi> IBridge.getJedis()
        {
            List<Jedi> allJedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom, isSith, image FROM jedis;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristique> carac = new List<Caracteristique>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        String id = sqlDataReader.GetInt32((int)JediField.ID).ToString();
                        String request2 = "SELECT C.id, C.nom, C.def, C.type, C.valeur FROM jedis J, caracteristiques C, JediCarac JC WHERE J.id=" + id + " AND J.id=JC.idjedi AND C.id=JC.idcarac;";
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            carac.Add(new Caracteristique(  convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                            sqlDataReader2.GetString((int)CaracField.NOM),
                                                            convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                            sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                            );
                        }
                        sqlConnection2.Close();
                    }

                    allJedis.Add(new Jedi(carac, sqlDataReader.GetBoolean((int)JediField.ISSITH),
                                                 sqlDataReader.GetString((int)JediField.NOM),
                                                 sqlDataReader.GetString((int)JediField.IMAGE)));
                }
                sqlConnection.Close();
            }
            return allJedis;
        }

        private EDefCaracteristique convertDef(String s)
        {
            EDefCaracteristique retour;

            if(s.Equals("Strength"))
            {
                retour = EDefCaracteristique.Strength;
            }
            else if(s.Equals("Dexterity"))
            {
                retour = EDefCaracteristique.Dexterity;
            }
            else
            {
                retour = EDefCaracteristique.Perception;
            }

            return retour;
        }

        private ETypeCaracteristique convertType(String s)
        {
            ETypeCaracteristique retour = 0;

            if (s.Equals("Jedi"))
            {
                retour = ETypeCaracteristique.Jedi;
            }
            else if (s.Equals("Stade"))
            {
                retour = ETypeCaracteristique.Stade;
            }

            return retour;
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
