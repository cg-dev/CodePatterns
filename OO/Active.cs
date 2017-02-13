namespace OO
{
    using System;

    public class Active : IAccountState
    {
        private Action OnUnFreeze { get; }

        public Active (Action onUnUnFreeze)
        {
            this.OnUnFreeze = onUnUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(this.OnUnFreeze);

        public IAccountState Verified() => this;

        public IAccountState Close() => new Closed();
    }
}