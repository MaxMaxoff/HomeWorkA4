using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

namespace HomeWorkA4
{
    class Knight
    {
        /// <summary>
        /// x position
        /// </summary>
        int x;

        /// <summary>
        /// property return X
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// y position
        /// </summary>
        int y;

        /// <summary>
        /// property return Y
        /// </summary>
        public int Y
        {
            get { return y; }
        }

        public int sleep;

        /// <summary>
        /// size of field
        /// </summary>
        int fieldX = 0;
        int fieldY = 0;

        /// <summary>
        /// field
        /// </summary>
        int[,] field;

        /// <summary>
        /// property return field
        /// </summary>
        public int[,] Field
        {
            get { return field; }
        }

        /// <summary>
        /// fork in case if movement with equal weight
        /// </summary>
        int[,] fork;

        /// <summary>
        /// propery return fork
        /// </summary>
        public int[,] Fork
        {
            get { return fork; }
        }

        /// <summary>
        /// movement number
        /// </summary>
        int moveNumber;

        /// <summary>
        /// property return and set move number
        /// </summary>
        public int MoveNumber
        {
            get { return moveNumber; }
            set { moveNumber = value; }
        }

        /// <summary>
        /// initialize Knight with random values of position x and y from 1 up to 9 each
        /// </summary>
        public Knight()
        {
            Random random = new Random();

            this.x = random.Next(1, 9);
            this.y = random.Next(1, 9);
            fieldX = 9;
            fieldY = 9;
            field = new int[9, 9];
            fork = new int[9 * 9, 9];
            field[this.x, this.y] = 1;
            MoveNumber = 1;
        }

        /// <summary>
        /// initialize Knight position with requested field size
        /// </summary>
        /// <param name="x">columns</param>
        /// <param name="y">rows</param>
        public Knight(int x, int y)
        {
            Random random = new Random();

            this.x = random.Next(1, x + 1);
            this.y = random.Next(1, y + 1);
            fieldX = x + 1;
            fieldY = y + 1;
            field = new int[fieldX, fieldY];
            fork = new int[x * y + 1, 9];
            field[this.x, this.y] = 1;
            MoveNumber = 1;
            SupportMethods.Print($"{field[this.x, this.y]}", this.x * 3, this.y + 7);
            Thread.Sleep(sleep);
        }

        public bool CheckMoveUR()
        {
            fork[moveNumber, 1] = GetAvailableMovementFromCell(x + 1, y - 2);
            return (CheckMove(x + 1, y - 2));
        }

        public bool CheckMoveRU()
        {
            fork[moveNumber, 2] = GetAvailableMovementFromCell(x + 2, y - 1);
            return (CheckMove(x + 2, y - 1));
        }

        public bool CheckMoveRD()
        {
            fork[moveNumber, 3] = GetAvailableMovementFromCell(x + 2, y + 1);
            return (CheckMove(x + 2, y + 1));
        }

        public bool CheckMoveDR()
        {
            fork[moveNumber, 4] = GetAvailableMovementFromCell(x + 1, y + 2);
            return (CheckMove(x + 1, y + 2));
        }

        public bool CheckMoveDL()
        {
            fork[moveNumber, 5] = GetAvailableMovementFromCell(x - 1, y + 2);
            return (CheckMove(x - 1, y + 2));
        }

        public bool CheckMoveLD()
        {
            fork[moveNumber, 6] = GetAvailableMovementFromCell(x - 2, y + 1);
            return (CheckMove(x - 2, y + 1));
        }

        public bool CheckMoveLU()
        {
            fork[moveNumber, 7] = GetAvailableMovementFromCell(x - 2, y - 1);
            return (CheckMove(x - 2, y - 1));
        }

        public bool CheckMoveUL()
        {
            fork[moveNumber, 8] = GetAvailableMovementFromCell(x - 1, y - 2);
            return (CheckMove(x - 1, y - 2));
        }

        /// <summary>
        /// Property Check move
        /// </summary>
        /// <returns></returns>
        public bool CheckMove(int a, int b)
        {
            return (a > 0 && a < fieldX && b > 0 && b < fieldY) ? (field[a, b] == 0) : (a > 0 && a < fieldX && b > 0 && b < fieldY);
        }

        /// <summary>
        /// Move to requested point
        /// </summary>
        /// <param name="x">column</param>
        /// <param name="y">row</param>
        public void MoveAny(int a, int b)
        {
            x = a;
            y = b;
            field[x, y] = moveNumber;
            SupportMethods.Print($"{field[x, y]}", x * 3, y + 7);
            Thread.Sleep(sleep);
        }

        /// <summary>
        /// Properties Get Available Movement
        /// </summary>
        public int GetBestMovement
        {
            get
            {
                fork[moveNumber, 0] = 9;
                int min = 9;

                CheckMoveUR();
                CheckMoveRU();
                CheckMoveRD();
                CheckMoveDR();
                CheckMoveDL();
                CheckMoveLD();
                CheckMoveLU();
                CheckMoveUL();

                for (int i = 1; i < 9; i++)
                    if (fork[moveNumber, i] < min)
                    {
                        min = fork[moveNumber, i];
                        fork[moveNumber, 0] = i;
                    }
                
                return fork[moveNumber, 0];
            }
        }

        /// <summary>
        /// Properties Get Last Move
        /// </summary>
        public int GetLastMove
        {
            get
            {
                int curMove = 9;

                if (CheckMoveUR())
                {
                    curMove = 1;
                }
                if (CheckMoveRU())
                {
                    curMove = 2;
                }
                if (CheckMoveRD())
                {
                    curMove = 3;
                }
                if (CheckMoveDR())
                {
                    curMove = 4;
                }
                if (CheckMoveDL())
                {
                    curMove = 5;
                }
                if (CheckMoveLD())
                {
                    curMove = 6;
                }
                if (CheckMoveLU())
                {
                    curMove = 7;
                }
                if (CheckMoveUL())
                {
                    curMove = 8;
                }
                return curMove;
            }
        }

        /// <summary>
        /// Method Get Available Movement from Cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetAvailableMovementFromCell(int a, int b)
        {
            int availableMovement = 0;
            if (CheckMove(a, b))
            {
                if (CheckMove(a + 1, b - 2)) if (field[a + 1, b - 2] == 0) availableMovement++;
                if (CheckMove(a + 2, b - 1)) if (field[a + 2, b - 1] == 0) availableMovement++;
                if (CheckMove(a + 2, b + 1)) if (field[a + 2, b + 1] == 0) availableMovement++;
                if (CheckMove(a + 1, b + 2)) if (field[a + 1, b + 2] == 0) availableMovement++;
                if (CheckMove(a - 1, b + 2)) if (field[a - 1, b + 2] == 0) availableMovement++;
                if (CheckMove(a - 2, b + 1)) if (field[a - 2, b + 1] == 0) availableMovement++;
                if (CheckMove(a - 2, b - 1)) if (field[a - 2, b - 1] == 0) availableMovement++;
                if (CheckMove(a - 1, b - 2)) if (field[a - 1, b - 2] == 0) availableMovement++;
            }
            return availableMovement > 0 ? availableMovement : 9;
        }

        /// <summary>
        /// Method Move
        /// </summary>
        /// <param name="curMove">requested move</param>
        /// <param name="move">number of movement</param>
        public void Move(int curMove)
        {
            switch (curMove)
            {
                case 1:
                    // Move 2xUp and Right
                    MoveAny(x + 1, y - 2);
                    break;
                case 2:
                    // Move 2xRight and Up
                    MoveAny(x + 2, y - 1);
                    break;
                case 3:
                    // Move 2xRight and Down
                    MoveAny(x + 2, y + 1);
                    break;
                case 4:
                    // Move 2xDown and Right
                    MoveAny(x + 1, y + 2);
                    break;
                case 5:
                    // Move 2xDown and Left
                    MoveAny(x - 1, y + 2);
                    break;
                case 6:
                    // Move 2xLeft and Down
                    MoveAny(x - 2, y + 1);
                    break;
                case 7:
                    // Move 2xLeft and Up
                    MoveAny(x - 2, y - 1);
                    break;
                case 8:
                    // Move 2xUp and Left
                    MoveAny(x - 1, y - 2);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// roll out current step
        /// </summary>
        public void StepBack()
        {
            for (int i = 1; i < fieldX; i++)
                for (int j = 1; j < fieldY; j++)
                { 
                    if (field[i, j] >= moveNumber)
                    {
                        field[i, j] = 0;
                        SupportMethods.Print($"   ", i * 3, j + 7);
                        Thread.Sleep(sleep);
                    } else if ((field[i,j]) == moveNumber - 1)
                    {
                        x = i;
                        y = j;
                    }
                }
        }

        /// <summary>
        /// roll out fork
        /// </summary>
        public void ForkBack()
        {
            for (int i = 0; i < 9; i++)
                fork[moveNumber, i] = 0;
        }

        /// <summary>
        /// method roll out till got equal weight of movement
        /// </summary>
        public int RollOut()
        {
            ForkBack();

            moveNumber--;
            do
            {
                for (int j = 1; j < 9; j++)
                    if (fork[moveNumber, fork[moveNumber, 0]] == fork[moveNumber, j] && fork[moveNumber, 0] < j)
                    {
                        StepBack();

                        fork[moveNumber, 0] = j;
                        return fork[moveNumber, 0];
                    }
                ForkBack();
                moveNumber--;
            }
            while (true);
        }

        /// <summary>
        /// Method ToSring overrided
        /// </summary>
        /// <returns>array in string</returns>
        public override string ToString()
        {
            string str = "";

            for (int j = 1; j < fieldY; j++)
            {
                str += "\n";
                for (int i = 1; i < fieldX; i++)
                {
                    str += $"{field[i, j],3}";
                }
            }

            return str;
        }
    }
}
