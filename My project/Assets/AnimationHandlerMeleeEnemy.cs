using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandlerMeleeEnemy : MonoBehaviour
{
    public MeleeEnemy parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<MeleeEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackFront()
    {
        parent.AttackFront();
    }
}
