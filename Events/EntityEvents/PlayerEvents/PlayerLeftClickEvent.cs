using UnityEngine;
using System.Collections;
using System;

public class PlayerLeftClickEvent : CancellableEvent
{
    private Player player;
    private bool cancelled = false;
    public PlayerLeftClickEvent(Player player)
    {
        this.player = player;
    }
    public Player getPlayer()
    {
        return player;
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
