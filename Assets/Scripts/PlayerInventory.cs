using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryItem> _inventory = new List<InventoryItem>();
    private Dictionary<Color, int> _itemColorCounter = new Dictionary<Color, int>();
    
    void Start()
    {
        InitItemCounter();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            DisplayInventory();
    }

    public void DisplayInventory()
    {
        Debug.Log("Inventory");
        foreach (var itemColor in _itemColorCounter)
        {
            Debug.Log($"{ItemHelper.ItemsColors[itemColor.Key]} x {itemColor.Value}");
        }
    }
        
    private void InitItemCounter()
    {
        foreach (var color in ItemHelper.ItemsColorsKeys)
        {
            if(!_itemColorCounter.ContainsKey(color)) 
                _itemColorCounter.Add(color, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Item))
        {
            var item = other.gameObject.GetComponent<Item>();
            var inventoryItem = new InventoryItem(item.name, item.Color);
            _itemColorCounter[item.Color] += 1;
            _inventory.Add(inventoryItem);
        }
    }   
}
