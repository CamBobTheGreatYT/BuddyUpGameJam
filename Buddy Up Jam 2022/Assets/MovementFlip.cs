using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("a") && transform.eulerAngles.y == 90.0f)
        {
            transform.Rotate (Vector3.up, 180.0f);
            Debug.Log ("working");
        }
 
        if(Input.GetKey("d") && transform.eulerAngles.y == 270.0f)
        {
            transform.Rotate (Vector3.up, -180.0f);
        }
    }
}
