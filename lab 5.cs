using System;
using System.Windows.Forms; // Для MessageBox
using Microsoft.VisualBasic; // Для InputBox

class Program
{
    [STAThread] // Це потрібно для використання діалогових вікон Windows Forms
    static void Main()
    {
        bool repeat = true; // Прапорець для повторення виконання програми

        while (repeat)
        {
            // Введення значення x з клавіатури за допомогою InputBox
            string input = Interaction.InputBox("Введіть значення x:", "Введення параметра", "0");
            double x;

            // Перевірка коректності введення
            if (!double.TryParse(input, out x))
            {
                MessageBox.Show("Введено некоректне значення. Спробуйте знову.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            string resultMessage = $"Початкове значення x: {x}\nОбчислене значення y: {y}";
            DialogResult dialogResult = MessageBox.Show(resultMessage + "\n\nБажаєте виконати програму ще раз?", "Результат", MessageBoxButtons.YesNo);


            if (dialogResult == DialogResult.No)
            {
                repeat = false;
            }
        }
    }
}
