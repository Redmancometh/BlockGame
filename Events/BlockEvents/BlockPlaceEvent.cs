using UnityEngine;
using System.Collections;

public class BlockPlaceEvent  {
    private Player player;
    public BlockPlaceEvent(Player player)
    {
        this.player = player;
    }

    public Player getPlayer()
    {
        return player;
    }
}
