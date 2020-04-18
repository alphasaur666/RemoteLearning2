using System;
using System.Threading.Tasks;

namespace TaskHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCopier copier = new FileCopier();
            Targeter target = new Targeter();
            Task copy = copier.ProcessWriteAsync(@"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder1\TextFile1.txt", @"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder2\TextFile1.txt");
            Task.Run(() => copy);
            Task.WaitAll();
            Console.WriteLine(target.computeSHA(@"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder1\TextFile1.txt"));


        }
    }
}
