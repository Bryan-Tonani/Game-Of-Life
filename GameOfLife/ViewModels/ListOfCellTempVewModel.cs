using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace GameOfLife.ViewModels
{
    public class ListOfCellTempViewModel : INotifyPropertyChanged
    {
        //private List<CellTemp> cellList;

        //public ListOfCellTempViewModel(List<CellTemp> cellList)
        //{
            //this.cellList = cellList;
        //}

        //public List<CellTemp> CellList
        //{
        //    get
        //    {
        //        return this.cellList;
        //    }
        //    set
        //    {
        //        this.cellList = value;
        //        OnPropertyChanged("CellList");
        //    }
        //}

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
