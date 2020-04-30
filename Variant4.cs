/*
* 4. Пусть дан файл, содержащий двумерный массив чисел. Структура файла определена пользователем.
*     Составить программу, которая формирует новый массив, состоящий из нечетных элементов четных строк массива, и записывает его в новый файл.
*/

using System;
using System.IO;
using System.Text;

namespace CW_3_5
{
    public class Variant4
    {
        private string[,] Array;
        private string PathNewFile;
        private string[] newArray;

        public Variant4(string[,] array, string pathNewFile)
        {
            this.Array = array;
            this.PathNewFile = pathNewFile;
        }

        public void Start()
        {
            InitNewArray();
            SearchCurrentElements();
            WriteArrayOnFile();
        }

        void InitNewArray()
        {
            var countElements = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i + 1) % 2 == 0 && (j + 1) % 2 != 0)
                    {
                        countElements++;
                    }
                }
            }
            newArray = new string[countElements];
        }
        
        void SearchCurrentElements()
        {
            var c = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i + 1) % 2 == 0 && (j + 1) % 2 != 0)
                    {
                        newArray[c] = Array[i, j];
                        c++;
                    }
                }
            }
        }
        
        void WriteArrayOnFile()
        {
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
                Console.WriteLine($"[4][УСПЕШНО] Новый массив создан и записан в новый файл [{PathNewFile}]");
            }
            catch (Exception e)
            {
                Console.WriteLine("[4][ОШИБКА] " + e.Message);
                Program.Exit();
            }
        }
    }
}