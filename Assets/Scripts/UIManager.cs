using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] inventoryImages; // Imagens dos slots do inventário
    public Text[] inventoryQuantityTexts; // Textos para mostrar as quantidades

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

    // Atualiza o inventário com um novo item (ou coloca ele no primeiro slot vazio)
    public static void SetInventoryImages(Item item)
    {
        if (Instance == null) return;

        // Encontrar o primeiro slot vazio
        for (int i = 0; i < Instance.inventoryImages.Length; i++)
        {
            // Se o slot estiver vazio
            if (!Instance.inventoryImages[i].gameObject.activeInHierarchy)
            {
                // Coloca a imagem do item no slot vazio
                Instance.inventoryImages[i].sprite = item.itemImage;
                Instance.inventoryImages[i].gameObject.SetActive(true);

                // Atualiza a quantidade no texto correspondente
                if (Instance.inventoryQuantityTexts.Length > i && Instance.inventoryQuantityTexts[i] != null)
                {
                    // Exibe a quantidade no slot (no canto inferior direito)
                    Instance.inventoryQuantityTexts[i].text = item.quantity.ToString();
                    RectTransform rt = Instance.inventoryQuantityTexts[i].GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(1, 0);  // Âncora para o canto inferior direito
                    rt.anchorMax = new Vector2(1, 0);
                    rt.anchoredPosition = new Vector2(-5, 5); // Ajuste a posição conforme necessário
                }
                break;
            }
        }
    }

    // Atualiza a quantidade de um item já existente no inventário
    public static void UpdateInventorySlot(Item item)
    {
        if (Instance == null) return;

        // Procurar pelo item no inventário e atualizar a quantidade
        for (int i = 0; i < Instance.inventoryImages.Length; i++)
        {
            // Verifica se a imagem do slot é a mesma do item
            if (Instance.inventoryImages[i].sprite == item.itemImage)
            {
                // Atualiza a quantidade no slot correspondente
                if (Instance.inventoryQuantityTexts.Length > i && Instance.inventoryQuantityTexts[i] != null)
                {
                    Instance.inventoryQuantityTexts[i].text = item.quantity.ToString();
                }
                break;
            }
        }
    }
}
