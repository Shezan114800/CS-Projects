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
    class donorController
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
                string sql = "SELECT * FROM tbl_donors";

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

        #region Insert Data into Database for Donor 
        public bool Insert(donorModel d)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string variable to store the INSERT query
                string sql = "INSERT INTO tbl_donors(first_name,last_name,email,contact,gender,address,blood_group,added_date,image_name,added_by) VALUES(@first_name,@last_name,@email,@contact,@gender,@address,@blood_group,@added_date,@image_name,@added_by)";
                
                //Create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@first_name", d.first_name);
                cmd.Parameters.AddWithValue("@last_name", d.last_name);
                cmd.Parameters.AddWithValue("@email", d.email);
                cmd.Parameters.AddWithValue("@contact", d.contact);
                cmd.Parameters.AddWithValue("@gender", d.gender);
                cmd.Parameters.AddWithValue("@address", d.address);
                cmd.Parameters.AddWithValue("@blood_group", d.blood_group);
                cmd.Parameters.AddWithValue("@added_date", d.added_date);
                cmd.Parameters.AddWithValue("@image_name", d.image_name);
                cmd.Parameters.AddWithValue("@added_by", d.added_by);

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

        #region Update Data into Database for Donor 
        public bool Update(donorModel d)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string variable to store the UPDATE query
                string sql = "UPDATE  tbl_donors SET first_name=@first_name,last_name=@last_name,email=email,contact=@contact,gender=@gender,address=@address,blood_group=@blood_group,image_name=@image_name,added_by=@added_by WHERE donor_id =@donor_id";

                //Create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@first_name", d.first_name);
                cmd.Parameters.AddWithValue("@last_name", d.last_name);
                cmd.Parameters.AddWithValue("@email", d.email);
                cmd.Parameters.AddWithValue("@contact", d.contact);
                cmd.Parameters.AddWithValue("@gender", d.gender);
                cmd.Parameters.AddWithValue("@address", d.address);
                cmd.Parameters.AddWithValue("@blood_group", d.blood_group);
                cmd.Parameters.AddWithValue("@image_name", d.image_name);
                cmd.Parameters.AddWithValue("@added_by", d.added_by);
                cmd.Parameters.AddWithValue("@donor_id", d.donor_id);


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

        #region Delete Data from Database for Donor 
        public bool Delete(donorModel d)
        {
            //Create a boolean variable
            bool isSuccess = false;

            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string variable to store the DELETE query
                string sql = "DELETE FROM tbl_donors WHERE donor_id=@donor_id";

                //Create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to get value from Views and pass it on sql query
                cmd.Parameters.AddWithValue("@donor_id", d.donor_id);

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

        #region Counting Donors For Specific Blood Group
        public string countDonors(string blood_group)
        {
            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create String variable for donor count and set its default value to 0
            string donors = "0";

            try
            {
                //Sql query to count donors for specific blood group
                string sql = "SELECT * FROM tbl_donors WHERE blood_group='"+blood_group+"'";

                //Create sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create sql DataAdapter to hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Create a DataTable to Hold the Data from Database
                DataTable dt = new DataTable();

                //Open Database connection
                conn.Open();

                //Transfer data from sql DataAdapter to DataTable
                adapter.Fill(dt);

                //Get the total number of Donors Based on Blood Group
                donors = dt.Rows.Count.ToString();
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
            return donors;
        }
        #endregion

        #region Search From Donor
        public DataTable Search(string keywords)
        {
            //Create an object to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DataTable to Hold the Data from Database
            DataTable dt = new DataTable();

            try
            {
                //Sql query to search the donorname
                string sql = "SELECT * FROM tbl_donors WHERE donor_id LIKE '%" + keywords + "%' OR first_name LIKE '%" + keywords + "%' OR blood_group LIKE '%" + keywords + "%' OR gender LIKE '%" + keywords + "%' ";

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
