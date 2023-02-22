using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed;
    
    private void Update()
    {
        transform.Rotate(0f, Time.deltaTime * _rotationSpeed, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (player)
        {
            FindObjectOfType<DiamondManager>().CollectDiamond();
            Destroy(gameObject);
        }
    }
}
