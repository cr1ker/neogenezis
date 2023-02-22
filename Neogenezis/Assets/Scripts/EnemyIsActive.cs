using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsActive : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _enemies;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private byte _minimalDistanceForEnemyActive;

    private void LateUpdate()
    {
        StartCoroutine(IsEnemyClose());
    }

    private IEnumerator IsEnemyClose()
    {
        yield return new WaitForSeconds(1.5f);
        CheckEnemyDistance();
    }

    private void CheckEnemyDistance()
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

    public List<GameObject> GetEnemies()
    {
        return _enemies;
    }
}
