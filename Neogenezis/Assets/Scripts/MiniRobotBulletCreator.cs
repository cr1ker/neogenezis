using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRobotBulletCreator : MonoBehaviour, ISetShotAudio
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<Transform> _spawnsBullet;
    [SerializeField] private AudioSource _bulletShotAudio;
    private float _bulletSpeed;
    
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    public void Bullet()
    {
        Vector3 toPlayer = _playerTransform.position - gameObject.transform.position; //vector to Player
        _bulletSpeed = Random.Range(8f, 20f); //generating bullet speed
        for (int i = 0; i < 2; i++)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, _spawnsBullet[i].position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;
        }
        SetShotAudio(_bulletShotAudio);
    }

    public void SetShotAudio(AudioSource shotAudio)
    {
        shotAudio.pitch = Random.Range(1f, 1.1f);
        shotAudio.Play();
    }
}
