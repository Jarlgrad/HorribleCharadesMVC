using HorribleCharadesMVC.Viewmodels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Models
{
    public static class DataManager
    {
        const string conStr = "Data Source=horriblecharades.database.windows.net;Initial Catalog = HorribleCharades; Persist Security Info=True;User ID = DBAdmin; Password=this!s4password";

        #region GetWordsFromDB

       
        public static Entity GetEntity(int id)
        {
            Entity objectword = new Entity();

            SqlConnection myConnection = new SqlConnection(conStr);

            SqlDataReader rdr = null;

            SqlCommand myCommand = new SqlCommand("sp_GetEntity", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ID", id);
            myCommand.Parameters.Add("@Description", SqlDbType.VarChar, 250);
            myCommand.Parameters["@Description"].Direction = ParameterDirection.Output;

            try
            {
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                objectword.Description = myCommand.Parameters["@Description"].Value.ToString();
                      }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return objectword;
        }

        public static List<Team> GetTeams(string gameCode)
        {
            List<Team> tmpList = new List<Team>();

            Team tmpTeam = new Team();

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand($"select * from Teams WHERE GameCode = '{gameCode}'", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tmpTeam.TeamId = (int)myReader["TeamID"];
                    tmpTeam.TeamName = myReader["Name"].ToString();
                    tmpList.Add(tmpTeam);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return tmpList;
        }

    public static Activity GetActivity(int id)
    {
        Activity activityWord = new Activity();


            SqlConnection myConnection = new SqlConnection(conStr);

            SqlDataReader rdr = null;

            SqlCommand myCommand = new SqlCommand("sp_GetActivity", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ID", id);
            myCommand.Parameters.Add("@Description", SqlDbType.VarChar, 250);
            myCommand.Parameters["@Description"].Direction = ParameterDirection.Output;

            try
        {
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                activityWord.Description = myCommand.Parameters["@Description"].Value.ToString();
            }
        catch (Exception ex)
        {

        }
        finally
        {
            myConnection.Close();
        }
        return activityWord;
    }
    #endregion

    public static string CombinedWords()
    {
        Entity wordEntity = DataManager.GetEntity(RandomUtils.ReturnValue(1, 19));
        Activity wordActivity = DataManager.GetActivity(RandomUtils.ReturnValue(1, 19));

        string charade = $"{wordEntity.Description} {wordActivity.Description}";

        return charade;

    }

        public static void AddTeam(string gameCode, string name)
        {
            Team team = new Team();

            SqlConnection myConnection = new SqlConnection(conStr);

            SqlCommand myCommand = new SqlCommand("sp_AddTeam", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGameCode = new SqlParameter("@GameCode", SqlDbType.VarChar);
            myCommand.Parameters.Add("@GameCode", SqlDbType.VarChar).Value = gameCode;

            SqlParameter paramName = new SqlParameter("@Name", SqlDbType.VarChar);
            myCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}


