using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.IO;

namespace GameOfLife.ViewModels
{
    public class CellTempViewModel : INotifyPropertyChanged
    {
        private string deadCellImg = "";
        private string aliveCellImg = "";
        private string emptyCellImg = "";

        private Cell cell;

        public CellTempViewModel(Cell cell)
        {
            if (ConfigurationSettings.AppSettings["alivecellimg"] != null)
                this.aliveCellImg = ConfigurationSettings.AppSettings["alivecellimg"];
            if (ConfigurationSettings.AppSettings["deadcellimg"] != null)
                this.deadCellImg = ConfigurationSettings.AppSettings["deadcellimg"];
            if (ConfigurationSettings.AppSettings["emptycellimg"] != null)
                this.emptyCellImg = ConfigurationSettings.AppSettings["emptycellimg"];

            this.Cell = cell;
        }

        public Cell Cell
        {
            get
            {
                return this.cell;
            }
            set
            {
                this.cell = value;
                OnPropertyChanged("ImgPath");
            }
        }

        public string ImgPath
        {
            get 
            {
                string imgName = "";
                switch (this.cell.Status)
                {
                    case CellStatus.alive:
                        imgName = this.aliveCellImg;
                        break;
                    case CellStatus.dead:
                        imgName = this.deadCellImg;
                        break;
                    default:
                        imgName = this.emptyCellImg;
                        break;
                }

                return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,
                                    "/Resources/" + imgName);
            }
            //set 
            //{
            //    this.ImgPath = value;
            //    OnPropertyChanged("ImgPath");
            //}
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
