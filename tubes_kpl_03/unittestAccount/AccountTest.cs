using AccountManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittestAccount
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestRegisterPembeli()
        {
            AccountMachine am = new AccountMachine();
            am.currentState = AccountMachine.State.Start;

            am.activeTrigger(AccountMachine.Trigger.RegisButton);
            am.activeTrigger(AccountMachine.Trigger.SelectPembeli);

            //Simulasi input username dan password
            string userInput = "rihan\n12345d\n";
            using (var stringReader = new StringReader(userInput))
            {
                Console.SetIn(stringReader);

                //Memanggil method Register
                am.Register();
            }
            am.activeTrigger(AccountMachine.Trigger.Submit);
            Assert.AreEqual(AccountMachine.State.Start, am.currentState);
        }

        [TestMethod]
        public void TestLoginPembeli()
        {
            AccountMachine am = new AccountMachine();
            am.currentState = AccountMachine.State.Start;

            am.activeTrigger(AccountMachine.Trigger.LoginButton);
            am.activeTrigger(AccountMachine.Trigger.SelectPembeli);

            //Simulasi input username dan password
            string userInput = "rihan\n12345d\n";
            using (var stringReader = new StringReader(userInput))
            {
                Console.SetIn(stringReader);

                am.Login();
            }
            am.activeTrigger(AccountMachine.Trigger.Submit);
            Assert.AreEqual(AccountMachine.State.PembeliScreen, am.currentState);
        }

        [TestMethod]
        public void TestLogoutDariAkun()
        {
            AccountMachine am = new AccountMachine();

            am.currentState = AccountMachine.State.PembeliScreen;

            string userInput = "1";
            using (var stringReader = new StringReader(userInput))
            {
                Console.SetIn(stringReader);

                am.MainScreen();

            }
            Assert.AreEqual(AccountMachine.State.Start, am.currentState);

        }
    }
}