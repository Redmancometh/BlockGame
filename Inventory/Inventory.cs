using UnityEngine;
using System.Collections.Generic;

public class Inventory {

    private ItemMap items = new ItemMap();
    public InventoryItem getItem(int index)
    {
        if(!items.ContainsKey(index))
        {
            return new InventoryItem(0);
        }
        return items[index];
    }

    public bool hasItemAtIndex(int index)
    {
        return items.ContainsKey(index);
    }

    public void setItem(int index, InventoryItem item)
    {
        items[index] = item;
    }

}
