using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires(daftarPesanan != null && daftarPesanan.Count > 0, "DaftarPesanan cannot be null or empty");
            Contract.Requires(Contract.ForAll(daftarPesanan, item => item != null), "All DaftarPesanan items cannot be null");
            Contract.Requires(receipts != null, "Receipt cannot be null");

            try
            {
                Printing.FormatingStruk formatingStruk = new Printing.FormatingStruk();
                formatingStruk.headerStruk();
                isiStruk(receipts);
                formatingStruk.footerStruk();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void isiStruk(Receipt receipts)
        {

            Console.WriteLine("\tID Transaksi : " + receipts.ID_Transaksi);
            Console.WriteLine("\tTanggal : " + receipts.Tanggal);
            Console.WriteLine("\tDaftar Pesanan :");
            for (int y = 0; y < receipts.Items.Count; y++)
            {   
                Console.WriteLine("\t"+receipts.Items[y].name_menu+" \t\t "+ receipts.Items[y].harga_menu);
            }
            Console.WriteLine("\tTotal :" + receipts.TotalCost);

        }   
    }
}
