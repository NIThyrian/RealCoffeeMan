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
        var obj = collision.gameObject.GetComponent<Enemy>();

        if (obj != null)
        {
            obj.health -= player.damage;
            obj.Hit();

            if (obj.health <= 0f)
            {
                obj.Die();
            }

        }

        Destroy(gameObject);
    }

}
