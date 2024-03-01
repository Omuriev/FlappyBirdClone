using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private int _damage;

    private Rigidbody2D _rigidbody;
    private Coroutine _waitBeforeDestroyCoroutine;

    public event Action<Bullet> Destroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (_waitBeforeDestroyCoroutine != null)
        {
            StopCoroutine(_waitBeforeDestroyCoroutine);
        }

        _waitBeforeDestroyCoroutine = StartCoroutine(WaitBeforeDestroy());
    }

    private void OnDisable()
    {
        if (_waitBeforeDestroyCoroutine != null)
            StopCoroutine(_waitBeforeDestroyCoroutine);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            Destroy(health.gameObject);
            Destroyed?.Invoke(this);
        }
    }

    public void Fire(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;

    }

    private IEnumerator WaitBeforeDestroy()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeBeforeDestroy);

        yield return waitTime;

       Destroyed?.Invoke(this);
    }
}
