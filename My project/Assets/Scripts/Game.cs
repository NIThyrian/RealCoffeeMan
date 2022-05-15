using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Color currentColor;
    public int level;
    public float difficultyFactor;
    public GameObject map;
    private GameObject mapReference; 

    public Dictionary<string, int> playerDict = new Dictionary<string, int> {
            {"SteakPurchased", 0},
            {"GunPurchased", 0},
            {"BootsPurchased", 0},
            {"CoffeePurchased", 1},
            {"CaHeld", 0},
            {"GoldHeld", 0},
            {"NotACubeHeld", 0},
            {"PoopHeld", 0},
            {"RocketHeld", 0},
            {"CashHeld", 0}
        };

    void Start() {
        level = 1;
        difficultyFactor = 1;
        currentColor = Random.ColorHSV();
        mapReference = Instantiate(map, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, transform);
    }

    void Update() { }

    public void ChangeLevel() {
        Destroy(mapReference);
        currentColor = Random.ColorHSV();
        level++;
        difficultyFactor += 0.25f;
        mapReference = Instantiate(map, map.transform.position, Quaternion.identity, transform);
    }
}
