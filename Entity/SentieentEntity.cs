using UnityEngine;
using System.Collections;
using System;

public abstract class SentientEntity : LivingEntity, ConversableEntity
{
    public abstract void talkTo(); 
}
