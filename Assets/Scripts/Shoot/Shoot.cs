using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected float TimeBetweenShot;

    protected bool CanShoot = true;

    protected virtual void OnTryShoot() {}

    protected Bullet CreateBullet()
    {
        return Instantiate(Prefab, transform.position, Quaternion.identity);
    }

    protected IEnumerator WaitBeforeShoot()
    {
        WaitForSeconds waitTime = new WaitForSeconds(TimeBetweenShot);
        CanShoot = false;

        yield return waitTime;

        CanShoot = true;
    }
}
