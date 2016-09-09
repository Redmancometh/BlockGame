using UnityEngine;
using System.Collections;

public class CuboidBounds
{
    public int lowXBound {get; set;}
    public int lowYBound {get; set;}
    public int lowZBound {get; set;}

    public int highXBound {get; set;}
    public int highYBound {get; set;}
    public int highZBound {get; set;}

    public CuboidBounds(int lowXBound,int lowYBound,int lowZBound,int highXBound,int highYBound,int highZBound)
    {
        this.lowXBound = lowXBound;
        this.lowYBound = lowYBound;
        this.lowZBound = lowXBound;
        this.highXBound = lowXBound;
        this.highYBound = lowYBound;

    }
}
