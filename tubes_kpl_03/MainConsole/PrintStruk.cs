using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printing;

namespace MainConsole
{
    public class PrintStruk
    {
        public void mencetak(List<MenuMakanan<string>> daftarPesanan, Receipt receipts)
        {
            Printing.FormatingStruk formatingStruk = new Printing.FormatingStruk();
            formatingStruk.headerStruk();
            isiStruk(receipts);
            formatingStruk.footerStruk();
        }
        public void isiStruk(Receipt receipts)
        {

            Console.WriteLine("\tID Transaksi : " + receipts.ID_Transaksi);
            Console.WriteLine("\tTanggal : " + receipts.Tanggal);
            Console.WriteLine("\tDaftar Pesanan :");
            for (int y = 0; y < receipts.items.Count; y++)
            {   
                Console.WriteLine("\t"+receipts.items[y].name_menu+" \t\t "+ receipts.items[y].harga_menu);
            }
            Console.WriteLine("\tTotal :" + receipts.TotalCost);

        }   





    }
}
