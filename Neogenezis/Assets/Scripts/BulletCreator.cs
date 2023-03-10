using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class BulletCreator : MonoBehaviour, ISetShotAudio
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform SpawnBullet;
    [SerializeField] private float BulletSpeed;

    [SerializeField] private GameObject LightAim; //light after shot

    [SerializeField] private AudioSource Shot;
    [SerializeField] private AudioSource NotShot; //active while _currentbullets == 0
    [SerializeField] private AudioSource BulletPick;
    [SerializeField] private UnityEvent _eventOnTakeBulletPack;
    private float _time;

    private int _currentBullets; //reference to Gun
    private int _quantityOfBullets;
    private float _shootTime;
    private Gun _currentGun;
    private bool _isShootActive;
    private bool _isGunActive;

    private void Awake()
    {
        _quantityOfBullets = 50;
        _isGunActive = false;
    }

    private void Update()
    {
        if (_isGunActive)
        {
            _currentBullets = _currentGun.GetCurrentBullets();
            if (_isShootActive)
            {
                if (_currentBullets > 0)
                {
                    _time += Time.deltaTime;
                    if (_time > _shootTime)
                    {
                        Shoot();
                        _time = 0;
                    }
                }
                else if (_quantityOfBullets == 0)
                {
                    _time += Time.deltaTime;
                    if (_time > _shootTime)
                    {
                        NotShot.Play();
                        _time = 0;
                    }
                }
            }
        }
    }

    public void OnShootButtonEnter() => _isShootActive = true;

    public void OnShootButtonExit() => _isShootActive = false;

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
        _eventOnTakeBulletPack.Invoke();
        BulletPick.pitch = Random.Range(1f, 1.25f);
        BulletPick.Play();
    }

    public int GetTotalNumberOfBullets()
    {
        return _quantityOfBullets;
    }

    public void GetCurrentGun()
    {
        _currentGun = FindObjectOfType<Gun>();
        _isGunActive = true;
    }
    
    public void RefreshGunInformation(ref float shootTime)
    {
        _shootTime = shootTime;
    }
}
