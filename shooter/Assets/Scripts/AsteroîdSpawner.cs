using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroîdSpawner : MonoBehaviour
{
    public GameObject asteroîd1;

    public GameObject asteroîd2;
    
    public float horizontalScale = 6f;

    public float zSpawn = 13f;

    public int spawnCountInWave = 5;

    public float delayInWave = 0.5f;

    public int numberOfWaves = 9;

    public float delayBetweenWaves = 4f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaveSpawn()
    {
        for (int i = 0; i < numberOfWaves; i++)
        {
            for (int j = 0; j < spawnCountInWave; j++)
            {
                float xSpawn = Random.Range(-horizontalScale, horizontalScale);
                Vector3 spawnPosition = new Vector3(xSpawn, 0, zSpawn);
                float randomValue = Random.Range(0, 2);
                if (randomValue < 1 )
                {
                    Instantiate(asteroîd1, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(asteroîd2, spawnPosition, Quaternion.identity);
                }

                yield return new WaitForSeconds(delayInWave);
            }

            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }

}
