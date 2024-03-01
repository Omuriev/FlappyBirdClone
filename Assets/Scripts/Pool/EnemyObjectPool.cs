using UnityEngine;

public class EnemyObjectPool : ObjectPool
{
    [SerializeField] private ObjectPool _bulletsPool;

    public override GameObject GetObject()
    {
        if (Pool.Count == 0)
        {
            GameObject gameObject = Instantiate(Prefab, transform.position, Quaternion.identity);
            EnemyShoot shoot = gameObject.GetComponentInChildren<EnemyShoot>();
            
            if (shoot != null)
            {
                shoot.SetPool(_bulletsPool);
            }

            return gameObject;
        }

        return Pool.Dequeue();
    }
}
