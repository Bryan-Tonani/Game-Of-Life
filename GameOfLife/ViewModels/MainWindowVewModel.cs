using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Input;

namespace GameOfLife.ViewModels
{
    #region Commands
    public class KeyDownEnterCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public KeyDownEnterCommand(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public void Execute(object parameter)
        {
            if (!this._viewModel.WorldManager.IsEvolutionRunning)
                this._viewModel.WorldManager.KickEvolutionOff();
        }

        #endregion
    }

    public class KeyDownDeleteCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public KeyDownDeleteCommand(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public void Execute(object parameter)
        {
            if (this._viewModel.WorldManager.IsEvolutionRunning)
                this._viewModel.WorldManager.StopEvolution();
        }

        #endregion
    }

    public class KeyDownF5Command : ICommand
    {
        private MainWindowViewModel _viewModel;

        public KeyDownF5Command(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public void Execute(object parameter)
        {
            this._viewModel.StartNewEvolution();
        }

        #endregion
    }

    public class KeyDownAltF4Command : ICommand
    {
        private MainWindowViewModel _viewModel;

        public KeyDownAltF4Command(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public event EventHandler Close = null;

        public void Execute(object parameter)
        {
            if (this.Close != null)
                this.Close(this, null);
        }

        #endregion
    }
    #endregion

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private WorldManager worldManager;
        private List<List<Cell>> world;
        private ICommand keyDownEnterCommand;
        private ICommand keyDownDeleteCommand;
        private ICommand keyDownF5Command;
        private ICommand keyDownAltF4Command;

        public MainWindowViewModel()
        {
            this.worldManager = new WorldManager(true);
            this.worldManager.WorldChanged += this.WorldChanged;
            this.keyDownEnterCommand = new KeyDownEnterCommand(this);
            this.keyDownDeleteCommand = new KeyDownDeleteCommand(this);
            this.keyDownF5Command = new KeyDownF5Command(this);
            this.keyDownAltF4Command = new KeyDownAltF4Command(this);
            PopulateWorld(true);
        }

        public WorldManager WorldManager
        {
            get
            {
                return this.worldManager;
            }
        }

        public List<List<Cell>> World
        {
            get
            {
                return this.world;
            }
            set
            {
                this.world = value;
                OnPropertyChanged("World");
            }
        }

        public ICommand KeyDownEnterCommand
        {
            get { return this.keyDownEnterCommand; }
        }

        public ICommand KeyDownDeleteCommand
        {
            get { return this.keyDownDeleteCommand; }
        }

        public ICommand KeyDownF5Command
        {
            get { return this.keyDownF5Command; }
        }

        public ICommand KeyDownAltF4Command
        {
            get { return this.keyDownAltF4Command; }
        }

        public void StartNewEvolution()
        {
            if (this.worldManager.IsEvolutionRunning)
                this.worldManager.StopEvolution();
            this.worldManager = new WorldManager(true);
            this.worldManager.WorldChanged += this.WorldChanged;
            PopulateWorld(false);
        }

        private void WorldChanged(object sender, EventArgs e)
        {
            List<List<Cell>> _tempWorld = new List<List<Cell>>();

            for (int i = 0; i < this.worldManager.WorldVM.Count; i++)
            {
                List<Cell> cellTempList = new List<Cell>();
                for (int j = 0; j < this.worldManager.WorldVM.Count; j++)
                {
                    cellTempList.Add(this.worldManager.WorldVM[i][j]);
                }
                _tempWorld.Add(cellTempList);
            }

            this.World = _tempWorld;
        }

        private void PopulateWorld(bool SenderIsContructor)
        {
            this.world = new List<List<Cell>>();

            for (int i = 0; i < this.worldManager.WorldVM.Count; i++)
            {
                List<Cell> cellTempList = new List<Cell>();
                for (int j = 0; j < this.worldManager.WorldVM.Count; j++)
                {
                    cellTempList.Add(this.worldManager.WorldVM[i][j]);
                }
                this.world.Add(cellTempList);
            }

            if (!SenderIsContructor)
                WorldChanged(this, null);
        }

        public event EventHandler CloseApp 
        {
            add
            {
                (this.keyDownAltF4Command as KeyDownAltF4Command).Close += value;
            }
            remove
            {
                (this.keyDownAltF4Command as KeyDownAltF4Command).Close -= value;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanged Members

        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}