using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShot;
    [SerializeField] protected ObjectPool Pool;

    private List<Bullet> _bullets;

    protected bool CanShoot = true;
    protected Coroutine WaitBeforeSpawnBulletCoroutine;

    private void Awake()
    {
        _bullets = new List<Bullet>();
    }

    private void OnDisable()
    {
        foreach (Bullet item in _bullets)
        {
            item.Destroyed -= OnDestroyed;
        }

        Pool.Reset();
    }

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
                _bullets.Add(bullet);

                bullet.Fire(direction);
                bullet.Destroyed += OnDestroyed;
                WaitBeforeSpawnBulletCoroutine = StartCoroutine(WaitBeforeSpawnBullet());
            }
        }
    }

    protected IEnumerator WaitBeforeSpawnBullet()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeBetweenShot);
        CanShoot = false;

        yield return waitTime;

        CanShoot = true;
    }

    protected Bullet SpawnBullet()
    {
        var item = Pool.GetObject();

        if (item.TryGetComponent(out Bullet bullet))
        {
            item.gameObject.SetActive(true);
            item.transform.position = transform.position;
        }

        return bullet;
    }

    private void OnDestroyed(Bullet bullet)
    {
        Bullet bulletForRemove;

        foreach (Bullet item in _bullets)
        {
            if (bullet == item)
            {
                bulletForRemove = item;
                Pool.PutObject(bullet.gameObject);
            }
        }

        _bullets.Remove(bullet);
    }
}
