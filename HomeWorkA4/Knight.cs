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
            get
            {
                return field;
            }
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
            field[this.x, this.y] = 1;
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
            field = new int[x + 1, y + 1];
            field[this.x, this.y] = 1;
            SupportMethods.Print($"{field[this.x, this.y]}", this.x * 3, this.y + 7);
            Thread.Sleep(200);
        }

        public bool CheckMoveUR()
        {
            bool check = false;
            if (x + 1 < fieldX && y - 2 > 0 && field[x + 1, y - 2] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xUp and Right
        /// </summary>
        public void MoveUR(int move)
        {
            MoveAny(x + 1, y - 2, move);
        }

        public bool CheckMoveRU()
        {
            bool check = false;
            if (x + 2 < fieldX && y - 1 > 0 && field[x + 2, y - 1] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xRight and Up
        /// </summary>
        public void MoveRU(int move)
        {
            MoveAny(x + 2, y - 1, move);
        }

        public bool CheckMoveRD()
        {
            bool check = false;
            if (x + 2 < fieldX && y + 1 < fieldY && field[x + 2, y + 1] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xRight and Down
        /// </summary>
        public void MoveRD(int move)
        {
            MoveAny(x + 2, y + 1, move);
        }

        public bool CheckMoveDR()
        {
            bool check = false;
            if (x + 1 < fieldX && y + 2 < fieldY && field[x + 1, y + 2] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xDown and Right
        /// </summary>
        public void MoveDR(int move)
        {
            MoveAny(x + 1, y + 2, move);
        }

        public bool CheckMoveDL()
        {
            bool check = false;
            if (x - 1 > 0 && y + 2 < fieldY && field[x - 1, y + 2] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xDown and Left
        /// </summary>
        public void MoveDL(int move)
        {
            MoveAny(x - 1, y + 2, move);
        }

        public bool CheckMoveLD()
        {
            bool check = false;
            if (x - 2 > 0 && y + 1 < fieldY && field[x - 2, y + 1] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xLeft and Down
        /// </summary>
        public void MoveLD(int move)
        {
            MoveAny(x - 2, y + 1, move);
        }

        public bool CheckMoveLU()
        {
            bool check = false;
            if (x - 2 > 0 && y - 1 > 0 && field[x - 2, y - 1] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xLeft and Up
        /// </summary>
        public void MoveLU(int move)
        {
            MoveAny(x - 2, y - 1, move);
        }

        public bool CheckMoveUL()
        {
            bool check = false;
            if (x - 1 > 0 && y - 2 > 0 && field[x - 1, y - 2] == 0) check = true;
            return check;
        }

        /// <summary>
        /// Move 2xUp and Left
        /// </summary>
        public void MoveUL(int move)
        {
            MoveAny(x - 1, y - 2, move);
        }

        public bool CheckMove()
        {
            bool check = false;
            if (x > 0 && x < fieldX && y > 0 && y < fieldY) check = true;
            return check;
        }

        /// <summary>
        /// Move to requested point
        /// </summary>
        /// <param name="x">column</param>
        /// <param name="y">row</param>
        public void MoveAny(int x, int y, int move)
        {
            this.x = x;
            this.y = y;
            field[x, y] = move;
            SupportMethods.Print($"{field[x, y]}", x * 3, y + 7);
            Thread.Sleep(200);
        }

        /// <summary>
        /// Properties Get Available Movement
        /// </summary>
        public int GetAvailbleMovement
        {
            get
            {
                int availableMovement = 0;
                if (x + 2 < fieldX && y + 1 < fieldY && field[x + 2, y + 1] == 0) availableMovement++;
                if (x + 1 < fieldX && y + 2 < fieldY && field[x + 1, y + 2] == 0) availableMovement++;
                if (x - 1 > 0 && y + 2 < fieldY && field[x - 1, y + 2] == 0) availableMovement++;
                if (x - 2 > 0 && y + 1 < fieldY && field[x - 2, y + 1] == 0) availableMovement++;
                if (x - 2 > 0 && y - 1 > 0 && field[x - 2, y - 1] == 0) availableMovement++;
                if (x - 1 > 0 && y - 2 > 0 && field[x - 1, y - 2] == 0) availableMovement++;
                if (x + 1 < fieldX && y - 2 > 0 && field[x + 1, y - 2] == 0) availableMovement++;
                if (x + 2 < fieldX && y - 1 > 0 && field[x + 2, y - 1] == 0) availableMovement++;

                return availableMovement;
            }
        }

        /// <summary>
        /// Method Get Available Movement from Cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetAvailableMovementFromCell(int x, int y)
        {
            int availableMovement = 0;
            if (x + 2 < fieldX && y + 1 < fieldY && field[x + 2, y + 1] == 0) availableMovement++;
            if (x + 1 < fieldX && y + 2 < fieldY && field[x + 1, y + 2] == 0) availableMovement++;
            if (x - 1 > 0 && y + 2 < fieldY && field[x - 1, y + 2] == 0) availableMovement++;
            if (x - 2 > 0 && y + 1 < fieldY && field[x - 2, y + 1] == 0) availableMovement++;
            if (x - 2 > 0 && y - 1 > 0 && field[x - 2, y - 1] == 0) availableMovement++;
            if (x - 1 > 0 && y - 2 > 0 && field[x - 1, y - 2] == 0) availableMovement++;
            if (x + 1 < fieldX && y - 2 > 0 && field[x + 1, y - 2] == 0) availableMovement++;
            if (x + 2 < fieldX && y - 1 > 0 && field[x + 2, y - 1] == 0) availableMovement++;

            return availableMovement;
        }

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
