using UnityEngine;

public class EnemyShoot : Shoot
{
    private float currentTime = 0;

    private void Update()
    {
        OnTryShoot();
    }

    protected override void OnTryShoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= TimeBetweenShot)
        {
            currentTime = 0;
            Bullet bullet = CreateBullet();

            bullet.Fire(-transform.right);
        }
    }
}
