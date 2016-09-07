using UnityEngine;
using System.Collections;

public interface Cancellable
{
    bool isCancelled();
    void setCancelled(bool cancelled);
}
