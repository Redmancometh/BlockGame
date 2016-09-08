using UnityEngine;
using System.Collections;
using System;

namespace StarColony
{
    public abstract class SentientEntity : LivingEntity, ConversableEntity
    {
        public abstract void talkTo();
    }
}
