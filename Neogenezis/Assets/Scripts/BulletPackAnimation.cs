using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackAnimation : MonoBehaviour
{
    public float SpeedOfRotation;

    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * SpeedOfRotation);
    }
}
