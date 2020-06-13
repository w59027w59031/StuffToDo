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

			string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +	"\\StuffToDo\\Notatki";
			string[] pliki = Directory.GetFiles(Dir);

			foreach (string plik in pliki)
			{
				StreamReader streamReader = new StreamReader(plik);
				string zawartoscPliku = streamReader.ReadToEnd();
				streamReader.Close();

				string tresc = zawartoscPliku.Substring(0, zawartoscPliku.LastIndexOf(Environment.NewLine));
				tresc = tresc.Substring(0, tresc.LastIndexOf(Environment.NewLine));

				DateTime data_od = new DateTime();
				data_od.Date.AddYears(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 2].Split('.')[2]));
				data_od.Date.AddMonths(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 2].Split('.')[1]));
				data_od.Date.AddDays(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 2].Split('.')[0]));


				DateTime data_do = new DateTime();
				data_do.Date.AddYears(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1].Split('.')[2]));
				data_do.Date.AddMonths(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1].Split('.')[1]));
				data_do.Date.AddDays(int.Parse(zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None)[zawartoscPliku.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1].Split('.')[0]));

				Notatki.Add(new Notatka_Item()
				{
					Tytul = plik.Split(new string[] { "\\" }, StringSplitOptions.None)[plik.Split(new string[] { "\\" }, StringSplitOptions.None).Length-1].Split('.')[0],
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
