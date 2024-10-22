using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns;
            Console.Write("Ведите количество строк в матрице: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов в матрице: ");
            columns = int.Parse(Console.ReadLine());

            // Создание матрицы
            int[,] matrix = new int[rows, columns];

            // Заполнение матрицы случайными числами
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(100);
                }
            }

            // Вывод матрицы на экран
            Console.WriteLine("Матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }

            // Сумма элементов матрицы
            int sum = matrix.Cast<int>().Sum();

            // Вывод суммы на экран
            Console.WriteLine($"Сумма всех элементов: {sum}");
        }
    }
}
