using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContactPlayer : MonoBehaviour
{
    public Slider PlayerLife;
    
    public GameManager gameManagerScriptReference;
    
    public GameObject AsteroîdExplosionVFX;
    
    public GameObject PlayerExplosionVFX;

    private int HealthPoints = 100;

    
    
    void Start()
    {
        gameManagerScriptReference = FindObjectOfType<GameManager>();
        PlayerLife = GameObject.Find("PlayerLife").GetComponent<Slider>();
    }

   
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroîd"))
        {
            Instantiate(AsteroîdExplosionVFX, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //lancer game over
            HealthPoints -= 10;
            HealthPoints = Mathf.Clamp(HealthPoints, 0, 100);
            PlayerLife.value = HealthPoints;
            if (HealthPoints == 0)
            {
                Destroy(gameObject);
                Instantiate(PlayerExplosionVFX, collision.transform.position,Quaternion.identity);
                gameManagerScriptReference.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("LazerBoss"))
        {
            Destroy(collision.gameObject);
            //lancer game over
            HealthPoints -= 20;
            HealthPoints = Mathf.Clamp(HealthPoints, 0, 100);
            PlayerLife.value = HealthPoints;
            if (HealthPoints == 0)
            {
                Destroy(gameObject);
                Instantiate(PlayerExplosionVFX, collision.transform.position,Quaternion.identity);
                gameManagerScriptReference.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<DestroyByContactBoss>().healthDown();
            //lancer game over
            HealthPoints -= 1;
            HealthPoints = Mathf.Clamp(HealthPoints, 0, 100);
            PlayerLife.value = HealthPoints;
            if (HealthPoints == 0)
            {
                Destroy(gameObject);
                Instantiate(PlayerExplosionVFX, collision.transform.position,Quaternion.identity);
                gameManagerScriptReference.GameOver();
            }
        }
    }
}
