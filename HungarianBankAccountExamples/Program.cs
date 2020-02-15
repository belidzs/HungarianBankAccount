// <copyright file="Program.cs" company="Balázs Keresztury">
// Copyright (c) Balázs Keresztury. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using HungarianBankAccount;

namespace HungarianBankAccountExamples
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        public static void Main()
        {
            string validAccountNumber = "10032000-01076349";
            var accountValid = new BankAccount(validAccountNumber);
            Console.WriteLine($"{accountValid.AccountNumber}: IsValid = {accountValid.IsValid}, Bank = {accountValid.Bank}");

            var accountInvalidNumber = new BankAccount("00000000-00000000-00000001");
            Console.WriteLine($"{accountInvalidNumber.AccountNumber}: IsValid = {accountInvalidNumber.IsValid}");
            try
            {
                Console.WriteLine($"Checking bank details for {accountInvalidNumber.AccountNumber}");
                Console.WriteLine(accountInvalidNumber.Bank);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{typeof(FormatException)} was thrown because account number was not valid");
            }

            var accountInvalidBank = new BankAccount("00000000-00000000");
            Console.WriteLine($"{accountInvalidBank.AccountNumber}: IsValid = {accountInvalidBank.IsValid} (it's technically valid)");
            try
            {
                Console.WriteLine($"Checking bank details for {accountInvalidBank.AccountNumber}");
                Console.WriteLine(accountInvalidBank.Bank);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"{typeof(KeyNotFoundException)} was thrown because the bank account number doesn't belong to any known bank.");
            }

            Console.ReadKey();
        }
    }
}
