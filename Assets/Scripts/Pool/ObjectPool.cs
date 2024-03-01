using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject Prefab;

    protected Queue<GameObject> Pool;

    public IEnumerable<GameObject> PooledObjects => Pool;

    private void Awake()
    {
        Pool = new Queue<GameObject>();
    }

    public virtual GameObject GetObject()
    {
        if (Pool.Count == 0)
        {
            GameObject gameObject = Instantiate(Prefab, transform.position, Quaternion.identity);
            return gameObject;
        }

        return Pool.Dequeue();
    }

    public void PutObject(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        Pool.Enqueue(gameObject);
    }

    public void Reset()
    {
        Pool.Clear();
    }
}
