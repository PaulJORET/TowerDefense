using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5.5f;

    private float countDown = 2f;

    [SerializeField]
    private TMP_Text waveCountDownTimer;

    private int waveIndex = 0;

    void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        waveCountDownTimer.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawWave() {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
