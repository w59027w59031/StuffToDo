using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace StuffToDo
{
	public class Node_Item
	{
		public int Id { get; set; }
		public string NazwaZadania { get; set; }
		public int Szerokosc { get; set; }
		public Thickness Margines { get; set; }
		public bool TakNie { get; set; }
		public SolidColorBrush Kolor { get; set; }
	}
}
