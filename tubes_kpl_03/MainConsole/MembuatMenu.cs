using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using static MainConsole.Menu;

namespace MainConsole
{
    public class Menu
    {
        private List<MenuMakanan<string>> DaftarMenu = new List<MenuMakanan<string>>();

        public MenuMakanan<string> MembuatMenu()
        {
            bool inputLagi = true;

            try
            {
                Console.Write("Silahkan Masukkan Nama Makanan Baru: ");
                string nama = Console.ReadLine();

                Debug.Assert(!string.IsNullOrEmpty(nama), "Name cannot be null or empty.");

                Console.WriteLine("Silahkan Masukkan Gambar Makanan:");
                List<string> list = new List<string> { };
                while (inputLagi)
                {
                    Console.WriteLine("input:");
                    string str = Console.ReadLine();
                    Debug.Assert(!string.IsNullOrEmpty(str), "Image path cannot be null or empty.");
                    list.Add(str);

                    Console.WriteLine("Apakah ingin tambah gambar? Y/N");
                    string pilihan = Console.ReadLine();
                    Debug.Assert(!string.IsNullOrEmpty(pilihan), "Answer cannot be null or empty.");
                    
                    if (pilihan.ToUpper() == "N")
                    {
                        inputLagi = false;
                    }
                    else if (pilihan.ToUpper() != "Y")
                    {
                        Console.WriteLine("Input tidak valid. Harap masukkan Y atau N.");
                    }
                }

                Console.WriteLine("Silahkan Masukkan Harga Makanan: ");
                double harga = Convert.ToDouble(Console.ReadLine());

                Debug.Assert(harga >= 0, "Price cannot be negative.");

                Console.WriteLine("Silahkan Masukkan Deskripsi Singkat Makanan: ");
                string deskripsi = Console.ReadLine();

                Debug.Assert(!string.IsNullOrEmpty(deskripsi), "Description cannot be null or empty.");

                MenuMakanan<string> menuMakanan = new MenuMakanan<string>(nama, list, harga, deskripsi);
                return menuMakanan;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void MenambahMenu(MenuMakanan<string> menuMakanan)
        {
            DaftarMenu.Add(menuMakanan);
        }
        public void HapusMenu(string name)
        {
            MenuMakanan<string> menuToRemove = DaftarMenu.Find(menu => menu.name_menu.Equals(name));
            if (menuToRemove != null)
            {
                DaftarMenu.Remove(menuToRemove);
                Console.WriteLine($"Menu {name} berhasil dihapus.");
            }
            else
            {
                Console.WriteLine($"Tidak ada menu dengan nama {name} ditemukan.");
            }
        }

        public void UbahMenu(string nama_menu, string newNama_menu, double harga, string deskripsi, List<string> path_images)
        {
            for (int i = 0; i < DaftarMenu.Count; i++)
            {
                if (DaftarMenu[i].name_menu == nama_menu)
                {
                    DaftarMenu[i].name_menu = newNama_menu;
                    DaftarMenu[i].harga_menu = harga;
                    DaftarMenu[i].deskripsi_menu = deskripsi;
                    DaftarMenu[i].path_images = path_images;
                    Console.WriteLine("Menu berhasil diubah.");
                    return;
                }
            }
            Console.WriteLine("Menu dengan nama tersebut tidak ditemukan.");
        }


        public void showAllMenu()
        {
            Console.WriteLine("Daftar Menu :");
            for (int i = 0; i < DaftarMenu.Count; i++)
            {
                Console.WriteLine("Nama :" + DaftarMenu[i].name_menu + " Harga :" + DaftarMenu[i].harga_menu);
                Console.WriteLine("Deskripsi :" + DaftarMenu[i].deskripsi_menu);
                Console.WriteLine("Gambar :");
                DaftarMenu[i].showImages();
                Console.WriteLine();
            }
        }
    }
}
