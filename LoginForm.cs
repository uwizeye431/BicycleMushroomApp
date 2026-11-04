using System;
using System.Windows.Forms;

namespace BicycleMushroomApp
{
    public partial class LoginForm : Form
    {
        // Change these two values to set your own username and password
        private const string ValidUsername = "admin";
        private const string ValidPassword = "1234";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(username, ValidUsername, StringComparison.OrdinalIgnoreCase)
                && password == ValidPassword)
            {
                ChooseForm choose = new ChooseForm(this);
                choose.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please try again.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Called by the other forms when the user logs out
        public void ResetForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}