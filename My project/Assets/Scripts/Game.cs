using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Color currentColor;
    public int level;
    public GameObject map;
    private GameObject mapReference; 

    public Dictionary<string, int> playerDict = new Dictionary<string, int> {
            {"SteakPurchased", 10},
            {"GunPurchased", 1},
            {"BootsPurchased", 1},
            {"CoffeePurchased", 1},
            {"CaHeld", 1},
            {"GoldHeld", 1},
            {"NotACubeHeld", 1},
            {"PoopHeld", 1},
            {"RocketHeld", 1},
            {"CashHeld", 100}
        };

    void Start() {
        level = 1;
        currentColor = Random.ColorHSV();
        mapReference = Instantiate(map, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, transform);
    }

    void Update() {
        if (Input.GetKeyDown("f")) ChangeLevel();
    }

    void ChangeLevel() {
        Destroy(mapReference);
        currentColor = Random.ColorHSV();
        level++;
        mapReference = Instantiate(map, map.transform.position, Quaternion.identity, transform);
    }
}
