using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public RangeEnemy parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<RangeEnemy>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeapon()
    {
        parent.SpawnWeapon();
    }
}
