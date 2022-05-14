using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    private void Awake() {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
    }

    private void Start() {
        Sprite sprite = Resources.Load<Sprite>("Steak");
        CreateItemButton(sprite, "Steak", 100, 0);
        CreateItemButton(sprite, "Steak", 100, 1);
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemPrice, int positionIndex) {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 60f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemRectTransform.Find("ItemNameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemRectTransform.Find("ItemPriceText").GetComponent<TextMeshProUGUI>().SetText(itemPrice.ToString());
        shopItemRectTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemRectTransform.gameObject.SetActive(true);

        shopItemRectTransform.GetComponent<Button>().onClick.AddListener(() => ClickedShopItem());
    }

    private void ClickedShopItem() {
        
    }
}
