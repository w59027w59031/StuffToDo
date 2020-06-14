using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
	public class UstawieniaViewModel : INotifyPropertyChanged
	{
		public UstawieniaViewModel()
		{
			ComboBoxItems = new ObservableCollection<ComboBoxItem>()
			{
				new ComboBoxItem(){Tekst="Jasny"},
				new ComboBoxItem(){Tekst="Ciemny"}
			};
			WybranyStyl = ComboBoxItems[0];

			Wstecz = new RelayCommand(o => { WsteczHandler(); }, o => true);
		}

		private void WsteczHandler()
		{
			App.Current.MainWindow.Content = new MenuGlowneView();
			((MenuGlowneView)App.Current.MainWindow.Content).Width = 850;
			((MenuGlowneView)App.Current.MainWindow.Content).Height = 550;
		}

		private ComboBoxItem wybranyStyl;
		public ComboBoxItem WybranyStyl
		{
			get => wybranyStyl;
			set
			{
				wybranyStyl = value;
				AktualizujStyl();
			}
		}

		private void AktualizujStyl()
		{
			if (WybranyStyl.Tekst == "Jasny")
			{
				KolorCzcionki = Kolory.KolorCzcionkiStylJasny;
				KolorTla = Kolory.KolorTlaStylJasny;
			}
			else
			{
				KolorCzcionki = Kolory.KolorCzcionkiStylCiemny;
				KolorTla = Kolory.KolorTlaStylCiemny;
			}
		}

		private ObservableCollection<ComboBoxItem> comboBoxItems;

		public ObservableCollection<ComboBoxItem> ComboBoxItems
		{
			get { return comboBoxItems; }
			set { comboBoxItems = value; }
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

		public Brush KolorTla
		{
			get { return Global.KolorTla; }
			set
			{
				Global.KolorTla = value;
				OnPropertyRaised("KolorTla");
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

		public RelayCommand Wstecz { get; set; }
	}
}
