using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Color Color { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Color = ItemHelper.GetRandomItemColor();
        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
