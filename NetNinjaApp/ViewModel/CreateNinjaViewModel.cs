using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using NetNinjaApp.Model;
using NetNinjaApp.View;

namespace NetNinjaApp.ViewModel
{
    public class CreateNinjaViewModel :ViewModelBase
    {
        private List<NinjaModel> _ninjaList;
        public ICommand SaveNinjaCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public object NinjaName { get; set; }
        public string ImageUrl { get; set; }
        public BitmapImage Image { get; set; }

        public CreateNinjaViewModel()
        {
            LoadNinjaList();
            SaveNinjaCommand = new RelayCommand(SaveNinjaMethod);
            BackCommand = new RelayCommand(BackMethod);
        }

        private void BackMethod()
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.Windows[0].Close();
            mainWindow.Show();
        }

        private void SaveNinjaMethod()
        {
            bool succeeded = true;
            if (NinjaName != null && ImageUrl != null)
            {

                NinjaModel n = new NinjaModel();
                n.Name = NinjaName;
                n.ImageBytes = ConvertImageToByteArray(Image);
                //n.ImageURL = ImageUrl;
                n.Agility = 0;
                n.Intelligence = 0;
                n.Strength = 0;
                n.Gold = Math.Abs(new Random().Next(100, 10000));

                if (_ninjaList != null || _ninjaList.Count > 0)
                {
                    foreach (NinjaModel compareNinja in _ninjaList)
                    {
                        if (compareNinja.Name == n.Name)
                        {
                            succeeded = false;
                            MessageBox.Show("This name already exists, choose a different one.");
                        }
                    }
                }
                if (succeeded == true)
                {/* TODO:Save Ninja To DATABASE
                    using (var context = new NetNinjas.NetNinjaDatabaseEntities())
                    {
                        context.Ninjas.Add(n);
                        context.SaveChanges();
                    }
                    */
                    _ninjaList.Add(n);
                    StoreWindow storeWindow = new StoreWindow();
                    Application.Current.Windows[0].Close();
                    storeWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Make sure both values are filled in.");
            }
        }

        private byte[] ConvertImageToByteArray(BitmapImage image)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private void LoadNinjaList()
        {
            _ninjaList = new List<NinjaModel>();
            //TODO:Fix loading Ninjas from database, AND convert Ninjas from DataBase to NinjaModels.
            /*            using (var context = new NetNinjaDatabaseEntities())
                            _ninjaList = new ObservableCollection<NetNinjas.Ninja>(context.Ninjas);
                    */
        }
    }
}
