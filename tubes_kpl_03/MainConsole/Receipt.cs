using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    public class Receipt
    {
        public string ID_Transaksi { get; set; }
        public DateTime Tanggal { get; set; }
        public List<MenuMakanan<string>> items { get; set; }
        public double TotalCost { get; set; }

        public Receipt() { }
        public Receipt(string iD_Transaksi, DateTime tanggal, List<MenuMakanan<string>> items)
        {
            this.ID_Transaksi = iD_Transaksi;
            this.Tanggal = tanggal;
            this.items = items;
            this.TotalCost = 0;
            for(int i= 0; i < items.Count; i++)
            {
                this.TotalCost += items[i].harga_menu;
            }
        }
    }
}
