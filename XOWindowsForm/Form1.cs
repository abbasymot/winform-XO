namespace XOWindowsForm
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X    false = O
        int turnCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            // Reset the game.

            turn = true;
            turnCounter = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    // Make button enable.
                    b.Enabled = turn;
                    // Change the button text to empty.
                    b.Text = "";
                }
            }
            catch { }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            // Exit app.
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Player turn text
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            turnCounter++;

            // Make button disable.
            b.Enabled = false;

            checkForWinner(); // Check for win
        }
        private void checkForWinner()
        {
            bool win = false;

            // 1-2-3
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                win = true;
            }

            // 4-5-6
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                win = true;
            }

            // 7-8-9
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                win = true;
            }

            // 1-5-9
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                win = true;
            }

            //3-5-7
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                win = true;
            }

            //1-4-7
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                win = true;
            }

            //2-5-8
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                win = true;
            }

            //3-6-9
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                win = true;
            }

            if (win)
            {
                // Find the winner
                string winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                // Show a message box
                MessageBox.Show(winner + " Wins!");
            }

            // If no ones win
            if (turnCounter == 9)
            {
                MessageBox.Show("Click on new game, Nobody wins!");
            }
        }
    }
}