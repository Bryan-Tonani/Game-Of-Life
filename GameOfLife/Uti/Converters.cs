using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace GameOfLife.Uti
{
    public class CellStatusToImage : IValueConverter
    {
        private string deadCellImg;
        private string aliveCellImg;
        private string emptyCellImg;

        public CellStatusToImage()
        {
            this.aliveCellImg = "";
            if (ConfigurationSettings.AppSettings["alivecellimg"] != null)
                this.aliveCellImg = ConfigurationSettings.AppSettings["alivecellimg"];
            this.deadCellImg = "";
            if (ConfigurationSettings.AppSettings["deadcellimg"] != null)
                this.deadCellImg = ConfigurationSettings.AppSettings["deadcellimg"];
            this.emptyCellImg = "";
            if (ConfigurationSettings.AppSettings["emptycellimg"] != null)
                this.emptyCellImg = ConfigurationSettings.AppSettings["emptycellimg"];
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imgName;

            switch ((CellStatus)(value))
            {
                case CellStatus.alive:
                    imgName = this.aliveCellImg;
                    break;
                case CellStatus.dead:
                    imgName = this.emptyCellImg;
                    break;
                default:
                    imgName = this.emptyCellImg;
                    break;
            }

            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "/Resources/" + imgName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imgName;

            switch ((CellStatus)(value))
            {
                case CellStatus.alive:
                    imgName = this.aliveCellImg;
                    break;
                case CellStatus.dead:
                    imgName = this.emptyCellImg;
                    break;
                default:
                    imgName = this.emptyCellImg;
                    break;
            }

            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "/Resources/" + imgName);
        }
    }
}
