using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModernPistol : MonoBehaviour
{
    public int GunDamage;
    private int _sizeOfMagazine;
    private BulletCreator _bulletCreator; // reference to totalBullets
    public int _currentBullets;
    public int _reserveBullets;
    public int _totalBullets;
    public TextMeshProUGUI BulletsText;
    
    private void Start()
    {
        _sizeOfMagazine = 15;
        _bulletCreator = FindObjectOfType<BulletCreator>();
        _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets 50
        _reserveBullets = _totalBullets - _sizeOfMagazine; // calculate reserve bullets 35
    }

    private void Update()
    {
        _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets
        _currentBullets = _totalBullets - _reserveBullets; // calculate reserve bullets
        BulletsText.text = _currentBullets.ToString() + " / " + _reserveBullets.ToString();
        if (Input.GetKeyDown(KeyCode.R)) //reload
        {
            while (_currentBullets != _sizeOfMagazine && _reserveBullets != 0)
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

    public int LostBulletByShot()
    {
        return _currentBullets--;
    }
}
