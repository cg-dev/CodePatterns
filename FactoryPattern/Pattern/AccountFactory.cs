namespace FactoryPattern.Pattern
{
    using CodePatterns.Entities;

    using FactoryPattern.Tests;

    public static class AccountFactory
    {
        public static Account Create(AccountTypes accountType)
        {
            switch (accountType)
            {
                case AccountTypes.ChequeAccount:
                    return new ChequeAccount();
                case AccountTypes.CreditCardAccount:
                    return new CreditCardAccount();
                case AccountTypes.SavingsAccount:
                    return new SavingsAccount();
            }
            return null;
        }
    }
}