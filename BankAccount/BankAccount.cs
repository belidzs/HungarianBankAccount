using System;
using System.Collections.Generic;

namespace MagyarNemzetiBank
{
    public class BankAccount
    {
        /// <summary>
        /// Bank Account Number in the format of 00000000-00000000 or 00000000-00000000-00000000 with or without the hyphens
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Tells whether the bank account's account number is valid
        /// </summary>
        public bool IsValid => BankAccountValidator.Validate(AccountNumber);
        /// <summary>
        /// Name of the bank the BankAccount belongs to
        /// </summary>
        public string Bank
        {
            get
            {
                if (IsValid)
                {
                    return _giroBankDictionary[Convert.ToInt32(AccountNumber.Substring(0, 3))];
                }
                else
                {
                    throw new FormatException("Invalid Bank Account");
                }
            }
        } 

        // https://www.mnb.hu/letoltes/hitelintezetek-azonosito-adatai.pdf
        private readonly Dictionary<int, string> _giroBankDictionary = new Dictionary<int, string>()
        {
            { 181, "Allianz Bank Zrt." },
            { 644, "Alsónémedi és Vidéke Takarékszövetkezet" },
            { 807, "Alsónémedi Általános Közlekedési Hitelszövetkezet" },
            { 175, "Bank of China Zrt." },
            { 179, "Bank Plus Bank Zrt." },
            { 131, "BNP Paribas Hungária Bank Zrt." },
            { 183, "BNP Paribas Magyarországi Fióktelepe" },
            { 101, "Budapest Hitel és Fejlesztési Bank Zrt." },
            { 107, "CIB Közép-Európai Nemzetközi Bank Zrt." },
            { 108, "Citibank Budapest Zrt." },
            { 180, "Cofidis Magyarországi Fióktelep" },
            { 142, "Commerzbank Budapest Zrt." },
            { 172, "Credigen Bank Zrt." },
            { 136, "CaLyon Bank Magyarország Zrt." },
            { 185, "Calyon S.A. Magyarország Bankfióktelep" },
            { 135, "KDB Bank (Magyarország) Zrt." },
            { 163, "Deutche Bank Zrt." },
            { 177, "Dresdner Bank AG Magyarországi Fióktelepe" },
            { 116, "Erste Bank Hungary Zrt." },
            { 170, "Ella Első Lakáshitel Kereskedelmi Bank Zrt." },
            { 168, "FHB Földhitel és Jelzálog Bank Nyrt." },
            { 182, "FHB Kereskedelmi Bank Zrt." },
            { 178, "Fortis Bank SA/NV Magyarországi Fióktelepe" },
            { 880, "Fundamenta Lakáskassza Lakástakarékpénztár Zrt." },
            { 619, "Füzesabony és Vidéke Takarékszövetkezet, Füzesabony" },
            { 603, "Hajdúdorog és Vidéke Takarékszövetkezet" },
            { 114, "Hawha Bank Magyarország Zrt." },
            { 162, "HBW Express Takarékszövetkezet" },
            { 109, "UniCredit Bank Hungary Zrt." },
            { 171, "UniCredit Jelzálogbank Zrt." },
            { 147, "IC Bank Zrt." },
            { 111, "Inter-Európa Bank Zrt."},
            { 137, "ING Bank (Magyarország) Zrt." },
            { 104, "Kereskedelmi és Hitelbank Zrt." },
            { 144, "Központi Elszámolóház és Értéktár Zrt. (KELER)" },
            { 100, "Magyar Államkincstár" },
            { 146, "Magyar Fejlesztési Bank Zrt." },
            { 167, "Magyar Cetelem Bank Zrt." },
            { 148, "Magyar Export-Import Bank Zrt. (Eximbank)" },
            { 103, "Magyar Külkereskedelmi Bank Nyrt." },
            { 190, "Magyar Nemzeti Bank" },
            { 115, "Magyar Takarékszövetkezeti Bank Zrt." },
            { 141, "Magyarországi Volksbank Zrt." },
            { 503, "Mecsek-Vidéke Takarékszövetkezet, Mecseknádasd" },
            { 128, "Merkantil Bank Zrt." },
            { 652, "Nagykáta és Vidéke Takarékszövetkezet, Nagykáta" },
            { 184, "Oberbank AG Magyarországi Fióktelepe" },
            { 117, "Országos Takarékpénztár és Kereskedelmi Bank Nyrt." },
            { 884, "OTP Jelzálogbank Zrt." },
            { 881, "OTP Lakástakarékpénztár Zrt." },
            { 655, "Örkényi Takarékszövetkezet, Örkény" },
            { 657, "Pilisvörösvár és Vidéke Takarékszövetkezet, Pilisvörösvár" },
            { 160, "Porsche Bank Hungária Zrt." },
            { 120, "Raiffeisen Bank Zrt." },
            { 506, "Siklós és Vidéke Takarékszövetkezet, Siklós" },
            { 527, "Soltvadkert és Vidéke Takarékszövetkezet, Soltvadkert" },
            { 176, "EB und HYPO Bank Burgenland-Sopron Zrt." },
            { 539, "Szarvas és Vidéke Takarékszövetkezet, Szarvas" },
            { 572, "Szegvár és Vidéke Takarékszövetkezet, Szegvár" },
            { 808, "Széchenyi István Hitelszövetkezet" },
            { 700, "Tiszaföldvár és Vidéke Takarékszövetkezet, Tiszaföldvár" },
            { 803, "Tiszántúli Első Hitelszövetkezet" },
            { 659, "Turai Takarékszövetkezet, Tura" },
            { 121, "Westdeutche Landesbank (Hungária) Zrt." }
        };

        /// <summary>
        /// Bank Account
        /// </summary>
        /// <param name="accountNumber">Bank Account Number in the format of 00000000-00000000 or 00000000-00000000-00000000 with or without the hyphens</param>
        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
