using GalaSoft.MvvmLight.Messaging;
using StuffToDo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StuffToDo.View.Kontrolki
{
	/// <summary>
	/// Interaction logic for UstawieniaView.xaml
	/// </summary>
	public partial class Zadanie : UserControl
	{
		public string Tytul { get; set; }
		public string Tresc { get; set; }
		public DateTime Data_od { get; set; }
		public DateTime Data_do { get; set; }
		public bool TakNie { get; set; }

		public Zadanie()
		{
			InitializeComponent();
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			try
			{
				if (x_ID.Content != null && x_NazwaZadania.Content != null)
				{
					Messenger.Default.Send(new Zadanie_Wykonane_Message
					{
						Tytul = x_ID.Content.ToString(),
						Tresc = x_NazwaZadania.Content.ToString(),
						Data_od = x_Data_od.Text,
						Data_do = x_Data_do.Text,
						taknie = true
					});
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			try
			{
				if (x_ID.Content != null && x_NazwaZadania.Content != null)
				{
					Messenger.Default.Send(new Zadanie_Wykonane_Message
					{
						Tytul = x_ID.Content.ToString(),
						Tresc = x_NazwaZadania.Content.ToString(),
						Data_od = x_Data_od.Text,
						Data_do = x_Data_do.Text,
						taknie = false
					});
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
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
