using System;
using System.IO;
using System.Text;

namespace FindText
{
    class Program
    {
        static bool FindStringInStream(string path, string findString)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                int count = 0;
                bool isFound = false;
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                    if (line.Contains(findString))
                    {
                        Console.WriteLine(count);
                        isFound = true;
                    }

                }
                if (isFound == false)
                {
                    Console.WriteLine("Text not found!");
                }
                return isFound;
            }
        }

        static int Main(string[] args)
        {
            InputProcessor inputProcessor = new InputProcessor(args);
            if (!inputProcessor.CheckArgs())
            {
                return 1;
            }
            if (!FindStringInStream(inputProcessor.Path, args[1]))
            {
                return 1;
            }
            return 0;
        }
        
    }

    public class InputProcessor
    {
        public string[] Input { get; private set; }
        public string Path { get; private set; }

        public InputProcessor(string[] args)
        {
            Input = args;
        }

        public bool CheckArgs()
        {
            if (Input.Length != 2)
            {
                Console.WriteLine("Введите параметры <filename.txt> <text to search>!");
                return false;
            }

            Path = Input[0];
            FileInfo fileInfo = new FileInfo(Path);
            if (!fileInfo.Exists || fileInfo.Extension != ".txt")
            {
                Console.WriteLine("Файл не существует или у файла недопустимое расширение.");
                return false;
            }
            return true;
        }
    }
}
