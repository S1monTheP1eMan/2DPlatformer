using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _delay;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            Instantiate(_template, _points[GetRandomPoint()].position, Quaternion.identity);
            
            yield return waitForSeconds;
        }
    }

    private int GetRandomPoint()
    {
        int randomPoint = Random.Range(0, transform.childCount);
        return randomPoint;
    }
}
