using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Program
    {
       static void Main(string[] args)
        {
            // converter.exe <file_To_Convert> <Convertion to : -h = hex, -b = base64> <Outputfile>
            
            if (args.Length < 0)
            {
                Console.WriteLine("Please enter all parameters required");
            }
            else
            {
                switch (args[1])
                {
                    case "-h":
                        Console.WriteLine("Converting file into hex");
                        writeFileText(args[2],convertByteToHex(args[0]));
                        break;
                    case "-b":
                        Console.WriteLine("Converting file into Base64");
                        writeFileText(args[2], convertToBase64(args[0]));
                        break;
                    default:
                        Console.WriteLine("Invalid option : use -b or -h");
                        break;
                }

            }
            Console.ReadLine();

        }
        static void writeFileText(string path,string text)
        {
            File.WriteAllText(path, text);
        }
       static void writeFileBytes(string path,byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
       static byte[] getFileBytes(string filename)
        {
            return File.ReadAllBytes(filename);
        }
        static string convertByteToHex(string filename)
        {
            byte[] bytes = getFileBytes(filename);
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
            }
            return hex.ToString();
        }
       static string convertToBase64(string filename)
        {
            return Convert.ToBase64String(getFileBytes(filename));
        }
       static byte[] convertBase64ToByte(string base64)
        {
            return Convert.FromBase64String(base64);
        }
       static byte[] convertHexToByte(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
