namespace OO
{
    using System;

    public interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState Verified();
        IAccountState Close();
    }
}