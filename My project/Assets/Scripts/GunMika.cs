using UnityEngine;

public class GunMika : MonoBehaviour
{
    public Transform spawnBullet;
    public GameObject bulletPrefab;
    public ParticleSystem gunFire;
    public AudioClip gunShot;
    public AudioSource audioSource;

    public float vitesseBalles = 50f;

    void Update() {
        if(Input.GetButtonDown("Fire1") && !Game.isPaused) {
            Shoot();
        }
    }

    void Shoot() {
        gunFire.Play();
        audioSource.PlayOneShot(gunShot, 0.7F);

        GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        bullet.GetComponent<Rigidbody>().velocity = spawnBullet.forward * vitesseBalles;
    }
}
