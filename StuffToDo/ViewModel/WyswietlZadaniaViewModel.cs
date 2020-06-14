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
	public class WyswietlZadaniaViewModel
	{
		public WyswietlZadaniaViewModel()
		{
			Load();
			RegisterMessages();
			Commands();
		}

		private ObservableCollection<Zadanie_Item> zadania;
		public ObservableCollection<Zadanie_Item> Zadania
		{
			get { return zadania; }
			set { zadania = value; OnPropertyRaised("Zadania"); }
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
			Zadania = new ObservableCollection<Zadanie_Item>();

			string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StuffToDo\\Zadania";

			if (!Directory.Exists(Dir))
			{
				Directory.CreateDirectory(Dir);
			}

			string[] pliki = Directory.GetFiles(Dir);

			foreach (string plik in pliki)
			{
				StreamReader streamReader = new StreamReader(plik);
				string zawartoscPliku = streamReader.ReadToEnd();
				streamReader.Close();

				int ostatniElement = (zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1);
				string[] linie = zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None);
				while (linie[linie.Length - 1].Length < 1)
				{
					zawartoscPliku = zawartoscPliku.Substring(0, zawartoscPliku.LastIndexOf(Environment.NewLine));
					linie = zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None);
				}

				string tresc = zawartoscPliku.Substring(0, zawartoscPliku.LastIndexOf(Environment.NewLine));
				tresc = tresc.Substring(0, tresc.LastIndexOf(Environment.NewLine));
				tresc = tresc.Substring(0, tresc.LastIndexOf(Environment.NewLine));

				bool taknie = false;

				if (linie[linie.Length - 3] != "")
				{
					taknie = linie[linie.Length - 3].Contains("tak");
				}

				DateTime data_od = new DateTime();
				DateTime data_do = new DateTime();


				string data = linie[linie.Length - 2];

				char[] znak = new char[] { '.', '/', ' ' };

				string rok = data.Split(znak)[2];
				string miesiac = data.Split(znak)[1];
				string dzien = data.Split(znak)[0];

				data_od = new DateTime(int.Parse(rok), int.Parse(miesiac), int.Parse(dzien));

				data = linie[linie.Length - 1];
				rok = data.Split(znak)[2];
				miesiac = data.Split(znak)[1];
				dzien = data.Split(znak)[0];

				data_do = new DateTime(int.Parse(rok), int.Parse(miesiac), int.Parse(dzien));

				Zadania.Add(new Zadanie_Item()
				{
					Id = int.Parse(plik.Split(new string[] { "\\" }, StringSplitOptions.None)[plik.Split(new string[] { "\\" }, StringSplitOptions.None).Length - 1].Split('.')[0]),
					NazwaZadania = tresc,
					Data_od = data_od,
					Data_do = data_do,
					TakNie = taknie
				});
			}
		}

		private void Commands()
		{
			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);
		}

		private void RegisterMessages()
		{
			Messenger.Default.Register<Zadanie_Wykonane_Message>(this, msg =>
			{
				if (msg.Tytul != null)
				{
					DodajZadanieViewModel dodajZadanieViewModel = new DodajZadanieViewModel();
					dodajZadanieViewModel.FunDodajZadanie(msg.Tytul, msg.Tresc, msg.Data_od, msg.Data_do, msg.taknie);
					Load();
				}
			});
		}

		private void WsteczHandler()
		{
			App.Current.MainWindow.Content = new MenuGlowneView();
			((MenuGlowneView)App.Current.MainWindow.Content).Width = 850;
			((MenuGlowneView)App.Current.MainWindow.Content).Height = 550;
		}

		public RelayCommand Wstecz { get; set; }

		public Brush KolorTla
		{
			get { return Global.KolorTla; }
			set { Global.KolorTla = value; OnPropertyRaised("KolorTla"); }
		}

		public Brush KolorCzcionki
		{
			get { return Global.KolorCzcionki; }
			set
			{
				Global.KolorCzcionki = value;
				OnPropertyRaised("KolorCzcionki");
			}
		}
	}
}
