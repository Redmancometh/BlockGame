using UnityEngine;
using System.Collections;
using System;

namespace Colonist
{
    public abstract class SentientEntity : LivingEntity, ConversableEntity
    {
        public abstract void talkTo();
    }
}
