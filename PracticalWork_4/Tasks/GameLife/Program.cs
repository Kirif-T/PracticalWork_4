using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife
    {

        public class LifeSimulation
        {
            private int _heigth;
            private int _width;
            private bool[,] cells;

            /// Создаем новую игру
            /// <param name="Heigth">Высота поля.</param>
            /// <param name="Width">Ширина поля.</param>

            public LifeSimulation(int Heigth, int Width)
            {
                _heigth = Heigth;
                _width = Width;
                cells = new bool[Heigth, Width];
                GenerateField();
            }

            /// Перейти к следующему поколению и вывести результат на консоль.
          
            public void DrawAndGrow()
            {
                DrawGame();
                Grow();
            }

            /// Двигаем состояние на одно вперед, по установленным правилам

            private void Grow()
            {
                for (int i = 0; i < _heigth; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        int numOfAliveNeighbors = GetNeighbors(i, j);

                        if (cells[i, j])
                        {
                            if (numOfAliveNeighbors < 2)
                            {
                                cells[i, j] = false;
                            }

                            if (numOfAliveNeighbors > 3)
                            {
                                cells[i, j] = false;
                            }
                        }
                        else
                        {
                            if (numOfAliveNeighbors == 3)
                            {
                                cells[i, j] = true;
                            }
                        }
                    }
                }
            }

            /// Смотрим сколько живых соседий вокруг клетки.
            /// <param name="x">X-координата клетки.</param>
            /// <param name="y">Y-координата клетки.</param>
            /// <returns>Число живых клеток.</returns>

            private int GetNeighbors(int x, int y)
            {
                int NumOfAliveNeighbors = 0;

                for (int i = x - 1; i < x + 2; i++)
                {
                    for (int j = y - 1; j < y + 2; j++)
                    {
                        if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                        {
                            if (cells[i, j] == true) NumOfAliveNeighbors++;
                        }
                    }
                }
                return NumOfAliveNeighbors;
            }

            /// Нарисовать Игру в консоле

            private void DrawGame()
            {
                for (int i = 0; i < _heigth; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        Console.Write(cells[i, j] ? "x" : " ");
                        if (j == _width - 1) Console.WriteLine("\r");
                    }
                }
                Console.SetCursorPosition(0, Console.WindowTop);
            }

            /// Инициализируем случайными значениями

            private void GenerateField()
            {
                Random generator = new Random();
                int number;
                for (int i = 0; i < _heigth; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        number = generator.Next(2);
                        cells[i, j] = ((number == 0) ? false : true);
                    }
                }
            }
        }

        internal class Program
        {

            // Ограничения игры
            private const int Heigth = 10;
            private const int Width = 30;
            private const uint MaxRuns = 100;

            private static void Main(string[] args)
            {
                int runs = 0;
                LifeSimulation sim = new LifeSimulation(Heigth, Width);

                while (runs++ < MaxRuns)
                {
                    sim.DrawAndGrow();

                    // Дадим пользователю шанс увидеть, что происходит, немного ждем
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
    }
