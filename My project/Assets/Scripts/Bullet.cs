using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] PlayerScript player;

    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Enemy") {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            enemy.health -= player.damage;
            Debug.Log("Health : " + enemy.health);
            if(enemy.health <= 0f) {
                enemy.Die();
            }
        }
        Destroy(gameObject);
    }

}
