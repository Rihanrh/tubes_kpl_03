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

            while (am.currentState != AccountMachine.State.End)
            {
                Console.WriteLine("Pilih Menu:");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. End");
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        am.activeTrigger(AccountMachine.Trigger.RegisButton);
                        Console.WriteLine("\nAnda berada di halaman Registrasi");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Tenant");
                        Console.WriteLine("3. Kasir");
                        Console.WriteLine("4. Cancel");
                        int regisSelect = Convert.ToInt32(Console.ReadLine());

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
                                am.activeTrigger(AccountMachine.Trigger.Cancel);
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.");
                                break;
                        }
                        break;

                    case 2:
                        am.activeTrigger(AccountMachine.Trigger.LoginButton);
                        Console.WriteLine("\nAnda berada di halaman Login");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Tenant");
                        Console.WriteLine("3. Kasir");
                        Console.WriteLine("4. Cancel");
                        int loginSelect = Convert.ToInt32(Console.ReadLine());

                        switch (loginSelect)
                        {
                            case 1:
                                am.activeTrigger(AccountMachine.Trigger.SelectPembeli);
                                am.Login();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                am.MainScreen();
                                break;
                            case 2:
                                am.activeTrigger(AccountMachine.Trigger.SelectTenant);
                                am.Login();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                am.MainScreen();
                                break;
                            case 3:
                                am.activeTrigger(AccountMachine.Trigger.SelectKasir);
                                am.Login();
                                am.activeTrigger(AccountMachine.Trigger.Submit);
                                am.MainScreen();
                                break;
                            case 4:
                                am.activeTrigger(AccountMachine.Trigger.Cancel);
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.");
                                break;
                        }
                        break;

                    case 3:
                        am.activeTrigger(AccountMachine.Trigger.Cancel);
                        break;

                    default:
                        Console.WriteLine("Pilihan Invalid.");
                        break;
                }

            }

            Console.WriteLine("Program diberhentikan.");
        }
    }
}