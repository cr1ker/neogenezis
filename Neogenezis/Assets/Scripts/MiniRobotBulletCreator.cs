using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRobotBulletCreator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public List<Transform> SpawnsBullet;
    private float _bulletSpeed;
    
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    public void Bullet()
    {
        Vector3 toPlayer = _playerTransform.position - gameObject.transform.position; //vector to Player
        _bulletSpeed = Random.Range(10f, 20f); //generating bullet speed
        for (int i = 0; i < 2; i++)
        {
            GameObject newBullet = Instantiate(BulletPrefab,SpawnsBullet[i].position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;
        }
    }
}
