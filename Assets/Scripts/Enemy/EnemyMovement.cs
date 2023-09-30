using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private readonly float _speedMove = 3f;
    private readonly float _speedRotate = 1f;

    private void Update()
    {
        MoveToTarget();
        RotationEnemyToTarget();
    }

    public void Init(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);
    }

    private void RotationEnemyToTarget()
    {
        Vector3 target = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotate * Time.deltaTime);
    }
}
