using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContactBoss : MonoBehaviour
{
    
    public GameManager gameManagerScriptReference;
    
    public GameObject AsteroîdExplosionVFX;
    
    public GameObject BossExplosionVFX;
    
    public int HealthPointsBoss = 100;
    
    public Slider BossLife;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScriptReference = FindObjectOfType<GameManager>();
        BossLife = GameObject.Find("BossLife").GetComponent<Slider>();
    }

    // Update is called once per frame
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
            HealthPointsBoss -= 10;
            HealthPointsBoss = Mathf.Clamp(HealthPointsBoss, 0, 100);
            BossLife.value = HealthPointsBoss;
            if (HealthPointsBoss == 0)
            {
                Destroy(gameObject);
                Instantiate(BossExplosionVFX, collision.transform.position,Quaternion.identity);
                gameManagerScriptReference.Win();
            }
        }

        if (collision.gameObject.CompareTag("Lazer"))
        {
            Destroy(collision.gameObject);
            //lancer game over
            HealthPointsBoss -= 20;
            HealthPointsBoss = Mathf.Clamp(HealthPointsBoss, 0, 100);
            BossLife.value = HealthPointsBoss;
            if (HealthPointsBoss == 0)
            {
                Destroy(gameObject);
                Instantiate(BossExplosionVFX, collision.transform.position,Quaternion.identity);
                gameManagerScriptReference.Win();
            }
            
        }
    }

    public void healthDown()
    {
        HealthPointsBoss--;
        HealthPointsBoss = Mathf.Clamp(HealthPointsBoss, 0, 100);
        BossLife.value = HealthPointsBoss;
        if (HealthPointsBoss == 0)
        {
            Destroy(gameObject);
            Instantiate(BossExplosionVFX, gameObject.transform.position,Quaternion.identity);
            gameManagerScriptReference.Win();
        }
    }
}
