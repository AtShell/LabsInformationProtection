using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    internal class TempClass
    {/*
        static string fileToCompress = "Test.txt";
        static string encodedFile = "TestOutput.txt";
        static string decodedFile = "TestDecodedOutput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Generate ANSI table ...");

            ANSI ascii = new ANSI();
            ascii.WriteToFile();

            Console.WriteLine("ANSI table generated.");

            Console.WriteLine("Start encoding " + fileToCompress + " ...");

            string text = File.ReadAllText(fileToCompress, System.Text.ASCIIEncoding.Default);
            LZWEncoder encoder = new LZWEncoder();
            byte[] b = encoder.EncodeToByteList(text);
            File.WriteAllBytes(encodedFile, b);

            Console.WriteLine("File " + fileToCompress + " encoded to " + encodedFile);

            Console.WriteLine("Start decoding " + encodedFile);

            LZWDecoder decoder = new LZWDecoder();
            byte[] bo = File.ReadAllBytes(encodedFile);
            string decodedOutput = decoder.DecodeFromCodes(bo);
            File.WriteAllText(decodedFile, decodedOutput, System.Text.Encoding.Default);

            Console.WriteLine("File " + encodedFile + " decoded to " + decodedFile);
        }*/
    }
}
