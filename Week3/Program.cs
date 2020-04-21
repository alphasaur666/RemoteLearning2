using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TaskHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Targeter target = new Targeter();
            FileCopier copier = new FileCopier();
            Console.WriteLine("Give target folder..");
            string sourceFolder = Console.ReadLine();
            Console.WriteLine("Give destination folder..");
            string destinationFolder = Console.ReadLine();
            //"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder1"
            //"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder2"
            Task copy = copier.ProcessWriteAsync(sourceFolder, destinationFolder);
            Task.Run(() => copy);
            Task.WaitAll();           
        }
    }
}
