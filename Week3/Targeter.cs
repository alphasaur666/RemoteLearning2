using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomework
{
    internal class Targeter
    {
        public string ComputeSHA(string rawData)
        {
            using(SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder stringBuilder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public void FileDetails(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            Console.WriteLine($"File {fileName} has {fileInfo.Length} bytes.");
        }


        public string FileRankings(string targetDirectory)
        {
            Console.WriteLine("File rankings from smallest to biggest:");
            var files = Directory.EnumerateFiles(targetDirectory).Select(f => new FileInfo(f)).OrderBy(f => f.Length);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            return files.ToString();
        }

        public void FolderFilesInformation(string sourceFolder)
        {           
            FileCopier fileCopier = new FileCopier();
            Parallel.ForEach(Directory.EnumerateFiles(sourceFolder), (currentFile) => 
            {
                string fileName = Path.GetFileName(currentFile);
                Console.WriteLine($"Found file {fileName}..");
                Console.WriteLine($"File {fileName} having SHA value {ComputeSHA(fileName)}");               
            });;
        }

        public bool VerifySHA(string sourceFileSHA, string destinationFileSHA)
        {
            if(sourceFileSHA == destinationFileSHA)
            {
                Console.WriteLine($"The sha is {destinationFileSHA} and it matches to the one before copying.");
            }
            else
            {
                Console.WriteLine($"The sha is {destinationFileSHA} and it doesnt match to the one before copying.");
            }

            return true;
        }
    }
}