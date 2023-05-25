using System;
using System.IO;
using System.IO.Compression;

namespace zip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide a source file path and a destination directory as arguments.");
                return;
            }

            string sourceFilePath = args[0];
            string destinationDirectory = args[1];

            UnzipFile(sourceFilePath, destinationDirectory);
        }

        static void UnzipFile(string sourceFilePath, string destinationDirectory)
        {
            // Check if the source file exists
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException($"Source file not found: {sourceFilePath}");
            }

            // Check if the destination directory exists, if not create it
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Extract the zip file to the destination directory
            try
            {
                ZipFile.ExtractToDirectory(sourceFilePath, destinationDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while extracting the file: {ex.Message}", ex);
            }
        }
    }
}
