using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> ItemsPrefab;

    private int _itemsPerWave = 3;
    
    private const float TopBoundary = 14f;
    private const float BottomBoundary = -14f;
    private const float LeftBoundary = -14f;
    private const float RightBoundary = 14f;

    private int _itemCount;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnItemWave();
    }

    // Update is called once per frame
    private void Update()
    {
        _itemCount = FindObjectsOfType<Sphere>().Length;
        
        if(_itemCount == 0)
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


    private void SpawnItemWave()
    {
        for (var i = 0; i < _itemsPerWave; i++)
        {
            Instantiate(GetRandomItem(), GenerateSpawnPos(), Quaternion.identity);
        }
    }
    
}
