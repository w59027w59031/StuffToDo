using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffToDo
{
	public class Zadanie_Item
	{
		public int Id { get; set; }
		public string NazwaZadania { get; set; }
		public DateTime? Data_od { get; set; }
		public DateTime? Data_do { get; set; }
		public bool TakNie { get; set; }
	}
}
