using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsActive : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private byte _minimalDistanceForEnemyActive;

    private void LateUpdate()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, _playerTransform.position);
                if (distance <= _minimalDistanceForEnemyActive)
                {
                    enemy.SetActive(true);
                }
                else
                {
                    enemy.SetActive(false);
                }
            }
        }
    }
}
