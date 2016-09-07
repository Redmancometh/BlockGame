using UnityEngine;
using System.Collections;

public class PlayerInventory : Inventory
{
    private int heldSlot = 0;
    public int getHeldSlot()
    {
        return heldSlot;
    }

    public void setHeldSlot(int heldSlot)
    {
        this.heldSlot = heldSlot;
    }
}
