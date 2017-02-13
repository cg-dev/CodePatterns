namespace OO
{
    using System;

    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnFreeze)
        {
            this.OnUnfreeze = onUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState Verified() => new Active(this.OnUnfreeze);

        public IAccountState Close() => new Closed();
    }
}