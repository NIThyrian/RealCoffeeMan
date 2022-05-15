using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMika : MonoBehaviour
{
    public Transform spawnBalle;
    public GameObject ballePrefab;
    public float vitesseBalles = 10;
    public ParticleSystem tirFeu;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        tirFeu.Play();
        var balle = Instantiate(ballePrefab, spawnBalle.position, spawnBalle.rotation);
        balle.GetComponent<Rigidbody>().velocity = spawnBalle.forward * vitesseBalles;
        Destroy(balle, 5f);
    }
}
