using System;

namespace база.Economy
{
    public sealed class Wallet
    {
        public int CurrentBalance { get; private set; }

        public event Action<int, int> OnBalanceChanged;

        public void AddMoney(int toAdd)
        {
            if(toAdd <= 0)
                return;

            CurrentBalance += toAdd;

            OnBalanceChanged?.Invoke(CurrentBalance - toAdd, CurrentBalance);
        }

        public bool RemoveMoney(int toRemove)
        {
            if(toRemove <= 0)
                return false;

            if (CurrentBalance < toRemove)
                return false;

            CurrentBalance -= toRemove;
            OnBalanceChanged?.Invoke(CurrentBalance + toRemove, CurrentBalance);
            return true;
        }
    }
}
