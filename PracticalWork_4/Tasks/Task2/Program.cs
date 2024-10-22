using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns;
            Console.Write("Введите количество строк в матрице: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов в матрице: ");
            columns = int.Parse(Console.ReadLine());

            // Создание двух матриц
            int[,] matrixA = new int[rows, columns];
            int[,] matrixB = new int[rows, columns];
            int[,] matrixC = new int[rows, columns];  // для результата

            // Заполнение матриц случайными числами
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixA[i, j] = random.Next(100);  // первая матрица
                    matrixB[i, j] = random.Next(100);  // вторая матрица
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];  // сумма
                }
            }

            // Вывод первой матрицы на экран
            Console.WriteLine("\nПервая матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixA[i, j]} ");
                }
                Console.WriteLine();
            }

            // Вывод второй матрицы на экран
            Console.WriteLine("\nВторая матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixB[i, j]} ");
                }
                Console.WriteLine();
            }

            // Вывод суммы матриц на экран
            Console.WriteLine("\nСумма матриц:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixC[i, j]} ");
                }
                Console.WriteLine();
            }

            // Сумма всех элементов матрицы C
            int sumC = matrixC.Cast<int>().Sum();
            Console.WriteLine($"\nСумма всех элементов матрицы суммы: {sumC}");
        }
    }
}
