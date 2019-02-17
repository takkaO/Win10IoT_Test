using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IoTtest
{
    class ModelView : INotifyPropertyChanged
    {

        public ICommand ChangeColorClicked { get; set; }
        private string[] colors = {"#FFFF0000", "#FF00FF00" };
        private int i;

        public ModelView()
        {
            i = 0;
            CircleColor = colors[colors.Length - 1];
            ChangeColorClicked = new RelayCommand(ChangeColor);
            
        }

        private void ChangeColor()
        {
            Debug.WriteLine("Before {0}", CircleColor);
            CircleColor = colors[i];
            Debug.WriteLine("After  {0}", CircleColor);
            i++;
            if (i == colors.Length)
            {
                i = 0;
            }
        }
        

        private string _circleColor;
        public string CircleColor{
            get
            {
                return _circleColor;
            }
            set
            {
                _circleColor = value;
                NotifyPropertyChanged("CircleColor");
            }
        }


        // イベント設定
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
