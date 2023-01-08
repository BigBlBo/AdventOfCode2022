using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    internal class Day10
    {
        public void Task1()
        {
            IList<Instrucion> insList = ReadFile();
            int[] strengths = new int[6];
            int iteration = 0;
            int value = 1;
            foreach(Instrucion instrucion in insList)
            {
                if(instrucion.name == "noop")
                {
                    iteration++;
                    RecordValue(strengths, iteration, value);
                }
                else
                {
                    iteration++;
                    RecordValue(strengths, iteration, value);
                    iteration++;
                    RecordValue(strengths, iteration, value);
                    value += instrucion.Amount;
                }
            }

            Console.WriteLine(strengths[0] + strengths[1] + strengths[2] + strengths[3] + strengths[4] + strengths[5]);
        }

        public void Task2()
        {
            char[][] draw = new char[6][];
            for(int index = 0; index < 6; index++)
            {
                draw[index] = new char[40];
            }

            IList<Instrucion> insList = ReadFile();
            int iteration = 0;
            int value = 1;
            foreach (Instrucion instrucion in insList)
            {
                if (instrucion.name == "noop")
                {
                    DrawValue(draw, iteration, value);
                    iteration++;
                }
                else
                {
                    DrawValue(draw, iteration, value);
                    iteration++;
                    DrawValue(draw, iteration, value);
                    iteration++;
                    value += instrucion.Amount;
                }
            }

            for (int index = 0; index < 6; index++)
            {
                for (int indexNot = 0; indexNot < 40; indexNot++)
                {
                    Console.Write(draw[index][indexNot]);
                }
                    Console.WriteLine();
            }
        }

        private void DrawValue(char[][] draw, int iteration, int value)
        {
            if (iteration <= 239)
            {
                int line = iteration / 40;
                int poz = iteration - 40 * line;
                if (Math.Abs(value - poz) < 2) { draw[line][poz] = '#'; }
                else { draw[line][poz] = '.'; }
            }
        }

        private void RecordValue(int[] strengths, int iteration, int value)
        {
            switch (iteration)
            {
                case 20:
                    strengths[0] = value * 20;
                    break;
                case 60:
                    strengths[1] = value * 60;
                    break;
                case 100:
                    strengths[2] = value * 100;
                    break;
                case 140:
                    strengths[3] = value * 140;
                    break;
                case 180:
                    strengths[4] = value * 180;
                    break;
                case 220:
                    strengths[5] = value * 220;
                    break;
            }
        }

        private IList<Instrucion> ReadFile()
        {
            IList<Instrucion> insList = new List<Instrucion>();
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day10.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Instrucion instrucion = new Instrucion();
                    string[] lnSplit = ln.Split(' ');
                    instrucion.name = lnSplit[0];

                    if (lnSplit[0] == "addx")
                    {
                        instrucion.Amount = Int32.Parse(lnSplit[1]);
                    }

                    insList.Add(instrucion);
                }
                file.Close();
            }
            return insList;
        }
    }

    class Instrucion
    {
        public string name { get; set; }
        public int Amount { get; set; }
    }
}
