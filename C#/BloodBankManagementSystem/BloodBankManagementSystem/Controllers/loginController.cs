using BloodBankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.Controllers
{
    class loginController
    {
        //Create a Static String to Connect Database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(loginModel l)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {

                //Write Sql query to get data
                string sql = "SELECT * FROM tbl_users WHERE username=@username AND password=@password";

                //Create sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);

                //Create sql DataAdapter to hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Create a DataTable to Hold the Data from Database
                DataTable dt = new DataTable();

                //Transfer data from sql DataAdapter to DataTable
                adapter.Fill(dt);

                //Open Database connection
                conn.Open();

                //Check whether user exist or not
                if (dt.Rows.Count > 0)
                {
                    //User login successful
                    isSuccess = true;
                }
                else
                {
                    //Failed to login
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display error message if there is any error
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return isSuccess;
        }

    }
}

        
