using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMika : MonoBehaviour
{
    public Transform spawnBalle;
    public GameObject ballePrefab;
    public float vitesseBalles = 10;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var balle = Instantiate(ballePrefab, spawnBalle.position, spawnBalle.rotation);
        balle.GetComponent<Rigidbody>().velocity = spawnBalle.forward * vitesseBalles;
        Destroy(balle, 5f);
    }
}
