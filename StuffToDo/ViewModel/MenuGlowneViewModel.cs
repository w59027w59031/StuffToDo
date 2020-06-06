﻿using System;
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

			PrzejdzDoDodawaniaNotatki = new RelayCommand(o => { PrzejdzDoDodawaniaNotatkiHandler(); }, o => true);

			PrzejdzDoListyZadan = new RelayCommand(o => { PrzejdzDoListyZadanHandler(); }, o => true);

			PrzejdzDoUstawien = new RelayCommand(o => { PrzejdzDoUstawienHandler(); }, o => true);

			PrzejdzDoNotatek = new RelayCommand(o => { PrzejdzDoNotatekHandler(); }, o => true);

			PrzejdzDoDodawaniaZadania = new RelayCommand(o => { PrzejdzDoDodawaniaZadaniaHandler(); }, o => true);
		}

		private void PrzejdzDoDodawaniaZadaniaHandler()
		{
			App.Current.MainWindow.Content = new DodajZadanieView();
		}

		private void PrzejdzDoNotatekHandler()
		{
			App.Current.MainWindow.Content = new WyswietlNotatkeView();
		}

		public void PrzejdzDoOsiCzasuHandler()
		{
			System.Windows.MessageBox.Show("Test1");
		}
		public void ZamknijHandler()
		{
			App.Current.Shutdown();
		}
		public void PrzejdzDoDodawaniaNotatkiHandler()
		{
            App.Current.MainWindow.Content = new DodajNotatkeView();
        }
		public void PrzejdzDoListyZadanHandler()
		{
			App.Current.MainWindow.Content = new WyswietlZadaniaView();
		}
		public void PrzejdzDoUstawienHandler()
		{
			App.Current.MainWindow.Content = new UstawieniaView();
		}

		public RelayCommand PrzejdzDoDodawaniaZadania { get; set; }
		public RelayCommand PrzejdzDoNotatek { get; set; }
		public RelayCommand PrzejdzDoUstawien { get; set; }
		public RelayCommand PrzejdzDoListyZadan { get; set; }
		public RelayCommand PrzejdzDoDodawaniaNotatki { get; set; }
		public RelayCommand PrzejdzDoOsiCzasu { get; set; }
		public RelayCommand Zamknij { get; set; }
	}
}
