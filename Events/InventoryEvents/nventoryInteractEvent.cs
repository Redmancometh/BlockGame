using UnityEngine;
using System.Collections;
using System;

public class InventoryInteractEvent : InventoryEvent, Cancellable
{
    private bool cancelled = false;
    private Player clicker;
    public InventoryInteractEvent(Inventory inv, Player clicker) : base(inv)
    {
        this.clicker = clicker;
    }

    public Player getClicker()
    {
        return clicker;
    }

    bool Cancellable.isCancelled()
    {
        return cancelled;
    }

    void Cancellable.setCancelled(bool cancelled)
    {
        this.cancelled = cancelled;
    }
}
