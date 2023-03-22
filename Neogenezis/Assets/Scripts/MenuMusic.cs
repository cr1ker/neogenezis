using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource _backgroundMusic;
    private string _isMusicActive;

    private void Awake() => _backgroundMusic = gameObject.GetComponent<AudioSource>();
    
    private void Start()
    {
        CheckMusicStatus();
    }

    public void SetMusicStatus(string status)
    {
        PlayerPrefs.SetString("isMusicOn", status);
        CheckMusicStatus();
    }

    private void CheckMusicStatus()
    {
        _isMusicActive = PlayerPrefs.GetString("isMusicOn", "true");
        if (_isMusicActive == "true")
        {
            _backgroundMusic.Play();
        }
        else
        {
            _backgroundMusic.Stop();
        }
    }
}
