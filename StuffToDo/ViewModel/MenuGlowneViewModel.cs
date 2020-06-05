using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using StuffToDo.Assets;
using StuffToDo.View;

namespace StuffToDo.ViewModel
{
	public class MenuGlowneViewModel
	{
		public MenuGlowneViewModel()
		{
			PrzejdzDoOsiCzasu = new RelayCommand(o => { PrzejdzDoOsiCzasuHandler(); }, o => true);

			Zamknij = new RelayCommand(o => { ZamknijHandler(); }, o => true);

			PrzejdzDoNotatek = new RelayCommand(o => { PrzejdzNotatkiHandler(); }, o => true);

			PrzejdzDoListyZadan = new RelayCommand(o => { PrzejdzDoListyZadanHandler(); }, o => true);

			PrzejdzDoUstawien = new RelayCommand(o => { PrzejdzDoUstawienHandler(); }, o => true);

		}
		public void PrzejdzDoOsiCzasuHandler()
		{
			System.Windows.MessageBox.Show("DUPA!!!!!");
		}
		public void ZamknijHandler()
		{
			App.Current.Shutdown();
		}
		public void PrzejdzNotatkiHandler()
		{
            App.Current.MainWindow.Content = new NotatkiView();
        }
		public void PrzejdzDoListyZadanHandler()
		{

		}
		public void PrzejdzDoUstawienHandler()
		{
			App.Current.MainWindow.Content = new UstawieniaView();
		}

		public RelayCommand PrzejdzDoUstawien { get; set; }
		public RelayCommand PrzejdzDoListyZadan { get; set; }
		public RelayCommand PrzejdzDoNotatek { get; set; }
		public RelayCommand PrzejdzDoOsiCzasu { get; set; }
		public RelayCommand Zamknij { get; set; }
	}
}
