using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> ItemsPrefab;
    private List<GameObject> _spawnedItems = new List<GameObject>();
    
    private int _itemCount;
    private void Start()
    {
        SpawnItemWave(3);
    }
    
    public GameObject GetRandomItem()
    {
        return ItemsPrefab[Random.Range(0, ItemsPrefab.Count)];
    }
    
    private static Vector3 GenerateSpawnPos()
    {
        const float topBoundary = 14f;
        const float bottomBoundary = -14f;
        const float leftBoundary = -14f;
        const float rightBoundary = 14f;
        
        return new Vector3(
            Random.Range(leftBoundary, rightBoundary),
            0.5f,
            Random.Range(bottomBoundary, topBoundary));
    }

    private void ItemRemovedHandler(GameObject item)
    {
        _spawnedItems.Remove(item);
        
        if(!_spawnedItems.Any())
            SpawnItemWave(3);
    }

    private void SpawnItemWave(int itemsNumber)
    {
        for (var i = 0; i < itemsNumber; i++)
        {
            var gameObject = Instantiate(GetRandomItem(), GenerateSpawnPos(), Quaternion.identity);
            _spawnedItems.Add(gameObject);
            
            gameObject.GetComponent<Item>().OnItemRemoved += ItemRemovedHandler;
        }
    }
    
}
