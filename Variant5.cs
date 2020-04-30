/*
* 5. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
*     Составить программу, которая организует и записывает в файл новый двумерный массив,
*     элементы главной диагонали которого равны соответствующим элементам исходного массива, а остальные элементы заданы случайным образом. 
*/

using System;
using System.IO;
using System.Text;

namespace CW_3_5
{
    public class Variant5
    {
        private string[,] Array;
        private string PathNewFile;
        private string Path;

        public Variant5(string[,] array,string path, string pathNewFile)
        {
            this.Array = array;
            this.Path = path;
            this.PathNewFile = pathNewFile;
        }

        public void Start()
        {
            WriteArrayOnFile();
        }

        void WriteArrayOnFile()
        {
            var rnd = new Random();
            if (Array.GetLength(0) != Array.GetLength(1))
            {
                Console.WriteLine($"[5][ВНИМАНИЕ] В файле [{Path}] задана не квадратная матрица. Учтите это при проверке нового файла!");
            }
            try
            {
                using (var sw = new StreamWriter(PathNewFile, false, Encoding.UTF8))
                {
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        for (int j = 0; j < Array.GetLength(1); j++)
                        {
                            if (i == j)
                            {
                                sw.Write(Array[i, j]);
                            }
                            else
                            {
                                sw.Write(Array[rnd.Next(0, Array.GetLength(0)), rnd.Next(0, Array.GetLength(1))]); // ?? Не могу понять, почему постоянно один и тот же элемент записывается.
                            }
                            
                            if (i < Array.GetLength(0) - 1 || j < Array.GetLength(1) - 1) // Без лишних пробелов.
                                sw.Write(" ");
                        }
                        if(i < Array.GetLength(0) - 1)
                            sw.WriteLine();
                    }
                }
                Console.WriteLine($"[5][УСПЕШНО] Новый массив создан и записан в новый файл [{PathNewFile}]");
            }
            catch (Exception e)
            {
                Console.WriteLine("[5][ОШИБКА] " + e.Message);
                Program.Exit();
            }
        }
    }
}