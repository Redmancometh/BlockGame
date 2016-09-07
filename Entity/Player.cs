using UnityEngine;
using System.Collections;
using System;
using StarColony;

public class Player : MonoBehaviour, Entity
{
    public PlayerInventory inventory { get; set; }
    public PlayerGUIManager gui { get; set; }
    private string playerName = "Redmancometh";
    private KeyPoller poller = new KeyPoller();
    string getName()
    {
        return playerName;
    }

    public InventoryItem getItemInHand()
    {
        return inventory.getItem(inventory.getHeldSlot());
    }

    public bool hasItemInHand()
    {
        return inventory.hasItemAtIndex(inventory.getHeldSlot());
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void Start()
    {
        inventory = new PlayerInventory();
        gui = new PlayerGUIManager();
    }

    void OnGUI()
    {
        gui.draw(poller, this);
    }

    public void Update()
    {
        poller.tick();
        this.inventory.setHeldSlot(poller.HeldSlot);
    }

    public string getPlayerName()
    {
        return playerName;
    }

    string Entity.getName()
    {
        return playerName;
    }
}
