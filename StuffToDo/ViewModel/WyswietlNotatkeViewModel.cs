using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using StuffToDo.Assets;
using StuffToDo.View;

namespace StuffToDo.ViewModel
{
	public class WyswietlNotatkeViewModel
	{
		public WyswietlNotatkeViewModel()
		{
			Load();
			RegisterMessages();
			Commands();
		}

		private ObservableCollection<Notatka_Item> notatki;
		public ObservableCollection<Notatka_Item> Notatki
		{
			get { return notatki; }
			set { notatki = value; OnPropertyRaised("Notatki"); }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyRaised(string propertyname)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}

		private void Load()
		{
			Notatki = new ObservableCollection<Notatka_Item>();

			string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StuffToDo\\Notatki";
			string[] pliki = Directory.GetFiles(Dir);

			foreach (string plik in pliki)
			{
				StreamReader streamReader = new StreamReader(plik);
				string zawartoscPliku = streamReader.ReadToEnd();
				streamReader.Close();

				int ostatniElement = (zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1);
				string[] linie = zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None);
				while (linie[linie.Length-1].Length < 1)
				{
					zawartoscPliku = zawartoscPliku.Substring(0, zawartoscPliku.LastIndexOf(Environment.NewLine));
					linie = zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None);
				}

				string tresc = zawartoscPliku.Substring(0, zawartoscPliku.LastIndexOf(Environment.NewLine));
				tresc = tresc.Substring(0, tresc.LastIndexOf(Environment.NewLine));

				DateTime data_od = new DateTime();
				DateTime data_do = new DateTime();

				string data = linie[linie.Length - 2];
				string rok = data.Split('.')[2];
				string miesiac = data.Split('.')[1];
				string dzien = data.Split('.')[0];

				data_od = new DateTime(int.Parse(rok), int.Parse(miesiac), int.Parse(dzien));

				data = linie[linie.Length - 1];
				rok = data.Split('.')[2];
				miesiac = data.Split('.')[1];
				dzien = data.Split('.')[0];

				data_do = new DateTime(int.Parse(rok), int.Parse(miesiac), int.Parse(dzien));

				Notatki.Add(new Notatka_Item()
				{
					Tytul = plik.Split(new string[] { "\\" }, StringSplitOptions.None)[plik.Split(new string[] { "\\" }, StringSplitOptions.None).Length - 1].Split('.')[0],
					Tresc = tresc,
					Data_od = data_od,
					Data_do = data_do
				}); ;
			}
		}

		private void Commands()
		{
			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);
		}

		private void RegisterMessages()
		{
			Messenger.Default.Register<Wykonano_Zadanie_Message>(this, msg =>
			{
				if (msg.SzukTytul != null)
				{
					string url = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StuffToDo\\Notatki\\" + msg.SzukTytul + ".txt";
					File.Delete(url);
				}
			});
		}

		private void WsteczHandler()
		{
			App.Current.MainWindow.Content = new MenuGlowneView();
		}

		public RelayCommand Wstecz { get; set; }
	}
}
