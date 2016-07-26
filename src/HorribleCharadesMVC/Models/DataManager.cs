using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Models
{
    public class DataManager
    {
        const string conStr = "Data Source=horriblecharades.database.windows.net;Initial Catalog = HorribleCharades; Persist Security Info=True;User ID = DBAdmin; Password=this!s4password";

        #region GetWordsFromDB
        public static Object GetObject(int id)
        {
            Object objectword = new Object();

            SqlConnection myConnection = new SqlConnection(conStr);

            SqlCommand myCommand = new SqlCommand("select * from Object WHERE ID=" + id, myConnection);

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

        public static Activity GetActivity(int id)
        {
            Activity activityWord = new Activity();

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand("select * from activity WHERE ID=" + id, myConnection);

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

        public static Charade CombinedWords()
        {
            Charade charade = new Charade();
            Object wordObject = DataManager.GetObject(RandomUtils.ReturnValue(1, 8));
            Activity wordActivity = DataManager.GetActivity(RandomUtils.ReturnValue(1, 8));

            charade.charadeWord = $"{wordObject.Description} {wordActivity.Description}";

            return charade;

        }
    }
}


