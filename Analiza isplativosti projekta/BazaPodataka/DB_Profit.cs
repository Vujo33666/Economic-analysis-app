using Analiza_isplativosti_projekta.Klase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analiza_isplativosti_projekta.BazaPodataka
{
    class DB_Profit
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        #region Insert data into DB from user module
        public bool Insert(classProfit p)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            if (p.name != "" && p.year != 0)
            {
                try
                {
                    //Create a string var to store the insert query
                    String sql = "INSERT INTO tblProfit(name,year,ukupni_prihodi,ukupni_troskovi,profit) VALUES (@name,@year,@ukupni_prihodi,@ukupni_troskovi,@profit)";

                    //Create an SQL command to pass the value in our query
                    SqlCommand cmd = new SqlCommand(sql, conn);


                    //Create the paramater to get value from UI and pass it to SQL query above
                    cmd.Parameters.AddWithValue("@name", p.name);
                    cmd.Parameters.AddWithValue("@year", p.year);
                   // cmd.Parameters.AddWithValue("@years_in_progress", p.years_in_progress);
                    cmd.Parameters.AddWithValue("@ukupni_prihodi", p.ukupni_prihodi);
                    cmd.Parameters.AddWithValue("@ukupni_troskovi", p.ukupni_troskovi);
                    cmd.Parameters.AddWithValue("@profit", p.profit);
                    //Open DB connection
                    conn.Open();

                    //INT value to hold the value after query is executed
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        //Query executed successfully
                        isSuccess = true;
                    }
                    else
                    {
                        //Failed to execute query
                        isSuccess = false;
                    }

                }
                catch (Exception ex)
                {
                    //Display error mssg if there is any exceptional errors
                    MessageBox.Show(ex.Message + " BPgreska");
                }
                finally
                {
                    //Close DB connection
                    conn.Close();
                }
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Niste unijeli neko obavezno polje", "Upozorenje!");
                return false;
            }
        }
        #endregion

       #region UPDATE data in DB(User module)
        public bool Update(classProfit p)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblProfit SET  ukupni_prihodi=@ukupni_prihodi,ukupni_troskovi=@ukupni_troskovi,profit=@profit  WHERE name=@name AND year=@year";

                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@year", p.year);
                // cmd.Parameters.AddWithValue("@years_in_progress", p.years_in_progress);
                cmd.Parameters.AddWithValue("@ukupni_prihodi", p.ukupni_prihodi);
                cmd.Parameters.AddWithValue("@ukupni_troskovi", p.ukupni_troskovi);
                cmd.Parameters.AddWithValue("@profit", p.profit);
                //Open DB connection
                conn.Open();

                //INT value to hold the value after query is executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion */

        #region UPDATE data in DB(User module)
        public bool UpdateNew(classProfit p)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblProfit SET  year=@year,ukupni_prihodi=@ukupni_prihodi,ukupni_troskovi=@ukupni_troskovi,profit=@profit  WHERE name=@name";

                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@year", p.year);
                // cmd.Parameters.AddWithValue("@years_in_progress", p.years_in_progress);
                cmd.Parameters.AddWithValue("@ukupni_prihodi", p.ukupni_prihodi);
                cmd.Parameters.AddWithValue("@ukupni_troskovi", p.ukupni_troskovi);
                cmd.Parameters.AddWithValue("@profit", p.profit);
                //Open DB connection
                conn.Open();

                //INT value to hold the value after query is executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion */

        #region Delete data from DB(User module)
        public bool Delete(classProfit p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tblProfit WHERE name=@name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", p.name);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion
    }
}
