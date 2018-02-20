using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace SystemFileReader
{
    public class Manager
    {
        static object locker = new object();

        //public static string[] EnteredString = new string[0];

        public static string dirName = Console.ReadLine();
        public DirectoryInfo dirInfo = new DirectoryInfo(dirName);
        public static bool IsParentFiles { get; set; }
        public bool IsWork { get; set; }

        //ConsoleKeyInfo info = Console.ReadKey(true);

        Thread[] threads = new Thread[3];

        //List<string> elements = new List<string>();


        public void Read()
        {
            //ConsoleKeyInfo info;

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    threads[i] = new Thread(new ThreadStart(Search));
                    threads[i].Start();
                    Console.WriteLine("new Thread");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //info = Console.ReadKey(true);

            //if (info.Key == ConsoleKey.Spacebar)
            //{
            //    if (!IsWork)
            //    {
            //        Console.WriteLine("Go");
            //        IsWork = true;

            //        for (int i = 0; i < threads.Length; i++)
            //        {
            //            //threads[i].Resume();
            //            //threads[i].Interrupt();
            //            threads[i].Start();
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Stop");
            //        IsWork = false;

            //        for (int i = 0; i < threads.Length; i++)
            //        {
            //            threads[i].Interrupt();
            //            //threads[i].Suspend();
            //            //threads[i].Resume();

            //        }
            //    }
            //}
        }


        public void Search()
        {
            try
            {
                if (Directory.Exists(dirInfo.FullName))
                {
                    string[] Dirs = Directory.GetDirectories(dirInfo.FullName);

                    foreach (var s in Dirs)
                    {

                        dirInfo = new DirectoryInfo(s);

                        //for (int i = 0; i < elements.Count; i++)
                        //{
                        //    if (s != elements[i])
                        //    {
                        //        //AddElement(s);
                        //        elements.Add(s);
                        //    }
                        //    else
                        //    {
                        //        Search();
                        //    }
                        //}

                        Console.WriteLine("Подкаталог: " + dirInfo.FullName);

                        // Вывод файлов корневого каталога.
                        if (IsParentFiles == false)
                        {
                            IsParentFiles = true;
                            string[] filesMain = Directory.GetFiles(dirName);

                            foreach (var main in filesMain)
                            {
                                FileInfo fileInf = new FileInfo(main);
                                Console.WriteLine("Фаил: " + fileInf.FullName);
                            }
                        }

                        string[] files = Directory.GetFiles(dirInfo.FullName);

                        foreach (string st in files)
                        {
                            FileInfo fileInf = new FileInfo(st);
                            Console.WriteLine("Фаил: " + fileInf.FullName);
                        }

                        Search();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(dirInfo.FullName + " Доступ ограничен");
            }
        }

        //private static void AddElement(string st)
        //{
        //    lock (locker)
        //    {
        //        string[] tmpArray = new string[EnteredString.Length + 1];
        //        for (var i = 0; i < EnteredString.Length; i++)
        //        {
        //            tmpArray[i] = EnteredString[i];
        //        }
        //        tmpArray[EnteredString.Length] = st;
        //        EnteredString = tmpArray;
        //    }
        //}
    }
}

