/*
 * 3. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
 *    Составить программу, которая формирует новый массив, состоящий из элементов четных столбцов массива, и записывает его в новый файл.
 * 4. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
 *    Составить программу, которая формирует новый массив, состоящий из нечетных элементов четных строк массива, и записывает его в новый файл.
 * 5. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
 *    Составить программу, которая организует и записывает в файл новый двумерный массив,
 *    элементы главной диагонали которого равны соответствующим элементам исходного массива, а остальные элементы заданы случайным образом. 
 */

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CW_3_5
{
    public static class Program
    {
        const string Path = "Array.txt";
        static string[,] Array;
        
        public static void Main()
        {
            ReadArrayFromFile();
            Welcome(); // Приветственное сообщение.
            Exit();
        }
        
        private static void Welcome()
        {
            var t3 = new Variant3(Array, Path, "Variant3.txt"); // 3 вариант.
            var t4 = new Variant4(Array, "Variant4.txt"); // 4 вариант.
            var t5 = new Variant5(Array, Path, "Variant5.txt"); // 5 вариант.   
            var correctExecution = false;
            Console.WriteLine("# [ К О Н Т Р О Л Ь Н А Я  Р А Б О Т А ] //>>\n" +
                              "#\n" +
                              "# 3 ВАРИАНТ: Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.\n" +
                              "#   Составить программу, которая формирует новый массив, состоящий из элементов четных столбцов массива,\n" +
                              "#   и записывает его в новый файл.\n" + 
                              "# 4 ВАРИАНТ: Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.\n" +
                              "#   Составить программу, которая формирует новый массив, состоящий из нечетных элементов четных строк массива,\n" +
                              "#   и записывает его в новый файл.\n" +
                              "# 5 ВАРИАНТ: Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.\n" +
                              "#   Составить программу, которая организует и записывает в файл новый двумерный массив,\n" +
                              "#   элементы главной диагонали которого равны соответствующим элементам исходного массива,\n" +
                              "#   а остальные элементы заданы случайным образом.\n" +
                              "#\n" +
                              "# P.S Если хотите выполнить все варианты, введите \"0\"."
                              );
            Console.WriteLine(new string('_', Console.WindowWidth));
            while (!correctExecution)
            {
                Console.Write("Выберите вариант исполнения программой: ");
                switch (Console.ReadLine())
                {
                    case "3":
                        t3.Start();
                        correctExecution = true;
                        break;
                    case "4":
                        t4.Start();
                        correctExecution = true;
                        break;
                    case "5":
                        t5.Start();
                        correctExecution = true;
                        break;
                    case "0":
                        t3.Start();
                        t4.Start();
                        t5.Start();
                        correctExecution = true;
                        break;
                    default:
                        Console.WriteLine("[ОШИБКА] Введен неверный номер варианта. Повторите попытку.\n");
                        break;
                }
            }
        }
        
        static void ReadArrayFromFile() // Название говорит само за себя.
        {
            try
            {
                using (var sr = new StreamReader(Path, Encoding.UTF8))
                {
                    var columns = sr.ReadLine().Split().Length;
                    var lines = File.ReadAllLines(Path).Length;
                    Array = new string[lines, columns];
                    var tempNum = 0; // Как обойтись без него?
                    var temp = File.ReadAllText(Path).Split().Where(s => s != "").ToArray();
                    for (int i = 0; i < lines; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            Array[i, j] = temp[tempNum];
                            if (Array[i,j].Length > 1)
                                throw new Exception("Неверно введен двумерный массив в файле! Повторите попытку сделав матрицу в формате:\nn1 n2 n3\nn4 n5 n6\nи т.д...");
                            tempNum++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(
                    $"[ОШИБКА] Файл [{Path}] не найден.\nСоздайте файл в формате матрицы и повторите попытку!");
                Exit();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ОШИБКА] " + e.Message);
                Exit();
            }
        }

        public static void Exit()
        {
            Console.Write("\nНажмите любую клавишу для выхода..."); 
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}