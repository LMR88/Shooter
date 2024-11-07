using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    float moveHorizontal=0;
    float moveVertical=0;
    public float moveSpeed = 0.5f;
    public float xMinLim=-2f;
    public float xMaxLim=2f;
    public float zMinLim=-2f;
    public float zMaxLim=2f;
    public float tiltSpeed = 10f;

    public GameObject lazerPrefab;
    public GameObject lazerSpawn;

    public float fireRate = 0.3f;
    private float lastFireTime = -1f;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gestion des déplacements
       moveHorizontal = Input.GetAxis("Horizontal");
       moveVertical = Input.GetAxis("Vertical");
       

       Vector3 direction = new Vector3(moveHorizontal,0,moveVertical);
       direction = direction.normalized;
       GetComponent<Rigidbody>().velocity= direction * moveSpeed;

       Vector3 horizontalRot = new Vector3(0, 0, moveHorizontal);
       GetComponent<Rigidbody>().rotation = Quaternion.Euler(horizontalRot*-tiltSpeed);

       Vector3 initialPosition = transform.position;
       float newX = Mathf.Clamp(initialPosition.x, xMinLim, xMaxLim);
       float newZ = Mathf.Clamp(initialPosition.z, zMinLim, zMaxLim);
       transform.position = new Vector3(newX, 0, newZ);
       
       //gestion du tir
       if (Input.GetButtonDown("Fire1") && (Time.time - lastFireTime)>fireRate)
       {
           Instantiate(lazerPrefab, lazerSpawn.transform);
           GetComponent<AudioSource>().Play();
           lastFireTime = Time.time;
       }



    }
}
