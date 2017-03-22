namespace OO
{
    using System;

    public class Account
    {
        public decimal Balance { get; private set; }

        public IAccountState State { get; set; }

        public Account(Action onUnfreeze, decimal openingBalance = 0)
        {
            this.State = new NotVerified(onUnfreeze);
            this.Balance = openingBalance;
        }

        // #1 (Interaction): Deposit was invoked on the State
        // #2 (Behavior): Result of State.Deposit is new State
        // #5 (Behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance += amount; });
        }

        // #3 (Interaction): Withdraw was invoked on the State
        // #4 (Behavior): Result of State.Withdraw is new State
        // #6 (Behavior): Deposit 1, Verify, Withdraw 1 - Balance == 9
        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() => { this.Balance -= amount; });
        }

        public void HolderVerified()
        {
            this.State = this.State.Verified();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }
    }
}