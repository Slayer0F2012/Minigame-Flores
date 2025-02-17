using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necess�rio para usar o TextMesh Pro

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new(); // Lista de itens do invent�rio
    public TextMeshProUGUI itemCountText; // Refer�ncia ao TextMeshPro para exibir a quantidade de itens

    static Inventory instance;

    private void Awake()
    {
        // Garantir que s� tenha uma inst�ncia do Inventory
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetItem(Item newItem)
    {
        if (instance == null) return;

        // Verifica se o item j� existe no invent�rio usando o 'id'
        InventoryItem existingItem = instance.items.Find(item => item != null && item.item.id == newItem.id);

        if (existingItem != null)
        {
            // Se o item j� existir, apenas aumenta a quantidade
            existingItem.quantity += 1;  // Incrementa a quantidade
            UIManager.UpdateInventorySlot(existingItem); // Atualiza a UI com a nova quantidade
        }
        else
        {
            // Se n�o existir, adiciona o item ao invent�rio
            instance.items.Add(new InventoryItem()
            {
                item = newItem,
                quantity = 1,
            });
            UIManager.SetInventoryImages(newItem); // Adiciona a imagem e a quantidade � UI
        }

        // Atualiza o contador de itens
        instance.UpdateItemCount();
    }

    // Fun��o para atualizar o contador de itens no TextMesh Pro
    void UpdateItemCount()
    {
        int totalItemCount = 0;

        // Conta a quantidade total de itens no invent�rio
        foreach (var item in items)
        {
            totalItemCount += item.quantity; // Soma as quantidades de todos os itens
        }

        // Atualiza o texto do contador
        if (itemCountText != null)
        {
            itemCountText.text = "Total de Itens: " + totalItemCount.ToString(); // Exibe a quantidade total
        }
    }
}
