using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayform : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
