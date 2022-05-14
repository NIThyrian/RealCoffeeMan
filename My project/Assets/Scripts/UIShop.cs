using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIShop : MonoBehaviour
{
    [SerializeField] private PlayerScript player;

    private Dictionary<string, int> priceDict;

    private void Start() {
        priceDict = new Dictionary<string, int> {
            {"SteakPrice", 0},
            {"GunPrice", 0},
            {"BootsPrice", 0},
            {"CoffeePrice", 0},
            {"CaPrice", 0},
            {"GoldPrice", 0},
            {"NotACubePrice", 0},
            {"PoopPrice", 0},
            {"RocketPricePrice", 0}
        };
        RandomizeCurrencies();
        SetBtnActions();
    }

    void Update() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void SetBtnActions() {
        Transform steakItem = transform.Find("SteakItem");
        steakItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedSteak(); } );
        steakItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["SteakPrice"]).ToString();

        Transform gunItem = transform.Find("GunItem");
        gunItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedGun(); } );
        gunItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["GunPrice"]).ToString();

        Transform bootsItem = transform.Find("BootsItem");
        bootsItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedBoots(); } );
        bootsItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["BootsPrice"]).ToString();

        Transform coffeeItem = transform.Find("CoffeeItem");
        coffeeItem.GetComponent<Button>().onClick.AddListener(delegate { ClickedCoffee(); } );
        coffeeItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["CoffeePrice"]).ToString();

        Transform caCoin = transform.Find("CaCoin");
        caCoin.GetComponent<Button>().onClick.AddListener(delegate { SellCa(); } );
        caCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["CaPrice"]).ToString();

        Transform goldCoin = transform.Find("GoldCoin");
        goldCoin.GetComponent<Button>().onClick.AddListener(delegate { SellGold(); } );
        goldCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["GoldPrice"]).ToString();

        Transform notACubeCoin = transform.Find("NotACubeCoin");
        notACubeCoin.GetComponent<Button>().onClick.AddListener(delegate { SellNotACube(); } );
        notACubeCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["NotACubePrice"]).ToString();

        Transform poopCoin = transform.Find("PoopCoin");
        poopCoin.GetComponent<Button>().onClick.AddListener(delegate { SellPoop(); } );
        poopCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["PoopPrice"]).ToString();

        Transform rocketCoin = transform.Find("RocketCoin");
        rocketCoin.GetComponent<Button>().onClick.AddListener(delegate { SellRocket(); } );
        rocketCoin.GetChild(0).GetComponent<TextMeshProUGUI>().text = (priceDict["RocketPrice"]).ToString();
    }

    private void RandomizeCurrencies() {
        priceDict["CaPrice"] = Random.Range(0, 100);
        priceDict["GoldPrice"] = Random.Range(0, 100);
        priceDict["NotACubePrice"] = Random.Range(0, 100);
        priceDict["PoopPrice"] = Random.Range(0, 100);
        priceDict["RocketPrice"] = Random.Range(0, 100);
    }

    private void UpdatePrices() { }

    private void ClickedSteak() {
        Debug.Log("AddHealth");
    }
    private void ClickedGun() {
        Debug.Log("AddDamage");
    }
    private void ClickedBoots() {
        Debug.Log("AddSpeed");
    }
    private void ClickedCoffee() {
        Debug.Log("FinishGame");
    }

    private void SellCa() {
        Debug.Log("SellCa");
    }
    private void SellGold() {
        Debug.Log("SellGold");
    }
    private void SellNotACube() {
        Debug.Log("SellNotACube");
    }
    private void SellPoop() {
        Debug.Log("SellPoop");
    }
    private void SellRocket() {
        Debug.Log("SellRocket");
    }
}
