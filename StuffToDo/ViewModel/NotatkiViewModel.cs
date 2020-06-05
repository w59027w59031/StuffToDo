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
	public class NotatkiViewModel : INotifyPropertyChanged
	{
		public NotatkiViewModel()
		{
			DodajNotatke = new RelayCommand(o => { DodajNotatkeHandler(); }, o => true);
			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);
			//test
		}

		private void WsteczHandler()
		{
			AktualnaNotatka = "";
			App.Current.MainWindow.Content = new MenuGlowneView();
		}

		public void DodajNotatkeHandler()
		{
			string Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
				"\\StuffToDo\\Notatki";
			if (!Directory.Exists(Dir))
			{
				Directory.CreateDirectory(Dir);
			}
			string url = Dir + "\\" + DajNowyNumerNotatki(Dir)+".txt";
			
			StreamWriter streamWriter = new StreamWriter(url);
			streamWriter.Write(TekstNotatki);
			streamWriter.Close();

			AktualnaNotatka = "";
			App.Current.MainWindow.Content = new MenuGlowneView();
		}
		public string AktualnaNotatka="";
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

		private string tekstNotatki;
		public string TekstNotatki
		{
			get { return tekstNotatki; }
			set { tekstNotatki = value; OnPropertyRaised("TekstNotatki"); }
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
	}
}
