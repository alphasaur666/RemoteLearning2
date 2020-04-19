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
            FileCopier copier = new FileCopier();
            Task copy = copier.ProcessWriteAsync(copier.projectDirectory+@"\Folder1\TextFile1.txt", copier.projectDirectory+@"\Folder2\TextFile1.txt");
            Task.Run(() => copy);
            Task.WaitAll(copy);

        }
    }
}
