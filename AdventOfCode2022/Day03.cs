using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day03
    {
        public void Task1()
        {
            IList<Tuple<string, string>> pairs = ReadFile();
            int score = 0;
            foreach(Tuple<string, string> pair in pairs)
            {
                char[] items = pair.Item1.ToCharArray();
                string item2 = pair.Item2;
                for (int x = 0; x < items.Length; x++)
                {
                    if(item2.Contains(items[x]))
                    {
                        int value = (int)items[x];
                        if (value <= 91)
                        {
                            score += value - 38;
                        }
                        else
                        {
                            score += value - 96;
                        }
                    }
                    item2 = item2.Replace(items[x], ' ');
                }
            }

            Console.WriteLine(score);
        }

        public void Task2()
        {
            IList<Tuple<string, string>> pairs = ReadFile();
            int score = 0;
            for(int index = 0; index < pairs.Count; index = index + 3)
            {
                string pair = pairs[index].Item1 + pairs[index].Item2;
                char[] items = pair.ToCharArray();

                for (int x = 0; x < items.Length; x++)
                {
                    if ((pairs[index + 1].Item1 + pairs[index + 1].Item2).Contains(items[x]) &&
                        (pairs[index + 2].Item1 + pairs[index + 2].Item2).Contains(items[x]))
                    {
                        int value = (int)items[x];
                        if (value <= 91)
                        {
                            score += value - 38;
                        }
                        else
                        {
                            score += value - 96;
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(score);
        }

        private IList<Tuple<string, string>> ReadFile()
        {
            IList<Tuple<string, string>> pairs = new List<Tuple<string, string>>();

            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day03.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    int length = ln.Length;
                    pairs.Add(Tuple.Create(ln.Substring(0, length / 2), ln.Substring(length / 2, length / 2)));

                }
                file.Close();
            }
            return pairs;

        }
    }
}