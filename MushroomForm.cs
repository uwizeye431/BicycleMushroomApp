using System;
using System.Windows.Forms;

namespace BicycleMushroomApp
{
    public partial class MushroomForm : Form
    {
        private LoginForm loginForm;
        private bool navigating = false;

        // Which question we are on:
        // 0 = ring, 1 = forest (has ring), 2 = convex cap (has ring),
        // 3 = gills (no ring), 4 = convex cap (no ring)
        private int step = 0;

        public MushroomForm(LoginForm login)
        {
            InitializeComponent();
            loginForm = login;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            switch (step)
            {
                case 0:
                    lblQuestion.Text = "Does your mushroom have a ring?";
                    break;
                case 1:
                    lblQuestion.Text = "Does your mushroom grow in a forest?";
                    break;
                case 2:
                    lblQuestion.Text = "Does your mushroom have a convex cap?";
                    break;
                case 3:
                    lblQuestion.Text = "Does your mushroom have gills?";
                    break;
                case 4:
                    lblQuestion.Text = "Does your mushroom have a convex cap?";
                    break;
            }
        }

        private void Answer(bool yes)
        {
            switch (step)
            {
                case 0:
                    step = yes ? 1 : 3;
                    break;

                case 1:
                    if (yes)
                    {
                        ShowResult("Amanite tue-mouche");
                        return;
                    }
                    step = 2;
                    break;

                case 2:
                    ShowResult(yes ? "Agaric Jaunissant" : "Coprin chevelu");
                    return;

                case 3:
                    if (!yes)
                    {
                        ShowResult("Cepe de bordeau");
                        return;
                    }
                    step = 4;
                    break;

                case 4:
                    ShowResult(yes ? "Pied bleu" : "Girolle");
                    return;
            }

            ShowQuestion();
        }

        private void ShowResult(string mushroomName)
        {
            MessageBox.Show("Your mushroom is " + mushroomName + ".", "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            step = 0;
            ShowQuestion();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Answer(true);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Answer(false);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            step = 0;
            ShowQuestion();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm.ResetForm();
            loginForm.Show();
            navigating = true;
            this.Close();
        }

        // If the user closes this window with the X button, the whole app ends
        private void MushroomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!navigating)
            {
                Application.Exit();
            }
        }
    }
}