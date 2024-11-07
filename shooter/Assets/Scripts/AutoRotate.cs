using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autorotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = new Vector3( Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f));
        GetComponent<Rigidbody>().angularVelocity = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
