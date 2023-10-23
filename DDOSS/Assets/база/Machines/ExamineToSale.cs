using UnityEngine;

public sealed class ExamineToSale : MonoBehaviour, IExaminable
{
    public AudioSource saleSource;

    private Inventory _inventory;
    private Wallet _wallet;

    private void Construct(Inventory inventory, Wallet wallet)
    {
        _inventory = inventory;
        _wallet = wallet;
    }

    public void Examine()
    {
        var allItems = inventory.GetAll();

        foreach(var item in allItems)
        {
            if(item is ISellable)
            {
                wallet.AddMoney(item.Price);
                _inventory.Remove(item);
            }
        }
    }
}
