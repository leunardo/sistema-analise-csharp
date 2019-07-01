using System;
using System.IO;
using System.Threading;
using south.application.services;

namespace south
{
    class Program
    {
        static void Main(string[] args)
        {
            var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var input = homePath + @"\data\in";
            var extension = "*.dat";
            var sleepTime = 10000;

            while (true)
            {
                string[] filePaths = Directory.GetFiles(input, extension);
                
                foreach (var path in filePaths)
                {
                    var outputPath = path
                        .Replace("in", "out")
                        .Replace(".dat", ".done.dat");

                    try
                    {
                        Console.WriteLine(">>> Reading file: " + path.Replace(input, ""));
                        var data = FileService.ReadFile(path);

                        Console.WriteLine("<<< Writing file: " + outputPath);
                        FileService.WriteFile(outputPath, data);
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Error ocurred while writing file on " + outputPath);
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine("ZzZ Waiting " + sleepTime + "ms to scan directory again...");
                Thread.Sleep(sleepTime);
            }
        }
    }
}
