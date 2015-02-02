namespace FactoryPattern.Pattern
{
    using CodePatterns.Entities;

    public static class AccountFactory
    {
        public static Account Create(int accountType)
        {
            switch (accountType)
            {
                case 1:
                    return new ChequeAccount();
                    break;
                case 2:
                    return new CreditCardAccount();
                    break;
                default:
                    return new SavingsAccount();
                    break;
            }
        }
    }
}
