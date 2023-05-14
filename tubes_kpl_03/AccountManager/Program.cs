// See https://aka.ms/new-console-template for more information
using System;
using static AccountManager.AccountMachine;

namespace AccountManager
{
    class program
    {
        public static void Main(string[] args)
        {
            AccountMachine am = new AccountMachine();
            am.currentState = AccountMachine.State.Start;

            Console.WriteLine("Selamat datang.");

            int selection = 0;
            while (am.currentState != AccountMachine.State.End)
            {
                switch (selection)
                {
                    case 0:
                        Console.WriteLine("Pilih Menu:");
                        Console.WriteLine("1. Registrasi");
                        Console.WriteLine("2. Login");
                        Console.WriteLine("3. End");

                        try
                        {
                            selection = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input invalid. Tolong masukkan inputan angka.\n");
                            continue;
                        }
                        break;

                    case 1:
                        am.activeTrigger(AccountMachine.Trigger.RegisButton);
                        Console.WriteLine("Anda berada di halaman Registrasi");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Tenant");
                        Console.WriteLine("3. Kasir");
                        Console.WriteLine("4. Cancel");
                        int regisSelect;

                        try
                        {
                            regisSelect = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input invalid. Tolong masukkan inputan angka.\n");
                            continue;
                        }

                        switch (regisSelect)
                        {
                            case 1:
                                am.activeTrigger(AccountMachine.Trigger.SelectPembeli);
                                am.Register();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                break;
                            case 2:
                                am.activeTrigger(AccountMachine.Trigger.SelectTenant);
                                am.Register();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                break;
                            case 3:
                                am.activeTrigger(AccountMachine.Trigger.SelectKasir);
                                am.Register();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                break;
                            case 4:
                                Console.WriteLine("Kembali ke halaman Registrasi/Login.\n");
                                am.activeTrigger(AccountMachine.Trigger.Cancel);
                                selection = 0;
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.");
                                break;
                        }
                        break;

                    case 2:
                        am.activeTrigger(AccountMachine.Trigger.LoginButton);
                        Console.WriteLine("Anda berada di halaman Login");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Tenant");
                        Console.WriteLine("3. Kasir");
                        Console.WriteLine("4. Cancel");
                        int loginSelect;

                        try
                        {
                            loginSelect = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input invalid. Tolong masukkan inputan angka.\n");
                            continue;
                        }

                        switch (loginSelect)
                        {
                            case 1:
                                am.activeTrigger(AccountMachine.Trigger.SelectPembeli);
                                am.Login();
                                if (am.currentState == AccountMachine.State.PembeliScreen)
                                {
                                    am.MainScreen();
                                }
                                break;
                            case 2:
                                am.activeTrigger(AccountMachine.Trigger.SelectTenant);
                                am.Login();
                                if (am.currentState == AccountMachine.State.TenantScreen)
                                {
                                    am.MainScreen();
                                }
                                break;
                            case 3:
                                am.activeTrigger(AccountMachine.Trigger.SelectKasir);
                                am.Login();
                                if (am.currentState == AccountMachine.State.KasirScreen)
                                {
                                    am.MainScreen();
                                }
                                break;
                            case 4:
                                Console.WriteLine("Kembali ke halaman Registrasi/Login.\n");
                                am.activeTrigger(AccountMachine.Trigger.Cancel);
                                selection = 0;
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.\n");
                                break;
                        }
                        break;

                    case 3:
                        am.activeTrigger(AccountMachine.Trigger.Cancel);
                        break;

                    default:
                        Console.WriteLine("Pilihan Invalid.\n");
                        selection = 0;
                        break;
                }

            }

            Console.WriteLine("Program diberhentikan.");
        }
    }
}