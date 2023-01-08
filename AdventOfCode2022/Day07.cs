using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022
{
    internal class Day07
    {
        public void Task1()
        {
            IList<string> commands = ReadFile();
            BigInteger sumSize = 0;
            Directory rootDir = new Directory();
            rootDir.Name = "/";
            IDictionary<string, Directory> BigDirs = new Dictionary<string, Directory>();

            Directory currentDir = null;

            foreach(string command in commands)
            {
                if(command.StartsWith("$"))
                {
                    if (command == "$ cd /") { currentDir = rootDir; }
                    else if (command == "$ ls") {  }
                    else if (command == "$ cd ..") { currentDir = currentDir.ParentDir; }
                    else 
                    { 
                        string dir = command.Substring(4, command.Length - 4).Trim();
                        currentDir = currentDir.SubDirs[dir]; 
                    }
                }
                else
                {
                    string[] commandParse = command.Split(' ');
                    if (commandParse[0] == "dir")
                    {
                        if (!currentDir.SubDirs.ContainsKey(commandParse[1]))
                        {
                            currentDir.SubDirs[commandParse[1]] = new Directory();
                            currentDir.SubDirs[commandParse[1]].ParentDir= currentDir;
                            currentDir.SubDirs[commandParse[1]].Name= commandParse[1];
                        }
                    }
                    else 
                    {
                        if (!currentDir.Files.ContainsKey(commandParse[1]))
                        {
                            currentDir.Files[commandParse[1]] = Int32.Parse(commandParse[0]);
                            currentDir.Size += Int32.Parse(commandParse[0]);
                            Directory tempDir = currentDir.ParentDir;
                            if(currentDir.Size > 100000 && !BigDirs.ContainsKey(currentDir.Name))
                            {
                                BigDirs[currentDir.Name] = currentDir;
                            }
                            while(tempDir != null)
                            {
                                tempDir.Size += Int32.Parse(commandParse[0]);
                                if (tempDir.Size > 100000 && !BigDirs.ContainsKey(tempDir.Name))
                                {
                                    BigDirs[tempDir.Name] = tempDir;
                                }

                                tempDir = tempDir.ParentDir;
                            }
                        }
                    }
                }
            }

            List<Directory> smallDirs = SmallDirs(rootDir);
            foreach(Directory smallDir in smallDirs)
            {
                sumSize+= smallDir.Size;    
            }
            Console.WriteLine(sumSize);
        }

        public void Task2()
        {
            IList<string> commands = ReadFile();
            BigInteger sumSize = 0;
            Directory rootDir = new Directory();
            rootDir.Name = "/";
            IDictionary<string, Directory> BigDirs = new Dictionary<string, Directory>();

            Directory currentDir = null;

            foreach (string command in commands)
            {
                if (command.StartsWith("$"))
                {
                    if (command == "$ cd /") { currentDir = rootDir; }
                    else if (command == "$ ls") { }
                    else if (command == "$ cd ..") { currentDir = currentDir.ParentDir; }
                    else
                    {
                        string dir = command.Substring(4, command.Length - 4).Trim();
                        currentDir = currentDir.SubDirs[dir];
                    }
                }
                else
                {
                    string[] commandParse = command.Split(' ');
                    if (commandParse[0] == "dir")
                    {
                        if (!currentDir.SubDirs.ContainsKey(commandParse[1]))
                        {
                            currentDir.SubDirs[commandParse[1]] = new Directory();
                            currentDir.SubDirs[commandParse[1]].ParentDir = currentDir;
                            currentDir.SubDirs[commandParse[1]].Name = commandParse[1];
                        }
                    }
                    else
                    {
                        if (!currentDir.Files.ContainsKey(commandParse[1]))
                        {
                            currentDir.Files[commandParse[1]] = Int32.Parse(commandParse[0]);
                            currentDir.Size += Int32.Parse(commandParse[0]);
                            Directory tempDir = currentDir.ParentDir;
                            if (currentDir.Size > 100000 && !BigDirs.ContainsKey(currentDir.Name))
                            {
                                BigDirs[currentDir.Name] = currentDir;
                            }
                            while (tempDir != null)
                            {
                                tempDir.Size += Int32.Parse(commandParse[0]);
                                if (tempDir.Size > 100000 && !BigDirs.ContainsKey(tempDir.Name))
                                {
                                    BigDirs[tempDir.Name] = tempDir;
                                }

                                tempDir = tempDir.ParentDir;
                            }
                        }
                    }
                }
            }

            int reqSpace = rootDir.Size - (70000000 - 30000000);
            Directory candidate = new Directory(); candidate.Size = int.MaxValue;
            SmallDirsBigEnught(rootDir, reqSpace, candidate);

           
            Console.WriteLine(candidate.Size);
        }

        private List<Directory>  SmallDirs(Directory rootDir)
        {
            List<Directory> smallDirs = new List<Directory>();
            if(rootDir.Size <= 100000) { smallDirs.Add(rootDir); }

            foreach (string key in rootDir.SubDirs.Keys)
            {
                smallDirs.AddRange(SmallDirs(rootDir.SubDirs[key]));
            }

            return smallDirs;
        }

        private void SmallDirsBigEnught(Directory rootDir, int reqSpace, Directory candidate)
        {
            if (rootDir.Size >= reqSpace && rootDir.Size < candidate.Size) { candidate.Size = rootDir.Size; }

            foreach (string key in rootDir.SubDirs.Keys)
            {
                SmallDirsBigEnught(rootDir.SubDirs[key], reqSpace, candidate);
            }
        }

        private IList<string> ReadFile()
        {
            IList<string> commands = new List<string>();
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day07.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    commands.Add(ln);
                }
                file.Close();
            }
            return commands;
        }
    }

    class Directory
    {
        public string Name { get; set; }
        public Directory ParentDir { get; set; }
        public IDictionary<string, Directory> SubDirs { get; set; }
        public IDictionary<string, int> Files { get; set; }
        public int Size { get; set; }

        public Directory() 
        {
            SubDirs = new Dictionary<string, Directory>();
            Files = new Dictionary<string, int>();
            Size = 0;
        }
    }
}
