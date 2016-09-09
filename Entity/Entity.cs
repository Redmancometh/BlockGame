using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Colonist
{
    public abstract class Entity : MonoBehaviour
    {
        public enum EntityState { ATTACKING, BLOCKING, DODGING, FALLING, DEAD, ALIVE, RUNNING, WALKING };
        public List<EntityState> stateList = new List<EntityState>();

        virtual public void  iterateStates(Action<EntityState> action)
        {
            stateList.ForEach((state)=>action.Invoke(state));
        }

        virtual public void addState(EntityState state)
        {
            stateList.Add(state);
        }

        virtual public void removeState(EntityState state)
        {
            stateList.Add(state);
        }

        public abstract string getName();
        public abstract void onCollideWithEntity(Entity e);
    }
}
