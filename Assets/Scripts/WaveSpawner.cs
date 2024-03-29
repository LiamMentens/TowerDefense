﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform spawnPoint;

    public Wave[] waves;

    public float timeBetweenWaves = 4f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    public GameManager gameManager;
    private void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        } 
        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:0.00}", countdown);
    }


    IEnumerator SpawnWave()
    {
        Debug.Log("Incoming wave");
        PlayerStats.Rounds++;


        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {

            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        
        }
        waveIndex++;
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }


    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
