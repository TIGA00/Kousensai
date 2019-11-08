using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 6f * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * 6f * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * 6f * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * 6f * Time.deltaTime;
        }
    }
}
