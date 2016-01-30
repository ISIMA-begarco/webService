using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class MSSQLSFile : IBridge
    {
        private String connectionString;
        private DataTable[] dataTables;

        public MSSQLSFile(String pConnectionString)
        {
            connectionString = pConnectionString;
            dataTables = new DataTable[9];
            for(int i = 0; i<9; i++)
            {
                dataTables[i] = new DataTable();
            }
        }

        private enum DTName
        {
            JEDIS = 0,
            STADES = 1,
            CARAC = 2,
            MATCHES = 3,
            TOURNOIS = 4,
            USERS = 5,
            STADECARAC = 6,
            JEDICARAC = 7,
            MATCHTOURNOI = 8
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
                    carac.Add(new Caracteristique(  sqlDataReader2.GetInt32((int)CaracField.ID),
                                                    convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                    sqlDataReader2.GetString((int)CaracField.NOM),
                                                    convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                    sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                    );
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                sqlDataAdapter.Fill(dataTables[(int)DTName.CARAC]);

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
        public enum UserField
        {
            ID = 0,
            LOGIN = 1,
            PASSWORD = 2
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
                            carac.Add(new Caracteristique(  sqlDataReader2.GetInt32((int)CaracField.ID),
                                                            convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                            sqlDataReader2.GetString((int)CaracField.NOM),
                                                            convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                            sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                            );
                        }
                        sqlConnection2.Close();
                    }

                    allJedis.Add(new Jedi(       sqlDataReader.GetInt32((int)JediField.ID), 
                                                 carac,
                                                 sqlDataReader.GetBoolean((int)JediField.ISSITH),
                                                 sqlDataReader.GetString((int)JediField.NOM),
                                                 sqlDataReader.GetString((int)JediField.IMAGE)));
                }
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTables[(int)DTName.JEDIS]);
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT idjedi, idcarac FROM JediCarac;", sqlConnection));
                sqlDataAdapter.Fill(dataTables[(int)DTName.JEDICARAC]);
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
                    allMatches.Add(new Match(   sqlDataReader.GetInt32((int)MatchField.ID),
                                                allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.JEDI1))).First(),
                                                allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.JEDI2))).First(),
                                                convertPhase(sqlDataReader.GetInt32((int)MatchField.PHASE)),
                                                allStade.Where(s => s.Planete.Equals(sqlDataReader.GetString((int)MatchField.STADE))).First(),
                                                allJedis.Where(j => j.Nom.Equals(sqlDataReader.GetString((int)MatchField.WINNER))).First()));
                }
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTables[(int)DTName.MATCHES]);
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
                            carac.Add(new Caracteristique(  sqlDataReader2.GetInt32((int)CaracField.ID),
                                                            convertDef(sqlDataReader2.GetString((int)CaracField.DEF)),
                                                            sqlDataReader2.GetString((int)CaracField.NOM),
                                                            convertType(sqlDataReader2.GetString((int)CaracField.TYPE)),
                                                            sqlDataReader2.GetInt32((int)CaracField.VALEUR))
                            );
                        }
                        sqlConnection2.Close();
                    }

                    allStades.Add(new Stade(    sqlDataReader.GetInt32((int)StadeField.ID),
                                                sqlDataReader.GetInt32((int)StadeField.NBPLACES),
                                                sqlDataReader.GetString((int)StadeField.NOM),
                                                carac,
                                                sqlDataReader.GetString((int)StadeField.IMAGE)));
                }
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTables[(int)DTName.STADES]);
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT idstade, idcarac FROM StadeCarac;", sqlConnection));
                sqlDataAdapter.Fill(dataTables[(int)DTName.STADECARAC]);
                sqlConnection.Close();
            }
            return allStades;
        }

        private int UpdateByCommandBuilder(string request, DataTable table)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlTransaction myTrans = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection, myTrans);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                SqlCommandBuilder sqlCommandbuild = new SqlCommandBuilder(sqlDataAdapter);

                sqlDataAdapter.UpdateCommand = sqlCommandbuild.GetUpdateCommand();
                sqlDataAdapter.InsertCommand = sqlCommandbuild.GetInsertCommand();
                sqlDataAdapter.DeleteCommand = sqlCommandbuild.GetDeleteCommand();

                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                try
                {
                    result = sqlDataAdapter.Update(table);
                    myTrans.Commit();
                }
                catch (DBConcurrencyException)
                {
                    myTrans.Rollback();
                }
            }
            return result;
        }

        public int updateCaracteristiques(List<Caracteristique> l)
        {
            int result = 0;
            


            return result;
        }

        public int updateJedis(List<Jedi> l)
        {
            throw new NotImplementedException();
        }

        public int updateMatches(List<Match> l)
        {
            throw new NotImplementedException();
        }

        public int updateStades(List<Stade> l)
        {
            throw new NotImplementedException();
        }

        public Utilisateur getUtilisateurByLogin(string login)
        {
            Utilisateur us = null;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, login, password FROM users WHERE login="+login+";";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    us = new Utilisateur(sqlDataReader.GetInt32((int)UserField.ID), sqlDataReader.GetString((int)UserField.LOGIN), sqlDataReader.GetString((int)UserField.PASSWORD));
                }
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTables[(int)DTName.USERS]);
                sqlConnection.Close();
            }
            return us;
        }

        enum TournoiField
        {
            ID = 0,
            NOM = 1
        }

        public List<Tournoi> getTournois()
        {
            List<Tournoi> allTournois = new List<Tournoi>();
            List<Match> allMatches =  this.getMatches();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom FROM Tournois;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Match> matches = new List<Match>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        String id = sqlDataReader.GetInt32((int)TournoiField.ID).ToString();
                        String request2 = "SELECT idMatch FROM MatchTournoi WHERE idMatch=" + id;
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            matches.Add(allMatches.Where(x => x.Id == sqlDataReader2.GetInt32(0)).First());
                        }
                        sqlConnection2.Close();
                    }

                    allTournois.Add(new Tournoi(sqlDataReader.GetInt32((int)TournoiField.ID),
                                                sqlDataReader.GetString((int)TournoiField.NOM),
                                                matches));
                }
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTables[(int)DTName.MATCHES]);
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT idtournoi, idmatch FROM MatchTournoi;", sqlConnection));
                sqlDataAdapter.Fill(dataTables[(int)DTName.MATCHTOURNOI]);
                sqlConnection.Close();
            }
            return allTournois;
        }

        public int updateTournois(List<Tournoi> l)
        {
            throw new NotImplementedException();
        }
    }
}
