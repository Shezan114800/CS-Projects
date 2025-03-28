using BloodBankManagementSystem.Controllers;
using BloodBankManagementSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
    public partial class homeView : Form
    {
        public homeView()
        {
            InitializeComponent();
        }

        //Create the object of DonorController
        donorController c = new donorController();


        private void lblOpositiveCount_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {

        }

        private void menuStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userView users = new userView();
            users.Show();
        }

        private void donorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            donorView donors = new donorView();
            donors.Show();
        }

        private void homeView_Load(object sender, EventArgs e)
        {
            //Load all the Blood Donors Count When Form is loaded
            allDonorCount();

            //Display all the donors
            DataTable dt = c.Select();
            dgvDonors.DataSource = dt;

            //Display the name of Logged In user
            lblUser.Text = loginView.loggedInUser;

        }

        public void allDonorCount()
        {
            //Get the Donor Count from Database 
            lblOpositiveCount.Text = c.countDonors("O+");
            lblOnegativeCount.Text = c.countDonors("O-");
            lblApositiveCount.Text = c.countDonors("A+");
            lblAnegativeCount.Text = c.countDonors("A-");
            lblBpositiveCount.Text = c.countDonors("B+");
            lblBnegativeCount.Text = c.countDonors("B-");
            lblABpositiveCount.Text = c.countDonors("AB+");
            lblABnegativeCount.Text = c.countDonors("AB-");
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
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


