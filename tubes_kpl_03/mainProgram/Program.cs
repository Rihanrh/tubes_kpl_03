using Library_StatusOrder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            statusPesananConfig config = new statusPesananConfig();
            typeConfig typeConfig = new typeConfig();
            typeConfig.ReadConfigFile();

            MengubahStatusPesanan statusPesanan = new MengubahStatusPesanan();

            List<order> orders = new List<order>
            {
                new order(
                    "Rasya",
                    new List<orderStatus> { new orderStatus(123, "Menunggu konfirmasi pembayaran") },
                    new List<orderItems> { new orderItems("Nasi Goreng", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Goreng", 10000, 20000) },
                    "Tunai"
                ),
                new order(
                    "Katsu",
                    new List<orderStatus> { new orderStatus(456, "Menunggu konfirmasi pembayaran") },
                    new List<orderItems> { new orderItems("Mie Goreng", 3), new orderItems("Es Teh", 2) },
                    new List<paymentDetails> { new paymentDetails("Mie Goreng", 12000, 36000), new paymentDetails("Es Teh", 5000, 10000) },
                    "Tunai"
                ),
                new order(
                    "Kansas",
                    new List<orderStatus> { new orderStatus(789, "Menunggu konfirmasi pembayaran") },
                    new List<orderItems> { new orderItems("Nasi Kuning", 1), new orderItems("Es Jeruk", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Kuning", 15000, 15000), new paymentDetails("Es Jeruk", 7000, 14000) },
                    "Qris"
                ),
                new order(
                    "Rasya",
                    new List<orderStatus> { new orderStatus(101, "Menunggu konfirmasi pembayaran") },
                    new List<orderItems> { new orderItems("Nasi Uduk", 1), new orderItems("Es Lemon Tea", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Uduk", 15000, 15000), new paymentDetails("Es Lemon Tea", 7000, 14000) },
                    "Qris"
                ),
                new order(
                    "Rasya",
                    new List<orderStatus> { new orderStatus(112, "Pesanan sedang disiapkan") },
                    new List<orderItems> { new orderItems("Boneless Fried Chicken", 1), new orderItems("Air Mineral", 2) },
                    new List<paymentDetails> { new paymentDetails("Boneless Fried Chicken", 15000, 15000), new paymentDetails("Air Mineral", 7000, 14000) },
                    "Qris"
                )
            };

            foreach (var order in orders)
            {
                statusPesanan.addOrder(order);
            }

            Console.WriteLine("Login sebagai apa?");
            Console.WriteLine("1. Tenant");
            Console.WriteLine("2. Kasir");

            try
            {
                int role = int.Parse(Console.ReadLine());
                if (role == 1)
                {
                    Console.WriteLine("Pilih Tenant Anda ( Masukkan Nama Tenant Anda )");


                    for (int i = 0; i < typeConfig.config.listTenant.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + typeConfig.config.listTenant[i]);
                    }

                    string tenantID = Console.ReadLine();


                    if (typeConfig.config.listTenant.Contains(tenantID))
                    {
                        Console.WriteLine("MENU : ");
                        Console.WriteLine("1. Mengubah Status Pesanan");
                        Console.WriteLine("2. Melihat Daftar Pesanan");
                        Console.WriteLine("3. EXIT");
                        Console.WriteLine();
                        string menuSelected = Console.ReadLine();
                        while (menuSelected != "3" && menuSelected != "EXIT")
                        {
                            switch (menuSelected)
                            {
                                case "1":
                                    Console.WriteLine("Masukkan nomor antrian yang ingin diubah statusnya,ketik EXIT jika anda ingin pindah menu");

                                    int targetAntrian = int.Parse(Console.ReadLine());

                                    statusPesanan.MengubahStatusPesananTenant(targetAntrian);

                                    break;

                                case "2":
                                    Console.WriteLine("==================== Berikut List Pesanan di Tenant Anda ====================");

                                    statusPesanan.DisplayOrdersTenant(tenantID);
                                    break;

                                default:
                                    Console.WriteLine("Menu yang Anda pilih tidak valid.");
                                    break;
                            }

                            
                            Console.WriteLine();
                            Console.WriteLine("MENU : ");
                            Console.WriteLine("1. Mengubah Status Pesanan");
                            Console.WriteLine("2. Melihat Daftar Pesanan");
                            Console.WriteLine("3. EXIT");
                            menuSelected = Console.ReadLine();
                        }

                        Console.WriteLine("Terima kasih. Program telah berakhir.");
                  
                    }
                    else
                    {
                        Console.WriteLine("Tenant anda tidak terdaftar");
                    }



                }
                else if (role == 2)
                {
                    Console.WriteLine("MENU : ");
                    Console.WriteLine("1. Mengonfirmasi Pembayaran Tunai");
                    Console.WriteLine("2. Melihat Daftar Pesanan");
                    Console.WriteLine("3. EXIT");
                    Console.WriteLine();
                    string menuSelected = Console.ReadLine();
                    while (menuSelected != "3" && menuSelected != "EXIT")
                    {
                        switch (menuSelected)
                        {
                            case "1":
                                Console.WriteLine("Masukkan nomor antrian yang ingin diubah statusnya,ketik EXIT jika anda ingin pindah menu");

                                int targetAntrian = int.Parse(Console.ReadLine());

                                statusPesanan.MengonfirmasiPembayaranKasir(targetAntrian);

                                break;

                            case "2":
                                Console.WriteLine("==================== Berikut Pesanan Dengan Metode Pembayaran Tunai ====================");

                                statusPesanan.DisplayOrdersKasir();
                                break;

                            default:
                                Console.WriteLine("Menu yang Anda pilih tidak valid.");
                                break;
                        }


                        Console.WriteLine();
                        Console.WriteLine("MENU : ");
                        Console.WriteLine("1. Mengubah Status Pesanan");
                        Console.WriteLine("2. Melihat Daftar Pesanan");
                        Console.WriteLine("3. EXIT");
                        menuSelected = Console.ReadLine();
                    }

                    Console.WriteLine("Terima kasih. Program telah berakhir.");

                }
            else
            {
                Console.WriteLine("Role Tidak Valid");
            }

            }
            catch (FormatException)
            {
                Console.WriteLine("Role Tidak Valid");
            }
   
        }
    }
}
