using UnityEngine;

public class PlayerShoot : Shoot
{
    private void Update()
    {
        TryShoot(transform.right);
    }

    protected override void TryShoot(Vector3 direction)
    {
        if (Input.GetKey(KeyCode.E))
        {
            base.TryShoot(direction);
        }
    }

    private void OnDisable()
    {
        if (WaitBeforeSpawnBulletCoroutine != null)
        {
            StopCoroutine(WaitBeforeSpawnBulletCoroutine);
        }
    }
}
