using System;
using System.Windows.Forms; // ��� MessageBox
using Microsoft.VisualBasic; // ��� InputBox

class Program
{
    [STAThread] // �� ������� ��� ������������ ��������� ���� Windows Forms
    static void Main()
    {
        bool repeat = true; // ��������� ��� ���������� ��������� ��������

        while (repeat)
        {
            // �������� �������� x � ��������� �� ��������� InputBox
            string input = Interaction.InputBox("������ �������� x:", "�������� ���������", "0");
            double x;

            // �������� ���������� ��������
            if (!double.TryParse(input, out x))
            {
                MessageBox.Show("������� ���������� ��������. ��������� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                continue;
            }

            double y = 0;


            if (x >= 1)
            {
                y = Math.Exp(-Math.Abs(x));
            }

            if (x < 1 && Math.Abs(x) < 1)
            {
                y = Math.Log(Math.Sqrt(1 - x * x));
            }

            if (x <= -1)
            {
                y = Math.Atan(x); // arctg(x)
            }


            string resultMessage = $"��������� �������� x: {x}\n��������� �������� y: {y}";
            DialogResult dialogResult = MessageBox.Show(resultMessage + "\n\n������ �������� �������� �� ���?", "���������", MessageBoxButtons.YesNo);


            if (dialogResult == DialogResult.No)
            {
                repeat = false;
            }
        }
    }
}
