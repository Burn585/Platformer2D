using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Opossum : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 1f;

    private Transform[] _points;
    private Transform target;
    private Vector2 direction;
    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        target = _points[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        direction = (target.position - transform.position).normalized;

        if(direction.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
