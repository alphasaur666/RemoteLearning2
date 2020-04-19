using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomework
{
    public class FileCopier
    {
        //private string[] filesPath = Directory.GetFiles(@"TaskHomework\Folder1");
        public string sourceFile;
        public string destinationFile;
        public string projectDirectory = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public FileCopier()
        {
        }


        public async Task ProcessWriteAsync(string sourceFile, string destinationFile)
        {
            await MoveAsync(sourceFile, destinationFile);
        }

        private static async Task MoveAsync(string sourceFile, string destinationFile)
        {
            Targeter targeter = new Targeter();
            string sourceFileSHA = targeter.computeSHA(sourceFile);
            Console.WriteLine($"Started the moving for file {sourceFile}.");
            
            using (Stream source = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (Stream destination = File.Open(destinationFile, FileMode.CreateNew, FileAccess.Write))
                {
                    Console.WriteLine($"Finished the moving for file {sourceFile}.");
                    targeter.fileDetails(sourceFile);
                    string destinationFileSHA = targeter.computeSHA(destinationFile);
                    targeter.verifySHA(sourceFileSHA, destinationFileSHA);
                    await source.CopyToAsync(destination);                  
                    

                    
                }
            }
            Console.WriteLine($"Finished. All files are now moved on the new folder.");
        }



    }
}
