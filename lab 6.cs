using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;



using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        int turn = 1;
        bool isWin = false;

        while (!isWin && turn <= 9)
        {
            PrintBoard();
            Console.WriteLine($"������� {currentPlayer}, ������ ������� (1-9): ");
            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';

            if (isValidChoice)
            {
                board[choice - 1] = currentPlayer;
                isWin = CheckWin();
                if (!isWin)
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    turn++;
                }
            }
            else
            {
                Console.WriteLine("������������� ����, ��������� �����.");
            }
        }

        PrintBoard();
        if (isWin)
        {
            Console.WriteLine($"³����! ������� {currentPlayer} ������!");
        }
        else
        {
            Console.WriteLine("ͳ���!");
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }

    static bool CheckWin()
    {
        int[][] winCombinations = new int[][]
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 },
            new int[] { 2, 4, 6 }
        };

        foreach (var combination in winCombinations)
        {
            if (board[combination[0]] == currentPlayer &&
                board[combination[1]] == currentPlayer &&
                board[combination[2]] == currentPlayer)
            {
                return true;
            }
        }
        return false;
    }
}


class Program
{
    [STAThread]
    static void Main()
    {



        double n, m, a, b, c, p;
        double max, min;
        string prevM = "0";
        string prevN = "0";
        string prevA = "0";
        string prevB = "0";

        do
        {
            DialogResult taskChoice = MessageBox.Show("������� ������:\n\n�������� '���' ��� ������ 1 (���������� a, b, c).\n�������� 'ͳ' ��� ������ 2 (���������� p, max, min).",
                                                      "���� ������",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);

            if (taskChoice == DialogResult.Cancel)
                return;

            MessageBox.Show("���� �����, ������ �������� ��� m �� n.",
                            "����������",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            while (true)
            {
                string inputM = Interaction.InputBox("������ �������� ��� m:", "�������� m", prevM);

                if (string.IsNullOrEmpty(inputM))
                {
                    return;
                }

                if (double.TryParse(inputM, out m))
                {
                    prevM = inputM;
                    break;
                }

                MessageBox.Show("������� �������� �� � ������. ��������� �� ���.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            while (true)
            {
                string inputN = Interaction.InputBox("������ �������� ��� n:", "�������� n", prevN);

                if (string.IsNullOrEmpty(inputN))
                {
                    return;
                }

                if (double.TryParse(inputN, out n))
                {
                    prevN = inputN;
                    break;
                }

                MessageBox.Show("������� �������� �� � ������. ��������� �� ���.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (taskChoice == DialogResult.Yes)
            {
                a = (m + n) / 5;
                b = (m * n) / (m - 1);
                c = 3.5 * n;

                string resultMessage = $"�� ������� ������ 1.\n\n������ ��������: m = {m}, n = {n}\n\n" +
                                       $"�������� ��������:\na = {a:F2}\nb = {b:F2}\nc = {c:F2}";

                DialogResult retry = MessageBox.Show(resultMessage + "\n\n������ ��������� � ������ ����������?",
                                                     "���������� ���������",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Information);

                if (retry == DialogResult.No)
                    break;
            }
            else if (taskChoice == DialogResult.No)
            {
                while (true)
                {
                    string inputA = Interaction.InputBox("������ �������� ��� a:", "�������� a", prevA);

                    if (string.IsNullOrEmpty(inputA))
                    {
                        return;
                    }

                    if (double.TryParse(inputA, out a))
                    {
                        prevA = inputA;
                        break;
                    }

                    MessageBox.Show("������� �������� �� � ������. ��������� �� ���.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                while (true)
                {
                    string inputB = Interaction.InputBox("������ �������� ��� b:", "�������� b", prevB);

                    if (string.IsNullOrEmpty(inputB))
                    {
                        return;
                    }

                    if (double.TryParse(inputB, out b))
                    {
                        prevB = inputB;
                        break;
                    }

                    MessageBox.Show("������� �������� �� � ������. ��������� �� ���.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                max = Math.Max(m, n);
                min = Math.Min(m, n);
                p = Math.Min(a, b) + max;

                string resultMessage = $"�� ������� ������ 2.\n\n������ ��������: m = {m}, n = {n}, a = {a}, b = {b}\n\n" +
                                       $"����������� �������� = {max}\n̳������� �������� = {min}\n" +
                                       $"��������� �������� p = {p:F2}";

                DialogResult retry = MessageBox.Show(resultMessage + "\n\n������ ��������� � ������ ����������?",
                                                     "���������� ���������",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Information);

                if (retry == DialogResult.No)
                    break;
            }

        } while (true);
    }
}
