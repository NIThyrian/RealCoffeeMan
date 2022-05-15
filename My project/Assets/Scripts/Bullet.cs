using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] PlayerScript player;


    private float elapsedTime = 0f;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision of bullet");
        var obj = collision.gameObject.GetComponent<Enemy>();

        if (obj != null)
        {
            Debug.Log("[Health] : " + obj.health + " -> Setting damage " + player.damage);
            obj.health -= player.damage;
            obj.Hit();
            Debug.Log("[Health AFTER] : " + obj.health);

            if (obj.health <= 0f)
            {
                obj.Die();
            }

        }

        Destroy(gameObject);
    }

}
