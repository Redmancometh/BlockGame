using UnityEngine;
using System.Collections;

public class InventoryItem
{
    private ushort itemID { get; set; }
    private int quantity { get; set; }
    public InventoryItem(ushort itemID)
    {
        this.itemID = itemID;
        this.quantity = 1;
    }

    public InventoryItem(ushort itemID, int amount)
    {
        this.itemID = itemID;
        this.quantity = amount;
    }

}
