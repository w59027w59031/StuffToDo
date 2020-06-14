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
	public partial class Node : UserControl
	{
		public int Id { get; set; }
		public string NazwaZadania { get; set; }
		public int Szerokosc { get; set; }
		public Thickness Margines { get; set; }
		public bool TakNie { get; set; }
		public SolidColorBrush Kolor { get; set; }

		public Node()
		{
			InitializeComponent();
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
