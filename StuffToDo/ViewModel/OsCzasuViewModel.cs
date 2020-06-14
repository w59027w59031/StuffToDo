using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using StuffToDo.Assets;
using StuffToDo.View;

namespace StuffToDo.ViewModel
{
	public class OsCzasuViewModel
	{
		public OsCzasuViewModel()
		{
			Load();
			RegisterMessages();
			Commands();
		}

		private ObservableCollection<Node_Item> nodey;
		public ObservableCollection<Node_Item> Nodey
		{
			get { return nodey; }
			set { nodey = value; OnPropertyRaised("Nodey"); }
		}

		private DateTime najstarsza_data;
		public DateTime Najstarsza_data
		{
			get { return najstarsza_data; }
			set { najstarsza_data = value; OnPropertyRaised("Najstarsza_data"); }
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
			Najstarsza_data = DateTime.Today;

			Nodey = new ObservableCollection<Node_Item>();

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

				/*if (data_od < Najstarsza_data)
				{
					Najstarsza_data = data_od;
				}*/
				double roznica_dat = (data_od - Najstarsza_data).TotalDays;
				string rdat = roznica_dat.ToString();
				int Dni_od_poczatku = int.Parse(rdat) * 10;

				Nodey.Add(new Node_Item()
				{
					Id = int.Parse(plik.Split(new string[] { "\\" }, StringSplitOptions.None)[plik.Split(new string[] { "\\" }, StringSplitOptions.None).Length - 1].Split('.')[0]),
					NazwaZadania = tresc,
					Szerokosc = int.Parse((data_do - data_od).TotalDays.ToString()) * 10,
					Margines = new Thickness(Dni_od_poczatku, 0, 0, 0),
					Kolor = taknie ? new SolidColorBrush(Color.FromRgb(0, 255, 0)) : new SolidColorBrush(Color.FromRgb(255, 0, 0))
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
