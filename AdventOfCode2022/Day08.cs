using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode2022
{
    internal class Day08
    {

        public void Task1()
        {
            Tree[][] forest = ReadFile();
            int count = 0;

            //count += 2 * forest.Length;
            //count += 2 * forest[0].Length;
            for (int index = 0; index < forest.Length; index++)
            {
                int maxHeight = int.MinValue;
                for (int indexNot = 0; indexNot < forest[index].Length; indexNot++)
                {
                    Tree tree = forest[index][indexNot];
                    if (maxHeight < tree.Height)
                    {
                        maxHeight = tree.Height;
                        if (!tree.seen)
                        {
                            tree.seen = true;
                            count++;
                        }
                    }
                }
            }

            for (int index = 0; index < forest.Length; index++)
            {
                int outherIndex = forest[index].Length - 1;
                int maxHeight = int.MinValue;
                for (int indexNot = outherIndex; indexNot >= 0; indexNot--)
                {
                    Tree tree = forest[index][indexNot];
                    if (maxHeight < tree.Height)
                    {
                        maxHeight = tree.Height;
                        if (!tree.seen)
                        {
                            tree.seen = true;
                            count++;
                        }
                    }
                }
            }

            for (int index = 0; index < forest.Length; index++)
            {
                int maxHeight = int.MinValue;
                for (int indexNot = 0; indexNot < forest[index].Length; indexNot++)
                {
                    Tree tree = forest[indexNot][index];
                    if (maxHeight < tree.Height)
                    {
                        maxHeight = tree.Height;
                        if (!tree.seen)
                        {
                            tree.seen = true;
                            count++;
                        }
                    }
                }
            }

            for (int index = 0; index < forest.Length; index++)
            {
                int outherIndex = forest[index].Length - 1;
                int maxHeight = int.MinValue;
                for (int indexNot = outherIndex; indexNot >= 0; indexNot--)
                {
                    Tree tree = forest[indexNot][index];
                    if (maxHeight < tree.Height)
                    {
                        maxHeight = tree.Height;
                        if (!tree.seen)
                        {
                            tree.seen = true;
                            count++;
                        }
                    }
                }
            }
            /*
            for (int index = 0; index < forest.Length; index++)
            {
                for (int indexNot = 0; indexNot < forest[index].Length; indexNot++)
                {
                    Tree tree = forest[index][indexNot];
                    Console.Write(tree.Height + " " + tree.seen + "  ");
                }
                Console.WriteLine();
            }
            */
            Console.WriteLine(count);
        }

        public void Task2()
        {
            Tree[][] forest = ReadFile();
            int count1 = 0; int count2 = 0; int count3 = 0; int count4 = 0;
            int maxTree = int.MinValue;


            for (int index = 0; index < forest.Length; index++)
            {
                for (int indexNot = 0; indexNot < forest[index].Length; indexNot++)
                {
                    Tree tree = forest[index][indexNot];
                    int height = tree.Height;

                    int maxHeightOfWay = int.MinValue;
                    for(int x = index + 1; x < forest.Length; x++)
                    {
                        if (/*forest[x][indexNot].Height <= height &&*/ forest[x][indexNot].Height >= maxHeightOfWay) 
                        {
                            count1++; 
                        }

                        if (forest[x][indexNot].Height >= height)
                        {
                            break;
                        }

                        if (forest[x][indexNot].Height > maxHeightOfWay)
                        {
                            maxHeightOfWay = forest[x][indexNot].Height;
                        }
                    }

                    maxHeightOfWay = int.MinValue;
                    for (int x = index - 1; x >= 0; x--)
                    {
                        if (/*forest[x][indexNot].Height <= height &&*/ forest[x][indexNot].Height >= maxHeightOfWay)
                        {
                            count2++;
                        }

                        if (forest[x][indexNot].Height >= height)
                        {
                            break;
                        }

                        if (forest[x][indexNot].Height > maxHeightOfWay)
                        {
                            maxHeightOfWay = forest[x][indexNot].Height;
                        }
                    }

                    maxHeightOfWay = int.MinValue;
                    for (int y = indexNot + 1; y < forest.Length; y++)
                    {
                        if (/*forest[index][y].Height <= height && */forest[index][y].Height >= maxHeightOfWay)
                        {
                            count3++;
                            
                        }

                        if (forest[index][y].Height >= height)
                        {
                            break;
                        }

                        if (forest[index][y].Height > maxHeightOfWay)
                        {
                            maxHeightOfWay = forest[index][y].Height;
                        }
                    }

                    maxHeightOfWay = int.MinValue;
                    for (int y = indexNot - 1; y >= 0; y--)
                    {
                        if (/*forest[index][y].Height <= height && */forest[index][y].Height >= maxHeightOfWay)
                        {
                            count4++;
                            
                        }

                        if (forest[index][y].Height >= height)
                        {
                            break;
                        }

                        if (forest[index][y].Height > maxHeightOfWay)
                        {
                            maxHeightOfWay = forest[index][y].Height;
                        }
                    }

                    if(maxTree < count1 * count2 * count3 * count4) { maxTree = count1 * count2 * count3 * count4; }
                    count1 = 0; count2 = 0; count3 = 0; count4 = 0;
                }
            }
            Console.WriteLine(maxTree);
        }

        private Tree[][] ReadFile()
        {
            int counter = 0;
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day08.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    counter++;
                }
                file.Close();
            }

            Tree[][] forest = new Tree[counter][];

            counter = 0;
            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day08.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Tree[] line = new Tree[ln.Length];
                    char[] lineChar = ln.ToCharArray();
                    for(int index = 0; index < lineChar.Length; index++)
                    {
                        Tree tree = new Tree { Height = Int32.Parse(lineChar[index].ToString()), seen = false };
                        line[index] = tree;
                    }
                    forest[counter] = line; 
                    counter++;
                }
                file.Close();
            }

            return forest;
        }
    }

    class Tree
    {
        public int Height { get; set; }
        public bool seen { get; set; } = false;
    }
}
