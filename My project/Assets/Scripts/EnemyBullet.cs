using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        var player = hit.gameObject.GetComponent<PlayerScript>();

        if (player != null) {
            var game = player.GetComponentInParent<Game>();
            game.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
