using UnityEngine;
using System.Collections;

public class InventoryClickEvent : InventoryInteractEvent
{
    private int slot = 0;
    public InventoryClickEvent(Inventory inv, Player clicker, int slot) : base(inv, clicker)
    {
        this.slot = slot;
    }

    public int getSlot()
    {
        return slot;
    }
}
