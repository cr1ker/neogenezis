using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public class LevelTabScroll : MonoBehaviour
{
    [SerializeField] private GameObject _scrollbar;
    [SerializeField] private GameObject[] _levelsImages;
    private Scrollbar _scrollBarHorizontal;
    private bool _isFingerScanActive;
    
    private float _scrollPosition;
    private int _currentLevelImage;

    private void Start()
    {
        _scrollBarHorizontal = _scrollbar.GetComponent<Scrollbar>();
    }

    private void LateUpdate()
    {
        _scrollPosition = _scrollBarHorizontal.value;
        if (_scrollPosition > 0 && _scrollPosition < 1) //this expresion solve IndexOfArray
        {
            _currentLevelImage = Mathf.FloorToInt(_levelsImages.Length * _scrollPosition);
        }
        for (int i = 0; i < _levelsImages.Length; i++)
        {
            Vector3 currentLevelImageScale = _levelsImages[_currentLevelImage].transform.localScale;
            Vector3 levelImageScale = _levelsImages[i].transform.localScale;
            if (i == _currentLevelImage)
            {
                _levelsImages[_currentLevelImage].transform.localScale = Vector3.Lerp(currentLevelImageScale, Vector3.one * 1.25f, Time.deltaTime * 15);
            }
            else
            {
                _levelsImages[i].transform.localScale = Vector3.Lerp(levelImageScale, Vector3.one, Time.deltaTime * 15);
            }
        }
    }
}
