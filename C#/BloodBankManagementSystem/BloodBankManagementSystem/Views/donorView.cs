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
    public partial class donorView : Form
    {
        public donorView()
        {
            InitializeComponent();
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        //Create object of DonorModel and DonorController
        donorModel d = new donorModel();
        donorController c = new donorController();
        userController uc = new userController();

        string imageName = "no-image.jpg";

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //functionality to close form
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            d.first_name = txtFirstName.Text;
            d.last_name = txtLastName.Text;
            d.email = txtEmail.Text;
            d.contact = txtContact.Text;
            d.gender = cmbGender.Text;
            d.address = txtAddress.Text;
            d.blood_group = cmbBloodGroup.Text;
            d.added_date = DateTime.Now;
            d.image_name = imageName;

            //Get the ID of LoggedInUser
            string loggedInUser = loginView.loggedInUser;
            userModel user = uc.GetIDFromUserName(loggedInUser);
            //Get the id of Logged in User
            d.added_by = user.user_id; 

            //Step2:Adding Values from Views to Database
            //Create a Boolean variable to check whether the data is inserted or not

            bool success = c.Insert(d);

            //Step3:Check Whether the data is inserted successfully or not
            if (success == true)
            {
                //Data or Donor added Successfully
                MessageBox.Show("New Donor Added Successfully.");

                //For Displaying the Donor in Data GridView
                DataTable dt = c.Select();
                dgvDonors.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Add New Donor.");
            }
        }

        //To Clear text boxes
        public void Clear()
        {
            txtDonorID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            cmbGender.Text = "";
            cmbBloodGroup.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
        }

        private void donorView_Load(object sender, EventArgs e)
        {
            //Display the Donors in Data GridView when the form is loaded
            DataTable dt = c.Select();
            dgvDonors.DataSource = dt;
        }

        private void dgvDonors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Find the row index of users Data Grid View
            int RowIndex = e.RowIndex;
            txtDonorID.Text = dgvDonors.Rows[RowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvDonors.Rows[RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvDonors.Rows[RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDonors.Rows[RowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDonors.Rows[RowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvDonors.Rows[RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvDonors.Rows[RowIndex].Cells[6].Value.ToString();
            cmbBloodGroup.Text = dgvDonors.Rows[RowIndex].Cells[7].Value.ToString();
            d.image_name = dgvDonors.Rows[RowIndex].Cells[9].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            d.donor_id = int.Parse(txtDonorID.Text);
            d.first_name = txtFirstName.Text;
            d.last_name = txtLastName.Text;
            d.email = txtEmail.Text;
            d.contact = txtContact.Text;
            d.gender = cmbGender.Text;
            d.address = txtAddress.Text;
            d.blood_group = cmbBloodGroup.Text;
            d.image_name = imageName;

            //Get the ID of LoggedInUser
            string loggedInUser = loginView.loggedInUser;
            userModel user = uc.GetIDFromUserName(loggedInUser);
            //Get the id of Logged in User
            d.added_by = user.user_id;

            //Step2:Create a Boolean variable to check whether the data is inserted or not
            bool success = c.Update(d);

            //Step3:Check Whether the data is Updated successfully or not
            if (success == true)
            {
                //Data or Donor Updated Successfully
                MessageBox.Show("New Donor Updated Successfully.");

                //For Displaying the Donor in Data GridView
                DataTable dt = c.Select();
                dgvDonors.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Update Donor
                MessageBox.Show("Failed to Update Donor.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Step1:Get the Values from Views
            d.donor_id = int.Parse(txtDonorID.Text);

            //Step2:Create a Boolean variable to check whether the data is inserted or not
            bool success = c.Delete(d);

            //Step3:Check Whether the data is Deleted successfully or not
            if (success == true)
            {
                //Data or Donor Deleted Successfully
                MessageBox.Show("Donor Deleted Successfully.");

                //For Displaying the User in Data GridView
                DataTable dt = c.Select();
                dgvDonors.DataSource = dt;

                //Clear textboxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Delete Donor.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear textboxes
            Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Write the code to get Donors based on Search keywords
            string keywords = txtSearch.Text;

            //check Whether the textbox is empty or not
            if (keywords != null)
            {
                DataTable dt = c.Search(keywords);
                dgvDonors.DataSource = dt;
            }
            else
            {
                DataTable dt = c.Select();
                dgvDonors.DataSource = dt;
            }
        }
    }
}
