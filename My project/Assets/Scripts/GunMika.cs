using UnityEngine;

public class GunMika : MonoBehaviour
{
    public Transform spawnBalle;
    public GameObject ballePrefab;
    public float vitesseBalles = 10;
    public ParticleSystem gunFire;
    public AudioClip gunshot;
    public AudioSource audioSource;

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        gunFire.Play();
        
        audioSource.PlayOneShot(gunshot, 0.7F);
        var balle = Instantiate(ballePrefab, spawnBalle.position, spawnBalle.rotation);
        balle.GetComponent<Rigidbody>().velocity = spawnBalle.forward * vitesseBalles;
        Destroy(balle, 5f);
    }
}
