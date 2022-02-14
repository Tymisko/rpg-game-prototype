using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
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

        private void DisplayInventory()
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
                if (!_itemColorCounter.ContainsKey(color))
                    _itemColorCounter.Add(color, 0);
            }
        }

        public static event Action OnItemCollected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagsHelper.Item))
            {
                _itemColorCounter[other.gameObject.GetComponent<Item>().Color] += 1;
                OnItemCollected?.Invoke();
            }
        }
    }
}