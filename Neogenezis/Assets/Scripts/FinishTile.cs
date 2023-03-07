using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTile : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    
    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (player && _joystick.Horizontal == 0)
        {
            FindObjectOfType<FinishUFO>().FinishLevelAnimation();
            StartCoroutine(nameof(RemoveFinishTile));
        }
    }

    private IEnumerator RemoveFinishTile()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
