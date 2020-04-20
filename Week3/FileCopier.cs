using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomework
{
    public class FileCopier
    {
        
        public async Task ProcessWriteAsync(string sourceDirectory, string destinationDirectory)
        {
            await MoveAsync(sourceDirectory, destinationDirectory);
        }

        private static async Task MoveAsync(string sourceDirectory, string destinationDirectory)
        {
            Targeter targeter = new Targeter();
            foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourceDirectory, destinationDirectory));

            foreach (string filename in Directory.EnumerateFiles(sourceDirectory))
            {
                string sourceFileSHA = targeter.computeSHA(filename);
                Console.WriteLine($"Started the moving for file {filename}.");
                using (FileStream sourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream destinationStream = File.Create(destinationDirectory+ filename.Substring(filename.LastIndexOf('\\'))))
                    {
                        Console.WriteLine($"Finished the moving for file {filename}.");
                        targeter.fileDetails(filename);
                        string destinationFileSHA = targeter.computeSHA(filename.Substring(filename.LastIndexOf('\\')));
                        targeter.verifySHA(sourceFileSHA, destinationFileSHA);
                        await sourceStream.CopyToAsync(destinationStream);

                    }
                }
            }
            Console.WriteLine("Finished. All files are now moved in the new folder.");
            targeter.fileRankings(destinationDirectory);
        }



    }
}
