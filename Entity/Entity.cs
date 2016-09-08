using UnityEngine;
using System.Collections;

public interface Entity
{
    string getName();
    void onCollideWithEntity(Entity e);
}
