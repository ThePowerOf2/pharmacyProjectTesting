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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginPassword_TextChanged(object sender, EventArgs e){}

        private void loginButton_Click(object sender, EventArgs e){
            // this is where we go to the server and check whether this loginUsername.Text is in the database and then that loginPassword.Text match.
            if (loginUsername.Text == "Corey" && loginPassword.Text == "Passw0rd"){
                MessageBox.Show("Welcome " + loginUsername.Text);
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginUsername.Select();
            }
            else{
                MessageBox.Show("Invalid name or password");
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginUsername.Select();
            }
        }
    }
}
