using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectPharmacy{
    public partial class loginForm : Form{
        public loginForm(){
            InitializeComponent();
        }

        // When the exit button is clicked exit the application.
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // When the login button is clicked check the username and password are valid.
        private void loginButton_Click(object sender, EventArgs e){
            // This is where we go to the server and check whether this loginUsername.Text is in the database and then that loginPassword.Text match.
            // This should be done as a seperate function. 'if(validateUser(loginUsername.Text,loginPassword.Text)'
            if (loginUsername.Text == "Corey" && loginPassword.Text == "Passw0rd"){
                MessageBox.Show("Welcome " + loginUsername.Text);
                // We would then move onto the next screen for the user.
            }
            else if (loginUsername.Text != "" && loginPassword.Text != ""){
                MessageBox.Show("Invalid name or password");
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginUsername.Select();
            }
            else if (loginUsername.Text == ""){
                MessageBox.Show("You must enter a username.");
                loginUsername.Select();
            }
            else{
                MessageBox.Show("You must enter a password.");
                loginPassword.Select();
            }
        }
    }
}
