using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace IoTtest
{
    
    class PageAViewModel : INotifyPropertyChanged
    {

        public ICommand BackClicked { get; set; }
        private PageA PageAFrame;
        public PageAViewModel(PageA pageFrame)
        {
            PageAFrame = pageFrame;
            BackClicked = new RelayCommand(Back);
        }

        private void Back()
        {
            PageAFrame.Frame.Navigate(typeof(IoTtest.MainPage));
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
