using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public string waveName;
    public int noOfEnemies;
    public int _noOfEnemies;
    public float spawnInterval;
    public GameObject[] typeOfEnemies;

    public Transform[] spawnPoints;
    public Animator animator;
    public TextMeshProUGUI _waveName;

    private int currentWaveNumber = 1;
    private float nextSawnTime;

    private bool canSpawn = true;

    private void Update() 
    {
        waveName = "wave " + currentWaveNumber;
        _waveName.text = waveName;
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("mob");
        if (totalEnemies.Length == 0 && noOfEnemies == 0)
        {
            AddWave();
            animator.SetTrigger("WaveComplete");
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber = currentWaveNumber + 1 ;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if(canSpawn && nextSawnTime < Time.time)
        {
            GameObject randomEnemy = typeOfEnemies[Random.Range(0, typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            noOfEnemies--;
            nextSawnTime = Time.time + spawnInterval;
            if (noOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }

    void AddWave()
    {
        if(currentWaveNumber < 10)
        {
            _noOfEnemies = _noOfEnemies +1;
            noOfEnemies = _noOfEnemies;
        }
        if (currentWaveNumber == 10)
        {
            _noOfEnemies = 10;
            noOfEnemies = _noOfEnemies;
            spawnInterval = 2;
        }
        if (currentWaveNumber < 20 && currentWaveNumber > 10)
        {
            _noOfEnemies = _noOfEnemies +1;
            noOfEnemies = _noOfEnemies;
            spawnInterval = 4;
        }
        if(currentWaveNumber == 20)
        {
            _noOfEnemies = 20;
            noOfEnemies = _noOfEnemies;
            spawnInterval = 5;
        }
    }
}