using UnityEngine;
using System.Collections;
using System;

public class PlayerMoveEvent : CancellableEvent
{
    private bool cancelled = false;
    private Vector3 from { get; set; }
    private Vector3 to { get; set; }

    public PlayerMoveEvent(Vector3 to, Vector3 from)
    {
        this.to = to;
        this.from = from;
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
