using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StuffToDo.Assets
{
	class Kolory
	{
		public static Brush KolorTlaStylCiemny => new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
		public static Brush KolorCzcionkiStylCiemny => new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

		public static Brush KolorTlaStylJasny => new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
		public static Brush KolorCzcionkiStylJasny => new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
	}
}
