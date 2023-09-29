using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Toilet _target;

    private void Start()
    {
        var enemy = Instantiate(_prefabEnemy, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().Init(_target.gameObject.transform);
    }
}
