using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class MSSQLSFile : IBridge
    {
        private String connectionString;

        public MSSQLSFile(String pConnectionString)
        {
            connectionString = pConnectionString;
        }
        public List<Caracteristique> getCaracteristiques()
        {
            List<Caracteristique> carac = new List<Caracteristique>();

            using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
            {
                String request2 = "SELECT C.id, C.nom, C.def, C.type, C.valeur FROM caracteristiques C;";
                SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                sqlConnection2.Open();

                SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                while (sqlDataReader2.Read())
                {
                    carac.Add(new Caracteristique(convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                    sqlDataReader2.GetString((int)CaracField.NOM),
                                                    convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                    sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                    );
                }
                sqlConnection2.Close();
            }

            return carac;
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
        public enum StadeField
        {
            ID = 0,
            NOM = 1,
            NBPLACES = 2,
            IMAGE = 3
        }

        public List<Jedi> getJedis()
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

        private EPhaseTournoi convertPhase(int n)
        {
            EPhaseTournoi retour;
            if(n < 8)
            {
                retour = EPhaseTournoi.HuitiemeFinale;
            }
            else if (n < 12)
            {
                retour = EPhaseTournoi.QuartFinale;
            }
            else if (n < 14)
            {
                retour = EPhaseTournoi.DemiFinale;
            }
            else
            {
                retour = EPhaseTournoi.Finale;
            }
            return retour;
        }

        public enum MatchField
        {
            ID = 0,
            JEDI1 = 1,
            JEDI2,
            STADE,
            WINNER,
            PHASE
        }

        public List<Match> getMatches()
        {
            List<Match> allMatches = new List<Match>();
            List<Stade> allStade = this.getStades();
            List<Jedi> allJedis = this.getJedis();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT M.id, J1.nom, J2.nom, S.nom, V.nom, M.phase FROM matches M, jedis J1, jedis J2, stades S, jedis V WHERE M.jedi1=J1.id AND M.jedi2=J2.id AND M.stade=S.id AND M.vainqueur=V.id;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristique> carac = new List<Caracteristique>();

                    allMatches.Add(new Match(allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.JEDI1))).First(),
                                                allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.JEDI2))).First(),
                                                convertPhase(sqlDataReader.GetInt32((int)MatchField.PHASE)),
                                                allStade.Where(s => s.Planete.Equals(sqlDataReader.GetString((int)MatchField.STADE))).First(),
                                                allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.WINNER))).First()));
                }
                sqlConnection.Close();
            }
            return allMatches;
        }

        public List<Stade> getStades()
        {
            List<Stade> allStades = new List<Stade>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom, nbplaces, image FROM stades;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristique> carac = new List<Caracteristique>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        String id = sqlDataReader.GetInt32((int)JediField.ID).ToString();
                        String request2 = "SELECT C.id, C.nom, C.def, C.type, C.valeur FROM stades s, caracteristiques C, StadeCarac SC WHERE S.id=" + id + " AND S.id=SC.idstade AND S.id=SC.idcarac;";
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            carac.Add(new Caracteristique(convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                            sqlDataReader2.GetString((int)CaracField.NOM),
                                                            convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                            sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                            );
                        }
                        sqlConnection2.Close();
                    }

                    allStades.Add(new Stade(sqlDataReader.GetInt32((int)StadeField.NBPLACES),
                                                sqlDataReader.GetString((int)StadeField.NOM),
                                                carac,
                                                sqlDataReader.GetString((int)StadeField.IMAGE)));
                }
                sqlConnection.Close();
            }
            return allStades;
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
