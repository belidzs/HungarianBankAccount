// <copyright file="BankAccountTests.cs" company="Balázs Keresztury">
// Copyright (c) Balázs Keresztury. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MagyarNemzetiBank.Tests
{
    /// <summary>
    /// Tests for the BankAccount class.
    /// </summary>
    [TestFixture]
    public class BankAccountTests
    {
        /// <summary>
        /// Tests if a valid bank account number belonging to a known bank is recognized.
        /// </summary>
        [Test]
        public void TestKnownBank()
        {
            var testAccount = new BankAccount("10032000-01076349-00000000");
            Assert.That(testAccount.Bank, Is.EqualTo("Magyar Államkincstár"));
        }

        /// <summary>
        /// Tests if reading bank information of a valid bank account number which doesn't belong to a known bank throws an exception.
        /// </summary>
        [Test]
        public void TestUnknownBank()
        {
            var testAccount = new BankAccount("00000000-00000000");
            Assert.That(() => testAccount.Bank, Throws.InstanceOf(typeof(KeyNotFoundException)));
        }

        /// <summary>
        /// Tests if an invalid bank account number is recognized as such and an exception is thrown.
        /// </summary>
        [Test]
        public void TestInvalidFormat()
        {
            var testAccount = new BankAccount("10032000-01076349-00000001");
            Assert.That(() => testAccount.Bank, Throws.InstanceOf(typeof(FormatException)));
        }
    }
}
