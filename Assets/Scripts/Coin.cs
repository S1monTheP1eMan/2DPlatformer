using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] float _force;

    private void Start()
    {
        float randomX = Random.Range(-2f, 2f) * _force;
        float randomY = Random.Range(0f, 5f) * _force;

        _rb2d.AddForceAtPosition(new Vector2(randomX, randomY), new Vector2(randomX, randomY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
