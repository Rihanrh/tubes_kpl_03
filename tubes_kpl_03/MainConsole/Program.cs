using MainConsole;

class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();
        
        menu.MenambahMenu(menu.MembuatMenu());
        menu.MenambahMenu(menu.MembuatMenu());
        menu.showAllMenu();

        menu.UbahMenu("potato", "Big potato", 1000000, "its big", new List<string> { "g1", "g2" });
        menu.showAllMenu();

        menu.HapusMenu("Mie");
        menu.showAllMenu();
    }
}