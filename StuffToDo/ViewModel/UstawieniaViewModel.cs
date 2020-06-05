using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using StuffToDo.Assets;
using StuffToDo.View;

namespace StuffToDo.ViewModel
{
	public class UstawieniaViewModel:INotifyPropertyChanged
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
			Zapisz = new RelayCommand(o => { ZapiszHandler(); }, o => true);
		}

		private void WsteczHandler()
		{
			App.Current.MainWindow.Content = new MenuGlowneView();
		}

		private void ZapiszHandler()
		{
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

		private Brush kolorCzcionki;
		public Brush KolorCzcionki
		{
			get { return kolorCzcionki; }
			set { kolorCzcionki = value; OnPropertyRaised("KolorCzcionki"); }
		}

		private Brush kolorTla;
		public Brush KolorTla
		{
			get { return kolorTla; }
			set { kolorTla = value; OnPropertyRaised("KolorTla"); }
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
		public RelayCommand Zapisz { get; set; }
	}
}
