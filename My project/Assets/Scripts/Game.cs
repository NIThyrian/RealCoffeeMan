using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
