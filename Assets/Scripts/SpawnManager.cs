using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> ItemsPrefab;
    private List<GameObject> _spawnedItems = new List<GameObject>();

    private int _itemsPerWave = 3;
    
    private const float TopBoundary = 14f;
    private const float BottomBoundary = -14f;
    private const float LeftBoundary = -14f;
    private const float RightBoundary = 14f;

    private int _itemCount;
    private void Start()
    {
        SpawnItemWave();
    }
    
    public GameObject GetRandomItem()
    {
        return ItemsPrefab[Random.Range(0, ItemsPrefab.Count)];
    }
    
    private static Vector3 GenerateSpawnPos()
    {
        return new Vector3(
            Random.Range(LeftBoundary, RightBoundary),
            0.5f,
            Random.Range(BottomBoundary, TopBoundary));
    }

    private void SphereRemovedEventHandler(GameObject sphere)
    {
        _spawnedItems.Remove(sphere);
        
        if(!_spawnedItems.Any())
            SpawnItemWave();
    }

    private void SpawnItemWave()
    {
        for (var i = 0; i < _itemsPerWave; i++)
        {
            var gameObject = Instantiate(GetRandomItem(), GenerateSpawnPos(), Quaternion.identity);
            _spawnedItems.Add(gameObject);
            gameObject.GetComponent<Sphere>().OnSphereRemoved += SphereRemovedEventHandler;
        }
    }
    
}
