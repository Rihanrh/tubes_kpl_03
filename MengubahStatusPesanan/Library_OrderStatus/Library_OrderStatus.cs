using System.Diagnostics.Contracts;

namespace MengubahStatusPesanan
{
    public class MengubahStatusPesanan_Test
    {
        private List<order> orders;

        public MengubahStatusPesanan_Test()
        {
            orders = new List<order>();
        }

        public void addOrder(order order)
        {
            orders.Add(order);
        }

        public void MengonfirmasiPembayaranKasir(int kodeAntrian)
        {
            // Cari order dengan kode antrian yang diberikan
            var orderCashMethod = orders.FirstOrDefault(o => o.status.Any(s => s.kodeAntrian == kodeAntrian) && o.paymentMethod == "cash");

            if (orderCashMethod == null)
            {
                Console.WriteLine("Tidak ada pesanan dengan kode antrian tersebut atau pesanan dibayar dengan bukan cash.");
                return;
            }

            // Ubah status pesanan
            foreach (var status in orderCashMethod.status)
            {
                if (status.statusOrder == "Menunggu konfirmasi pembayaran")
                {
                    status.statusOrder = "Pesanan sedang disiapkan";
                    Console.WriteLine("Status pesanan dengan kode antrian {0} berhasil diubah menjadi {1}.", kodeAntrian, status.statusOrder);
                    return;
                }
            }

        }

        public void MengubahStatusPesananTenant(int kodeAntrian)
        {
            // Cari order dengan kode antrian yang diberikan
            var orderCheck = orders.FirstOrDefault(o => o.status.Any(s => s.kodeAntrian == kodeAntrian));

            if (orderCheck == null)
            {
                Console.WriteLine("Tidak ada pesanan dengan kode antrian tersebut.");
                return;
            }

            // Ubah status pesanan
            foreach (var status in orderCheck.status)
            {
                if (status.statusOrder == "Menunggu konfirmasi pembayaran")
                {
                    status.statusOrder = "Pesanan sedang disiapkan";
                    Console.WriteLine("Status pesanan dengan kode antrian {0} berhasil diubah menjadi {1}.", kodeAntrian, status.statusOrder);
                    return;
                }
                else if (status.statusOrder == "Pesanan sedang disiapkan")
                {
                    status.statusOrder = "Pesanan sudah selesai";
                    Console.WriteLine("Status pesanan dengan kode antrian {0} berhasil diubah menjadi {1}.", kodeAntrian, status.statusOrder);
                    return;
                }
            }

        }
        public void DisplayOrders()
        {
            Console.WriteLine("Daftar Pesanan:");
            foreach (var order in orders)
            {
                Console.WriteLine("Tenant: " + order.tenant);
                Console.WriteLine("Status: ");
                foreach (var status in order.status)
                {
                    Console.WriteLine("- Kode Antrian: " + status.kodeAntrian);
                    Console.WriteLine("  Status Order: " + status.statusOrder);
                }
                Console.WriteLine("Items:");
                foreach (var item in order.items)
                {
                    Console.WriteLine("- Nama Menu: " + item.namaMenu);
                    Console.WriteLine("  Jumlah: " + item.qty);
                }
                Console.WriteLine("Payment Details:");
                foreach (var payment in order.paymentDetails)
                {
                    Console.WriteLine("- Nama Menu: " + payment.namaMenu);
                    Console.WriteLine("  Harga: " + payment.harga);
                    Console.WriteLine("  Total: " + payment.total);
                }
                Console.WriteLine("Payment Method: " + order.paymentMethod);
                Console.WriteLine();
            }
        }

        public void DisplayOrdersKasir()
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].paymentMethod == "Tunai")
                {
                    Console.WriteLine();
                    Console.WriteLine("Daftar Pesanan:");
                    Console.WriteLine("Tenant: " + orders[i].tenant);
                    Console.WriteLine("Status: ");
                    for (int j = 0; j < orders[i].status.Count; j++)
                    {
                        Console.WriteLine("- Kode Antrian: " + orders[i].status[j].kodeAntrian);
                        Console.WriteLine("  Status Order: " + orders[i].status[j].statusOrder);
                    }
                    Console.WriteLine("Items:");
                    for (int k = 0; k < orders[i].items.Count; k++)
                    {
                        Console.WriteLine("- Nama Menu: " + orders[i].items[k].namaMenu);
                        Console.WriteLine("  Jumlah: " + orders[i].items[k].qty);
                    }
                    Console.WriteLine("Payment Details:");
                    for (int l = 0; l < orders[i].paymentDetails.Count; l++)
                    {
                        Console.WriteLine("- Nama Menu: " + orders[i].paymentDetails[l].namaMenu);
                        Console.WriteLine("  Harga: " + orders[i].paymentDetails[l].harga);
                        Console.WriteLine("  Total: " + orders[i].paymentDetails[l].total);
                    }
                    Console.WriteLine("Payment Method: " + orders[i].paymentMethod);
                    Console.WriteLine();
                }
            }

        }

        public void DisplayOrdersTenant(string tenantID)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].tenant == tenantID)
                {
                    Console.WriteLine("Daftar Pesanan:");
                    Console.WriteLine("Tenant: " + orders[i].tenant);
                    Console.WriteLine("Status: ");
                    for (int j = 0; j < orders[i].status.Count; j++)
                    {
                        Console.WriteLine("- Kode Antrian: " + orders[i].status[j].kodeAntrian);
                        Console.WriteLine("  Status Order: " + orders[i].status[j].statusOrder);
                    }
                    Console.WriteLine("Items:");
                    for (int k = 0; k < orders[i].items.Count; k++)
                    {
                        Console.WriteLine("- Nama Menu: " + orders[i].items[k].namaMenu);
                        Console.WriteLine("  Jumlah: " + orders[i].items[k].qty);
                    }
                    Console.WriteLine("Payment Details:");
                    for (int l = 0; l < orders[i].paymentDetails.Count; l++)
                    {
                        Console.WriteLine("- Nama Menu: " + orders[i].paymentDetails[l].namaMenu);
                        Console.WriteLine("  Harga: " + orders[i].paymentDetails[l].harga);
                        Console.WriteLine("  Total: " + orders[i].paymentDetails[l].total);
                    }
                    Console.WriteLine("Payment Method: " + orders[i].paymentMethod);
                    Console.WriteLine();
                }
            }

        }



    }

    public class order
    {
        public string tenant { get; set; }
        public List<orderStatus> status { get; set; }
        public List<orderItems> items { get; set; }

        public List<paymentDetails> paymentDetails { get; set; }
        public string paymentMethod { get; set; }

        public order(string tenant, List<orderStatus> status, List<orderItems> items, List<paymentDetails> payment, string paymentMethod)
        {
            // tenenat tidak boleh kosong 
            try
            {
                Contract.Requires(!string.IsNullOrEmpty(tenant));
                this.tenant = tenant;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error Message :" + e.Message);

            }

            // Status order tidak boleh kosong
            try
            {
                Contract.Requires(status != null);
                this.status = status;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error Message :" + e.Message);
            }

            // Order Items tidak boleh kosong

            try
            {
                Contract.Requires(items != null);
                this.items = items;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error Message :" + e.Message);
            }

            // Payment Details tidak boleh kosong

            try
            {
                Contract.Requires(payment != null);
                this.paymentDetails = payment;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error Message :" + e.Message);
            }

            // payment method tidak boleh kosong
            try
            {
                Contract.Requires(!string.IsNullOrEmpty(tenant));
                this.paymentMethod = paymentMethod;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error Message :" + e.Message);

            }


        }

    }

    public class orderStatus
    {
        public int kodeAntrian { get; set; }
        public string statusOrder { get; set; }



        public orderStatus(int kodeAntrian, string statusOrder)
        {
            this.kodeAntrian = kodeAntrian;
            this.statusOrder = statusOrder;
        }
    }

    public class orderItems
    {
        public string namaMenu { get; set; }
        public int qty { get; set; }

        public orderItems(string namaMenu, int qty)
        {
            this.namaMenu = namaMenu;
            this.qty = qty;
        }
    }

    public class paymentDetails
    {
        public string namaMenu { get; set; }
        public double harga { get; set; }
        public double total { get; set; }

        public paymentDetails(string namaMenu, double harga, double total)
        {
            this.namaMenu = namaMenu;
            this.harga = harga;
            this.total = total;
        }
    }
}