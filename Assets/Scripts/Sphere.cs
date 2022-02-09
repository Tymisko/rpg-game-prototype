using System;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public event Action<GameObject> OnSphereRemoved; 
    public Color Color { get; private set; }
    
    void Start()
    {
        Color = ItemHelper.GetRandomItemColor();
        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player))
        {
            OnSphereRemoved?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}
