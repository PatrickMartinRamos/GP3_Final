using UnityEngine;
using UnityEngine.Pool;

    public class Pooling : MonoBehaviour
    {
        [Tooltip("Prefab to spawn")]
        [SerializeField] private ObjectToPool EnemyPrefab;
/*        [Tooltip("Projectile force")]
        [SerializeField] private float muzzleVelocity = 700f;*/
        [Tooltip("Spawn Point")]
        [SerializeField] private Transform spawnPoint;
        [Tooltip("Time between spawn / smaller = higher rate of Spawning")]
        [SerializeField] private float cooldownWindow = 2;

        // stack-based ObjectPool available with Unity 2021 and above
        private IObjectPool<ObjectToPool> objectPool;

        // throw an exception if we try to return an existing item, already in the pool
        [SerializeField] private bool collectionCheck = true;

        // extra options to control the pool capacity and maximum size
        [SerializeField] private int defaultCapacity = 1;
        [SerializeField] private int maxSize = 5;

        private float nextTimeToShoot=0;

        private void Awake()
        {
            objectPool = new ObjectPool<ObjectToPool>(CreateProjectile,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
        }

        // invoked when creating an item to populate the object pool
        private ObjectToPool CreateProjectile()
        {
            ObjectToPool EnemyInstance = Instantiate(EnemyPrefab);
            EnemyInstance.ObjectPool = objectPool;
            return EnemyInstance;
        }

        // invoked when returning an item to the object pool
        private void OnReleaseToPool(ObjectToPool pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        // invoked when retrieving the next item from the object pool
        private void OnGetFromPool(ObjectToPool pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
            nextTimeToShoot = Time.time + cooldownWindow;
        }

        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        private void OnDestroyPooledObject(ObjectToPool pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }

        private void FixedUpdate()
        {
        // shoot if we have exceeded delay
        if(Time.time == nextTimeToShoot)
        {
            // get a pooled object instead of instantiating
            ObjectToPool bulletObject = objectPool.Get();

            if (bulletObject == null)
                return;

            // align to gun barrel/muzzle position
            bulletObject.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);

            // move projectile forward
            /*                bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);*/

            // turn off after a few seconds
/*            bulletObject.Deactivate();*/
        }

        }
    }