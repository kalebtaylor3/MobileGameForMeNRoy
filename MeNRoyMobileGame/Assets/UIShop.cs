using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{

    private Transform container;
    private Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat1), Items.GetCost(Items.ItemType.Hat1), 1);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat2), Items.GetCost(Items.ItemType.Hat2), 2);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat3), Items.GetCost(Items.ItemType.Hat3), 3);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat4), Items.GetCost(Items.ItemType.Hat4), 4);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat5), Items.GetCost(Items.ItemType.Hat5), 5);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat6), Items.GetCost(Items.ItemType.Hat6), 6);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat7), Items.GetCost(Items.ItemType.Hat7), 7);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat8), Items.GetCost(Items.ItemType.Hat8), 8);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat9), Items.GetCost(Items.ItemType.Hat9), 9);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat10), Items.GetCost(Items.ItemType.Hat7), 10);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat11), Items.GetCost(Items.ItemType.Hat8), 11);
        CreateItemButton(Items.GetSprite(Items.ItemType.Hat12), Items.GetCost(Items.ItemType.Hat9), 12);
    }

    private void CreateItemButton(Sprite itemSprite, int itemCost, int poisitonIndex)
    {
        Transform shopItemTransfrom = Instantiate(shopItemTemplate, container);
        shopItemTransfrom.gameObject.SetActive(true);
        RectTransform shopItemRectTransfrom = shopItemTransfrom.GetComponent<RectTransform>();
        float shopItemHeight = -20;
        float shopItemWidth = 260;
        switch (poisitonIndex)
        {
            case 1:
            case 2:
            case 3:
                shopItemRectTransfrom.anchoredPosition = new Vector2(shopItemWidth * poisitonIndex - 295, -shopItemHeight);
                break;
            case 4:
            case 5:
            case 6:
                shopItemRectTransfrom.anchoredPosition = new Vector2(shopItemWidth * poisitonIndex - 1080, -shopItemHeight - shopItemWidth);
                break;
            case 7:
            case 8:
            case 9:
                shopItemRectTransfrom.anchoredPosition = new Vector2(shopItemWidth * poisitonIndex - 1865, -shopItemHeight - (shopItemWidth + 250));
                break;
            case 10:
            case 11:
            case 12:
                shopItemRectTransfrom.anchoredPosition = new Vector2(shopItemWidth * poisitonIndex - 2650, -shopItemHeight - (shopItemWidth + 500));
                break;
            default: return;
        }
        shopItemTransfrom.Find("costText").GetComponent<Text>().text = itemCost.ToString();

        shopItemTransfrom.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransfrom.Find("costText").GetComponent<Text>().text = itemCost.ToString();

        shopItemTransfrom.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
    }

}
