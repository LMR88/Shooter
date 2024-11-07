using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject AsteroîdExplosionVFX;

    //public GameObject PlayerExplosionVFX;

    public GameManager gameManagerScriptReference;

    public int pointValue = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScriptReference = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(PlayerExplosionVFX, collision.transform.position,Quaternion.identity);
            //Destroy(collision.gameObject);
            //lancer game over
            //gameManagerScriptReference.GameOver();
            //Destroy(gameObject);
        } 
        if (collision.gameObject.CompareTag("Lazer"))
        {
            Instantiate(AsteroîdExplosionVFX, collision.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            gameManagerScriptReference.UpdateScore(pointValue);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LazerBoss"))
        {
            Instantiate(AsteroîdExplosionVFX, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


    }
}
