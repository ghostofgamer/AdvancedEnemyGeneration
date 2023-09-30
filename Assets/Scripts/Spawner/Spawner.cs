using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _prefab;
    [SerializeField] private Toilet _target;

    private void Start()
    {
        EnemyMovement enemy = Instantiate(_prefab, transform.position, Quaternion.identity);
        enemy.Init(_target.gameObject.transform);
    }
}
