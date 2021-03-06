﻿using GalaSoft.MvvmLight.Messaging;
using StuffToDo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
	public partial class Notatka : UserControl
	{
		public string Tytul { get; set; }
		public string Tresc { get; set; }
		public DateTime Data_od { get; set; }
		public DateTime Data_do { get; set; }

		public Notatka()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Messenger.Default.Send(new Wykonano_Zadanie_Message
				{
					SzukTytul = (string)x_Tytul.Content,
					SzukTresc = x_Tresc.Text,
					SzukData_od = x_Data_od.Text,
					SzukData_do = x_Data_do.Text
				});
			}catch(Exception ex)
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
