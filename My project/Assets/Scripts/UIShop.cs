using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    [SerializeField] private DeplacementPersonnageMika player;

    private void Awake() {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
    }

    private void Start() {
        Sprite steakSprite = Resources.Load<Sprite>("Steak");
        Sprite gunSprite = Resources.Load<Sprite>("Gun");
        Sprite bootsSprite = Resources.Load<Sprite>("Boots");

        CreateItemButton(steakSprite, "Steak", 10, 0);
        CreateItemButton(gunSprite, "Gun", 100, 1);
        CreateItemButton(bootsSprite, "Boots", 100, 2);
    }

    void Update() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemPrice, int positionIndex) {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);

        float shopItemHeight = 60f;
        shopItemTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("ItemNameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("ItemPriceText").GetComponent<TextMeshProUGUI>().SetText(itemPrice.ToString());
        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.gameObject.SetActive(true);
        shopItemTransform.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ClickedShopItem(); });
    }

    private void ClickedShopItem() {
        player.health += 10;
        Debug.Log(player.health);
    }

    private string GetItemDescription(string itemName) {
        string itemDescription = "";
        switch(itemName) {
            case "Steak":
                itemDescription = "Steak";
                break;
            case "Gun":
                itemDescription = "Gun";
                break;
            case "Boots":
                itemDescription = "Boots";
                break;
            default:
                Debug.Log("Not able to find item in UIShop/GetItemDescription");
                break;
        }
        return itemDescription;
    }
}
