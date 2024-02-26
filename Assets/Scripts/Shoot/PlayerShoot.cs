using UnityEngine;

public class PlayerShoot : Shoot
{
    private void Update()
    {
        OnTryShoot();
    }

    protected override void OnTryShoot()
    {
        if (CanShoot == true && Input.GetKey(KeyCode.E))
        {
            Bullet bullet = CreateBullet();
            bullet.Fire(transform.right);
            StartCoroutine(WaitBeforeShoot());
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(WaitBeforeShoot());
    }
}
