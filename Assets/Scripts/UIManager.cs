using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] inventoryImages;
    public TextMeshProUGUI[] inventoryQuantityTexts;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void SetInventoryImages(Item item)
    {
        if (Instance == null) return;

        for (int i = 0; i < Instance.inventoryImages.Length; i++)
        {
            if (!Instance.inventoryImages[i].gameObject.activeInHierarchy)
            {
                Instance.inventoryImages[i].sprite = item.itemImage;
                Instance.inventoryImages[i].gameObject.SetActive(true);

                if (Instance.inventoryQuantityTexts.Length > i && Instance.inventoryQuantityTexts[i] != null)
                {
                    Instance.inventoryQuantityTexts[i].text = item.quantity.ToString();
                    RectTransform rt = Instance.inventoryQuantityTexts[i].GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(1, 0);
                    rt.anchorMax = new Vector2(1, 0);
                    rt.anchoredPosition = new Vector2(-5, 5);
                }
                break;
            }
        }
    }

    public static void UpdateInventorySlot(InventoryItem item)
    {
        if (Instance == null) return;

        for (int i = 0; i < Instance.inventoryImages.Length; i++)
        {
            if (Instance.inventoryImages[i].sprite == item.item.itemImage)
            {
                if (Instance.inventoryQuantityTexts.Length > i)
                {
                    Instance.inventoryQuantityTexts[i].text = item.quantity.ToString();
                }
                break;
            }
        }
    }
}
