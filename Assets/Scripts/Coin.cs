using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void Start()
    {
        float randomX = Random.Range(_minX, _maxX) * _force;
        float randomY = Random.Range(_minY, _maxY) * _force;

        _rigidbody.AddForceAtPosition(new Vector2(randomX, randomY), new Vector2(randomX, randomY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
