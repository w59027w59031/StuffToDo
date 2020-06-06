using StuffToDo.ViewModel;
using System;
using System.Collections.Generic;
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

namespace StuffToDo.View
{
	/// <summary>
	/// Interaction logic for UstawieniaView.xaml
	/// </summary>
	public partial class DodajZadanieView : UserControl
	{
		public DodajZadanieView()
		{
			DataContext = new DodajZadanieViewModel();
			InitializeComponent();
		}
	}
}
