using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day02
    {

        public void Task1()
        {
            IList<Tuple<string, string>> pairs = ReadFile();
            int score = 0;
            foreach(Tuple<string, string> pair in pairs)
            {
                if(pair.Item2 == "X")
                {
                    score = score + 1;
                    if(pair.Item1 == "A")
                    {
                        score = score + 3;
                    }
                    else if (pair.Item1 == "C")
                    {
                        score = score + 6;
                    }
                }
                else if (pair.Item2 == "Y")
                {
                    score = score + 2;
                    if (pair.Item1 == "A")
                    {
                        score = score + 6;
                    }
                    else if (pair.Item1 == "B")
                    {
                        score = score + 3;
                    }
                }
                else if (pair.Item2 == "Z")
                {
                    score = score + 3;
                    if (pair.Item1 == "B")
                    {
                        score = score + 6;
                    }
                    else if (pair.Item1 == "C")
                    {
                        score = score + 3;
                    }
                }
            }

            Console.WriteLine(score);
        }

        public void Task2()
        {
            IList<Tuple<string, string>> pairs = ReadFile();
            int score = 0;
            foreach (Tuple<string, string> pair in pairs)
            {
                if (pair.Item1 == "A")
                {
                    if (pair.Item2 == "X")
                    {
                        score = score + 0;
                        score = score + 3;
                    }
                    else if (pair.Item2 == "Y")
                    {
                        score = score + 3;
                        score = score + 1;
                    }
                    else if (pair.Item2 == "Z")
                    {
                        score = score + 6;
                        score = score + 2;
                    }
                }
                else if (pair.Item1 == "B")
                {
                    if (pair.Item2 == "X")
                    {
                        score = score + 0;
                        score = score + 1;
                    }
                    else if (pair.Item2 == "Y")
                    {
                        score = score + 3;
                        score = score + 2;
                    }
                    else if (pair.Item2 == "Z")
                    {
                        score = score + 6;
                        score = score + 3;
                    }
                }
                else if (pair.Item1 == "C")
                {
                    if (pair.Item2 == "X")
                    {
                        score = score + 0;
                        score = score + 2;
                    }
                    else if (pair.Item2 == "Y")
                    {
                        score = score + 3;
                        score = score + 3;
                    }
                    else if (pair.Item2 == "Z")
                    {
                        score = score + 6;
                        score = score + 1;
                    }
                }
            }

            Console.WriteLine(score);
        }

        private IList<Tuple<string, string>> ReadFile()
        {
            IList<Tuple<string, string>> pairs = new List<Tuple<string, string>>();

            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day02.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    String [] pair = ln.Split(' ');
                    pairs.Add(Tuple.Create(pair[0], pair[1]));

                }
                file.Close();
            }
            return pairs;

        }
    }
}
