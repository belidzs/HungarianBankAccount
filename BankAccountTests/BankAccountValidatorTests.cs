using NUnit.Framework;

namespace MagyarNemzetiBank.Tests
{
    [TestFixture]
    public class BankAccountValidatorTests
    {
        [TestCase("109180010000041626260018")]
        [TestCase("10918001-00000416-26260018")]
        [TestCase("100320000107634900000000")]
        [TestCase("10032000-01076349-00000000")]
        [TestCase("1003200001076349")]
        [TestCase("10032000-01076349")]
        public void TestValid(string accountNumber)
        {
            Assert.That(BankAccountValidator.Validate(accountNumber), Is.True);
        }

        [TestCase("109180010000041626260017")]
        [TestCase("10918001-00000416-26260017")]
        [TestCase("100320000107634900000001")]
        [TestCase("10032000-01076349-00000001")]
        [TestCase("1003200001076348")]
        [TestCase("10032000-01076348")]
        public void TestBadChecksum(string accountNumber)
        {
            Assert.That(BankAccountValidator.Validate(accountNumber), Is.False);
        }

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
            Assert.That(BankAccountValidator.Validate(accountNumber), Is.False);
        }
    }
}
