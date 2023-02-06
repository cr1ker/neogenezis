using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnBullet;
    public float BulletSpeed;

    public GameObject LightAim; //light after shot

    public AudioSource Shot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(BulletPrefab,SpawnBullet.position, SpawnBullet.rotation);//bullet creation
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;//bullet velocity
            //light bullet
            LightAim.SetActive(true);
            Invoke("SetOffLight",0.07f);
            //Shot Audio
            Shot.pitch = Random.Range(0.60f, 0.70f);
            Shot.Play();
        }
    }

    public void SetOffLight()
    {
        LightAim.SetActive(false);
    }
}
