using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagyarNemzetiBank;

namespace MagyarNemzetiBank.BankAccountExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string validAccountNumber = "10032000-01076349";
            var accountValid = new BankAccount(validAccountNumber);
            System.Console.WriteLine($"{accountValid.AccountNumber}: IsValid = {accountValid.IsValid}, Bank = {accountValid.Bank}");

            var accountInvalidNumber = new BankAccount("00000000-00000000-00000001");
            System.Console.WriteLine($"{accountInvalidNumber.AccountNumber}: IsValid = {accountInvalidNumber.IsValid}");
            try
            {
                System.Console.WriteLine($"Checking bank details for {accountInvalidNumber.AccountNumber}");
                System.Console.WriteLine(accountInvalidNumber.Bank);
            }
            catch (FormatException)
            {
                System.Console.WriteLine($"{typeof(FormatException)} was thrown because account number was not valid");
            }

            var accountInvalidBank = new BankAccount("00000000-00000000");
            System.Console.WriteLine($"{accountInvalidBank.AccountNumber}: IsValid = {accountInvalidBank.IsValid} (it's technically valid)");
            try
            {
                System.Console.WriteLine($"Checking bank details for {accountInvalidBank.AccountNumber}");
                System.Console.WriteLine(accountInvalidBank.Bank);
            }
            catch (KeyNotFoundException)
            {
                System.Console.WriteLine($"{typeof(KeyNotFoundException)} was thrown, because the bank account number doesn't belong to any known bank.");
            }
            System.Console.ReadKey();
        }
    }
}
