using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    public void PassLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("UnlockedLevels"))
        {
            PlayerPrefs.SetInt("UnlockedLevels", currentLevel + 1);
        }
    }

    public void OnFinishLevelButtonClick()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
