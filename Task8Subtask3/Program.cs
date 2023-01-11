using System;
using System.IO;


namespace Task8Subtask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный адрес для папки");
            string sourceDirectory = Console.ReadLine();
            if (Directory.Exists(sourceDirectory))
            {
                var di = new DirectoryInfo(sourceDirectory);
                Console.WriteLine("Исходный размер: "+ $"{DirSize(di)} байт");
                foreach (FileInfo file in di.GetFiles())
                {
                    if ((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(0))
                    {
                        file.Delete();
                        Console.WriteLine("Файл {0} удалён", file.Name);
                    }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if ((DateTime.Now - dir.LastAccessTime) > TimeSpan.FromMinutes(0))
                    {
                        dir.Delete(true);
                        Console.WriteLine("Папка {0} удалена", dir.Name);
                    }
                }
                Console.WriteLine("Текущий размер папки: " + $"{DirSize(di)} байт");
            }
            else
            {
                Console.WriteLine("Папка не найдена. \n Введите корректный адрес папки");
            }
        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
    }
}