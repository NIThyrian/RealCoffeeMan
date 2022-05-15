using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "RangeEnemy") {
            GameObject ennemy = collision.collider.gameObject;
            ennemy.GetComponent<RangeEnemy>();
        } else if(collision.collider.tag == "MeleeEnemy") {
            GameObject ennemy = collision.collider.gameObject;
            ennemy.GetComponent<MeleeEnemy>();
        }
    }
}
