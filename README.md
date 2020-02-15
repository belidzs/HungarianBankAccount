# HungarianBankAccount
This library written in C# checks the validity of a Hungarian bank account number (in GIRO format) and determines which bank it belongs to.

## Usage
Let's check a valid bank account:

```csharp
string validAccountNumber = "10032000-01076349";
var accountValid = new BankAccount(validAccountNumber);
System.Console.WriteLine($"{accountValid.AccountNumber}: IsValid = {accountValid.IsValid}, Bank = {accountValid.Bank}");
```

An invalid bank account will return `IsValid = false` and throws `FormatException` when `Bank` property is read:

```csharp
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
```

When the syntax of the bank account number is correct, but it doesn't belong to any known bank `KeyNotFoundException` is thrown:

```csharp
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
```

Alternatively you can use the static `Validator.Validate(string accountNumber)` method to check if the number is syntactically and mathematically correct.

## Download from Nuget
[!['nuget badge'](https://img.shields.io/nuget/v/HungarianBankAccount.svg)](https://www.nuget.org/packages/HungarianBankAccount/)
