using UnityEngine;

public sealed class Wallet
{
    public int CurrentBalance { get; private set; }

    public event Action<int, int> OnBalanceChanged;

    public void Add(int toAdd)
    {
        if(toAdd <= 0)
            return;

        CurrentBalance += toAdd;

        OnBalanceChanged?.Invoke(CurrentBalance - toAdd, CurrentBalance);
    }

    public bool Remove(int toRemove)
    {
        if(toRemove <= 0)
            return;

        if(CurrentBalance < toRemove)
            return;

        CurrentBalance -= toRemove;
        return true;
    }
}
