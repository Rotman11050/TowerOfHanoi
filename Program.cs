using System;
using System.Collections.Generic;
using System.Threading;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> leftTower = new Stack<int>();
            Stack<int> middleTower = new Stack<int>();
            Stack<int> rightTower = new Stack<int>();
            
            int diskNum = int.Parse(args[1]);
            
            for (int i = diskNum; i > 0; i--)
            {
                leftTower.Push(i);
            }

            if (args[0] == "-Recursive")
            {
                RecursiveSolution();
            }

            if (args[0] == "-Iterative")
            {
                IterativeSolution(diskNum,leftTower, rightTower, middleTower);
            }
        }

        static void IterativeSolution(int diskNum,Stack<int> leftTower, Stack<int> rightTower, Stack<int> middleTower)
        {
            string left = "L";
            string middle = "M";
            string right = "R";

            int totalMoves = (int)(Math.Pow(2, diskNum) - 1);

            if (diskNum == 0 || diskNum > 10 || diskNum < 0)
            {
                Console.WriteLine("Invalid number of disks. Please enter a number between 1 and 10.");
                return;
            }

            if (diskNum%2 == 0)
            {
                string tempName = right;
                right = middle;
                middle = tempName;

                Stack<int> tempStack = rightTower;
                rightTower = middleTower;
                middleTower = tempStack;
            }

            PrintTowers(leftTower, middleTower, rightTower, diskNum);
            Thread.Sleep(500);

            for (int i = 1; i <= totalMoves; i++)
            {
                Console.WriteLine($"This is move number {i} of {totalMoves}");

                if (i % 3 == 1)
                {
                    MoveDisk(leftTower, rightTower, left, right);
                }
                else if (i % 3 == 2)
                {
                    MoveDisk(leftTower, middleTower, left, middle);
                }
                else if (i % 3 == 0)
                {
                    MoveDisk(middleTower, rightTower, middle, right);
                }

                PrintTowers(leftTower, middleTower, rightTower, diskNum);
                Thread.Sleep(500);
            }
        }

        static void MoveDisk(Stack<int> source, Stack<int> destination, string sourceName, string destinationName)
        {
            int s;
            if (source.Count == 0)
            {
                s = int.MaxValue;
            }
            else
            {
                s = source.Peek();
            }

            int d;
            if (destination.Count == 0)
            {                
                d = int.MaxValue;
            }
            else
            {
                d = destination.Peek();
            }

            if (s < d)
            {
                destination.Push(source.Pop());
                Console.WriteLine($"Move disk from {sourceName} to {destinationName}");
            }
            else
            {
                source.Push(destination.Pop());
                Console.WriteLine($"Move disk from {destinationName} to {sourceName}");
            }
                
        }

        static string DrawDisk(int disk, int maxDisk)
        {
            if (disk == 0)
            {
                int space = maxDisk - 1;
                return new string(' ', space) + "|" + new string(' ', space);
            }

            int width = 2 * disk - 1;
            int spaces = maxDisk - disk;

            return new string(' ', spaces) + new string('#', width) + new string(' ', spaces);
        }
        static void PrintTowers(Stack<int> left, Stack<int> middle, Stack<int> right, int diskNum)
        {
            int[] l = left.ToArray();
            int[] m = middle.ToArray();
            int[] r = right.ToArray();

            Array.Reverse(l);
            Array.Reverse(m);
            Array.Reverse(r);

            for (int i = diskNum - 1; i >= 0; i--)
            {
                int ld = i < l.Length ? l[i] : 0;
                int md = i < m.Length ? m[i] : 0;
                int rd = i < r.Length ? r[i] : 0;

                Console.WriteLine($"{DrawDisk(ld, diskNum)}   {DrawDisk(md, diskNum)}   {DrawDisk(rd, diskNum)}");
            }

            Console.WriteLine(new string('-', diskNum * 6));
            Console.WriteLine("   L" + new string(' ', diskNum * 2) + "M" + new string(' ', diskNum * 2) + "R");
            Console.WriteLine();
        }

        static void RecursiveSolution()
        {
        }
    }
}