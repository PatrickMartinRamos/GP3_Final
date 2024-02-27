using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

    // projectile revised to use UnityEngine.Pool in Unity 2021
    public class ObjectToPool : MonoBehaviour
    {
        // deactivate after delay
/*        [SerializeField] private float timeoutDelay = 0.5f;*/

        private IObjectPool<ObjectToPool> objectPool;

        // public property to give the projectile a reference to its ObjectPool
        public IObjectPool<ObjectToPool> ObjectPool { set => objectPool = value; }

        public void Deactivate()
        {
/*            StartCoroutine(DeactivateRoutine());*/
            objectPool.Release(this);
        }

/*        IEnumerator DeactivateRoutine()
        {
            // release the projectile back to the pool
            objectPool.Release(this);
        }*/
    }
