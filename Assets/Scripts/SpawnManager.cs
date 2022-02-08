using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _itemsPerWave = 3;
    public List<GameObject> ItemsPrefab;
    
    private const float _topBoundary = 14f;
    private const float _bottomBoundary = -14f;
    private const float _leftBoundary = -14f;
    private const float _rightBoundary = 14f;

    private int _itemCount;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnItemWave();
    }

    // Update is called once per frame
    private void Update()
    {
        _itemCount = FindObjectsOfType<Item>().Length;
        
        if(_itemCount == 0)
            SpawnItemWave();
    }
    
    private static Vector3 GenerateSpawnPos()
    {
        return new Vector3(
            Random.Range(_leftBoundary, _rightBoundary),
            0.5f,
            Random.Range(_bottomBoundary, _topBoundary));
    }

    private GameObject GetRandomItem()
    {
        return ItemsPrefab[Random.Range(0, ItemsPrefab.Count)];
    }

    private void SpawnItemWave()
    {
        for (var i = 0; i < _itemsPerWave; i++)
        {
            Instantiate(GetRandomItem(), GenerateSpawnPos(), Quaternion.identity);
        }
    }
}
