using UnityEngine;
using UnityEngine.UIElements;

public class CurrentGun : MonoBehaviour
{
    private string _gunName;
    [SerializeField] private GameObject _blockShootButton; // need to delete block button before take shoot from taken gun
    [SerializeField] private GameObject _blaster;

    public void GetGunByName(string gunName)
    {
        switch (gunName)
        {
            case "Blaster":
                _blaster.SetActive(true);
                break;
            case "PlasmaRifle":
                
                break;
            case "PhotonGun":
                
                break;
            case "PulseBlaster":
                
                break;
            case "ElectromagneticMiniGun":
                
                break;
            default:
                
                break;
        }
        FindObjectOfType<BulletCreator>().GetCurrentGun();
        _blockShootButton.SetActive(false);
    }
}
