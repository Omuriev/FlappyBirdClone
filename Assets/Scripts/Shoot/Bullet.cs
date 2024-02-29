using UnityEngine;

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
            gameObject.SetActive(false);
        }
    }

    public void Fire(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
}
