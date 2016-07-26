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
        public static Object GetObjectWord(int id)
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
                    int objectid = (int)myReader["ID"];
                    string objectdescription = myReader["Description"].ToString();

                    objectword.Oid = objectid;
                    objectword.Description = objectdescription;
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

        public static Activity GetActivityWord(int id)
        {
            string word = "";

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand("select description from activity WHERE ID=" + id, myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    word = myReader["description"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return word;
        }
        #endregion

        //private static string CombinedWords(Object o, Activity a)
        //{
            //string wordObject = GetObjectWord(RandomUtils.ReturnValue(0, 8));
            //string wordActivity = GetActivityWord(RandomUtils.ReturnValue(0, 8));

            //string charadeWord = wordObject + " " + wordActivity;

            //return charadeWord;

        }
    }
}

