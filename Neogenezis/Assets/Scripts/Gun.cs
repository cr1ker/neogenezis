using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _gunDamage;
    [SerializeField] private int _sizeOfMagazine;
    [SerializeField] private float _reloadTime;
    [SerializeField] protected float _shootTime;
    [SerializeField] private AudioSource _reloadSound;
    private BulletCreator _bulletCreator; // reference to totalBullets
    private int _currentBullets;
    private int _reloadedBullets;
    private int _reserveBullets;
    private int _totalBullets;
    [SerializeField] private TextMeshProUGUI _bulletsText;
    private bool _isReloading;

    private void OnEnable()
    {
        FindObjectOfType<BulletCreator>().RefreshGunInformation(ref _shootTime);
    }
    
    private void Start()
    {
        _bulletCreator = FindObjectOfType<BulletCreator>();
        _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets 
        _reserveBullets = _totalBullets - _sizeOfMagazine; // calculate reserve bullets 
        _reloadedBullets = 0;
    }

    private void Update()
    {
        if (_isReloading == false)
        {
            _totalBullets = _bulletCreator.GetTotalNumberOfBullets(); //get all bullets
            _currentBullets = _totalBullets - _reserveBullets; // calculate reserve bullets
            _bulletsText.text = _currentBullets.ToString() + " / " + _reserveBullets.ToString();
        }
        if (_currentBullets == 0 && _isReloading != true && _reserveBullets != 0) //reload
        {
            _reloadSound.Play();
            StartCoroutine(nameof(Reload));
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
        return _gunDamage;
    }

    public void OnReloadButton()
    {
        if (_currentBullets < _sizeOfMagazine && _isReloading is false && _reserveBullets != 0)
        {
            _reloadSound.Play();
            StartCoroutine(nameof(Reload));
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        _reloadedBullets = _currentBullets;
        _currentBullets = 0;
        while (_reloadedBullets != _sizeOfMagazine && _reserveBullets != 0)
        {
            _reserveBullets--;
            _reloadedBullets++;
        }
        yield return new WaitForSeconds(_reloadTime);
        _currentBullets += _reloadedBullets;
        _reloadedBullets = 0;
        _isReloading = false;
    }
}
