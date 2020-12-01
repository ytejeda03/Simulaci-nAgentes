using System;
using System.Collections.Generic;
using System.Text;

namespace AgentsSimulationProject
{
    public class Robot
    {
        public bool IsCarryingBaby { get; set; }
        public Tuple<int, int> BoardPosition { get; set; }
        public Robot()
        {
            IsCarryingBaby = false;
        }

        public virtual Tuple<int, int> NextMove(Board board)
        {
            int x = -1;
            int y = -1;
            if (BoardPosition == null)
            {
                return new Tuple<int, int>(x, y);
            }
            if (InBound(BoardPosition.Item1 + 1, BoardPosition.Item2, board))
            {
                if (board.GetBoard[BoardPosition.Item1 + 1, BoardPosition.Item2] == null)
                {
                    x = BoardPosition.Item1 + 1;
                    y = BoardPosition.Item2;
                }
            }
            if (InBound(BoardPosition.Item1 + 1, BoardPosition.Item2 + 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1 + 1, BoardPosition.Item2 + 1] == null)
                {
                    x = BoardPosition.Item1 + 1;
                    y = BoardPosition.Item2 + 1;
                }
            }
            if (InBound(BoardPosition.Item1, BoardPosition.Item2 + 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2 + 1] == null)
                {
                    x = BoardPosition.Item1;
                    y = BoardPosition.Item2 + 1;
                }
            }
            if (InBound(BoardPosition.Item1 - 1, BoardPosition.Item2 + 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2 + 1] == null)
                {
                    x = BoardPosition.Item1 - 1;
                    y = BoardPosition.Item2 + 1;
                }
            }
            if (InBound(BoardPosition.Item1 - 1, BoardPosition.Item2, board))
            {
                if (board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2] == null)
                {
                    x = BoardPosition.Item1 - 1;
                    y = BoardPosition.Item2;
                }
            }
            if (InBound(BoardPosition.Item1 - 1, BoardPosition.Item2 - 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2 - 1] == null)
                {
                    x = BoardPosition.Item1 - 1;
                    y = BoardPosition.Item2 - 1;
                }
            }
            if (InBound(BoardPosition.Item1, BoardPosition.Item2 - 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2 - 1] == null)
                {
                    x = BoardPosition.Item1;
                    y = BoardPosition.Item2 - 1;
                }
            }
            if (InBound(BoardPosition.Item1 + 1, BoardPosition.Item2 - 1, board))
            {
                if (board.GetBoard[BoardPosition.Item1 + 1, BoardPosition.Item2 - 1] == null)
                {
                    x = BoardPosition.Item1 + 1;
                    y = BoardPosition.Item2 - 1;
                }
            }
            return new Tuple<int, int>(x, y);

        }

        private bool InBound(int x, int y, Board board)
        {
            if (x < 0)
            {
                return false;
            }
            if (x>= board.width)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (y >= board.height)
            {
                return false;
            }
            return true;
        }

        protected Tuple<int, int> BFS(Board board, int target)
        {
            List<Tuple<int, int , int>> path = new List<Tuple<int, int, int>>();
            bool[,] AlreadyPassed = new bool[board.width, board.height];
            AlreadyPassed[BoardPosition.Item1, BoardPosition.Item2] = true;
            int cantNodes = 0;
            if (InBound(BoardPosition.Item1+1, BoardPosition.Item2, board))
            {
                if (board.GetBoard[BoardPosition.Item1+1, BoardPosition.Item2] == null)
                {
                    cantNodes++;
                    path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1+1, BoardPosition.Item2));
                }
                else
                {
                    if (board.GetBoard[BoardPosition.Item1 + 1, BoardPosition.Item2].Item1 == target)
                    {
                        if (target == 0)
                        {
                            if (!board.IsCribFilled(board.GetBoard[BoardPosition.Item1 + 1, BoardPosition.Item2].Item2))
                            {
                                return new Tuple<int, int>(BoardPosition.Item1 + 1, BoardPosition.Item2);
                            }
                            else
                            {
                                AlreadyPassed[BoardPosition.Item1 + 1, BoardPosition.Item2] = true;
                            }
                        }
                        else
                        {
                            return new Tuple<int, int>(BoardPosition.Item1 + 1, BoardPosition.Item2);
                        }
                    }
                    else
                    {
                        if (target == 4)
                        {
                            cantNodes++;
                            path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1 + 1, BoardPosition.Item2));
                        }
                    }
                }
                AlreadyPassed[BoardPosition.Item1 + 1, BoardPosition.Item2] = true;
            }
            if (InBound(BoardPosition.Item1, BoardPosition.Item2+1, board))
            {
                if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2+1] == null)
                {
                    cantNodes++;
                    path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1, BoardPosition.Item2+1));
                }
                else
                {
                    if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2+1].Item1 == target)
                    {
                        if (target == 0)
                        {
                            if (!board.IsCribFilled(board.GetBoard[BoardPosition.Item1, BoardPosition.Item2+1].Item2))
                            {
                                return new Tuple<int, int>(BoardPosition.Item1, BoardPosition.Item2+1);
                            }
                            else
                            {
                                AlreadyPassed[BoardPosition.Item1, BoardPosition.Item2+1] = true;
                            }
                        }
                        else
                        {
                            return new Tuple<int, int>(BoardPosition.Item1, BoardPosition.Item2+1);
                        }
                    }
                    else
                    {
                        if (target == 4)
                        {
                            cantNodes++;
                            path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1, BoardPosition.Item2+1));
                        }
                    }
                }
                AlreadyPassed[BoardPosition.Item1, BoardPosition.Item2+1] = true;
            }
            if (InBound(BoardPosition.Item1 - 1, BoardPosition.Item2, board))
            {
                if (board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2] == null)
                {
                    cantNodes++;
                    path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1 - 1, BoardPosition.Item2));
                }
                else
                {
                    if (board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2].Item1 == target)
                    {
                        if (target == 0)
                        {
                            if (!board.IsCribFilled(board.GetBoard[BoardPosition.Item1 - 1, BoardPosition.Item2].Item2))
                            {
                                return new Tuple<int, int>(BoardPosition.Item1 - 1, BoardPosition.Item2);
                            }
                            else
                            {
                                AlreadyPassed[BoardPosition.Item1 - 1, BoardPosition.Item2] = true;
                            }
                        }
                        else
                        {
                            return new Tuple<int, int>(BoardPosition.Item1 - 1, BoardPosition.Item2);
                        }
                    }
                    else
                    {
                        if (target == 4)
                        {
                            cantNodes++;
                            path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1 - 1, BoardPosition.Item2));
                        }
                    }
                }
                AlreadyPassed[BoardPosition.Item1 - 1, BoardPosition.Item2] = true;
            }
            if (InBound(BoardPosition.Item1, BoardPosition.Item2-1, board))
            {
                if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2-1] == null)
                {
                    cantNodes++;
                    path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1, BoardPosition.Item2-1));
                }
                else
                {
                    if (board.GetBoard[BoardPosition.Item1, BoardPosition.Item2-1].Item1 == target)
                    {
                        if (target == 0)
                        {
                            if (!board.IsCribFilled(board.GetBoard[BoardPosition.Item1, BoardPosition.Item2-1].Item2))
                            {
                                return new Tuple<int, int>(BoardPosition.Item1, BoardPosition.Item2-1);
                            }
                            else
                            {
                                AlreadyPassed[BoardPosition.Item1, BoardPosition.Item2-1] = true;
                            }
                        }
                        else
                        {
                            return new Tuple<int, int>(BoardPosition.Item1, BoardPosition.Item2-1);
                        }
                    }
                    else
                    {
                        if (target == 4)
                        {
                            cantNodes++;
                            path.Add(new Tuple<int, int, int>(-1, BoardPosition.Item1, BoardPosition.Item2-1));
                        }
                    }
                }
                AlreadyPassed[BoardPosition.Item1, BoardPosition.Item2-1] = true;
            }
            for (int i = 0; i < cantNodes; i++)
            {
                if (InBound(path[i].Item2 + 1, path[i].Item3, board) && !AlreadyPassed[path[i].Item2 + 1, path[i].Item3])
                {
                    if (board.GetBoard[path[i].Item2 + 1, path[i].Item3] == null)
                    {
                        cantNodes++;
                        path.Add(new Tuple<int, int, int>(i, path[i].Item2 + 1, path[i].Item3));
                    }
                    else
                    {
                        if (board.GetBoard[path[i].Item2 + 1, path[i].Item3].Item1 == target)
                        {
                            if (target == 0)
                            {
                                if (!board.IsCribFilled(board.GetBoard[path[i].Item2 + 1, path[i].Item3].Item2))
                                {
                                    cantNodes++;
                                    path.Add(new Tuple<int, int, int>(i, path[i].Item2 + 1, path[i].Item3));
                                    break;
                                }
                                else
                                {
                                    AlreadyPassed[path[i].Item2 + 1, path[i].Item3] = true;
                                }
                            }
                            else
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2 + 1, path[i].Item3));
                                break;
                            }
                        }
                        else
                        {
                            if (target == 4)
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2 + 1, path[i].Item3));
                            }
                        }
                    }
                    AlreadyPassed[path[i].Item2 + 1, path[i].Item3] = true;
                }
                if (InBound(path[i].Item2, path[i].Item3 + 1, board) && !AlreadyPassed[path[i].Item2, path[i].Item3 + 1])
                {
                    if (board.GetBoard[path[i].Item2, path[i].Item3 + 1] == null)
                    {
                        cantNodes++;
                        path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 + 1));
                    }
                    else
                    {
                        if (board.GetBoard[path[i].Item2, path[i].Item3 + 1].Item1 == target)
                        {
                            if (target == 0)
                            {
                                if (!board.IsCribFilled(board.GetBoard[path[i].Item2, path[i].Item3 + 1].Item2))
                                {
                                    cantNodes++;
                                    path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 + 1));
                                    break;
                                }
                                else
                                {
                                    AlreadyPassed[path[i].Item2, path[i].Item3 + 1] = true;
                                }
                            }
                            else
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 + 1));
                                break;
                            }
                        }
                        else
                        {
                            if (target == 4)
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 + 1));
                            }
                        }
                    }
                    AlreadyPassed[path[i].Item2, path[i].Item3 + 1] = true;
                }
                if (InBound(path[i].Item2 - 1, path[i].Item3, board) && !AlreadyPassed[path[i].Item2 - 1, path[i].Item3])
                {
                    if (board.GetBoard[path[i].Item2 - 1, path[i].Item3] == null)
                    {
                        cantNodes++;
                        path.Add(new Tuple<int, int, int>(i, path[i].Item2 - 1, path[i].Item3));
                    }
                    else
                    {
                        if (board.GetBoard[path[i].Item2 - 1, path[i].Item3].Item1 == target)
                        {
                            if (target == 0)
                            {
                                if (!board.IsCribFilled(board.GetBoard[path[i].Item2 - 1, path[i].Item3].Item2))
                                {
                                    cantNodes++;
                                    path.Add(new Tuple<int, int, int>(i, path[i].Item2 - 1, path[i].Item3));
                                    break;
                                }
                                else
                                {
                                    AlreadyPassed[path[i].Item2 - 1, path[i].Item3] = true;
                                }
                            }
                            else
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2 - 1, path[i].Item3));
                                break;
                            }
                        }
                        else
                        {
                            if (target == 4)
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2 - 1, path[i].Item3));
                            }
                        }
                    }
                    AlreadyPassed[path[i].Item2 - 1, path[i].Item3] = true;
                }
                if (InBound(path[i].Item2, path[i].Item3 - 1, board) && !AlreadyPassed[path[i].Item2, path[i].Item3 - 1])
                {
                    if (board.GetBoard[path[i].Item2, path[i].Item3 - 1] == null)
                    {
                        cantNodes++;
                        path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 - 1));
                    }
                    else
                    {
                        if (board.GetBoard[path[i].Item2, path[i].Item3 - 1].Item1 == target)
                        {
                            if (target == 0)
                            {
                                if (!board.IsCribFilled(board.GetBoard[path[i].Item2, path[i].Item3 - 1].Item2))
                                {
                                    cantNodes++;
                                    path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 - 1));
                                    break;
                                }
                                else
                                {
                                    AlreadyPassed[path[i].Item2, path[i].Item3 - 1] = true;
                                }
                            }
                            else
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 - 1));
                                break;
                            }
                        }
                        else
                        {
                            if (target == 4)
                            {
                                cantNodes++;
                                path.Add(new Tuple<int, int, int>(i, path[i].Item2, path[i].Item3 - 1));
                            }
                        }
                    }
                    AlreadyPassed[BoardPosition.Item1, path[i].Item3 - 1] = true;
                }
            }
            if (cantNodes > 0 && (board.GetBoard[path[cantNodes - 1].Item2, path[cantNodes - 1].Item3] != null && board.GetBoard[path[cantNodes-1].Item2, path[cantNodes-1].Item3].Item1 == target))
            {
                int pos = cantNodes - 1;
                while (true)
                {
                    if (path[pos].Item1 == -1)
                    {
                        return new Tuple<int, int>(path[pos].Item2, path[pos].Item3);
                    }
                    else
                    {
                        pos = path[pos].Item1;
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }
    }

    public class GreedyRobot : Robot
    {
        private Random random;
        public GreedyRobot()
        {
            IsCarryingBaby = false;
            random = new Random();
        }

        public override Tuple<int, int> NextMove(Board board)
        {
            if (IsCarryingBaby)
            {
                return BFS(board, 0);
            }
            else
            {
                if (!board.IsChildrenLeft)
                {
                    return BFS(board, 4);
                }
                else
                {
                    var action = random.Next(0, 3);
                    if (action == 0)
                    {
                        return BFS(board, 4);
                    }
                    else
                    {
                        var bfs = BFS(board, 1);
                        if (bfs.Item1 == -1)
                        {
                            return BFS(board, 4);
                        }
                        return bfs;
                    }
                }
            }
        }
    }

    public class SmartRobot : Robot
    {
        public SmartRobot()
        {
            IsCarryingBaby = false;
        }

        public override Tuple<int, int> NextMove(Board board)
        {
            if (IsCarryingBaby)
            {
                return BFS(board, 0);
            }
            else
            {
                if (board.CurrentGarbagePercent > 40  || !board.IsChildrenLeft)
                {
                    return BFS(board, 4);
                }
                else
                {
                    var bfs = BFS(board, 1);
                    if (bfs.Item1 == -1)
                    {
                        return BFS(board, 4);
                    }
                    return bfs;
                }
            }
        }
    }
}
