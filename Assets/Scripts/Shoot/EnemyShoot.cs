using UnityEngine;

public class EnemyShoot : Shoot
{
    private void Update()
    {
        TryShoot(-transform.right);
    }

    private void OnDisable()
    {
        StopCoroutine(WaitBeforeSpawnBulletCoroutine);
    }

    protected override void TryShoot(Vector3 direction)
    {
        base.TryShoot(direction);
    }
}
