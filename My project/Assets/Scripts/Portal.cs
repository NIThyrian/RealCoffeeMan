using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            
            Game game = GetComponentInParent(typeof(Game)) as Game;

            if (game != null)
            {
                game.ChangeLevel();
            }
        }
    }
}
