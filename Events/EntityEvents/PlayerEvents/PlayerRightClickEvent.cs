using UnityEngine;
using System.Collections;

public class PlayerRightClickEvent : CancellableEvent
{
    private Player player;
    private bool cancelled = false;
    public PlayerRightClickEvent(Player player)
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
