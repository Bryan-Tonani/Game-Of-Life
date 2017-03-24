using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameOfLife.ViewModels;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class ListOfCellTempView : UserControl
    {
        public ListOfCellTempView(List<CellTemp> list)
        {
            InitializeComponent();
            //this.DataContext = new ListOfCellTempViewModel(list);
            this.DataContext = new ListOfCellTempViewModel();
        }
    }
}