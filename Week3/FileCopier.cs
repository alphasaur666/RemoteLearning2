using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomework
{
    public class FileCopier
    {
        private string filesPath;
        public string sourceFile;
        public string destinationFile;


        public async Task ProcessWriteAsync(string sourceFile, string destinationFile)
        {
            await MoveAsync(sourceFile, destinationFile);
        }

        private static async Task MoveAsync(string sourceFile, string destinationFile)
        {

            using (Stream source = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (Stream destination = File.Open(destinationFile, FileMode.CreateNew, FileAccess.Write))
                {
                    await source.CopyToAsync(destination);
                }
            }
        }



    }
}
