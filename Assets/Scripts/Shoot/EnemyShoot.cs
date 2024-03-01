using UnityEngine;

public class EnemyShoot : Shoot
{
    private void Update()
    {
        TryShoot(-transform.right);
    }

    private void OnDisable()
    {
        if (WaitBeforeSpawnBulletCoroutine != null)
            StopCoroutine(WaitBeforeSpawnBulletCoroutine);
    }

    private void OnEnable()
    {
        if (WaitBeforeSpawnBulletCoroutine != null)
        {
            StopCoroutine(WaitBeforeSpawnBulletCoroutine);
        }

        WaitBeforeSpawnBulletCoroutine = StartCoroutine(WaitBeforeSpawnBullet());
    }

    public void SetPool(ObjectPool pool)
    {
        Pool = pool;
    }

    protected override void TryShoot(Vector3 direction)
    {
        base.TryShoot(direction);
    }
}
