using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.transform.forward);
    }
}
