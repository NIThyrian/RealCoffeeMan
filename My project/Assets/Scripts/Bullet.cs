using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Enemy") {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            enemy.health -= 10f;
            if(enemy.health <= 0f) {
                enemy.Die();
                Destroy(gameObject);
            }
        }
        Debug.Log("collision");
        Destroy(gameObject,0.5f);
    }
}
