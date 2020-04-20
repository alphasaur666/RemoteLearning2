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
            string sourceFolder = @"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder1";
            string destinationFolder = @"C:\Users\Razvan\source\repos\TaskHomework\TaskHomework\Folder2";
            string[] sourceFiles = target.ParseFolder(sourceFolder);
            Task copy = copier.ProcessWriteAsync(sourceFolder, destinationFolder);
            Task.Run(() => copy);
            Task.WaitAll(copy);
            
        }
    }
}
