// <copyright file="ValidatorTests.cs" company="Balázs Keresztury">
// Copyright (c) Balázs Keresztury. All rights reserved.
// </copyright>

using HungarianBankAccount;
using NUnit.Framework;

namespace HungarianBankAccountTests
{
    /// <summary>
    /// Tests various valid and invalid account numbers.
    /// </summary>
    [TestFixture]
    public class ValidatorTests
    {
        /// <summary>
        /// Tests if valid bank account numbers are recognized.
        /// </summary>
        /// <param name="accountNumber">Bank account number.</param>
        [TestCase("109180010000041626260018")]
        [TestCase("10918001-00000416-26260018")]
        [TestCase("100320000107634900000000")]
        [TestCase("10032000-01076349-00000000")]
        [TestCase("1003200001076349")]
        [TestCase("10032000-01076349")]
        public void TestValid(string accountNumber)
        {
            Assert.That(Validator.Validate(accountNumber), Is.True);
        }

        /// <summary>
        /// Tests if correctly formatted but mathematically invalid bank account numbers are recognized as such.
        /// </summary>
        /// <param name="accountNumber">Bank account number.</param>
        [TestCase("109180010000041626260017")]
        [TestCase("10918001-00000416-26260017")]
        [TestCase("100320000107634900000001")]
        [TestCase("10032000-01076349-00000001")]
        [TestCase("1003200001076348")]
        [TestCase("10032000-01076348")]
        public void TestBadChecksum(string accountNumber)
        {
            Assert.That(Validator.Validate(accountNumber), Is.False);
        }

        /// <summary>
        /// Tests if bank account numbers not meeting basic format are recognized as invalid.
        /// </summary>
        /// <param name="accountNumber">Bank account number.</param>
        [TestCase("10032000010763490000000")]
        [TestCase("10032000-01076349-0000000")]
        [TestCase("100320000107634")]
        [TestCase("10032000-0107634")]
        [TestCase("10032000010763490000000a")]
        [TestCase("10032000-01076349-0000000a")]
        [TestCase("100320000107634a")]
        [TestCase("10032000-0107634a")]
        public void TestBadFormat(string accountNumber)
        {
            Assert.That(Validator.Validate(accountNumber), Is.False);
        }
    }
}
