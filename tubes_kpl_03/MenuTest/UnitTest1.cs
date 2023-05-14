using MainConsole;
using System;

namespace MenuTest
{
    [TestClass]
    public class UnitTest_MembuatMenu
    {
        [TestMethod]
        public void TestMembuatMenuValid()
        {
            // Arrange
            MenuMakanan<string> expectedMenu = new MenuMakanan<string>("Nasi Goreng", new List<string> { "image1.png", "image2.png" }, 25000.0, "Nasi Goreng with chicken and vegetables.");
            Menu menu = new Menu();

            var stringReader = new StringReader("Nasi Goreng\nimage1.png\nY\nimage2.png\nN\n25000\nNasi Goreng with chicken and vegetables.");
            Console.SetIn(stringReader);

            // Act
            MenuMakanan<string> actualMenu = menu.MembuatMenu();

            // Assert
            Assert.AreEqual(expectedMenu.name_menu, actualMenu.name_menu);
            CollectionAssert.AreEqual(expectedMenu.path_images, actualMenu.path_images);
            Assert.AreEqual(expectedMenu.harga_menu, actualMenu.harga_menu);
            Assert.AreEqual(expectedMenu.deskripsi_menu, actualMenu.deskripsi_menu);
        }
        [TestMethod]
        public void TestMenambahMenu()
        {
            // Arrange
            var menu = new Menu();
            var menuMakanan = new MenuMakanan<string>("Nasi Goreng", new List<string> { "img1.jpg", "img2.jpg" }, 20000, "Nasi goreng enak");

            // Act
            menu.MenambahMenu(menuMakanan);

            // Assert
            Assert.AreEqual(1, menu.DaftarMenu.Count);
            Assert.AreEqual("Nasi Goreng", menu.DaftarMenu[0].name_menu);
        }
        [TestMethod]
        public void TestHapusMenu()
        {
            // Arrange
            var menuMakanan1 = new MenuMakanan<string>("Nasi Goreng", new List<string> { "nasi_goreng.png" }, 15000, "Nasi goreng spesial");
            var menuMakanan2 = new MenuMakanan<string>("Mie Ayam", new List<string> { "mie_ayam.png" }, 12000, "Mie ayam pedas");
            var daftarMenu = new List<MenuMakanan<string>> { menuMakanan1, menuMakanan2 };
            var menu = new Menu { DaftarMenu = daftarMenu };

            // Act
            menu.HapusMenu("Nasi Goreng");

            // Assert
            Assert.AreEqual(1, daftarMenu.Count);
            Assert.IsFalse(daftarMenu.Any(menu => menu.name_menu.Equals("Nasi Goreng")));
        }
        [TestMethod]
        public void TestUbahMenu()
        {
            // Arrange
            var menuMakanan = new MenuMakanan<string>("Nasi Goreng", new List<string> { "path/to/image1", "path/to/image2" }, 15000, "Nasi goreng dengan bumbu rempah yang lezat");

            var menu = new Menu();
            menu.MenambahMenu(menuMakanan);

            // Act
            menu.UbahMenu("Nasi Goreng", "Nasi Goreng Spesial", 20000, "Nasi goreng dengan bumbu rempah yang lebih pedas", new List<string> { "path/to/image1", "path/to/image2", "path/to/image3" });

            // Assert
            var updatedMenu = menu.DaftarMenu.FirstOrDefault(m => m.name_menu == "Nasi Goreng Spesial");
            Assert.IsNotNull(updatedMenu);
            Assert.AreEqual("Nasi Goreng Spesial", updatedMenu.name_menu);
            Assert.AreEqual(20000, updatedMenu.harga_menu);
            Assert.AreEqual("Nasi goreng dengan bumbu rempah yang lebih pedas", updatedMenu.deskripsi_menu);
            CollectionAssert.AreEqual(new List<string> { "path/to/image1", "path/to/image2", "path/to/image3" }, updatedMenu.path_images);
        }
    }
}