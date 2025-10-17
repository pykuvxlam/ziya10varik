using System;

namespace WinFormsApp4_ziya_variant_10_
{
    public class GameLogic
    {
        public char[,] Board { get; private set; } = new char[3, 3];
        public char CurrentPlayer { get; set; } = 'X';

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || col < 0 || row > 2 || col > 2 || Board[row, col] != '\0')
                return false;

            Board[row, col] = CurrentPlayer;
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            return true;
        }

        public char CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] != '\0' && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                    return Board[i, 0];
                if (Board[0, i] != '\0' && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                    return Board[0, i];
            }

            if (Board[0, 0] != '\0' && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                return Board[0, 0];
            if (Board[0, 2] != '\0' && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                return Board[0, 2];

            return '\0';
        }

        public bool IsDraw()
        {
            foreach (char cell in Board)
                if (cell == '\0') return false;
            return CheckWinner() == '\0';
        }

        public (int, int)? ComputerMove()
        {
            // Сначала пытаемся выиграть
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Board[i, j] == '\0')
                    {
                        Board[i, j] = CurrentPlayer;
                        if (CheckWinner() == CurrentPlayer)
                        {
                            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
                            return (i, j);
                        }
                        Board[i, j] = '\0';
                    }

            // Потом блокируем игрока
            char opponent = (CurrentPlayer == 'X') ? 'O' : 'X';
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Board[i, j] == '\0')
                    {
                        Board[i, j] = opponent;
                        if (CheckWinner() == opponent)
                        {
                            Board[i, j] = CurrentPlayer;
                            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
                            return (i, j);
                        }
                        Board[i, j] = '\0';
                    }

            // Иначе первый свободный
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Board[i, j] == '\0')
                    {
                        MakeMove(i, j);
                        return (i, j);
                    }

            return null;
        }

        public void Reset()
        {
            Board = new char[3, 3];
            CurrentPlayer = 'X';
        }
    }
}
