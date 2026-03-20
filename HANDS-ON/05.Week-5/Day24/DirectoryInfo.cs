using System;
using System.IO;

namespace FileHandlingTuplesAndPatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory path: ");
            string rootPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(rootPath))
            {
                Console.WriteLine("Invalid directory path.");
                return;
            }

            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(rootPath);

                if (!rootDir.Exists)
                {
                    Console.WriteLine("Directory does not exist.");
                    return;
                }

                Console.WriteLine("Subdirectories and file counts:\n");

                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                foreach (DirectoryInfo dir in subDirs)
                {
                        int fileCount = dir.GetFiles().Length;
                        Console.WriteLine($"{dir.Name} -> {fileCount} files");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}