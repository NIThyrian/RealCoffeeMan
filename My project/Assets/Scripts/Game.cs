using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] HealthBarScript healthBar;
    [SerializeField] UIShop shop;
    public GameObject eText;

    public static bool isPaused = false;  
    public Color currentColor;
    public int level;
    public float difficultyFactor;
    public GameObject map;
    private GameObject mapReference;

    public int maxHealth = 100;
    public int currentHealth;
    
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
            {"CashHeld", 100}
        };

    private void Awake() {
        currentHealth = maxHealth;
    }

    void Start() {
        level = 1;
        difficultyFactor = 1;
        currentColor = Random.ColorHSV();
        mapReference = Instantiate(map, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, transform);

        healthBar.SetMaxHealth(maxHealth);
        shop.CloseShop();
    }

    public void E() {
        shop.OpenShop();
    }

    public void ChangeLevel() {
        Destroy(mapReference);
        currentColor = Random.ColorHSV();
        level++;
        difficultyFactor += 0.25f;
        mapReference = Instantiate(map, map.transform.position, Quaternion.identity, transform);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
