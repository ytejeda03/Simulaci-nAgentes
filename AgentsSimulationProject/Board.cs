using System;
using System.Collections.Generic;
using System.Text;

namespace AgentsSimulationProject
{
    public class Board
    {
        private int garbageCount;
        private int childrenCount;
        private int childrenLeft;
        private int cribCount;
        public int width { get; private set; }
        public int height { get; private set; }
        private Random randomGenerator;
        private List<Baby> babies;
        private List<Crib> cribs;
        private List<Object> objects;
        private Robot robot;
        public Tuple<int, int>[,] GetBoard { get { return board; } }
        public bool IsChildrenLeft { get { return childrenLeft > 0; } }
        public int CurrentGarbagePercent { get; private set; }
        private Tuple<int, int>[,] board;
        public Board(int width, int height, int childrenCount, float garbagePercent, float objectsPercent, Robot robot)
        {
            board = new Tuple<int, int>[width, height];
            this.width = width;
            this.height = height;
            this.childrenCount = childrenCount;
            this.childrenLeft = childrenCount;
            this.cribCount = childrenCount;
            randomGenerator = new Random();
            this.robot = robot;
            InitializeCribsAndBabies();
            InitializeObjects(objectsPercent, garbagePercent);
            ChangeAmbient();
        }

        private void InitializeCribsAndBabies()
        {
            cribs = new List<Crib>();
            for (int i = 0; i < cribCount; i++)
            {
                cribs.Add(new Crib());
            }
            babies = new List<Baby>();
            for (int i = 0; i < childrenCount; i++)
            {
                babies.Add(new Baby());
            }
        }

        private void InitializeObjects(float objectsPercent, float garbagePercent)
        {
            int objectsCount = Convert.ToInt32(objectsPercent * (width * height) / 100);
            objects = new List<Object>();
            for (int i = 0; i < objectsCount; i++)
            {
                objects.Add(new Object());
            }
            garbageCount = Convert.ToInt32(garbagePercent * (width * height) / 100);
        }

        private void ChangeAmbient()
        {
            board = new Tuple<int, int>[width, height];
            while(true)
            {
                if (PlaceCribs())
                {
                    break;
                }
            }
            for (int i = 0; i < cribs.Count; i++)
            {
                board[cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2] = new Tuple<int, int>(0, i);
            }
            PlaceBabies();
            PlaceObjects();
            PlaceGarbage();
            PlaceRobot();
        }

        private bool PlaceCribs()
        {
            Tuple<int, int> startCribPos = new Tuple<int, int>(randomGenerator.Next(0, width), randomGenerator.Next(0, height));
            cribs[0].BoardPosition = new Tuple<int, int>(startCribPos.Item1, startCribPos.Item2);
            for (int i = 0; i < cribCount-1; i++)
            {
                if (IsRightInsideBound(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2) & IsFree(cribs[i].BoardPosition.Item1+1, cribs[i].BoardPosition.Item2, i))
                {
                    cribs[i+1].BoardPosition = new Tuple<int, int>(cribs[i].BoardPosition.Item1 + 1, cribs[i].BoardPosition.Item2);
                    continue;
                }
                if (IsDownInsideBound(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2) & IsFree(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2 + 1, i))
                {
                    cribs[i+1].BoardPosition = new Tuple<int, int>(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2 + 1);
                    continue;
                }
                if (IsLeftInsideBound(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2) & IsFree(cribs[i].BoardPosition.Item1-1, cribs[i].BoardPosition.Item2, i))
                {
                    cribs[i+1].BoardPosition = new Tuple<int, int>(cribs[i].BoardPosition.Item1 - 1, cribs[i].BoardPosition.Item2);
                    continue;
                }
                if (IsUpInsideBound(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2) & IsFree(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2-1, i))
                {
                    cribs[i+1].BoardPosition = new Tuple<int, int>(cribs[i].BoardPosition.Item1, cribs[i].BoardPosition.Item2 - 1);
                    continue;
                }
                return false;
            }
            return true;
        }

        private void PlaceBabies()
        {
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].InCrib || babies[i].InRobot)
                {
                    continue;
                }
                while (true)
                {
                    Tuple<int, int> babyPos = new Tuple<int, int>(randomGenerator.Next(0, width), randomGenerator.Next(0, height));
                    if (board[babyPos.Item1, babyPos.Item2] == null)
                    {
                        board[babyPos.Item1, babyPos.Item2] = new Tuple<int, int>(1, i);
                        babies[i].BoardPosition = new Tuple<int, int>(babyPos.Item1, babyPos.Item2);
                        break;
                    }
                }
            }
        }
        private void PlaceObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                while (true)
                {
                    Tuple<int, int> objectPos = new Tuple<int, int>(randomGenerator.Next(0, width), randomGenerator.Next(0, height));
                    if (board[objectPos.Item1, objectPos.Item2] == null)
                    {
                        board[objectPos.Item1, objectPos.Item2] = new Tuple<int, int>(2, i);
                        objects[i].BoardPosition = new Tuple<int, int>(objectPos.Item1, objectPos.Item2);
                        break;
                    }
                }
            }
        }

        private void PlaceGarbage()
        {
            for (int i = 0; i < garbageCount; i++)
            {
                while (true)
                {
                    Tuple<int, int> objectPos = new Tuple<int, int>(randomGenerator.Next(0, width), randomGenerator.Next(0, height));
                    if (board[objectPos.Item1, objectPos.Item2] == null)
                    {
                        board[objectPos.Item1, objectPos.Item2] = new Tuple<int, int>(4, 0);
                        break;
                    }
                }
            }
        }

        private void PlaceRobot()
        {
            while (true)
            {
                Tuple<int, int> robotPos = new Tuple<int, int>(randomGenerator.Next(0, width), randomGenerator.Next(0, height));
                if (board[robotPos.Item1, robotPos.Item2] == null)
                {
                    board[robotPos.Item1, robotPos.Item2] = new Tuple<int, int>(3, 0);
                    robot.BoardPosition = new Tuple<int, int>(robotPos.Item1, robotPos.Item2);
                    break;
                }
            }
        }

        private bool IsFree(int x, int y, int i)
        {
            for (int j = 0; j <= i; j++)
            {
                if (cribs[i].BoardPosition.Item1 == x & cribs[i].BoardPosition.Item2 == y)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsRightInsideBound(int x, int y)
        {
            if (((x + 1) < width & (x + 1) >= 0) & (y < height & y >= 0))
            {
                return true;
            }
            return false;
        }
        private bool IsLeftInsideBound(int x, int y)
        {
            if (((x - 1) < width & (x - 1) >= 0) & (y < height & y >= 0))
            {
                return true;
            }
            return false;
        }
        private bool IsDownInsideBound(int x, int y)
        {
            if ((x < width & x >= 0) & (((y + 1) < height) & ((y + 1) >= 0)))
            {
                return true;
            }
            return false;
        }
        private bool IsUpInsideBound(int x, int y)
        {
            if ((x < width & x >= 0) & (((y - 1) < height) & ((y - 1) >= 0)))
            {
                return true;
            }
            return false;
        }

        public void MoveRobot(int lastX, int lastY, int x, int y)
        {
            if (board[lastX, lastY] != null && board[lastX, lastY].Item1 == 0)
            {

            }
            else
            {
                board[lastX, lastY] = null;
            }
            if (board[x, y] != null && board[x, y].Item1 == 4)
            {
                if (robot.IsCarryingBaby)
                {
                    return;
                }
                garbageCount--;
            }
            if (board[x, y] != null && board[x, y].Item1 == 1)
            {
                babies[board[x, y].Item2].InRobot = true;
                robot.IsCarryingBaby = true;
            }
            if (board[x, y] != null && board[x, y].Item1 == 0)
            {
                foreach (var item in babies)
                {
                    if (item.InRobot)
                    {
                        item.InRobot = false;
                        item.InCrib = true;
                        cribs[board[x, y].Item2].IsFilled = true;
                        robot.IsCarryingBaby = false;
                        childrenLeft--;
                        return;
                    }
                }
            }
            board[x, y] = new Tuple<int, int>(3, 0);
        }

        public void PerformTurn(bool changeAmbient)
        {
            if (changeAmbient)
            {
                ChangeAmbient();
            }
            else
            {
                MoveBabies();    
            }
            if (garbageCount == 0)
            {
                CurrentGarbagePercent = 0;
            }
            else
            {
                CurrentGarbagePercent = (garbageCount * 100) / ((width * height) - garbageCount - childrenLeft - objects.Count - childrenCount - 1);
            }
        }

        private void MoveBabies()
        {
            for (int i = 0; i < babies.Count; i++)
            {
                int movPossib = randomGenerator.Next(0, 4);
                if (movPossib == 0)
                {
                    if (!babies[i].InCrib & !babies[i].InRobot)
                    {
                        MoveBaby(i);
                    }
                }
                else
                {
                    continue;
                }
            };
        }

        private void MoveBaby(int i)
        {
            int babyArounds = BabyArounds(i).Item1;
            int x = BabyArounds(i).Item2;
            int y = BabyArounds(i).Item3;
            if (x == -1 || y == -1)
            {
                return;
            }
            board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2] = null;
            board[x, y] = new Tuple<int, int>(1, i);
            var garbagePositions = PutGarbage(i);
            babies[i].BoardPosition = new Tuple<int, int>(x, y);
            for (int j = 0; j < garbagePositions.Count; j++)
            {
                if (babyArounds <= 1 && j > 0)
                {
                    break;
                }
                if (babyArounds == 2 && j > 2)
                {
                    break;
                }
                if (babyArounds > 2 && j > 5)
                {
                    break;
                }
                int putGarbagePossibility = randomGenerator.Next(0, 4);
                if (putGarbagePossibility == 0)
                {
                    try
                    {
                        garbageCount++;
                        board[garbagePositions[j].Item1, garbagePositions[j].Item2] = new Tuple<int, int>(4, 0);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private Tuple<int, int, int> BabyArounds(int i)
        {
            int count = 0;
            int x = -1;
            int y = -1;
            if (InBound(babies[i].BoardPosition.Item1+1, babies[i].BoardPosition.Item2))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2] == null)
                {
                    x = babies[i].BoardPosition.Item1 + 1;
                    y = babies[i].BoardPosition.Item2;
                }
                else if(board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1+1, babies[i].BoardPosition.Item2+1))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2+1] == null)
                {
                    x = babies[i].BoardPosition.Item1 + 1;
                    y = babies[i].BoardPosition.Item2+1;
                }
                else if(board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 + 1].Item1 == 1)
                {

                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2+1))
            {
                if (board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2+1] == null)
                {
                    x = babies[i].BoardPosition.Item1;
                    y = babies[i].BoardPosition.Item2+1;
                }
                else if(board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 + 1].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1-1, babies[i].BoardPosition.Item2+1))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2+1] == null)
                {
                    x = babies[i].BoardPosition.Item1 - 1;
                    y = babies[i].BoardPosition.Item2+1;
                }
                else if(board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 + 1].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1-1, babies[i].BoardPosition.Item2))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2] == null)
                {
                    x = babies[i].BoardPosition.Item1 - 1;
                    y = babies[i].BoardPosition.Item2;
                }
                else if(board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1-1, babies[i].BoardPosition.Item2-1))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2-1] == null)
                {
                    x = babies[i].BoardPosition.Item1 - 1;
                    y = babies[i].BoardPosition.Item2-1;
                }
                else if(board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 - 1].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2-1))
            {
                if (board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2-1] == null)
                {
                    x = babies[i].BoardPosition.Item1;
                    y = babies[i].BoardPosition.Item2-1;
                }
                else if(board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 - 1].Item1 == 1)
                {
                    count += 1;
                }
            }
            if (InBound(babies[i].BoardPosition.Item1+1, babies[i].BoardPosition.Item2-1))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2-1] == null)
                {
                    x = babies[i].BoardPosition.Item1 + 1;
                    y = babies[i].BoardPosition.Item2-1;
                }
                else if(board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 - 1].Item1 == 1)
                {
                    count += 1;
                }
            }
            return new Tuple<int, int, int>(count, x, y);
        }

        private List<Tuple<int, int>> PutGarbage(int i)
        {
            List<Tuple<int, int>> garbagePositions = new List<Tuple<int, int>>();
            garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2));
            if (InBound(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 + 1))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 + 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2+1));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 + 1))
            {
                if (board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 + 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2+1));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 + 1))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 + 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1-1, babies[i].BoardPosition.Item2+1));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 - 1))
            {
                if (board[babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2 - 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1 - 1, babies[i].BoardPosition.Item2-1));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 - 1))
            {
                if (board[babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2 - 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1, babies[i].BoardPosition.Item2-1));
                }
            }
            if (InBound(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 - 1))
            {
                if (board[babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2 - 1] == null)
                {
                    garbagePositions.Add(new Tuple<int, int>(babies[i].BoardPosition.Item1 + 1, babies[i].BoardPosition.Item2-1));
                }
            }
            return garbagePositions;
        }

        private bool InBound(int x, int y)
        {
            return ((x >= 0 & x < width) & (y >= 0 & y < height));
        }

        public bool IsCribFilled(int i)
        {
            return cribs[i].IsFilled;
        }
    }
}
