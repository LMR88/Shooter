using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    float moveHorizontal=0;
    float moveVertical=0;
    public float moveSpeed = 0.5f;
    public float xMinLim=-2f;
    public float xMaxLim=2f;
    public float zMinLim=-2f;
    public float zMaxLim=2f;
    public float tiltSpeed = 10f;

    public GameObject LazerBossPrefab;
    public GameObject ShotSpawnBoss;

    public float fireRate = 0.3f;
    private float lastFireTime = -1f;

    [SerializeField]
    private Vector3 SpawnDestination;
    [SerializeField]
    private Vector3 SpawnPosition;
    public float spawnDelay = 2;
    public float spawnTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = transform.position;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ////// animation d'arrivée
        if (Time.time < spawnTime+spawnDelay)
        {
            float t = (Time.time-spawnTime) / spawnDelay;
            transform.position = Vector3.Lerp(SpawnPosition, SpawnDestination, t);
            Debug.Log(Vector3.Lerp(SpawnPosition, SpawnDestination, t));
        }
        //////
        
        //gestion des déplacements
        moveHorizontal = Input.GetAxis("HorizontalBoss");
        moveVertical = Input.GetAxis("VerticalBoss");
       

        Vector3 direction = new Vector3(moveHorizontal,0,moveVertical);
        direction = direction.normalized;
        GetComponent<Rigidbody>().velocity= direction * moveSpeed;

        Vector3 horizontalRot = new Vector3(0, 0, moveHorizontal);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(new Vector3(0,180,0))*Quaternion.Euler(horizontalRot*-tiltSpeed);

        Vector3 initialPosition = transform.position;
        float newX = Mathf.Clamp(initialPosition.x, xMinLim, xMaxLim);
        float newZ = Mathf.Clamp(initialPosition.z, zMinLim, zMaxLim);
        transform.position = new Vector3(newX, 0, newZ);
       
        //gestion du tir
        if (Input.GetButtonDown("Fire2") && (Time.time - lastFireTime)>fireRate)
        {
            Instantiate(LazerBossPrefab, ShotSpawnBoss.transform);
            GetComponent<AudioSource>().Play();
            lastFireTime = Time.time;
        }



    }

    public void setSpawnDestination(Vector3 destination)
    {
        SpawnDestination = destination;
    }
}
