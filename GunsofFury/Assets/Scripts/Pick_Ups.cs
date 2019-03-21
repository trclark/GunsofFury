using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Ups : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bob = new Vector3(transform.position.x, (Mathf.Sin(Time.time)/8) + 1, transform.position.z);
        transform.position = bob;
    }
}
