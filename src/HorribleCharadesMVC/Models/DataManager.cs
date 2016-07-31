﻿using HorribleCharadesMVC.Viewmodels;
using System;
using System.Collections.Generic;
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

            SqlCommand myCommand = new SqlCommand("select * from Entities WHERE ID=" + id, myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int objectId = (int)myReader["ID"];
                    string objectDescription = myReader["Description"].ToString();

                    objectword.Oid = objectId;
                    objectword.Description = objectDescription;
                }
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
        SqlCommand myCommand = new SqlCommand("select * from activities WHERE ID=" + id, myConnection);

        try
        {
            myConnection.Open();

            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                int activityId = (int)myReader["ID"];
                string activityDescription = myReader["Description"].ToString();

                activityWord.Aid = activityId;
                activityWord.Description = activityDescription;
            }
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

        SqlCommand myCommand = new SqlCommand($"insert into Teams VALUES ('{gameCode}','{name}' )", myConnection);

        try
        {
            myConnection.Open();

            int result = myCommand.ExecuteNonQuery();

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


