using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> makanan = new Dictionary<string, int>()
        {
            {"Nasi Goreng", 15000 },
            {"Katsu", 18000 },
            {"Mie Goreng", 13000 },
            {"Ayam Geprek", 18000 },
            {"N/A", 0 }
        };

        Dictionary<string, int> minuman = new Dictionary<string, int>() {
            {"Air Mineral", 4000 },
            {"Es Teh Manis", 5000 },
            {"Lemon Tea", 5000 },
            {"N/A", 0 }
        };

        //Menampilkan daftar makanan
        Console.WriteLine("Makanan");
        int i = 1;
        foreach (KeyValuePair<String, int> entry in makanan)
        {
            Console.WriteLine($"{i}. {entry.Key} (Rp {entry.Value})");
            i++;
        }

        Console.WriteLine(" ");

        //Menampilkan daftar minuman
        Console.WriteLine("Minuman");
        i = 1;
        foreach (KeyValuePair<string, int> entry in minuman)
        {
            Console.WriteLine($"{i}.{entry.Key} (Rp {entry.Value})");
            i++;
        }

        //inputan makanan dan minuman
        Console.Write("Masukkan nomor pesanan makanan yang akan dimasukkan (pisahkan dengan koma): ");
        string inputMakanan = Console.ReadLine();

        Console.Write("Masukkan nomor pesanan minuman yang akan dimasukkan (pisahkan dengan koma): ");
        string inputMinuman = Console.ReadLine();

        //Memproses input pengguna
        int total = hitungHargaTotal(makanan, inputMakanan) + hitungHargaTotal(minuman, inputMinuman);

        // Menampilkan harga
        Console.WriteLine($"Total harga: Rp{total}");
        Console.ReadLine();

    }

    static int hitungHargaTotal(Dictionary<string, int> menu, string input)
    {
        int total = 0;
        string[] pilihan = input.Split(',');
        foreach(string s in pilihan)
        {
            int index = int.Parse(s.Trim()) - 1;
            total += menu.Values.ElementAt(index);
        }
        return total;
    }
}