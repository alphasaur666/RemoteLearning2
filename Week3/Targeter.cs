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
 
        public async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }


        public string computeSHA(string rawData)
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

        public void fileDetails(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            Console.WriteLine($"File {fileName} has {fileInfo.Length}.");
        }


        public void fileRankings(string targetDirectory)
        {
            var files = Directory.GetFiles(targetDirectory);
            foreach(var file in files)
            {
                string fileName = Path.GetFileName(file);
                var fileInfo = new FileInfo(file);
                var fileSize = fileInfo.Length;
                var sorted = files.OrderBy(f => new FileInfo(f).Length);
                Console.WriteLine($"Filename: {fileName}, FileSize: {fileSize}.");
            }
            
        }

        public string[] ParseFolder(string sourceFolder)
        {           
            FileCopier fileCopier = new FileCopier();
            string[] files = Directory.GetFiles(sourceFolder);

            Parallel.ForEach(files, (currentFile) => 
            {
                string fileName = Path.GetFileName(currentFile);
                Console.WriteLine($"Found file {fileName}..");
                Console.WriteLine($"File {fileName} having SHA value {computeSHA(fileName)}");               
            });

            return files;
        }

        public bool verifySHA(string sourceFileSHA, string destinationFileSHA)
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