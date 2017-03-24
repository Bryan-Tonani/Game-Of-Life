using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace GameOfLife
{
    public enum CellStatus { alive, dead };

    public class Cell
    {
        private CellStatus _cellStatus;
        private Int32 _x;
        private Int32 _y;

        public CellStatus Status
        {
            get { return this._cellStatus; }
            set { this._cellStatus = value; }
        }

        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }
        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public Cell()
        {
        }

        public Cell(CellStatus Status, int XPos, int YPos)
        {
            this._cellStatus = Status;
            this._x = XPos;
            this._y = YPos;
        }

        public void UpdateCell(List<Cell> Neighbours)
        {
            int aliveNeighbours = 0;

            foreach (Cell cell in Neighbours)
            {
                if (cell.Status == CellStatus.alive)
                    aliveNeighbours++;
            }

            if (this._cellStatus == CellStatus.alive)
            {
                if (aliveNeighbours < 2)
                    this._cellStatus = CellStatus.dead;
                else if (aliveNeighbours > 3)
                    this._cellStatus = CellStatus.dead;
            }
            else
            {
                if (aliveNeighbours == 3)
                    this._cellStatus = CellStatus.alive;
            }
        }

        public void Clone(ref Cell cell)
        {
            cell._cellStatus = this._cellStatus;
            cell._x = this._x;
            cell._y = this._y;
        }
    }
}