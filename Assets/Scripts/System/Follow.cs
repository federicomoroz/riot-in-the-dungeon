using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject followTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = followTo.transform.position;
        transform.rotation = followTo.transform.rotation;

    }
   
}
