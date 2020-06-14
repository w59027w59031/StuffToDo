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
	public class DodajZadanieViewModel
	{
		public DodajZadanieViewModel()
		{
			DodajZadanie = new RelayCommand(o => { DodajZadanieHandler(); }, o => true);
			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);
		}

		public void DodajZadanieHandler()
		{
			FunDodajZadanie("",NazwaZadania, "", "",false);
		}

		public void FunDodajZadanie(string Numer_notatki, string wew_NazwaZadania, string wew_Data_od, string wew_Data_do, bool wew_taknie)
		{
			try
			{
				string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
					"\\StuffToDo\\Zadania";
				if (!Directory.Exists(Dir))
				{
					Directory.CreateDirectory(Dir);
				}
				string url = "";
				if (Numer_notatki == "")
				{
					url = Dir + "\\" + DajNowyNumerNotatki(Dir) + ".txt";
				}
				else
				{
					url = Dir + "\\" + Numer_notatki + ".txt";
				}


				StreamWriter streamWriter = new StreamWriter(url);
				streamWriter.Write(wew_NazwaZadania);
				streamWriter.WriteLine("");
				streamWriter.WriteLine(wew_taknie?"tak":"nie");

				if (wew_Data_od == "")
				{
					streamWriter.WriteLine(Data_od.Value.Date.Day + "." + Data_od.Value.Date.Month + "." + Data_od.Value.Date.Year);
					streamWriter.WriteLine(Data_do.Value.Date.Day + "." + Data_do.Value.Date.Month + "." + Data_do.Value.Date.Year);
				}
				else
				{
					streamWriter.WriteLine(wew_Data_od);
					streamWriter.WriteLine(wew_Data_do);
				}

				streamWriter.Close();

				AktualnaNotatka = "";
				if (wew_Data_od == "")
				{
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

		private string nazwaZadania;
		public string NazwaZadania
		{
			get { return nazwaZadania; }
			set { nazwaZadania = value; OnPropertyRaised("NazwaZadania"); }
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

		private bool takNie;
		public bool TakNie
		{
			get { return takNie; }
			set { takNie = value; OnPropertyRaised("TakNie"); }
		}

		private void WsteczHandler()
		{
			AktualnaNotatka = "";
			App.Current.MainWindow.Content = new MenuGlowneView();
			((MenuGlowneView)App.Current.MainWindow.Content).Width = 850;
			((MenuGlowneView)App.Current.MainWindow.Content).Height = 550;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyRaised(string propertyname)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}

		public RelayCommand Wstecz { get; set; }
		public RelayCommand DodajZadanie { get; set; }

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