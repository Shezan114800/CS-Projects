using BloodBankManagementSystem.Controllers;
using BloodBankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.Views
{
    public partial class userView : Form
    {
        public userView()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userView_Load(object sender, EventArgs e)
        {
            //Display the Users in Data GridView when the form is loaded
            DataTable dt = c.Select();
            dgvUsers.DataSource = dt;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Write the code to get Users based on Search keywords
            string keywords = txtSearch.Text;

            //check Whether the textbox is empty or not
            if(keywords!=null)
            {
                DataTable dt = c.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                DataTable dt = c.Select();
                dgvUsers.DataSource = dt;
            }
        }
        //Create object of userModel and UserController
        userModel u = new userModel();
        userController c = new userController();

        string imageName = "no-image.jpg";

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //functionality to close form
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;

            //Step2:Adding Values from Views to Database
            //Create a Boolean variable to check whether the data is inserted or not

            bool success = c.Insert(u);

            //Step3:Check Whether the data is inserted successfully or not
            if(success==true)
            {
                //Data or User added Successfully
                MessageBox.Show("New User Added Successfully.");

                //For Displaying the User in Data GridView
                DataTable dt = c.Select();
                dgvUsers.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Add New User.");
            }
        }

        //To Clear text boxes
        public void Clear()
        {
            txtUserID.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtPassword.Text ="";
            txtContact.Text = "";
            txtAddress.Text = "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Find the row index of users Data Grid View
            int RowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[RowIndex].Cells[0].Value.ToString();
            txtUserName.Text= dgvUsers.Rows[RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[RowIndex].Cells[3].Value.ToString();
            txtFullName.Text = dgvUsers.Rows[RowIndex].Cells[4].Value.ToString();
            txtContact.Text = dgvUsers.Rows[RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[RowIndex].Cells[6].Value.ToString();
            u.image_name = dgvUsers.Rows[RowIndex].Cells[7].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            u.user_id = int.Parse(txtUserID.Text);
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;

            //Step2:Create a Boolean variable to check whether the data is inserted or not
            bool success = c.Update(u);

            //Step3:Check Whether the data is Updated successfully or not
            if (success == true)
            {
                //Data or User Updated Successfully
                MessageBox.Show("New User Updated Successfully.");

                //For Displaying the User in Data GridView
                DataTable dt = c.Select();
                dgvUsers.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Update User
                MessageBox.Show("Failed to Update User.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            u.user_id = int.Parse(txtUserID.Text);

            //Step2:Create a Boolean variable to check whether the data is inserted or not
            bool success = c.Delete(u);

            //Step3:Check Whether the data is Delete successfully or not
            if (success == true)
            {
                //Data or User Deleted Successfully
                MessageBox.Show("User Deleted Successfully.");

                //For Displaying the User in Data GridView
                DataTable dt = c.Select();
                dgvUsers.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Delete User.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear textboxes
            Clear();
        }
    }
}
