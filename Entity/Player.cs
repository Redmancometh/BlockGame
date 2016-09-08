using UnityEngine;
using System.Collections;
using System;
using StarColony;

public class Player : SentientEntity
{
    public PlayerInventory inventory { get; set; }
    public PlayerGUIManager gui { get; set; }
    private string playerName = "Redmancometh";
    private KeyPoller poller = new KeyPoller();
    override public string getName()
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
        this.playerName = name;
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

    override public void onCollideWithEntity(Entity e)
    {
        Debug.Log("Collided with "+e.getName());
    }

    public override void talkTo()
    {
        throw new NotImplementedException();
    }
}
