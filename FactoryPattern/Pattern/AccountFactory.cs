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
                    break;
                case AccountTypes.CreditCardAccount:
                    return new CreditCardAccount();
                    break;
                case AccountTypes.SavingsAccount:
                    return new SavingsAccount();
                    break;
            }
            return null;
        }
    }
}