using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// https://github.com/MaxMaxoff
/// 
/// Домашняя работа "Алгоритмы и структуры данных"
/// 4 урок
/// </summary>
namespace HomeWorkA4
{
    class Program
    {
        /// <summary>
        /// 1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
        /// </summary>
        static void Task1()
        {
            SupportMethods.PrepareConsoleForHomeTask("1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.\n");

        }

        /// <summary>
        /// 2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
        /// </summary>
        static void Task2()
        {
            SupportMethods.PrepareConsoleForHomeTask("2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.\n");
            string str1 = SupportMethods.RequestString("Please type fist sequence: ");
            string str2 = SupportMethods.RequestString("Please type second sequence: ");
            str1 = " " + str1;
            str2 = " " + str2;

            int[,] arr = new int[str1.Length, str2.Length];
            char[] strArr1 = str1.ToCharArray();
            char[] strArr2 = str2.ToCharArray();

            for (int i = 0; i < strArr1.Length; i++)
            {
                SupportMethods.Print($"{strArr1[i]}", i * 2 + 2, 6);
                SupportMethods.Print($"0", i * 2 + 2, 7);
            }

            for (int j = 0; j < strArr2.Length; j++)
            {
                SupportMethods.Print($"{strArr2[j]}", 0, j + 7);
                SupportMethods.Print($"0", 2, j + 7);
            }

            SupportMethods.Pause($"\nMax overall sequence: {MaxL(arr, strArr1, strArr2)}\nPress any key to continue...");
        }

        /// <summary>
        /// Method MaxL
        /// </summary>
        /// <param name="arr">array of overall sequence</param>
        /// <param name="arr1">first sequence</param>
        /// <param name="arr2">second sequence</param>
        /// <returns>size of overall sequence</returns>
        static int MaxL(int[,] arr, char[] arr1, char[] arr2)
        {
            int i = 1;
            int j = 1;
            int jj = 0;

            if (arr1.Length == 0 || arr2.Length == 0)
            {
                return 0;
            }
            else
                while (i < arr1.Length)
                {
                    j = 1;
                    while (j < arr2.Length)
                        if (arr1[i] == arr2[j] && arr[i,j] == 0)
                        {
                            jj = j;
                            arr[i, j] = arr[i - 1, j - 1] + 1;
                            SupportMethods.Print($"{arr[i, j]}", i * 2 + 2, j + 7, "red");
                            for (int m = i + 1; m < arr1.Length; m++)
                            {
                                arr[m, j] = arr[i, j];
                                SupportMethods.Print($"{arr[m, j]}", m * 2 + 2, j + 7);
                            }
                            for (int m = j + 1; m < arr2.Length; m++)
                            {
                                arr[i, m] = arr[i, j];
                                SupportMethods.Print($"{arr[i, m]}", i * 2 + 2, m + 7);
                            }
                            j = arr2.Length;
                        }
                        else
                        {
                            arr[i, j] = arr[i - 1, j];
                            SupportMethods.Print($"{arr[i, j]}", i * 2 + 2, j + 7);
                            j++;
                        }
                    i++;
                }

            // return last item in arr
            return arr[arr1.Length - 1, arr2.Length - 1];
        }

        /// <summary>
        /// 3. ***Требуется обойти конём шахматную доску размером NxM, пройдя через все поля доски по одному разу.
        /// Здесь алгоритм решения такой же как и в задаче о 8 ферзях. Разница только в проверке положения коня.
        /// </summary>
        static void Task3()
        {
            SupportMethods.PrepareConsoleForHomeTask("3. ***Требуется обойти конём шахматную доску размером NxM, пройдя через все поля доски по одному разу.\n" +
                "Здесь алгоритм решения такой же как и в задаче о 8 ферзях. Разница только в проверке положения коня.\n");

            int x = SupportMethods.RequestIntValue("Please type size of field, x value: ");
            int y = SupportMethods.RequestIntValue("Please type size of field, y value: ");

            Knight knight = new Knight(x ,y);
            // Field field = new Field(x, y);

            int move = 1;
            int curMove = 1;
            int min = 0;

            while (move < x * y && curMove < 9)
            {
                move++;
                SupportMethods.Print($"{move}", 0, 7);
                min = 9;
                curMove = 9;
                if (move < x * y)
                {
                    if (knight.CheckMoveUR() && knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y - 2) < min && knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y - 2) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y - 2);
                        curMove = 1;
                    }
                    if (knight.CheckMoveRU() && knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y - 1) < min && knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y - 1) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y - 1);
                        curMove = 2;
                    }
                    if (knight.CheckMoveRD() && knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y + 1) < min && knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y + 1) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X + 2, knight.Y + 1);
                        curMove = 3;
                    }
                    if (knight.CheckMoveDR() && knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y + 2) < min && knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y + 2) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X + 1, knight.Y + 2);
                        curMove = 4;
                    }
                    if (knight.CheckMoveDL() && knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y + 2) < min && knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y + 2) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y + 2);
                        curMove = 5;
                    }
                    if (knight.CheckMoveLD() && knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y + 1) < min && knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y + 1) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y + 1);
                        curMove = 6;
                    }
                    if (knight.CheckMoveLU() && knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y - 1) < min && knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y - 1) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X - 2, knight.Y - 1);
                        curMove = 7;
                    }
                    if (knight.CheckMoveUL() && knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y - 2) < min && knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y - 2) > 0)
                    {
                        min = knight.GetAvailableMovementFromCell(knight.X - 1, knight.Y - 2);
                        curMove = 8;
                    }
                }
                else
                {
                    if (knight.CheckMoveUR())
                    {
                        curMove = 1;
                    }
                    if (knight.CheckMoveRU())
                    {
                        curMove = 2;
                    }
                    if (knight.CheckMoveRD())
                    {
                        curMove = 3;
                    }
                    if (knight.CheckMoveDR())
                    {
                        curMove = 4;
                    }
                    if (knight.CheckMoveDL())
                    {
                        curMove = 5;
                    }
                    if (knight.CheckMoveLD())
                    {
                        curMove = 6;
                    }
                    if (knight.CheckMoveLU())
                    {
                        curMove = 7;
                    }
                    if (knight.CheckMoveUL())
                    {
                        curMove = 8;
                    }
                }

                switch (curMove)
                {
                    case 1:
                        knight.MoveUR(move);
                        break;
                    case 2:
                        knight.MoveRU(move);
                        break;
                    case 3:
                        knight.MoveRD(move);
                        break;
                    case 4:
                        knight.MoveDR(move);
                        break;
                    case 5:
                        knight.MoveDL(move);
                        break;
                    case 6:
                        knight.MoveLD(move);
                        break;
                    case 7:
                        knight.MoveLU(move);
                        break;
                    case 8:
                        knight.MoveUL(move);
                        break;

                    default:
                        break;
                }
            }

            SupportMethods.Print("Done", 0, 8 + y);

            if (move < x * y)
                SupportMethods.Pause($"Unsucessfull...\n{knight.ToString()}\nPress any key to Continue...");
            else SupportMethods.Pause($"Sucessfull...\n{knight.ToString()}\nPress any key to Continue...");

        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
