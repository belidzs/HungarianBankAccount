/*
* 18/2009. (VIII. 6.) MNB rendelet a pénzforgalom lebonyolításáról
* http://net.jogtar.hu/jr/gen/hjegy_doc.cgi?docid=A0900018.MNB&celpara=#xcelparam
*
* A pénzforgalmi jelzőszám kialakítása
* 1. A belföldi pénzforgalmi jelzőszámot az alábbi szabályoknak megfelelően kell kialakítani:
* a) az első nyolc karakter az irányító kód; az irányító kód első három számjegye a pénzforgalmi szolgáltató azonosító kódja, amely a számlavezető pénzforgalmi szolgáltatót, a következő négy számjegy a pénzforgalmi szolgáltató fiókját vagy számlavezető helyét jelöli, a nyolcadik számjegy ellenőrző szám;
* b) a 9-16. karakter vagy a 9-24. karakter a fizetési számla azonosító száma; 16 karakter hosszúságú számsor esetében a 16. számjegy, 24 karakter hosszúságú számsor esetében a 24. számjegy ellenőrző szám, és a 24 karakter hosszúságú pénzforgalmi jelzőszám 16. számjegye értelemszerűen szabadon kialakítható;
* c) az ellenőrző számok az előttük álló számjegyek ellenőrzésére szolgálnak, melyeket a következő algoritmus szerint kell képezni: külön az 1-7., valamint külön a 9-15. vagy 9-23. számjegyeket helyi értékük csökkenő sorrendjében meg kell szorozni a „9, 7, 3, 1 ... 9, 7, 3, 1” számokkal, a szorzatokat össze kell adni, és az eredmény egyes helyi értékén lévő számot ki kell vonni 10-ből. A különbség az ellenőrző szám. (Ha a különbség „10”, az ellenőrző szám értéke „0”.)
*
*/

using System;
using System.Text.RegularExpressions;

namespace MagyarNemzetiBank
{
    /// <summary>
    /// Static class to validate Hungarian bank account numbers
    /// </summary>
    public static class BankAccountValidator
    {
        // ellenőrzőalgoritmusban meghatározott szorzók
        private static readonly int[] Multipliers = { 9, 7, 3, 1 };
        private const string RegexGiro = "^[0-9]{8}-?[0-9]{8}(-?[0-9]{8})?$";

        /// <summary>
        /// Checks if the given bank account number conforms to the Hungarian bank account number format and performs a parity check
        /// </summary>
        /// <param name="accountNumber">Bank account number with or without hyphens</param>
        /// <returns>True if the account number is valid</returns>
        public static bool Validate(string accountNumber)
        {
            if (accountNumber == null || accountNumber.Equals("")) return true;
            //megfelelés regex formátumnak
            Regex regexGiro = new Regex(RegexGiro);
            if (regexGiro.IsMatch(accountNumber))
            {
                // ha megfelel a regexnek
                // kötőjelek eltávolítása
                accountNumber = accountNumber.Replace("-", "");
                // első nyolc blokk és a maradék ellenőrzése, külön
                return ValidateBlock(accountNumber.Substring(0, 8)) && ValidateBlock(accountNumber.Substring(8));
            }
            else
            {
                // ha nem felel meg már a regexnek sem
                return false;
            }
        }

        private static bool ValidateBlock(string accountNumberBlock)
        {
            int result = 0;
            for (int j = 0; j < accountNumberBlock.Length - 1; j++)
            {
                // szorzatösszeg kalkulálása
                result += Int32.Parse(accountNumberBlock[j].ToString()) * Multipliers[j % 4];
            }
            if ((10 - result % 10) % 10 != Int32.Parse(accountNumberBlock[accountNumberBlock.Length - 1].ToString()))
            {
                // a szorzatösszeg modulo 10 értékét 10-ből kivonva az utolsó számjegyet kell kapni. Ha ez 10, akkor 0-t
                return false;
            }
            return true;
        }
    }
}
