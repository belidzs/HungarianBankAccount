using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MagyarNemzetiBank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void TestKnownBank()
        {
            var testAccount = new BankAccount("10032000-01076349-00000000");
            Assert.That(testAccount.Bank, Is.EqualTo("Magyar Államkincstár"));
        }

        [Test]
        public void TestUnknownBank()
        {
            var testAccount = new BankAccount("00000000-00000000");
            Assert.That(() => testAccount.Bank, Throws.InstanceOf(typeof(KeyNotFoundException)));
        }

        [Test]
        public void TestInvalidFormat()
        {
            var testAccount = new BankAccount("10032000-01076349-00000001");
            Assert.That(() => testAccount.Bank, Throws.InstanceOf(typeof(FormatException)));
        }
    }
}
