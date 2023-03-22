using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GetMessageOrActionByTrigger : MonoBehaviour
{
    [SerializeField] private string _textForAppear;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private UnityEvent _eventOnEnterActionZone;
    [SerializeField] private UnityEvent _eventOnExitActionZone;
    [SerializeField] private Image[] _imagesForAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            _text.text = _textForAppear;
            _text?.DOFade(1, 1);
            _eventOnEnterActionZone?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            _text?.DOFade(0, 1);
            _eventOnExitActionZone?.Invoke();
        }
    }
}
