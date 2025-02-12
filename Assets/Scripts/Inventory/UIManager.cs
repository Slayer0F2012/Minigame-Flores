using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] inventoryImages; // Imagens dos slots do invent�rio
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

    // Atualiza o invent�rio com um novo item (ou coloca ele no primeiro slot vazio)
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
                    rt.anchorMin = new Vector2(1, 0);  // �ncora para o canto inferior direito
                    rt.anchorMax = new Vector2(1, 0);
                    rt.anchoredPosition = new Vector2(-5, 5); // Ajuste a posi��o conforme necess�rio
                }
                break;
            }
        }
    }

    // Atualiza a quantidade de um item j� existente no invent�rio
    public static void UpdateInventorySlot(Item item)
    {
        if (Instance == null) return;

        // Procurar pelo item no invent�rio e atualizar a quantidade
        for (int i = 0; i < Instance.inventoryImages.Length; i++)
        {
            // Verifica se a imagem do slot � a mesma do item
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
