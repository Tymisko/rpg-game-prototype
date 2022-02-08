using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryItem> _inventory = new List<InventoryItem>();
    private Dictionary<Color, int> _itemColorCounter = new Dictionary<Color, int>();

    private bool _isInvOpened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InitItemCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_isInvOpened)
            {
                DisplayInventory();
            }
            else
            {
                ClearLog();
                _isInvOpened = false;
            }
        }
    }

    public void DisplayInventory()
    {
        _isInvOpened = true;
        Debug.Log("Inventory");
        foreach (var itemColor in _itemColorCounter)
        {
            Debug.Log($"{ItemHelper.ItemsColors[itemColor.Key]} x {itemColor.Value}");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Item))
        {
            var item = other.gameObject.GetComponent<Sphere>();
            
            var inventoryElem = new InventoryItem(item.name, item.Color);
            _inventory.Add(inventoryElem);

            _itemColorCounter[item.Color] += 1;
            
            Destroy(other.gameObject);
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
    
public void ClearLog()
{
    var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    var type = assembly.GetType("UnityEditor.LogEntries");
    var method = type.GetMethod("Clear");
    method.Invoke(new object(), null);
}
}
