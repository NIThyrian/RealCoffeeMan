using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIShop : MonoBehaviour
{
    [SerializeField] private Game game;

    private Dictionary<string, int> priceDict = new Dictionary<string, int> {
            {"SteakPrice", 10},
            {"SteakCurrentPrice", 10},
            {"GunPrice", 100},
            {"GunCurrentPrice", 100},
            {"BootsPrice", 100},
            {"BootsCurrentPrice", 100},
            {"CoffeePrice", 1000},
            {"CoffeeCurrentPrice", 100},
            {"CaPrice", 0},
            {"GoldPrice", 0},
            {"NotACubePrice", 0},
            {"PoopPrice", 0},
            {"RocketPrice", 0}
        };

    private void Start() {
        RandomizeCurrencies();
        SetBtnActions();
        UpdatePrices();
        //Open();
    }

    public void Open()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameObject.SetActive(true);

    }
    private void Update() {
  
    }

    private void SetBtnActions() {
        Transform steakItem = transform.Find("SteakItem");
        steakItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedSteak(); } );

        Transform gunItem = transform.Find("GunItem");
        gunItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedGun(); } );

        Transform bootsItem = transform.Find("BootsItem");
        bootsItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedBoots(); } );

        Transform coffeeItem = transform.Find("CoffeeItem");
        coffeeItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedCoffee(); } );

        Transform caCoin = transform.Find("CaCoin");
        caCoin.GetComponent<Button>().onClick.AddListener(delegate { SellCa(); } );

        Transform goldCoin = transform.Find("GoldCoin");
        goldCoin.GetComponent<Button>().onClick.AddListener(delegate { SellGold(); } );

        Transform notACubeCoin = transform.Find("NotACubeCoin");
        notACubeCoin.GetComponent<Button>().onClick.AddListener(delegate { SellNotACube(); } );

        Transform poopCoin = transform.Find("PoopCoin");
        poopCoin.GetComponent<Button>().onClick.AddListener(delegate { SellPoop(); } );

        Transform rocketCoin = transform.Find("RocketCoin");
        rocketCoin.GetComponent<Button>().onClick.AddListener(delegate { SellRocket(); } );

        Transform closeBtn = transform.Find("CloseShopBtn");
        closeBtn.GetComponent<Button>().onClick.AddListener(delegate { CloseShop(); } );
    }

    private void UpdatePrices()
    {
        priceDict["SteakCurrentPrice"] = Mathf.RoundToInt(priceDict["SteakPrice"] * Mathf.Pow(1.1f, game.playerDict["SteakPurchased"]));
        Transform steakItem = transform.Find("SteakItem");
        steakItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["SteakCurrentPrice"]).ToString();

        priceDict["GunCurrentPrice"] = Mathf.RoundToInt(priceDict["GunPrice"] * Mathf.Pow(1.1f, game.playerDict["GunPurchased"]));
        Transform gunItem = transform.Find("GunItem");
        gunItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["GunCurrentPrice"]).ToString();

        priceDict["BootsCurrentPrice"] = Mathf.RoundToInt(priceDict["BootsPrice"] * Mathf.Pow(1.1f, game.playerDict["BootsPurchased"]));
        Transform bootsItem = transform.Find("BootsItem");
        bootsItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["BootsCurrentPrice"]).ToString();

        priceDict["CoffeeCurrentPrice"] = Mathf.RoundToInt(priceDict["CoffeePrice"] * Mathf.Pow(1.1f, game.playerDict["CoffeePurchased"]));
        Transform coffeeItem = transform.Find("CoffeeItem");
        coffeeItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["CoffeeCurrentPrice"]).ToString();

        Transform caCoin = transform.Find("CaCoin");
        caCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["CaPrice"] * game.playerDict["CaHeld"]).ToString();
        caCoin.GetChild(1).GetComponent<TextMeshProUGUI>().text = (game.playerDict["CaHeld"]).ToString();

        Transform goldCoin = transform.Find("GoldCoin");
        goldCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["GoldPrice"] * game.playerDict["GoldHeld"]).ToString();
        goldCoin.GetChild(1).GetComponent<TextMeshProUGUI>().text = (game.playerDict["GoldHeld"]).ToString();

        Transform notACubeCoin = transform.Find("NotACubeCoin");
        notACubeCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["NotACubePrice"] * game.playerDict["NotACubeHeld"]).ToString();
        notACubeCoin.GetChild(1).GetComponent<TextMeshProUGUI>().text = (game.playerDict["NotACubeHeld"]).ToString();

        Transform poopCoin = transform.Find("PoopCoin");
        poopCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["PoopPrice"] * game.playerDict["PoopHeld"]).ToString();
        poopCoin.GetChild(1).GetComponent<TextMeshProUGUI>().text = (game.playerDict["PoopHeld"]).ToString();

        Transform rocketCoin = transform.Find("RocketCoin");
        rocketCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["RocketPrice"] * game.playerDict["RocketHeld"]).ToString();
        rocketCoin.GetChild(1).GetComponent<TextMeshProUGUI>().text = (game.playerDict["RocketHeld"]).ToString();

        Transform playerCurrency = transform.Find("PlayerCurrency");
        playerCurrency.GetChild(0).GetComponent<TextMeshProUGUI>().text = (game.playerDict["CashHeld"]).ToString();

        if (game.playerDict["CashHeld"] <= priceDict["SteakCurrentPrice"])
        {
            steakItem.GetComponent<Button>().interactable = false;
            steakItem.GetComponent<Image>().color = Color.gray;

        }
        else
        {
            steakItem.GetComponent<Button>().interactable = true;
            steakItem.GetComponent<Image>().color = Color.white;

        }
        if (game.playerDict["CashHeld"] <= priceDict["GunCurrentPrice"])
        {
            gunItem.GetComponent<Button>().interactable = false;
            gunItem.GetComponent<Image>().color = Color.gray;

        }
        else {
            gunItem.GetComponent<Button>().interactable = true;
            gunItem.GetComponent<Image>().color = Color.white;

        }

        if (game.playerDict["CashHeld"] <= priceDict["BootsCurrentPrice"])
        {
            bootsItem.GetComponent<Button>().interactable = false;
            bootsItem.GetComponent<Image>().color = Color.gray;

        }
        else {
            bootsItem.GetComponent<Button>().interactable = true;
            bootsItem.GetComponent<Image>().color = Color.white;
        }

        if (game.playerDict["CashHeld"] <= priceDict["CoffeeCurrentPrice"])
        {
            coffeeItem.GetComponent<Button>().interactable = false;
            coffeeItem.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            coffeeItem.GetComponent<Button>().interactable = true;
            coffeeItem.GetComponent<Image>().color = Color.white;
        }
    }

    public void CloseShop() {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    private void RandomizeCurrencies() {
        priceDict["CaPrice"] = Random.Range(0, 100);
        priceDict["GoldPrice"] = Random.Range(0, 100);
        priceDict["NotACubePrice"] = Random.Range(0, 100);
        priceDict["PoopPrice"] = Random.Range(0, 100);
        priceDict["RocketPrice"] = Random.Range(0, 100);
    }

    private void ClickedSteak() {
        if(game.playerDict["CashHeld"] >= priceDict["SteakCurrentPrice"]) {
            game.playerDict["CashHeld"] -= priceDict["SteakCurrentPrice"];
            game.playerDict["SteakPurchased"] += 1;
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.currentHealth += 30;
            if (player.currentHealth > player.maxHealth) player.currentHealth = player.maxHealth;
            UpdatePrices();
        }
    }
    private void ClickedGun() {
        if(game.playerDict["CashHeld"] >= priceDict["GunCurrentPrice"]) {
            game.playerDict["CashHeld"] -= priceDict["GunCurrentPrice"];
            game.playerDict["GunPurchased"] += 1;
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.damage += player.damageUpgradeIncrement;
            UpdatePrices();
        }
    }
    private void ClickedBoots() {
        if(game.playerDict["CashHeld"] >= priceDict["BootsCurrentPrice"]) {
            game.playerDict["CashHeld"] -= priceDict["BootsCurrentPrice"];
            game.playerDict["BootsPurchased"] += 1;
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.speed += player.speedUpgradeIncrement;
            UpdatePrices();
        }
    }
    private void ClickedCoffee() {
        if(game.playerDict["CashHeld"] >= priceDict["CoffeeCurrentPrice"]) {
            game.playerDict["CashHeld"] -= priceDict["CoffeeCurrentPrice"];
            game.playerDict["CoffeePurchased"] += 1;
            UpdatePrices();
        }
    }

    private void SellCa() {
        game.playerDict["CashHeld"] += game.playerDict["CaHeld"] * priceDict["CaPrice"];
        game.playerDict["CaHeld"] = 0;
        UpdatePrices();
    }
    private void SellGold() {
        game.playerDict["CashHeld"] += game.playerDict["GoldHeld"] * priceDict["GoldPrice"];
        game.playerDict["GoldHeld"] = 0;
        UpdatePrices();
    }
    private void SellNotACube() {
        game.playerDict["CashHeld"] += game.playerDict["NotACubeHeld"] * priceDict["NotACubePrice"];
        game.playerDict["NotACubeHeld"] = 0;
        UpdatePrices();
    }
    private void SellPoop() {
        game.playerDict["CashHeld"] += game.playerDict["PoopHeld"] * priceDict["PoopPrice"];
        game.playerDict["PoopHeld"] = 0;
        UpdatePrices();
    }
    private void SellRocket() {
        game.playerDict["CashHeld"] += game.playerDict["RocketHeld"] * priceDict["RocketPrice"];
        game.playerDict["RocketHeld"] = 0;
        UpdatePrices();
    }
}
