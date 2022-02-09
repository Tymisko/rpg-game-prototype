using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
