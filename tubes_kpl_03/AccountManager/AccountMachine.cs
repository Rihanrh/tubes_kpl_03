using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    internal class AccountMachine
    {
        public enum State { Start, Login, Registration, 
            PembeliRegistration, TenantRegistration, KasirRegistration, 
            PembeliLogin, TenantLogin, KasirLogin, 
            PembeliScreen, TenantScreen, KasirScreen,
            End };
        public enum Trigger { SelectPembeli, SelectTenant, SelectKasir, RegisButton, LoginButton, Submit, Cancel };

        class transition
        {
            public State prevState;
            public State nextState;
            public Trigger trigger;

            public transition(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        transition[] transitions =
        {
            // Bagian Start
            new transition(State.Start, State.Registration, Trigger.RegisButton),
            new transition(State.Start, State.Login, Trigger.LoginButton),
            new transition(State.Start, State.End, Trigger.Cancel),

            // Bagian Registration
            new transition(State.Registration, State.PembeliRegistration, Trigger.SelectPembeli),
            new transition(State.Registration, State.TenantRegistration, Trigger.SelectTenant),
            new transition(State.Registration, State.KasirRegistration, Trigger.SelectKasir),
            new transition(State.Registration, State.End, Trigger.Cancel),

            new transition(State.PembeliRegistration, State.Start, Trigger.Submit),
            new transition(State.PembeliRegistration, State.Registration, Trigger.Cancel),

            new transition(State.TenantRegistration, State.Start, Trigger.Submit),
            new transition(State.TenantRegistration, State.Registration, Trigger.Cancel),

            new transition(State.KasirRegistration, State.Start, Trigger.Submit),
            new transition(State.KasirRegistration, State.Registration, Trigger.Cancel),

            // Bagian Login
            new transition(State.Login, State.PembeliLogin, Trigger.SelectPembeli),
            new transition(State.Login, State.TenantLogin, Trigger.SelectTenant),
            new transition(State.Login, State.KasirLogin, Trigger.SelectKasir),
            new transition(State.Login, State.End, Trigger.Cancel),

            new transition(State.PembeliLogin, State.PembeliScreen, Trigger.Submit),
            new transition(State.PembeliLogin, State.Login, Trigger.Cancel),

            new transition(State.TenantLogin, State.TenantScreen, Trigger.Submit),
            new transition(State.TenantLogin, State.Login, Trigger.Cancel),

            new transition(State.KasirLogin, State.KasirScreen, Trigger.Submit),
            new transition(State.KasirLogin, State.Login, Trigger.Cancel),

            // Bagian MainScreen
            new transition(State.PembeliScreen, State.Start, Trigger.Cancel),
            new transition(State.TenantScreen, State.Start, Trigger.Cancel),
            new transition(State.KasirScreen, State.Start, Trigger.Cancel)
        };

        public State currentState;

        public State getNextState(State prevState, Trigger trigger)
        {
            State nextState = prevState;

            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
                {
                    nextState = transitions[i].nextState;
                }
            }
            return nextState;
        }

        public void activeTrigger(Trigger trigger)
        {
            State nextState = getNextState(currentState, trigger);
            currentState = nextState;
        }
        
        public void Register()
        {
            //Preconditions
            Debug.Assert(currentState == AccountMachine.State.PembeliRegistration ||
                currentState == AccountMachine.State.TenantRegistration ||
                currentState == AccountMachine.State.KasirRegistration, "Invalid state");

            if (currentState == AccountMachine.State.PembeliRegistration)
            {
                Console.WriteLine("--Registrasi Pembeli--");
            }
            else if (currentState == AccountMachine.State.TenantRegistration)
            {
                Console.WriteLine("--Registrasi Tenant--");
            }
            else if (currentState == AccountMachine.State.KasirRegistration)
            {
                Console.WriteLine("--Registrasi Kasir--");
            }

            Console.WriteLine("Username (maks: 20 huruf, tidak ada spasi)");
            Console.Write("Input: ");
            string username = Console.ReadLine();
            // Cek panjang username dan apakah terdapat spasi pada username
            if (username.Length > 20 || username.Contains(" "))
            {
                Console.WriteLine("Username tidak valid");
                return;
            }

            Console.WriteLine("Password (maks: 16 karakter, tidak ada spasi)");
            Console.Write("Input: ");
            string password = Console.ReadLine();

            // Cek panjang password dan apakah terdapat spasi pada password
            if (password.Length > 16 || password.Contains(" "))
            {
                Console.WriteLine("Password tidak valid");
                return;
            }

            // Memasukkan data ke dengan teknik Runtime Config
            string tipe_akun = "";
            if (currentState == State.PembeliRegistration)
            {
                tipe_akun = "Pembeli";
            }
            else if (currentState == State.TenantRegistration)
            {
                tipe_akun = "Tenant";
            }
            else if (currentState == State.KasirRegistration)
            {
                tipe_akun = "Kasir";
            }

            Config config = new Config(tipe_akun, username, password);
            AccountConfig acc = new AccountConfig();
            acc.config = config;
            acc.WriteNewConfigFile();

            Console.WriteLine("\nRegistrasi berhasil!");
            Console.WriteLine("Kembali ke halaman Registrasi/Login");
        }

        public void Login()
        {
            //Preconditions
            Debug.Assert(currentState == AccountMachine.State.PembeliLogin ||
                currentState == AccountMachine.State.TenantLogin ||
                currentState == AccountMachine.State.KasirLogin, "Invalid state");

            String tipe_akun = "";
            if (currentState == AccountMachine.State.PembeliLogin)
            {
                Console.WriteLine("--Login Pembeli--");
                tipe_akun = "Pembeli";
            }
            else if (currentState == AccountMachine.State.TenantLogin)
            {
                Console.WriteLine("--Login Tenant--");
                tipe_akun = "Tenant";
            }
            else if (currentState == AccountMachine.State.KasirLogin)
            {
                Console.WriteLine("--Login Kasir--");
                tipe_akun = "Kasir";
            }

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Pengecekan tipe akun, username, password
            AccountConfig acc = new AccountConfig();
            Config config = acc.ReadConfigFile();

            if (tipe_akun == config.tipe_akun && username == config.username && password == config.password)
            {
                Console.WriteLine("Login berhasil!");
            }
            else
            {
                Console.WriteLine("Login gagal, username atau password salah");
            }
        }

        public void MainScreen()
        {
            //Preconditions
            Debug.Assert(currentState == AccountMachine.State.PembeliScreen ||
                currentState == AccountMachine.State.TenantScreen ||
                currentState == AccountMachine.State.KasirScreen, "Invalid state");

            AccountConfig acc = new AccountConfig();
            Config config = acc.ReadConfigFile();

            if (currentState == AccountMachine.State.PembeliScreen)
            {
                Console.WriteLine("Selamat datang, pembeli " + config.username + "!");
            }
            else if (currentState == AccountMachine.State.TenantScreen)
            {
                Console.WriteLine("Selamat datang, tenant " + config.username + "!");
            }
            else if (currentState == AccountMachine.State.KasirScreen)
            {
                Console.WriteLine("Selamat datang, kasir " + config.username + "!");
            }

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Logout");
            string menuMain = Console.ReadLine();

            if (menuMain == "1")
            {
                Console.WriteLine("Logout. Kembali ke halaman Registrasi/Login");
                activeTrigger(Trigger.Cancel);
            }
        }
    }
}
