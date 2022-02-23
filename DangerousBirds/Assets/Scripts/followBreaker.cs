using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBreaker : MonoBehaviour
{
    public GameObject gameObject;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Player.isAlive == false)
        {
            gameObject.SetActive(false);
        }
    }
}
