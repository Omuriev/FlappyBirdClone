using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _birdMover.Reset();
    }

    private void ProcessCollision()
    {
         GameOver?.Invoke();
    }
}
