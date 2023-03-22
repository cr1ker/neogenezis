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

    public void OnMainMenuButtonClick() => SceneManager.LoadScene(0);

    public void OnNextLevelButtonClick(int indexOfNextLevel) => SceneManager.LoadScene(indexOfNextLevel);
    
    public void OnRestartLevelButtonClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
