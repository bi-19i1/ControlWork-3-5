/*
 * 3. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
 *    Составить программу, которая формирует новый массив, состоящий из элементов четных столбцов массива, и записывает его в новый файл.
 */

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CW_3_5
{
    public class Variant3
    {
        private string Path;
        private string[,] Array;
        private string PathNewFile;
        
        public Variant3(string[,] array,string path, string pathNewFile)
        {
            this.Path = path;
            this.PathNewFile = pathNewFile;
            this.Array = array;
        }
        
        public void Start()
        {
            WriteArrayOnFile();
        }
        
        string[] InitNewArray()
        {
            var newArray = new string[FindCountElementsInNewArray()];
            int counter = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((j + 1) % 2 == 0)
                    {
                        newArray[counter] = Array[i, j];
                        counter++;
                    }
                }
            }
            return newArray;
        }

        int FindCountElementsInNewArray()
        {
            using (var sr = new StreamReader(Path, Encoding.UTF8))
            {
                var columns = sr.ReadLine().Split().Length;
                        return columns / 2 * File.ReadLines(Path).Count();
            }
        }

        void WriteArrayOnFile()
        {
            var newArray = InitNewArray();
            try
            {
                using (var sw = new StreamWriter(PathNewFile, false, Encoding.UTF8))
                {
                    for (int i = 0; i < newArray.GetLength(0); i++)
                    {
                        sw.Write(newArray[i]);
                        if (i < newArray.GetLength(0) - 1) // Без лишних пробелов.
                            sw.Write(" ");
                    }
                }
                Console.WriteLine($"[3][УСПЕШНО] Новый массив создан и записан в новый файл [{PathNewFile}]");
            }
            catch (Exception e)
            {
                Console.WriteLine("[3][ОШИБКА] " + e.Message);
                Program.Exit();
            }
        }
    }
}