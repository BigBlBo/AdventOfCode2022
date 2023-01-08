using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode2022
{
    internal class Day09
    {
        public void Task1()
        {
            IList<Move> moves = ReadFile();

            Point head = new Point(0, 0);
            Point tail = new Point(0, 0);
            HashSet<Point> points = new HashSet<Point>();
            points.Add(tail);
            foreach (Move move in moves)
            {
                for (int index = 1; index <= move.Amount; index++)
                {
                    if (move.Dir == "L")
                    {
                        head.X--;
                    }
                    else if (move.Dir == "R")
                    {
                        head.X++;
                    }
                    else if (move.Dir == "D")
                    {
                        head.Y--;
                    }
                    else if (move.Dir == "U")
                    {
                        head.Y++;
                    }

                    if (MustMoveTailAlign(head, tail))
                    {
                        tail = MoveTailAlign(head, tail);
                    }

                    if (MustMoveTail(head, tail))
                    {
                        tail = MoveTail(head, tail);
                        points.Add(tail);
                    }
                }
            }

            Console.WriteLine(points.Count);
        }

        public void Task2()
        {
            IList<Move> moves = ReadFile();

            Point[] rope = new Point[10];
            for (int index = 0; index < 10; index++)
            {
                rope[index] = new Point(0, 0);
            }

            HashSet<Point> points = new HashSet<Point>();
            points.Add(new Point(0, 0));
            foreach (Move move in moves)
            {
                for (int index = 1; index <= move.Amount; index++)
                {
                    if (move.Dir == "L")
                    {
                        rope[0].X--;
                    }
                    else if (move.Dir == "R")
                    {
                        rope[0].X++;
                    }
                    else if (move.Dir == "D")
                    {
                        rope[0].Y--;
                    }
                    else if (move.Dir == "U")
                    {
                        rope[0].Y++;
                    }

                    for (int indexRope = 0; indexRope < 9; indexRope++)
                    {
                        if (MustMoveTailAlign(rope[indexRope], rope[indexRope + 1]))
                        {
                            rope[indexRope + 1] = MoveTailAlign(rope[indexRope], rope[indexRope + 1]);
                        }

                        if (MustMoveTail(rope[indexRope], rope[indexRope + 1]))
                        {
                            rope[indexRope + 1] = MoveTail(rope[indexRope], rope[indexRope + 1]);
                        }
                    }
                    points.Add(rope[9]);
                }
            }

            Console.WriteLine(points.Count);
        }

        private bool MustMoveTail(Point head, Point tail)
        {
            return (Math.Abs(head.X - tail.X) == 2 || Math.Abs(head.Y - tail.Y) == 2);
        }

        private bool MustMoveTailAlign(Point head, Point tail)
        {
            return (Math.Abs(head.X - tail.X) == 1 && Math.Abs(head.Y - tail.Y) == 2) ||
                    (Math.Abs(head.Y - tail.Y) == 1 && Math.Abs(head.X - tail.X) == 2);
        }

        private Point MoveTailAlign(Point head, Point tail)
        {
            if (head.X != tail.X && Math.Abs(head.X - tail.X) == 1)
            {
                if (head.X > tail.X) { tail.X++; }
                else { tail.X--; }
            }
            else if (head.Y != tail.Y && Math.Abs(head.Y - tail.Y) == 1)
            {
                if (head.Y > tail.Y) { tail.Y++; }
                else { tail.Y--; }
            }

            return tail;
        }

        private Point MoveTail(Point head, Point tail)
        {
            if (head.X != tail.X)
            {
                if (head.X > tail.X) { tail.X++; }
                else { tail.X--; }
            }
            else if (head.Y != tail.Y)
            {
                if (head.Y > tail.Y) { tail.Y++; }
                else { tail.Y--; }
            }

            return tail;
        }

        private IList<Move> ReadFile()
        {
            IList<Move> moves = new List<Move>();

            using (StreamReader file = new StreamReader(@"..\..\..\Inputs\Day09.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    string[] data = ln.Split(' ');

                    Move move = new Move { Amount = Int32.Parse(data[1]), Dir = data[0] };

                    moves.Add(move);
                }
                file.Close();
            }
            return moves;
        }
    }

    public class Move
    {
        public string Dir { get; set; }
        public int Amount { get; set; }
    }
}
