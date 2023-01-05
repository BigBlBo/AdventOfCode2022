using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day05
    {
        public void Task1()
        {
            InputParse inputParse = ReadFile();

            foreach(int[] move in inputParse.moves)
            {
                for(int index = 0; index < move[0]; index++)
                {
                    inputParse.stacksDic[move[2]].Push(inputParse.stacksDic[move[1]].Pop());
                }
            }

            List<int> keys = new List<int>();
            foreach (int key in inputParse.stacksDic.Keys)
            {
                keys.Add(key);
            }

            keys.Sort();

            foreach (int key in keys)
            {
                Console.Write(inputParse.stacksDic[key].Pop());
            }

            Console.WriteLine();
        }

        public void Task2()
        {
            InputParse inputParse = ReadFile();

            foreach (int[] move in inputParse.moves)
            {
                Stack<string> tempStack = new Stack<string>();
                for (int index = 0; index < move[0]; index++)
                {
                    tempStack.Push(inputParse.stacksDic[move[1]].Pop());
                }

                while (tempStack.Count > 0)
                {
                    inputParse.stacksDic[move[2]].Push(tempStack.Pop());
                }
            }

            List<int> keys = new List<int>();
            foreach (int key in inputParse.stacksDic.Keys)
            {
                keys.Add(key);
            }

            keys.Sort();

            foreach (int key in keys)
            {
                Console.Write(inputParse.stacksDic[key].Pop());
            }

            Console.WriteLine();
        }

        private InputParse ReadFile()
        {
            IList<int[]> moves = new List<int[]>();
            IDictionary<int, Stack<string>> stacksDic = new Dictionary<int, Stack<string>>();

            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day05.txt"))
            {
                string ln;
                List<string> stacks = new List<string>();

                while ((ln = file.ReadLine()) != null)
                {
                    if(!ln.StartsWith("["))
                    {
                        break;
                    }
                    stacks.Add(ln);
                }

                stacks.Reverse();

                char[] stacksNumbers = ln.ToCharArray();
                IDictionary<int, int> pozStacks = new Dictionary<int, int>();

                for (int index = 0; index < stacksNumbers.Length; index++)
                {
                    if(stacksNumbers[index] != ' ')
                    {
                        pozStacks[Int32.Parse(stacksNumbers[index].ToString())] = index;
                        stacksDic[Int32.Parse(stacksNumbers[index].ToString())] = new Stack<string>();
                    }
                }

                foreach(string stack in stacks)
                {
                    foreach(int key in pozStacks.Keys)
                    {
                        string eleme = stack.Substring(pozStacks[key], 1);
                        if(eleme != " ")
                        {
                            stacksDic[key].Push(eleme);
                        }
                    }
                }

                ln = file.ReadLine();

                while ((ln = file.ReadLine()) != null)
                {
                    ln = ln.Replace("move ", "");
                    ln = ln.Replace("from ", "");
                    ln = ln.Replace("to ", "");
                    string[] num =  ln.Split(' ');

                    int[] move = new int[3];

                    move[0] = Int32.Parse(num[0]);
                    move[1] = Int32.Parse(num[1]);
                    move[2] = Int32.Parse(num[2]);

                    moves.Add(move);
                }

                file.Close();
            }

            InputParse inputParse = new InputParse();
            inputParse.moves = moves;
            inputParse.stacksDic = stacksDic;
            return inputParse;

        }
    }

    class InputParse
    {
        public IList<int[]> moves { get; set; }
        public IDictionary<int, Stack<string>> stacksDic { get; set; }
    }
}
