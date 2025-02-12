using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public string id; // Adiciona um campo 'id' para identificação única
    public string itemName;
    public Sprite itemImage;
    public string description;
    public int quantity;
}