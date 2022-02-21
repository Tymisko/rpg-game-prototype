using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private float topBoundary = 14f;
        [SerializeField] private float bottomBoundary = -14f;
        [SerializeField] private float leftBoundary = -14f;
        [SerializeField] private float rightBoundary = 14f;
        public List<GameObject> ItemsPrefab;

        private List<GameObject> _spawnedItems = new List<GameObject>();

        private void Start()
        {
            SpawnItemWave(3);
        }

        private GameObject GetRandomItem()
        {
            return ItemsPrefab[Random.Range(0, ItemsPrefab.Count)];
        }

        private Vector3 GenerateSpawnPos()
        {
            return new Vector3(
                Random.Range(leftBoundary, rightBoundary),
                0.5f,
                Random.Range(bottomBoundary, topBoundary));
        }

        private void ItemRemovedHandler(GameObject item)
        {
            _spawnedItems.Remove(item);

            if (!_spawnedItems.Any())
                SpawnItemWave(3);
        }

        private void SpawnItemWave(int itemsNumber)
        {
            for (var i = 0; i < itemsNumber; i++)
            {
                var gameObj = Instantiate(GetRandomItem(), GenerateSpawnPos(), Quaternion.identity);
                _spawnedItems.Add(gameObj);

                gameObj.GetComponent<Item>().OnItemRemoved += ItemRemovedHandler;
            }
        }
    }
}