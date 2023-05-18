using Library_StatusOrder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestStatusOrder
{
    [TestClass]
    public class MengubahStatusPesananTests
    {
        private MengubahStatusPesanan pesanan;

        [TestInitialize]
        public void Setup()
        {
            pesanan = new MengubahStatusPesanan();
        }


        [TestMethod]
        public void MengonfirmasiPembayaranKasir()
        {
            // Arrange
            var order = new order(
                     "Rasya",
                     new List<orderStatus> { new orderStatus(123, "Menunggu konfirmasi pembayaran") },
                     new List<orderItems> { new orderItems("Nasi Goreng", 2) },
                     new List<paymentDetails> { new paymentDetails("Nasi Goreng", 10000, 20000) },
                     "Tunai"
                 );
            pesanan.addOrder(order);

            // Act
            pesanan.MengonfirmasiPembayaranKasir(123);

            // Assert
            Assert.AreEqual("Pesanan sedang disiapkan", order.status[0].statusOrder);
        }

        [TestMethod]
        public void MengubahStatusPesananTenant_KonfirmasiPembayaran()
        {
            // Arrange
            var order = new order(
                    "Kansas",
                    new List<orderStatus> { new orderStatus(789, "Menunggu konfirmasi pembayaran") },
                    new List<orderItems> { new orderItems("Nasi Kuning", 1), new orderItems("Es Jeruk", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Kuning", 15000, 15000), new paymentDetails("Es Jeruk", 7000, 14000) },
                    "Qris"
                );
            pesanan.addOrder(order);

            // Act
            pesanan.MengubahStatusPesananTenant(789);

            // Assert
            Assert.AreEqual("Pesanan sedang disiapkan", order.status[0].statusOrder);
        }

        [TestMethod]
        public void MengubahStatusPesananTenant_PesananSudahSelesai()
        {
            // Arrange
            var order = new order(
                    "Kansas",
                    new List<orderStatus> { new orderStatus(789, "Pesanan sedang disiapkan") },
                    new List<orderItems> { new orderItems("Nasi Kuning", 1), new orderItems("Es Jeruk", 2) },
                    new List<paymentDetails> { new paymentDetails("Nasi Kuning", 15000, 15000), new paymentDetails("Es Jeruk", 7000, 14000) },
                    "Qris"
                );
            pesanan.addOrder(order);

            // Act
            pesanan.MengubahStatusPesananTenant(789);

            // Assert
            Assert.AreEqual("Pesanan sudah selesai", order.status[0].statusOrder);
        }



    }
}

