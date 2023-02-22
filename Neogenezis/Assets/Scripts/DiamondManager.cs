using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiamondManager : MonoBehaviour
{
    [SerializeField] private int _currentDiamonds;
    [SerializeField] private int _totalDiamonds;
    [SerializeField] private AudioSource _diamondCollectSound;
    [SerializeField] private TextMeshProUGUI _diamondsText;
    
    
    public void CollectDiamond()
    {
        _currentDiamonds++;
        ChangeTextAndColor(_diamondsText, _currentDiamonds);
        //_diamondCollectSound.Play();
        /* need to create a method which calls out some audio or some UI warning that we got all coins*/
    }

    private void ChangeTextAndColor(TextMeshProUGUI text, int diamonds)
    {
        text.text = $"{diamonds} / {_totalDiamonds}";
        switch (diamonds)
        {
            case 3:
                text.color = new Color(255, 165, 0); //orange code
                break;
            case 6:
                text.color = Color.yellow;
                break;
            case 8:
                text.color = Color.green;
                break;
            case 10:
                text.color = Color.cyan;
                break;
        }
    }
}
