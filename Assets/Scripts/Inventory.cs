using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necessário para usar o TextMesh Pro

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new(); // Lista de itens do inventário
    public TextMeshProUGUI itemCountText; // Referência ao TextMeshPro para exibir a quantidade de itens

    static Inventory instance;

    private void Awake()
    {
        // Garantir que só tenha uma instância do Inventory
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

        // Verifica se o item já existe no inventário usando o 'id'
        InventoryItem existingItem = instance.items.Find(item => item != null && item.item.id == newItem.id);

        if (existingItem != null)
        {
            // Se o item já existir, apenas aumenta a quantidade
            existingItem.quantity += 1;  // Incrementa a quantidade
            UIManager.UpdateInventorySlot(existingItem); // Atualiza a UI com a nova quantidade
        }
        else
        {
            // Se não existir, adiciona o item ao inventário
            instance.items.Add(new InventoryItem()
            {
                item = newItem,
                quantity = 1,
            });
            UIManager.SetInventoryImages(newItem); // Adiciona a imagem e a quantidade à UI
        }

        // Atualiza o contador de itens
        instance.UpdateItemCount();
    }

    // Função para atualizar o contador de itens no TextMesh Pro
    void UpdateItemCount()
    {
        int totalItemCount = 0;

        // Conta a quantidade total de itens no inventário
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
