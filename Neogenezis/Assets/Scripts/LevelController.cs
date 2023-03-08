using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] _lockedLevelImages;
    private int _unlockedLevels;
    
    private void Start()
    {
        _unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        for (int i = 0; i < _lockedLevelImages.Length; i++)
        {
            if (i < _unlockedLevels)
            {
                _lockedLevelImages[i].SetActive(false);
            }
            else
            {
                _lockedLevelImages[i].SetActive(true);
            }
        }
    }

    public void LoadLevel(int levelIndex) => SceneManager.LoadScene(levelIndex);
}
