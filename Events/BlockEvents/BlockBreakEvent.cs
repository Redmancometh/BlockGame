using UnityEngine;
using System.Collections;
using System;

public class BlockBreakEvent : CancellableEvent
{
    private Player player;
    private bool cancelled = false;
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

    public BlockBreakEvent(Player player)
    {
        this.player = player;
    }

}
