using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTentamen
{
    public class File
    {
        public File(string name, bool isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;
        }
        public List<File> Files { get; private set; } = new List<File>();
        public string Name { get; }
        public bool IsDirectory { get; }

        public void AddFile(File file)
        {
            if (IsDirectory)
            {
                Files.Add(file);
            }
            else
            {
                throw new Exception("Can only add files to directories");
            }
        }
    }

    public class ClientProgram
    {
        public static void PrintFileNames(File file)
        {
            if (!file.IsDirectory)
            {
                Console.WriteLine(file.Name);
            }
            else
            {
                foreach(var subDir in file.Files)
                {
                    PrintFileNames(file);
                }
            }
        }
    }
}
