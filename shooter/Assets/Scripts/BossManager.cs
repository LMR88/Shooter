using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public GameObject Boss;
    
    public float horizontalScale = 6f;

    public float zSpawn = 13f;
    
    public float BossApparition = 4f;
    
    private bool bossAlreadySpawned = false;

    public static BossManager instance;

    public GameObject SliderObject;
    
    
    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }

    public void startBossSpawn()
    {
        StartCoroutine(BossSpawn());
    }

    IEnumerator BossSpawn()
    {
        float xSpawn = Random.Range(-horizontalScale, horizontalScale);
        Vector3 spawnPositionEnd = new Vector3(xSpawn, 0, zSpawn);
        Vector3 spawnPositionStart = new Vector3(xSpawn, 0, zSpawn+8);
        GameObject bossGameObject = Instantiate(Boss, spawnPositionStart, Quaternion.identity);
        bossGameObject.GetComponent<BossController>().setSpawnDestination(spawnPositionEnd);
        //bossGameObject.GetComponent<Animation>().Play();
        bossAlreadySpawned = true;
        SliderObject.SetActive(true);
        
        

        yield return new WaitForSeconds(BossApparition);
    }
    
    
}

