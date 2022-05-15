using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void show(bool active)
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(active);
    }
}
