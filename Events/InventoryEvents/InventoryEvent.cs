using UnityEngine;
using System.Collections;

public class InventoryEvent : Event
{
    private Inventory inv;
    public InventoryEvent(Inventory inv)
    {
        this.inv = inv;
    }

    public Inventory getInventory()
    {
        return inv;
    }

}
