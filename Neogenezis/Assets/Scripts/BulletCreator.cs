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
        if (_currentBullets > 0)
        {
            if (Input.GetMouseButtonDown(0))
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
        }
        else if (Input.GetMouseButtonDown(0))
        {
            NotShot.Play();
        }
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
