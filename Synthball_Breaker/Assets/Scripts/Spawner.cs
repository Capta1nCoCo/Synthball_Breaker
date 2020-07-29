using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerModifiers;
    [SerializeField] int thresholdForSpawn = 100;
    [SerializeField] int monitorScore;
        
   
    void Update()
    {
        SpawnPowerModifier();
    }

    private void SpawnPowerModifier()
    {
        if (monitorScore >= thresholdForSpawn)
        {
            Instantiate(powerModifiers[UnityEngine.Random.Range(0, powerModifiers.Length)], transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            monitorScore = 0;
        }
        
    }
    
    public int MonitorScore(int pointsPerBlockDestroyed)
    {
        return monitorScore += pointsPerBlockDestroyed;
    }
}
