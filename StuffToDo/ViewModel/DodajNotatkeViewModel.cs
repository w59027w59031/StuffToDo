using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using StuffToDo.Assets;
using StuffToDo.View;

namespace StuffToDo.ViewModel
{
	public class DodajNotatkeViewModel : INotifyPropertyChanged
	{
		public DodajNotatkeViewModel()
		{
			DodajNotatke = new RelayCommand(o => { DodajNotatkeHandler(); }, o => true);
			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);

			Data_od = DateTime.Today;
			Data_do = DateTime.Today;
		}

		private void WsteczHandler()
		{
			AktualnaNotatka = "";
			App.Current.MainWindow.Content = new MenuGlowneView();
			((MenuGlowneView)App.Current.MainWindow.Content).Width = 850;
			((MenuGlowneView)App.Current.MainWindow.Content).Height = 550;
		}

		public void DodajNotatkeHandler()
		{
			try
			{
				string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
					"\\StuffToDo\\Notatki";
				if (!Directory.Exists(Dir))
				{
					Directory.CreateDirectory(Dir);
				}
				string url = "";
				bool NazwaWolna = true;
				if (TytulNotatki == "")
				{
					url = Dir + "\\" + DajNowyNumerNotatki(Dir) + ".txt";
				}
				else
				{
					url = Dir + "\\" + TytulNotatki + ".txt";
					if (File.Exists(url))
					{
						NazwaWolna = false;
						System.Windows.MessageBox.Show("Taka notatka już istnieje.");
					}
				}

				if (NazwaWolna)
				{
					StreamWriter streamWriter = new StreamWriter(url);
					streamWriter.Write(TekstNotatki);
					streamWriter.WriteLine("");
					streamWriter.WriteLine(Data_od.Value.Date.Day + "." + Data_od.Value.Date.Month + "." + Data_od.Value.Date.Year);
					streamWriter.WriteLine(Data_do.Value.Date.Day + "." + Data_do.Value.Date.Month + "." + Data_do.Value.Date.Year);
					streamWriter.Close();

					AktualnaNotatka = "";
					App.Current.MainWindow.Content = new MenuGlowneView();
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
		}
		public string AktualnaNotatka = "";
		private string DajNowyNumerNotatki(string dir)
		{
			string res = "1";
			try
			{
				if (AktualnaNotatka.Length < 1)
				{
					foreach (string nazwa in Directory.GetFiles(dir))
					{
						if (res.Length < 1)
						{
							res = nazwa.Split('.')[0];
						}
						else
						{
							if (int.Parse(res) <= int.Parse(nazwa.Split('\\')[nazwa.Split('\\').Length - 1].Split('.')[0]))
							{
								res = (int.Parse(nazwa.Split('\\')[nazwa.Split('\\').Length - 1].Split('.')[0]) + 1).ToString();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
			AktualnaNotatka = res;
			return res;
		}

		private string tytulNotatki;
		public string TytulNotatki
		{
			get { return tytulNotatki; }
			set { tytulNotatki = value; OnPropertyRaised("TytulNotatki"); }
		}

		private string tekstNotatki;
		public string TekstNotatki
		{
			get { return tekstNotatki; }
			set { tekstNotatki = value; OnPropertyRaised("TekstNotatki"); }
		}

		private DateTime? data_od;
		public DateTime? Data_od
		{
			get { return data_od; }
			set { data_od = value; OnPropertyRaised("Data_od"); }
		}

		private DateTime? data_do;
		public DateTime? Data_do
		{
			get { return data_do; }
			set { data_do = value; OnPropertyRaised("Data_do"); }
		}

		public RelayCommand DodajNotatke { get; set; }
		public RelayCommand Wstecz { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyRaised(string propertyname)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}

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
