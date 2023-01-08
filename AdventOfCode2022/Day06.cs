using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    internal class Day06
    {
        public void Task1()
        {
            string signal = ReadFile();
            int count = 0;
            char[] signalInChar = signal.ToCharArray();
            
            for(int index = 3; index < signalInChar.Length; index++)
            {
                if (signalInChar[index - 3] != signalInChar[index - 2] &&
                    signalInChar[index - 3] != signalInChar[index - 1] && signalInChar[index - 2] != signalInChar[index - 1] &&
                    signalInChar[index - 3] != signalInChar[index] && signalInChar[index - 2] != signalInChar[index] && signalInChar[index - 1] != signalInChar[index])
                {
                    count = index + 1; break;
                }
            }

            Console.WriteLine(count);
        }

        public void Task2()
        {
            string signal = ReadFile();
            int count = 0;
            char[] signalInChar = signal.ToCharArray();

            for (int index = 0; index < signalInChar.Length; index++)
            {
                HashSet<int> distinctCharacters = new HashSet<int>();
                for (int indexIn = index; indexIn < index + 14; indexIn++)
                {
                    int value = (int)signalInChar[indexIn];
                    if (distinctCharacters.Contains(value))
                    {
                        break;
                    }
                    distinctCharacters.Add(value);
                }
                if(distinctCharacters.Count == 14)
                {
                    count = index + 14;
                    break;
                }
            }

            Console.WriteLine(count);
        }

        private string ReadFile()
        {
            string ln;
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day06.txt"))
            {

                ln = file.ReadLine();
                file.Close();
            }
            return ln;
        }
    }
}