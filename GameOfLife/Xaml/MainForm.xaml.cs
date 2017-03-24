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
using System.Threading;
using System.ComponentModel;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            (this.DataContext as MainWindowViewModel).CloseApp += new EventHandler(delegate(object o, EventArgs e) 
                {
                    this.Close();
                }
            );
        }
    }
}