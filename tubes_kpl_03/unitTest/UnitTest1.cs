namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HitungHargaTotal_Returns_CorrectTotal()
        {
            Dictionary<string, int> menu = new Dictionary<string, int>()
            {
                {"Nasi Goreng", 15000 },
                {"Katsu", 18000 },
                {"Mie Goreng", 13000 },
                {"Ayam Geprek", 18000 },
                {"N/A", 0 }
            };
            string input = "1,2,4";

            // Act
            int total = Program.hitungHargaTotal(menu, input);

            // Assert
            Assert.AreEqual(51000, total);
        }

        [TestMethod]
        public void TestHitungHargaTotalMinuman()
        {
            Dictionary<string, int> minuman = new Dictionary<string, int>()
    {
        {"Air Mineral", 4000 },
        {"Es Teh Manis", 5000 },
        {"Lemon Tea", 5000 },
        {"N/A", 0 }
    };

            int hargaTotal = Program.hitungHargaTotal(minuman, "1,2,3");
            Assert.AreEqual(14000, hargaTotal);

            hargaTotal = Program.hitungHargaTotal(minuman, "1,3");
            Assert.AreEqual(9000, hargaTotal);

            hargaTotal = Program.hitungHargaTotal(minuman, "2,2,2");
            Assert.AreEqual(15000, hargaTotal);

            hargaTotal = Program.hitungHargaTotal(minuman, "4");
            Assert.AreEqual(0, hargaTotal);
        }
    }
}