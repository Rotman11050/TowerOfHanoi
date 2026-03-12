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
                RecursiveSolution(diskNum, leftTower, rightTower, middleTower);
            }

            if (args[0] == "-Iterative")
            {
                IterativeSolution(diskNum,leftTower, rightTower, middleTower);
            }
        }

        static void RecursiveSolution(int diskNum, Stack<int> leftTower, Stack<int> rightTower, Stack<int> middleTower)
        {
            PrintTowers(leftTower, middleTower, rightTower, diskNum);
            Thread.Sleep(500);
            RecursiveHanoi(diskNum, leftTower, middleTower, rightTower, "Left tower", "Middle tower", "Right tower", leftTower, middleTower, rightTower, diskNum);
        }
        static void RecursiveHanoi(int n,  Stack<int> source,Stack<int> helper, Stack<int> destination,string sourceName,string helperName, string destinationName, Stack<int> leftTower, Stack<int> middleTower, Stack<int> rightTower,int diskNum)
        {
            if (n == 1)
            {
            MoveDisk(source, destination, sourceName, destinationName, leftTower, middleTower, rightTower, diskNum);
            return;
            }

            RecursiveHanoi(n - 1, source, destination, helper, sourceName, destinationName, helperName,
                           leftTower, middleTower, rightTower, diskNum);
            MoveDisk(source, destination, sourceName, destinationName, leftTower, middleTower, rightTower, diskNum);
            RecursiveHanoi(n - 1, helper, source, destination, helperName, sourceName, destinationName,
                           leftTower, middleTower, rightTower, diskNum);
        }
        static void IterativeSolution(int diskNum,Stack<int> leftTower, Stack<int> rightTower, Stack<int> middleTower)
        {
            string left = "Left tower";
            string middle = "Middle tower";
            string right = "Right tower";

            int totalMoves = (int)(Math.Pow(2, diskNum) - 1);

            if (diskNum <= 0)
            {
                Console.WriteLine("Invalid number of disks. Please enter a number bigger than 0.");
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

            for (int i = 1; i <= totalMoves; i++)
            {
                Console.WriteLine($"This is move number {i} of {totalMoves}");

                if (i % 3 == 1)
                {
                    MoveDisk(leftTower, rightTower, left, right , leftTower, middleTower, rightTower, diskNum);
                }
                else if (i % 3 == 2)
                {
                    MoveDisk(leftTower, middleTower, left, middle, leftTower, middleTower, rightTower, diskNum);
                }
                else if (i % 3 == 0)
                {
                    MoveDisk(middleTower, rightTower, middle, right, leftTower, middleTower, rightTower, diskNum);
                }
            }
        }

        static void MoveDisk(Stack<int> source, Stack<int> destination,
                             string sourceName, string destinationName,
                             Stack<int> leftTower, Stack<int> middleTower, Stack<int> rightTower,
                             int diskNum)
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
            PrintTowers(leftTower, middleTower, rightTower, diskNum);
            Thread.Sleep(500); 
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
    }
}