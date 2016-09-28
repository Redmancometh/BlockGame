using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Colonist;

public class WorldManager
{
    private Dictionary<string, Colonist.World> worldMap = new Dictionary<string, Colonist.World>();
    private Queue<World> worldProcessQueue = new Queue<World>();
        
    public void processWorlds()
    {

        Colonist.World world;
    }

    public void processWorld(Colonist.World world)
    {

    }

    public void loadWorld(string name)
    {

    }

    public void unloadWorld(string name)
    {

    }


}


