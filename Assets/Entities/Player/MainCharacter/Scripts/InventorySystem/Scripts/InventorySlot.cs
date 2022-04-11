using InventorySystem.Scripts.ScriptableObjects;

namespace InventorySystem.Scripts
{
    public class InventorySlot
    {
        public int Amount { get; private set; }
        public readonly ResourceItemData Item;
        public InventorySlot(ResourceItemData item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public bool TryIncreaseAmount(int increaseAmount, out int extraAmount)
        {
            if (Amount + increaseAmount > Item.MaximumAmountInSlot)
            {
                extraAmount = Amount + increaseAmount - Item.MaximumAmountInSlot;
                Amount += increaseAmount - extraAmount;
                return false;
            }

            extraAmount = 0;
            Amount += increaseAmount;
            return true;
        }

        public bool TryDecreaseAmount(int decreaseAmount)
        {
            if (Amount < decreaseAmount) return false;
            Amount -= decreaseAmount;
            return true;
        }
    }
}
