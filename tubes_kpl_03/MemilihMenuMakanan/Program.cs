using System;
class program
{
    static void Main(string[] args)
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
                    string input = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (input == "1")
                    {
                        state = "makanan";
                    }
                    else if (input == "2")
                    {
                        state = "minuman";
                    }
                    break;

                case "makanan":
                    Console.WriteLine("Silahkan pilih makanan anda");
                    Console.WriteLine("1. Nasi Goreng Ayam");
                    Console.WriteLine("2. Katsu");
                    Console.WriteLine("3. Mie Goreng");
                    Console.WriteLine("4. Ayam Geprek");                    
                    input = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (input == "1")
                    {
                        Console.WriteLine("Anda memesan Nasi Goreng Ayam");
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Anda memesan Katsu");
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine("Anda memesan Mie Goreng");
                    }
                    else if (input == "4")
                    {
                        Console.WriteLine("Anda memesan Ayam Goreng");
                    }
                    Console.WriteLine("Apakah anda ingin memesan minuman?");
                    Console.WriteLine("1. Iya");
                    Console.WriteLine("2 .Tidak");                    
                    input = Console.ReadLine();
                    Console.WriteLine("");

                    if (input == "1")
                    {
                        Console.WriteLine("Anda ingin memesan minuman apa?");
                        Console.WriteLine("1. Air Putih");
                        Console.WriteLine("2. Es Teh Manis");
                        Console.WriteLine("3. Lemon Tea");
                        Console.WriteLine("");
                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.WriteLine("Anda memesan air putih");
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Anda memesan Es Teh Manis");
                        }
                        else if (input == "3")
                        {
                            Console.WriteLine("Anda memesan Lemon Tea");
                        }
                    }
                    else if (input == "2") { }
                    {
                        Console.WriteLine("Pesanan anda akan segera diantar");
                        state = "selesai";
                    }
                    break;

                case "minuman":
                    Console.WriteLine("Silahkan pilih minuman anda");
                    Console.WriteLine("Anda ingin memesan minuman apa?");
                    Console.WriteLine("1. Air Mineral");
                    Console.WriteLine("2. Es Teh Manis");
                    Console.WriteLine("3. Lemon Tea");                    
                    input = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (input == "1")
                    {
                        Console.WriteLine("Anda memesan Air Mineral");
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Anda memesan Es Teh Manis");
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine("Anda memesan Lemon Tea");
                    }

                    Console.WriteLine("Apakah anda ingin memesan makanan?");
                    Console.WriteLine("1. Iya");
                    Console.WriteLine("2. Tidak");                    
                    input = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (input == "1")
                    {
                        Console.WriteLine("Anda ingin memesan apa?");
                        Console.WriteLine("1. Nasi Goreng Ayam");
                        Console.WriteLine("2. Katsu");
                        Console.WriteLine("3. Mie Goreng");
                        Console.WriteLine("4. Ayam Geprek");
                        input = Console.ReadLine();
                        Console.WriteLine(" ");

                        if (input == "1")
                        {
                            Console.WriteLine("Anda memesan Nasi Goreng Ayam");
                            Console.WriteLine("Pesanan anda akan segera diantar");
                            state = "selesai";
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Anda memesan Katsu");
                            Console.WriteLine("Pesanan anda akan segera diantar");
                            state = "selesai";
                        }
                        else if (input == "3")
                        {
                            Console.WriteLine("Anda memesan Mie Goreng");
                            Console.WriteLine("Pesanan anda akan segera diantar");
                            state = "selesai";
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine("Anda memesan Ayam Goreng");
                            Console.WriteLine("Pesanan anda akan segera diantar");
                            state = "selesai";
                        }
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Pesanan anda akan segera diantar");
                        state = "selesai";
                    }
                    break;
            }
        }
    }
}