using System;
using System.IO;

namespace FileLocker
{
    class Program
    {
        static void Main(string[] files)
        {
            Console.WriteLine($"Locking files:  {String.Join(",", files)}");

            foreach (var filePath in files)
            {
                try
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    Console.WriteLine($"Locked file {fileStream.Name} with handle {fileStream.SafeFileHandle.DangerousGetHandle()}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Unable to lock file {filePath}:  {exception}");
                }
            }

            Console.WriteLine("Press enter to terminate.");
            Console.ReadLine();
        }
    }
}
