using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCreate : MonoBehaviour
{
    public GameObject VirusPrefab;
    public Transform Spawn1;
    public Transform Spawn2;

    public void CreateVirus1()
    {
        Instantiate(VirusPrefab, Spawn1.position, Quaternion.identity);
    }
}
