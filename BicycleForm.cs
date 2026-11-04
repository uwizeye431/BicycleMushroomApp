using System;
using System.Windows.Forms;

namespace BicycleMushroomApp
{
    public partial class BicycleForm : Form
    {
        private LoginForm loginForm;
        private bool navigating = false;

        public BicycleForm(LoginForm login)
        {
            InitializeComponent();
            loginForm = login;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int start;
            int end;

            if (!TryReadHour(txtStart.Text, "Starting hour", 0, 23, out start))
            {
                txtStart.Focus();
                return;
            }

            if (!TryReadHour(txtEnd.Text, "Ending hour", 1, 24, out end))
            {
                txtEnd.Focus();
                return;
            }

            if (start >= end)
            {
                MessageBox.Show("The starting hour must be less than the ending hour.", "Bicycle Rental",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnd.Focus();
                return;
            }

            int totalCost = 0;

            for (int hour = start; hour < end; hour++)
            {
                totalCost += GetRate(hour);
            }

            txtTotal.Text = totalCost + " RWF";
        }

        private int GetRate(int hour)
        {
            if ((hour >= 0 && hour < 7) || (hour >= 21 && hour < 24))
            {
                return 500;
            }
            else if ((hour >= 7 && hour < 14) || (hour >= 19 && hour < 21))
            {
                return 1000;
            }
            else
            {
                return 1500;
            }
        }

        private bool TryReadHour(string text, string fieldName, int min, int max, out int value)
        {
            value = 0;
            text = text.Trim();

            if (text == "")
            {
                MessageBox.Show(fieldName + " cannot be empty. Please enter a whole number.", "Bicycle Rental",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (text.Contains(".") || text.Contains(","))
            {
                MessageBox.Show("Decimal numbers are not accepted. Please enter a whole number for " + fieldName + ".",
                    "Bicycle Rental", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(text, out value))
            {
                MessageBox.Show("Invalid input for " + fieldName + ". Please use digits only.", "Bicycle Rental",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (value < min || value > max)
            {
                MessageBox.Show(fieldName + " is out of range. Please enter a number between " + min + " and " + max + ".",
                    "Bicycle Rental", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm.ResetForm();
            loginForm.Show();
            navigating = true;
            this.Close();
        }

        // If the user closes this window with the X button, the whole app ends
        private void BicycleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!navigating)
            {
                Application.Exit();
            }
        }
    }
}