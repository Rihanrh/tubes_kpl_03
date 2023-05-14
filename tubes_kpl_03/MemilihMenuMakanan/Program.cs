using System;

namespace MemilihMenuMakanan
{
    public class pilihMakanan
    {
        public static void Main(string[] args)
        {
            string state = "awal";

            while (state != "selesai")
            {
                switch (state)
                {
                    case "awal":
                        Console.WriteLine("Selamat datang, Silahkan pilih menu makanan anda");
                        Console.WriteLine("1. Makanan");
                        Console.WriteLine("2. Minuman");
                        Console.WriteLine();
                        int select = 0;
                        try
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Input tidak valid! Silakan masukkan nomor pilihan yang valid.");
                            continue;
                        }
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine("Silahkan pilih makanan anda");
                                Console.WriteLine("1. Nasi Goreng Ayam");
                                Console.WriteLine("2. Katsu");
                                Console.WriteLine("3. Mie Goreng");
                                Console.WriteLine("4. Ayam Geprek");
                                Console.WriteLine("");
                                int selectMakanan = Convert.ToInt32(Console.ReadLine());

                                switch (selectMakanan)
                                {
                                    case 1:
                                        Console.WriteLine("Anda memesan Nasi Goreng Ayam");
                                        break;
                                    case 2:
                                        Console.WriteLine("Anda memesan Katsu");
                                        break;
                                    case 3:
                                        Console.WriteLine("Anda memesan Mie Goreng");
                                        break;
                                    case 4:
                                        Console.WriteLine("Anda memesan Ayam Goreng");
                                        break;
                                    default:
                                        Console.WriteLine("Menu tidak tersedia");
                                        break;
                                }
                                Console.WriteLine("Apakah anda ingin memesan minuman?");
                                Console.WriteLine("1. Iya");
                                Console.WriteLine("2 .Tidak");
                                Console.WriteLine("");
                                int inputPilihan1 = Convert.ToInt32(Console.ReadLine());

                                switch (inputPilihan1)
                                {
                                    case 1:
                                        Console.WriteLine("Anda ingin memesan minuman apa?");
                                        Console.WriteLine("1. Air Putih");
                                        Console.WriteLine("2. Es Teh Manis");
                                        Console.WriteLine("3. Lemon Tea");
                                        Console.WriteLine("");
                                        int inputMinuman1 = Convert.ToInt32(Console.ReadLine());

                                        switch (inputMinuman1)
                                        {
                                            case 1:
                                                Console.WriteLine("Anda memesan air putih");
                                                break;
                                            case 2:
                                                Console.WriteLine("Anda memesan Es Teh Manis");
                                                break;
                                            case 3:
                                                Console.WriteLine("Anda memesan Lemon Tea");
                                                break;
                                            default:
                                                Console.WriteLine("Menu tidak tersedia");
                                                break;
                                        }
                                        break;

                                    case 2:
                                        Console.WriteLine("Pesanan anda akan segera diantar");
                                        state = "selesai";
                                        break;

                                }
                                break;
                            case 2:
                                Console.WriteLine("Silahkan pilih minuman anda");
                                Console.WriteLine("Anda ingin memesan minuman apa?");
                                Console.WriteLine("1. Air Mineral");
                                Console.WriteLine("2. Es Teh Manis");
                                Console.WriteLine("3. Lemon Tea");
                                Console.WriteLine("");
                                int inputMinuman2 = Convert.ToInt32(Console.ReadLine());
                                switch (inputMinuman2)
                                {
                                    case 1:
                                        Console.WriteLine("Anda memesan Air Mineral");
                                        break;
                                    case 2:
                                        Console.WriteLine("Anda memesan Es Teh Manis");
                                        break;
                                    case 3:
                                        Console.WriteLine("Anda memesan Lemon Tea");
                                        break;
                                    default:
                                        Console.WriteLine("Menu tidak tersedia");
                                        break;
                                }
                                Console.WriteLine("Apakah anda ingin memesan makanan?");
                                Console.WriteLine("1. Iya");
                                Console.WriteLine("2. Tidak");
                                Console.WriteLine("");
                                int inputPilihan2 = Convert.ToInt32(Console.ReadLine());
                                switch (inputPilihan2)
                                {
                                    case 1:
                                        Console.WriteLine("Anda ingin memesan apa?");
                                        Console.WriteLine("1. Nasi Goreng Ayam");
                                        Console.WriteLine("2. Katsu");
                                        Console.WriteLine("3. Mie Goreng");
                                        Console.WriteLine("4. Ayam Geprek");
                                        Console.WriteLine("");
                                        int inputMakanan2 = Convert.ToInt32(Console.ReadLine());
                                        switch (inputMakanan2)
                                        {
                                            case 1:
                                                Console.WriteLine("Anda memesan Nasi Goreng Ayam");
                                                Console.WriteLine("Pesanan anda akan segera diantar");
                                                state = "selesai";
                                                break;
                                            case 2:
                                                Console.WriteLine("Anda memesan Katsu");
                                                Console.WriteLine("Pesanan anda akan segera diantar");
                                                state = "selesai";
                                                break;
                                            case 3:
                                                Console.WriteLine("Anda memesan Mie Goreng");
                                                Console.WriteLine("Pesanan anda akan segera diantar");
                                                state = "selesai";
                                                break;
                                            case 4:
                                                Console.WriteLine("Anda memesan Ayam Goreng");
                                                Console.WriteLine("Pesanan anda akan segera diantar");
                                                state = "selesai";
                                                break;
                                            default:
                                                Console.WriteLine("Menu tidak tersedia");
                                                break;
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Pesanan anda akan segera diantar");
                                        state = "selesai";
                                        break;
                                }
                                break;

                        }
                        break;
                }
            }
        }
    }
}
