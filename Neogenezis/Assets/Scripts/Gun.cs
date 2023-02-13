using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int GunDamage;
    public int SizeOfMagazine;
    private BulletCreator _bulletCreator; // reference to totalBullets
    private int _currentBullets;
    private int _reserveBullets;
    private int _totalBullets;
    public TextMeshProUGUI BulletsText;
    
    private void Start()
    {
        _bulletCreator = FindObjectOfType<BulletCreator>();
        _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets 50
        _reserveBullets = _totalBullets - SizeOfMagazine; // calculate reserve bullets 35
    }

    private void Update()
    {
        _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets
        _currentBullets = _totalBullets - _reserveBullets; // calculate reserve bullets
        BulletsText.text = _currentBullets.ToString() + " / " + _reserveBullets.ToString();
        //Debug.Log(_quantityOfBullets);
        if (Input.GetKeyDown(KeyCode.R)) //reload
        {
            while (_currentBullets != SizeOfMagazine && _reserveBullets != 0)
            {
                _reserveBullets--;
                _currentBullets++;
            }
        }
    }

    public int GetCurrentBullets()
    {
        return _currentBullets;
    }

    public int GetNewReserveBullets(ref int x)
    {
        return _reserveBullets = x - _currentBullets;
    }

    public int GetGunDamage()
    {
        return GunDamage;
    }
}
