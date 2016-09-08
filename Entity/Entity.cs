using UnityEngine;
using System.Collections;
using Boo.Lang;

namespace StarColony
{
    public abstract class Entity : MonoBehaviour
    {
        public enum EntityState { ATTACKING, BLOCKING, DODGING, FALLING, DEAD, ALIVE, RUNNING, WALKING };
        public List<EntityState> stateList = new List<EntityState>();

        public void Start()
        {

        }

        public void addState(EntityState state)
        {

        }

        public void removeState(EntityState state)
        {

        }

        public abstract string getName();
        public abstract void onCollideWithEntity(Entity e);
    }
}
