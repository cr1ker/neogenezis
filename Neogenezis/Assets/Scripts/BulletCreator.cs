using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCreator : MonoBehaviour, ISetShotAudio
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform SpawnBullet;
    [SerializeField] private float BulletSpeed;

    [SerializeField] private GameObject LightAim; //light after shot

    [SerializeField] private AudioSource Shot;
    [SerializeField] private AudioSource NotShot; //active while _currentbullets == 0
    [SerializeField] private AudioSource BulletPick;
    [SerializeField] private Joystick _joystick;
    private float _time;

    private int _currentBullets; //reference to Gun
    private int _quantityOfBullets;
    private Gun _currentGun;

    private void Awake()
    {
        _quantityOfBullets = 50;
        _currentGun = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        _currentBullets = _currentGun.GetCurrentBullets();
        bool _isStickMoving = _joystick.Vertical > 0 || _joystick.Vertical < 0 || _joystick.Horizontal > 0 ||
                              _joystick.Horizontal < 0;
        if (_currentBullets > 0)
        {
            if (_isStickMoving)
            {
                _time += Time.deltaTime;
                if (_time > 0.3f)
                {
                    Shoot();
                    _time = 0;
                }
            }
        }
        else if (_isStickMoving)
        {
            _time += Time.deltaTime;
            if (_time > 0.5f)
            {
                NotShot.Play();
                _time = 0;
            }
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab,SpawnBullet.position, SpawnBullet.rotation);//bullet creation
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;//bullet velocity
        _quantityOfBullets--; //lost bullet
        //light bullet
        LightAim.SetActive(true);
        Invoke(nameof(SetOffLight),0.07f);
        //Shot Audio
        SetShotAudio(Shot);
    }
    
    private void SetOffLight() => LightAim.SetActive(false);

    public void SetShotAudio(AudioSource shotAudio)
    {
        shotAudio.pitch = Random.Range(0.60f, 0.70f);
        shotAudio.Play();
    }

    public void GetBulletPack()
    {
        _quantityOfBullets += 50; //bullet pack
        FindObjectOfType<Gun>().GetNewReserveBullets(ref _quantityOfBullets);
        BulletPick.pitch = Random.Range(1f, 1.25f);
        BulletPick.Play();
    }

    public int GetTotalNumberOfBullets()
    {
        return _quantityOfBullets;
    }
}
