using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShot;
    [SerializeField] private ObjectPool _pool;

    protected bool CanShoot = true;
    protected Coroutine WaitBeforeSpawnBulletCoroutine;

    protected virtual void TryShoot(Vector3 direction) 
    {
        if (CanShoot == true)
        {
            if (WaitBeforeSpawnBulletCoroutine != null)
            {
                StopCoroutine(WaitBeforeSpawnBulletCoroutine);
            }

            Bullet bullet = SpawnBullet();

            if (bullet != null)
            {
                bullet.Fire(direction);
                WaitBeforeSpawnBulletCoroutine = StartCoroutine(WaitBeforeSpawnBullet(bullet));
            }
        }
    }

    protected IEnumerator WaitBeforeSpawnBullet(Bullet bullet)
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeBetweenShot);
        CanShoot = false;

        yield return waitTime;

        if (bullet.TryGetComponent(out GameObject gameObject))
        {
            _pool.PutObject(gameObject);
        }

        CanShoot = true;
    }

    protected Bullet SpawnBullet()
    {
        var item = _pool.GetObject();

        if (item.TryGetComponent(out Bullet bullet))
        {
            item.gameObject.SetActive(true);
            item.transform.position = transform.position;
        }

        return bullet;
    }
}
