using System;
using System.IO;

namespace FileHandlingTuplesAndPatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("Drive Information:");

                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"Drive Name: {drive.Name}");
                    Console.WriteLine($"Drive Type: {drive.DriveType}");

                        long totalSize = drive.TotalSize;
                        long freeSpace = drive.AvailableFreeSpace;

                        double freePercent = (double)freeSpace / totalSize * 100;

                        Console.WriteLine($"Total Size: {totalSize / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Free Space: {freeSpace / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Free Space %: {freePercent:F2}%");

                        if (freePercent < 15)
                        {
                            Console.WriteLine("WARNING: Low disk space!");
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}