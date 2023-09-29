using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint = 0;
    private float _speed = 3.5f;

    private void Start()
    {
        GetChildPath();
    }

    private void Update()
    {
        Move();
        QuaternionToPoints();
    }

    private void GetChildPath()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _points[_currentPoint].position)
        {
            _currentPoint++;

            if (_currentPoint >= _path.childCount)
                _currentPoint = 0;
        }
    }

    private void QuaternionToPoints()
    {
        Vector3 direction = _points[_currentPoint].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 1f * Time.deltaTime);
    }
}
