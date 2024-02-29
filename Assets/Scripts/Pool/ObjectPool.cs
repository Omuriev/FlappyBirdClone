using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private Queue<GameObject> _pool;

    public IEnumerable<GameObject> PooledObjects => _pool;

    private void Start()
    {
        _pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            GameObject gameObject = Instantiate(_prefab, transform.position, Quaternion.identity);
            return gameObject;
        }

        return _pool.Dequeue();
    }

    public void PutObject(GameObject enemy)
    {
        _pool.Enqueue(enemy);

        enemy.gameObject.SetActive(false);
    }
}
