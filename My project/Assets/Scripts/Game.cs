using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] HealthBarScript healthBar;
    [SerializeField] UIShop shop;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject gameOver;
    public GameObject win;

    public GameObject eText;

    public static bool isPaused = false;  
    public Color currentColor;
    public int difficultyFactor;
    public GameObject map;
    private GameObject mapReference;

    public float maxHealth = 100;
    public float currentHealth;
    
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
            {"CashHeld", 1150}
        };
    
    private StaticValues staticValues;

    private void Awake() {
        currentHealth = maxHealth;
        staticValues = new StaticValues();
    }
    
    void Start() {
        difficultyFactor = 1;
        currentColor = Random.ColorHSV();
        mapReference = Instantiate(map, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, transform);

        gameOver = GameObject.FindWithTag("GameOver");
        gameOver.SetActive(false);

        win = GameObject.FindWithTag("Win");
        win.SetActive(false);

        var obj = GameObject.FindGameObjectWithTag("UniversLabel");
        obj.GetComponent<TextMeshProUGUI>().text = "Univers #" + Random.Range(1, 10000);


        healthBar.SetMaxHealth(maxHealth);
    }

    public void E() {
        shop.OpenShop();
    }

    public void ChangeLevel() {
        var obj = GameObject.FindGameObjectWithTag("UniversLabel");
        obj.GetComponent<TextMeshProUGUI>().text = "Univers #" + Random.Range(1, 10000);
        
        Destroy(mapReference);
        currentColor = Random.ColorHSV();
        difficultyFactor ++;
        shop.RandomizeCurrencies();
        mapReference = Instantiate(map, map.transform.position, Quaternion.identity, transform);
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth <= 0)
        {
            GetComponentInChildren<PlayerScript>().GetComponentInChildren<Canvas>().gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            Game.isPaused = true;
            gameOver.SetActive(true);
        }
        healthBar.SetHealth(currentHealth);
    }

    public void AddCurency(string currencyName, int number)
    {
        playerDict[currencyName] += number;
        playerUI.transform.Find(currencyName).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerDict[currencyName].ToString();


    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
