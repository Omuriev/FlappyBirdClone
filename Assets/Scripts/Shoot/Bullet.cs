using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private int _damage;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            Destroy(health.gameObject);
        }

        StopCoroutine(WaitBeforeDestroy());
        Destroy(gameObject);
    }

    public void Fire(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        StartCoroutine(WaitBeforeDestroy());
    }
   
    private IEnumerator WaitBeforeDestroy()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeBeforeDestroy);
        yield return waitTime;

        Destroy(gameObject);
    }
}
