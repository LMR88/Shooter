using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automove : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction = new Vector3(0, 0, 1);
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = direction * speed;
        }
}
