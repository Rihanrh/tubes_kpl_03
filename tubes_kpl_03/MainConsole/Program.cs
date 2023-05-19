using MainConsole;

class Program
{
    private static void Main(string[] args)
    {
        
        // test implementasi membuat, menyuting, menghapus Menu
        Menu menu = new Menu();
        
        menu.MenambahMenu(menu.MembuatMenu());
        menu.MenambahMenu(menu.MembuatMenu());
        menu.showAllMenu();
        Console.WriteLine();

        menu.UbahMenu("potato", "Big potato", 1000000, "its big", new List<string> { "g1", "g2" });
        menu.showAllMenu();
        Console.WriteLine();

        menu.HapusMenu("Mie");
        menu.showAllMenu();
        Console.WriteLine();
        
        Console.WriteLine();
        
        //test implementasi print struk
        List<MenuMakanan<string>> daftarPesanan = new List<MenuMakanan<string>> { };

        MenuMakanan<string> m1 = new MenuMakanan<string>("burger", new List<string> { "g1", "g2" }, 20000, "roti, daging, salad");
        MenuMakanan<string> m2 = new MenuMakanan<string>("sandwich", new List<string> { "g1", "g2" }, 25000, "roti, daging, salad, butter");
        daftarPesanan.Add(m1);
        daftarPesanan.Add(m2);

        Receipt receipt = new Receipt("1001",DateTime.Today,daftarPesanan);
        PrintStruk s1 = new PrintStruk();
        s1.mencetak(daftarPesanan, receipt);

    }
}