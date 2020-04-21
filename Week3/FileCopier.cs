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

        private async Task MoveAsync(string sourceDirectory, string destinationDirectory)
        {
            Targeter targeter = new Targeter();
            targeter.FolderFilesInformation(sourceDirectory);
            Parallel.ForEach(Directory.EnumerateFiles(sourceDirectory), async filename =>
            {               
                string sourceFileSHA = targeter.ComputeSHA(filename);
                Console.WriteLine($"Started the moving for file {filename}.");
                using (FileStream sourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream destinationStream = File.Create(destinationDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                    {
                        Console.WriteLine($"Finished the moving for file {filename}.");
                        targeter.FileDetails(filename);
                        string destinationFileSHA = targeter.ComputeSHA(filename.Substring(filename.LastIndexOf('\\')));
                        targeter.VerifySHA(sourceFileSHA, destinationFileSHA);
                        await sourceStream.CopyToAsync(destinationStream);

                    }
                }
            });
            Console.WriteLine("Finished. All files are now moved in the new folder.");
            targeter.FileRankings(destinationDirectory);
        }



    }
}
