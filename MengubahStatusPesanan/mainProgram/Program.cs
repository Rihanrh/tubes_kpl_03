using MengubahStatusPesanan;
using System;
using System.Collections.Generic;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            statusPesananConfig config = new statusPesananConfig();
            typeConfig typeConfig = new typeConfig();
            typeConfig.ReadConfigFile();

            MengubahStatusPesanan_Test statusPesanan = new MengubahStatusPesanan_Test();

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
                    "Kansas",
                    new List<orderStatus> { new orderStatus(101, "Pesanan sedang disiapkan") },
                    new List<orderItems> { new orderItems("Nasi Uduk", 1), new orderItems("Es Lemon Tea", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Uduk", 15000, 15000), new paymentDetails("Es Lemon Tea", 7000, 14000) },
                    "Qris"
                )
            };

            foreach (var order in orders)
            {
                statusPesanan.addOrder(order);
            }
            statusPesanan.DisplayOrders();

            Console.WriteLine("Login sebagai apa?");
            Console.WriteLine("1. Tenant");
            Console.WriteLine("2. Kasir");

            int role = int.Parse(Console.ReadLine());

            if (role == 1)
            {
                Console.WriteLine("Pilih Tenant Anda ( cukup ketikkan nomor saja )");


                for (int i = 0; i < typeConfig.config.listTenant.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + typeConfig.config.listTenant[i]);
                }

                string tenantID = Console.ReadLine();

                Console.WriteLine("Berikut List Pesanan di Tenant Anda");
                for (int k = 0; k < typeConfig.config.listTenant.Count; k++)
                {
                    statusPesanan.DisplayOrdersTenant(tenantID);
                    break;
                }

                Console.WriteLine("Masukkan nomor antrian yang ingin diubah statusnya");

                int targetAntrian = int.Parse(Console.ReadLine());

                statusPesanan.MengubahStatusPesananTenant(targetAntrian);

                statusPesanan.DisplayOrdersTenant(tenantID);
            }
            else if (role == 2)
            {
                statusPesanan.DisplayOrdersKasir();

                statusPesanan.MengonfirmasiPembayaranKasir(123);
            }
            else
            {
                Console.WriteLine("Role Tidak Valid");
            }
        }
    }
}
