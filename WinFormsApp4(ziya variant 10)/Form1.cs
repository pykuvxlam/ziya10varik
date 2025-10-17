using System;
using System.Windows.Forms;

namespace WinFormsApp4_ziya_variant_10_
{
    public partial class Form1 : Form
    {
        private GameLogic game;
        private char playerSymbol = 'X';
        private char computerSymbol = 'O';

        public Form1()
        {
            InitializeComponent();
            game = new GameLogic();

            // Выбор за кого играть
            var result = MessageBox.Show("Вы хотите играть X? (Да = X, Нет = O)", "Выбор символа", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                playerSymbol = 'O';
                computerSymbol = 'X';
                game.CurrentPlayer = 'X';
                MakeComputerMove(); // компьютер ходит первым
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var (row, col) = ((int, int))btn.Tag;

            if (!game.MakeMove(row, col)) return;

            btn.Text = game.Board[row, col].ToString();

            char winner = game.CheckWinner();
            if (winner != '\0')
            {
                EndGame(winner);
                return;
            }

            if (game.IsDraw())
            {
                MessageBox.Show("Ничья!");
                return;
            }

            lblStatus.Text = $"Ходит: {game.CurrentPlayer}";

            if (game.CurrentPlayer == computerSymbol)
                MakeComputerMove();
        }

        private void MakeComputerMove()
        {
            var move = game.ComputerMove();
            if (move != null)
            {
                buttons[move.Value.Item1, move.Value.Item2].Text = computerSymbol.ToString();
                char winner = game.CheckWinner();
                if (winner != '\0')
                {
                    EndGame(winner);
                    return;
                }
                if (game.IsDraw())
                {
                    MessageBox.Show("Ничья!");
                    return;
                }
                lblStatus.Text = $"Ходит: {playerSymbol}";
            }
        }

        private void EndGame(char winner)
        {
            if (winner == playerSymbol)
                MessageBox.Show("Вы победили!");
            else
                MessageBox.Show("Вы проиграли!");
            DisableButtons();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            game.Reset();
            foreach (var btn in buttons)
            {
                btn.Enabled = true;
                btn.Text = "";
            }
            lblStatus.Text = $"Ходит: {playerSymbol}";

            // Если компьютер играет X
            if (playerSymbol == 'O')
                MakeComputerMove();
        }

        private void DisableButtons()
        {
            foreach (var btn in buttons)
                btn.Enabled = false;
        }
    }
}

