using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class LevelMessage : MonoBehaviour
{
    [SerializeField] private string _startText;
    [SerializeField] private string _finishText;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _blackScreen;
    [SerializeField] private GameObject _finishButtons;
    private Tween _tween;
    
    private void Start() => StartCoroutine(nameof(SetStartMessage));

    public void Finish() => StartCoroutine(nameof(SetFinishAction));

    private IEnumerator SetStartMessage()
    {
        _text.text = _startText;
        yield return new WaitForSeconds(2);
        _tween = _text.DOFade(1, 3);
        yield return new WaitForSeconds(3);
        _tween = _text.DOFade(0, 3);
        yield return new WaitForSeconds(3);
        _blackScreen.DOFade(0, 2);
        _tween.Kill();
    }
    
    private IEnumerator SetFinishAction()
    {
        _text.text = _finishText;
        _blackScreen.DOFade(1, 2);
        yield return new WaitForSeconds(2);
        _tween = _text.DOFade(1, 3);
        yield return new WaitForSeconds(3);
        GetComponent<LevelPass>().PassLevel();
        _finishButtons.SetActive(true);
        _tween.Kill();
    }
}
