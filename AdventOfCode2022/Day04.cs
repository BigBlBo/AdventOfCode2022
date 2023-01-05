using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day04
    {
        public void Task1()
        {
            IList<Tuple<int, int, int, int>> pairs = ReadFile();
            
            int score = 0;
            foreach (Tuple<int, int, int, int> pair in pairs)
            {
                if(pair.Item1<=pair.Item3 && pair.Item2 >= pair.Item4)
                {
                    score++;
                }
                else if (pair.Item1 >= pair.Item3 && pair.Item2 <= pair.Item4)
                {
                    score++;
                }
            }

            Console.WriteLine(score);
        }

        public void Task2()
        {
            IList<Tuple<int, int, int, int>> pairs = ReadFile();

            int score = pairs.Count;
            foreach (Tuple<int, int, int, int> pair in pairs)
            {
                if (pair.Item1 > pair.Item4 || pair.Item2 < pair.Item3)
                {
                    score--;
                }
                else if (pair.Item3 > pair.Item2 || pair.Item4 < pair.Item1)
                {
                    score--;
                }
            }

            Console.WriteLine(score);
        }

        private IList<Tuple<int, int, int, int>> ReadFile()
        {
            IList<Tuple<int, int, int, int>> pairs = new List<Tuple<int, int, int, int>>();

            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day04.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    string[] pair = ln.Split(',');
                    string[] range1 = pair[0].Split('-');
                    string[] range2 = pair[1].Split('-');

                    pairs.Add(Tuple.Create(Int32.Parse(range1[0]), Int32.Parse(range1[1]),
                        Int32.Parse(range2[0]), Int32.Parse(range2[1])));
                }
                file.Close();
            }
            return pairs;

        }
    }
}