using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    static Inventory instance;

    private void Awake()
    {
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
        Item existingItem = instance.items.Find(item => item.id == newItem.id);

        if (existingItem != null)
        {
            // Se o item j� existir, apenas aumenta a quantidade
            existingItem.quantity += newItem.quantity;  // Incrementa a quantidade
            UIManager.UpdateInventorySlot(existingItem); // Atualiza a UI com a nova quantidade
        }
        else
        {
            // Se n�o existir, adiciona o item ao invent�rio
            instance.items.Add(newItem);
            UIManager.SetInventoryImages(newItem); // Adiciona a imagem e a quantidade � UI
        }
    }
}
