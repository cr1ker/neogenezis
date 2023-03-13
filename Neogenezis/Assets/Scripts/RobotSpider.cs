using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RobotSpider : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _minimalDistanceForAttack;
    private Transform _player;
    private float _time;
    private float _distanceBetweenEnemyAndPlayer;

    private void Start()
    {
        _distanceBetweenEnemyAndPlayer = _minimalDistanceForAttack;
        _player = FindObjectOfType<Body>().transform;
    }

    private void LateUpdate()
    {
        _time += Time.deltaTime;
        if (_time > 1)
        {
            _distanceBetweenEnemyAndPlayer = Vector3.Distance(_player.position, gameObject.transform.position);
            _time = 0;
        }
        if (_distanceBetweenEnemyAndPlayer < _minimalDistanceForAttack)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * _movingSpeed);
        }
    }
}
