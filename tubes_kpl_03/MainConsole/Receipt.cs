using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    public class Receipt
    {
        public string ID_Transaksi { get; set; }
        public DateTime Tanggal { get; set; }
        public List<MenuMakanan<string>> Items { get; set; }
        public double TotalCost { get; set; }

        public Receipt() { }

        public Receipt(string iD_Transaksi, DateTime tanggal, List<MenuMakanan<string>> items)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(iD_Transaksi), "ID_Transaksi cannot be null or empty");
            Contract.Requires(items != null && items.Count > 0, "Items cannot be null or empty");
            Contract.Requires(Contract.ForAll(items, item => item != null), "All Items cannot be null");
            Contract.Requires(Contract.ForAll(items, item => item.harga_menu > 0), "All items harga_menu should be greater than 0");
            Contract.Requires(tanggal <= DateTime.Today, "Tanggal cannot be greater than today");

            this.ID_Transaksi = iD_Transaksi;
            this.Tanggal = tanggal;
            this.Items = items;
            this.TotalCost = items.Sum(item => item.harga_menu);
        }
    }
}
