using System;
using System.Collections.Generic;
using System.Text;

namespace AgentsSimulationProject
{
    public class SimulationSystem
    {
        private Board board;
        private int turnsToChangeAmbient;
        private Robot robot;
        private int timesFired;
        private int timesWon;
        private float currentGarbagePorcent;
        private int width;
        private int height;
        private int childrenCount;
        private float garbagePercent;
        private float objectsPercent;
        private List<float> garbagePercents;
        public SimulationSystem(int width, int height, int childrenCount, int garbagePercent, float objectsPercent, int turnsToChangeAmbient, Robot robot)
        {
            robot.IsCarryingBaby = false;
            robot.BoardPosition = new Tuple<int, int>(-1, -1);
            board = new Board(height, width, childrenCount, garbagePercent, objectsPercent, robot);
            this.turnsToChangeAmbient = turnsToChangeAmbient;
            this.robot = robot;
            this.width = width;
            this.height = height;
            this.childrenCount = childrenCount;
            this.garbagePercent = garbagePercent;
            this.objectsPercent = objectsPercent;
            this.garbagePercents = new List<float>();
        }
        public Tuple<int, int, float> SimulateTimes(int times)
        {
            for (int i = 1; i <= times; i++)
            {
                Simulate();
                robot.IsCarryingBaby = false;
                robot.BoardPosition = new Tuple<int, int>(-1, -1);
                board = new Board(height, width, childrenCount, garbagePercent, objectsPercent, robot);
            }
            for (int i = 0; i < garbagePercents.Count; i++)
            {
                currentGarbagePorcent = currentGarbagePorcent + garbagePercents[i];
            }
            currentGarbagePorcent = currentGarbagePorcent / garbagePercents.Count;
            return new Tuple<int, int, float>(timesWon, timesFired, currentGarbagePorcent);
        }

        private void Simulate()
        {
            int turnCount = 1;
            while (true)
            {
                //Console.WriteLine("Turno: " + turnCount.ToString());
                if (turnCount > turnsToChangeAmbient*100)
                {
                    garbagePercents.Add(board.CurrentGarbagePercent);
                    return;
                }
                if(EndCondition())
                {
                    return;
                }
                if (robot.IsCarryingBaby)
                {
                    var moveTo = robot.NextMove(board);
                    if (moveTo.Item1 != -1)
                    {
                        board.MoveRobot(robot.BoardPosition.Item1, robot.BoardPosition.Item2, moveTo.Item1, moveTo.Item2);
                        robot.BoardPosition = new Tuple<int, int>(moveTo.Item1, moveTo.Item2);
                        //PrintBoard(board);
                    }
                    if (robot.IsCarryingBaby)
                    {
                        moveTo = robot.NextMove(board);
                        if (moveTo.Item1 != -1)
                        {
                            board.MoveRobot(robot.BoardPosition.Item1, robot.BoardPosition.Item2, moveTo.Item1, moveTo.Item2);
                            robot.BoardPosition = new Tuple<int, int>(moveTo.Item1, moveTo.Item2);
                            //PrintBoard(board);
                        }
                    }
                }
                else
                {
                    var moveTo = robot.NextMove(board);
                    if (moveTo.Item1 != -1)
                    {
                        board.MoveRobot(robot.BoardPosition.Item1, robot.BoardPosition.Item2, moveTo.Item1, moveTo.Item2);
                        robot.BoardPosition = new Tuple<int, int>(moveTo.Item1, moveTo.Item2);
                        //PrintBoard(board);
                    }
                }
                board.PerformTurn(turnCount%turnsToChangeAmbient == 0);
                turnCount++;
            }
        }

        private void PrintBoard(Board board)
        {
            for (int i = 0; i < board.height; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("    0    1    2    3    4  ");
                }
                for (int j = 0; j < board.width; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("{0}:", i);
                    }
                    if (board.GetBoard[j,i] == null)
                    {
                        Console.Write("     ");
                    }
                    else
                    {
                        if (board.GetBoard[j, i].Item1 == 0)
                        {
                            Console.Write("  C  ");
                        }
                        if (board.GetBoard[j, i].Item1 == 1)
                        {
                            Console.Write("  N  ");
                        }
                        if (board.GetBoard[j, i].Item1 == 2)
                        {
                            Console.Write("  B  ");
                        }
                        if (board.GetBoard[j, i].Item1 == 3)
                        {
                            Console.Write("  Ö  ");
                        }
                        if (board.GetBoard[j, i].Item1 == 4)
                        {
                            Console.Write("  ×  ");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }

        private bool EndCondition()
        {
            if (board.CurrentGarbagePercent > 60)
            {
                timesFired++;
                garbagePercents.Add(board.CurrentGarbagePercent);
                return true;
            }
            if (!board.IsChildrenLeft && board.CurrentGarbagePercent == 0)
            {
                timesWon++;
                garbagePercents.Add(board.CurrentGarbagePercent);
                return true;
            }
            return false;
        }
    }
}
