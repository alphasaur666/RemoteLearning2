using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomework
{
    class Targeter
    {
        public string fileName;
        public string targetPath;
        Task<string> characterReader = ReadCharacters(@".\CallOfTheWild.txt");
        //string readerResult = characterReader.Result;


        private static async Task<string> ReadCharacters(string fn)
        {
            string text;
            using(StreamReader streamReader = new StreamReader(fn))
            {
                text = await streamReader.ReadToEndAsync();
            }
            return text;
        }


        private string computeSHA(string rawData)
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
    }


}