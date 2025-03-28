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
    class userController
    {
        //Create a Static String to Connect Database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select data from database
        public DataTable Select()
        {
            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DataTable to Hold the Data from Database
            DataTable dt = new DataTable();

           try
           {
                //Write Sql query to get data
                string sql = "SELECT * FROM tbl_users";

                //Create sql command to execute query
                SqlCommand cmd = new SqlCommand(sql,conn);

                //Create sql DataAdapter to hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database connection
                conn.Open();

                //Transfer data from sql DataAdapter to DataTable
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                //Display error message if there is any error
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert Data into Database for User 
        public bool Insert (userModel u)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string variable to store the INSERT query
                string sql = "INSERT INTO tbl_users(username,email,password,full_name,contact,address,added_date,image_name) VALUES(@username,@email,@password,@full_name,@contact,@address,@added_date,@image_name)";

                //Create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@username",u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@full_name", u.full_name);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);

                //Open Database connection
                conn.Open();

                //Create an int variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be greater than 0 if query executed successfully
                //Else it'll be zero

                if(rows>0)
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
        #endregion

        #region Update Data into Database for User 
        public bool Update(userModel u)
       {
        //Create a boolean variable
        bool isSuccess = false;

        //Create an object to Connect Database
        SqlConnection conn = new SqlConnection(myconnstrng);

        try
        {
            //Create a string variable to store the UPDATE query
            string sql = "UPDATE  tbl_users SET username=@username,email=@email,password=@password,full_name=@full_name,contact=@contact,address=@address,added_date=@added_date,image_name=@image_name WHERE user_id=@user_id";

            //Create sql command to pass the value
            SqlCommand cmd = new SqlCommand(sql, conn);

            //Create parameter to get value from Views and pass it on sql query
            cmd.Parameters.AddWithValue("@username", u.username);
            cmd.Parameters.AddWithValue("@email", u.email);
            cmd.Parameters.AddWithValue("@password", u.password);
            cmd.Parameters.AddWithValue("@full_name", u.full_name);
            cmd.Parameters.AddWithValue("@contact", u.contact);
            cmd.Parameters.AddWithValue("@address", u.address);
            cmd.Parameters.AddWithValue("@added_date", u.added_date);
            cmd.Parameters.AddWithValue("@image_name", u.image_name);
            cmd.Parameters.AddWithValue("@user_id", u.user_id);

            //Open Database connection
            conn.Open();

            //Create an int variable to hold the value after the query is executed
            int rows = cmd.ExecuteNonQuery();

            //the value of rows will be greater than 0 if query executed successfully
            //Else it'll be zero

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
        #endregion

        #region Delete Data from Database for User 
        public bool Delete(userModel u)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string variable to store the DELETE query
                string sql = "DELETE FROM tbl_users WHERE user_id=@user_id";

                //Create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@user_id", u.user_id);

                //Open Database connection
                conn.Open();

                //Create an int variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be greater than 0 if query executed successfully
                //Else it'll be zero

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
        #endregion

        #region Get ID from User
        public userModel GetIDFromUserName(string username)
        {
            userModel u = new userModel();

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DataTable to Hold the Data from Database
            DataTable dt = new DataTable();

            try
            {
                //Sql query to get ID from username
                string sql = "SELECT user_id FROM tbl_users WHERE username='"+username+"'";

                //Create sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create sql DataAdapter to hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database connection
                conn.Open();

                //Transfer data from sql DataAdapter to DataTable
                adapter.Fill(dt);

                //If there is User Based on username
                if (dt.Rows.Count > 0)
                {
                    u.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
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
            return u;
        }
        #endregion

        #region Search from User
        public DataTable Search(string keywords)
        {
            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DataTable to Hold the Data from Database
            DataTable dt = new DataTable();

            try
            {
                //Sql query to search the username
                string sql = "SELECT * FROM tbl_users WHERE user_id LIKE '%"+keywords+"%' OR full_name LIKE '%"+keywords+"%' ";

                //Create sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create sql DataAdapter to hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database connection
                conn.Open();

                //Transfer data from sql DataAdapter to DataTable
                adapter.Fill(dt);
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
            return dt;
        }
        #endregion
    }
}

