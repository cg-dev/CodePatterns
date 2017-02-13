namespace OO
{
    using System;

    class Frozen : IAccountState
    {
        private Action OnUnFreeze { get; }

        public Frozen(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnFreeze();
            addToBalance();
            return new Active(this.OnUnFreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnFreeze();
            subtractFromBalance();
            return new Active(this.OnUnFreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState Verified() => this;

        public IAccountState Close() => new Closed();
    }
}