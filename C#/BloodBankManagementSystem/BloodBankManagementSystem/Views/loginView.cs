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
    public partial class loginView : Form
    {
        public loginView()
        {
            InitializeComponent();
        }

        //Create object of LoginModel and LoginController
        loginModel l = new loginModel();
        loginController c = new loginController();

        //Create a static string method to sve the username
        public static string loggedInUser;

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //For login into Application
            //Step1:Get the UserName and Password from Views
            l.username = txtUserName.Text;
            l.password = txtPassword.Text;

            //Step2:Create a Boolean variable to check the login credentials
            bool success = c.loginCheck(l);

            //Step3:Check Whether the login is successful or not
            if (success == true)
            {
                //User Login Successful
                MessageBox.Show("User Login Successful.");

                //Display Home Form
                homeView home = new homeView();
                home.Show();

                //Save the UserName in static Method
                loggedInUser = l.username;

                //Close current form
                this.Hide();
            }
            else
            {
                //Failed to Login 
                MessageBox.Show("Login Failed.Try Again");
            }
        }
    }
}
