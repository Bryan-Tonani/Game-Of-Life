using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace GameOfLife
{
    public class WorldManager
    {
        const int WORLDSIZE = 30;

        private Cell[,] _world;
        private BackgroundWorker _worker;
        private bool _randomCreation;

        public WorldManager(bool RandomGeneration)
        {
            this._world = new Cell[WORLDSIZE,WORLDSIZE];
            this._worker = new BackgroundWorker();
            this._worker.DoWork += new DoWorkEventHandler(BackgroundEvolution);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(EvolutionProgressChanged);
            this._worker.WorkerReportsProgress = true;
            this._worker.WorkerSupportsCancellation = true;
            this._randomCreation = RandomGeneration;
            this.CreateWorld(this, null);
        }

        public List<List<Cell>> WorldVM
        {
            get 
            {
                List<List<Cell>> worldVM = new List<List<Cell>>();

                for (int i = 0; i < WORLDSIZE; i++)
                {
                    worldVM.Add(new List<Cell>());

                    for (int j = 0; j < WORLDSIZE; j++)
                    {
                        worldVM[i].Add((Cell)this._world[i,j]);
                    }
                }
                return worldVM;
            }
        }

        public Cell[,] World
        {
            get { return this._world; }
        }

        public bool IsEvolutionRunning
        { 
            get { return this._worker.IsBusy; }
        }

        private void CreateWorld(object sender, DoWorkEventArgs args)
        {
            if (this._randomCreation)
            {
                Cell _cell;

                for (int i = 0; i < WORLDSIZE; i++)
                {
                    for (int k = 0; k < WORLDSIZE; k++)
                    {
                        Random _random = new Random(DateTime.Now.Millisecond);
                        _cell = new Cell();

                        if ((_random.Next() % 2) == 0)
                            _cell.Status = CellStatus.alive;
                        else
                            _cell.Status = CellStatus.dead;

                        while (true)
                        {
                            Int32 _x = _random.Next(0, WORLDSIZE - 1);
                            Int32 _y = _random.Next(0, WORLDSIZE - 1);

                            if (_world[i, k] == null)
                            {
                                _cell.X = i;
                                _cell.Y = k;
                                _world[i, k] = _cell;
                                break;
                            }
                        }
                        Thread.Sleep(_random.Next(15));
                    }

                    //_creationWorker.ReportProgress(i);
                }
            }
            else
            {
                for (int i = 0; i < WORLDSIZE; i++)
                {
                    for (int k = 0; k < WORLDSIZE; k++)
                    {
                        Cell _cell;

                        if (((i == 1) && (k == 2)) ||
                            ((i == 2) && (k == 2)) ||
                            ((i == 3) && (k == 2)))
                        {
                            _cell = new Cell(CellStatus.alive, i, k);
                        }
                        else
                            _cell = new Cell(CellStatus.dead, i, k);

                        _world[i, k] = _cell;
                    }
                }
            }
        }

        private List<Cell> GetCellNeighbours(Cell Cell)
        {
            List<Cell> _neighbours = new List<Cell>();

            if ((Cell.X > 0) && (Cell.Y > 0))
                _neighbours.Add(_world[Cell.X - 1, Cell.Y - 1]);

            if ((Cell.X > 0) && (Cell.Y < WORLDSIZE - 1))
                _neighbours.Add(_world[Cell.X - 1, Cell.Y + 1]);

            if (Cell.Y > 0)
                _neighbours.Add(_world[Cell.X, Cell.Y - 1]);

            if (Cell.X > 0)
                _neighbours.Add(_world[Cell.X - 1, Cell.Y]);

            if ((Cell.Y > 0) && (Cell.X < WORLDSIZE - 1))
                _neighbours.Add(_world[Cell.X + 1, Cell.Y - 1]);

            if (Cell.Y < WORLDSIZE - 1)
                _neighbours.Add(_world[Cell.X, Cell.Y + 1]);

            if ((Cell.X < WORLDSIZE - 1) && (Cell.Y < WORLDSIZE - 1))
                _neighbours.Add(_world[Cell.X + 1, Cell.Y + 1]);

            if (Cell.X < WORLDSIZE - 1)
                _neighbours.Add(_world[Cell.X + 1, Cell.Y]);

            return _neighbours;
        }

        public void KickEvolutionOff()
        {
            _worker.RunWorkerAsync();
        }

        public void StopEvolution()
        {
            if (_worker.IsBusy)
                this._worker.CancelAsync();
        }

        private void EvolutionProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnWorldChanged(sender, null);
        }

        private void BackgroundEvolution(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Cell[,] _nextGenWorld = new Cell[WORLDSIZE, WORLDSIZE];

                for (int i = 0; i < WORLDSIZE; i++)
                {
                    for (int k = 0; k < WORLDSIZE; k++)
                    {
                        Cell _cell = _world[i, k];
                        List<Cell> _neighbours = this.GetCellNeighbours(_cell);
                        Cell _nextGenCell = new Cell();
                        _cell.Clone(ref _nextGenCell);
                        _nextGenCell.UpdateCell(_neighbours);
                        _nextGenWorld[i, k] = _nextGenCell;
                    }
                }

                _world = (Cell[,])_nextGenWorld.Clone();
                (sender as BackgroundWorker).ReportProgress(-1);

                if ((sender as BackgroundWorker).CancellationPending)
                    break;

                Thread.Sleep(500);
            }
        }

        public event EventHandler WorldChanged = null;

        private void OnWorldChanged(object sender, EventArgs args)
        {
            if (WorldChanged != null)
                WorldChanged(sender, args);
        }

        private void Print()
        {
            Console.WriteLine();
            Console.WriteLine("<------------------------------->");
            Console.WriteLine();
            for (int i = 0; i < WORLDSIZE; i++)
            {
                Console.WriteLine();
                for (int k = 0; k < WORLDSIZE; k++)
                {
                    Cell _currentCell = _world[k, i];

                    switch (_currentCell.Status)
                    { 
                        case CellStatus.alive:
                            Console.Write("X");
                            break;
                        case CellStatus.dead:
                            Console.Write("O");
                            break;
                    }                    
                }
            }
        }
    }
}