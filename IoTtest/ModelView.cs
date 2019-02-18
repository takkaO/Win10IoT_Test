using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace IoTtest
{
    class ModelView : INotifyPropertyChanged
    {

        public ICommand ChangeColorClicked { get; set; }
        private string[] colors = {"#FFFF0000", "#FF00FF00" };
        private int i;
        private MainPage MainFrame;

        public ModelView(MainPage mainFrame)
        {
            MainFrame = mainFrame;
            i = 0;
            CircleColor = colors[colors.Length - 1];
            ChangeColorClicked = new RelayCommand(ChangeColor);
            //write();
            read();
        }

        private async void write()
        {
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile appFile = await localFolder.CreateFileAsync("appData.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(appFile, "Test String OK");
            Debug.WriteLine("Write OK: {0}", localFolder.Path);
        }

        private async void read()
        {
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile appFile = await localFolder.GetFileAsync("appData.txt");
            var txt = await Windows.Storage.FileIO.ReadTextAsync(appFile);
            Debug.WriteLine(txt);
        }

        private void ChangeColor()
        {
            MainFrame.Frame.Navigate(typeof(IoTtest.PageA));
            /*
            Debug.WriteLine("Before {0}", CircleColor);
            CircleColor = colors[i];
            Debug.WriteLine("After  {0}", CircleColor);
            i++;
            if (i == colors.Length)
            {
                i = 0;
            }
            */
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
