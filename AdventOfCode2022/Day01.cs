using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day01
    {
        public void Task1()
        {
            IDictionary<int, IList<int>> calDic = ReadFile();
            int maxCal = 0;
            foreach(int key in calDic.Keys)
            {
                int sum = 0;
                foreach (int cal in calDic[key])
                {
                    sum += cal;
                }

                if(sum > maxCal)
                {
                    maxCal = sum;
                }
            }

            Console.WriteLine(maxCal);
        }

        public void Task2()
        {
            IDictionary<int, IList<int>> calDic = ReadFile();
            List<int> calSums = new List<int>();

            foreach (int key in calDic.Keys)
            {
                int sum = 0;
                foreach (int cal in calDic[key])
                {
                    sum += cal;
                }

                calSums.Add(sum);
            }

            calSums.Sort();
            calSums.Reverse();

            Console.WriteLine(calSums[0] + calSums[1] + calSums[2]);
        }

        private IDictionary<int, IList<int>> ReadFile()
        {
            IDictionary<int, IList<int>> calDic = new Dictionary<int, IList<int>>();
            IList<int> calList = new List<int>();
            int counter = 1;
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day01.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if(ln.Trim() == "")
                    {
                        calDic[counter] = calList;
                        counter++;
                        calList = new List<int>();
                        continue;
                    }

                    calList.Add(Int32.Parse(ln));
                }
                file.Close();
            }
            return calDic;
        }
    }
}
