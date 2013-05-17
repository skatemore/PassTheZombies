using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Position
    {
        int x;
        int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }

        //public MatrixCoords(int row, int col)
        //{
        //    this.Row = row;
        //    this.Col = col;
        //}

        //public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b)
        //{
        //    return new MatrixCoords(a.Row + b.Row, a.Col + b.Col);
        //}

        //public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b)
        //{
        //    return new MatrixCoords(a.Row - b.Row, a.Col - b.Col);
        //}

        //public override bool Equals(object obj)
        //{
        //    MatrixCoords objAsMatrixCoords = obj as MatrixCoords;

        //    return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
        //}

        //public override int GetHashCode()
        //{
        //    return this.Row.GetHashCode() * 7 + this.Col;
        //}
    }
}
