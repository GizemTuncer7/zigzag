using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_platform : MonoBehaviour
{
    public GameObject finalPlatform;
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            CreatingPlatform();
        }
    }
    public void CreatingPlatform()
    {
        Vector3 direction;
        if (Random.Range(0, 2) == 0) { direction = Vector3.right; }
        else { direction = Vector3.back; }
        transform.rotation = Quaternion.identity;
        finalPlatform=Instantiate(finalPlatform,finalPlatform.transform.position+direction,transform.rotation);
    }

    
    void Update()
    {
        
    }
}
