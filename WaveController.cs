using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    [SerializeField] private Wave _currentWave;
    [SerializeField] private float _waveOffset;

    private int _currentWaveIndex;

    private void Start()
    {
        _currentWave = _waves[0];
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private void SetNewWave()
    {

    }

    private void SpawnEnemies()
    {

    }
    
    private IEnumerator SpawnEnemiesCoroutine()
    {
        for (int i = 0; i < _currentWave._count; i++)
        {
            yield return new WaitForSeconds(_currentWave._spawnOffset);
            EnemyHealth enemy = Instantiate(_currentWave._enemies[UnityEngine.Random.Range(0, _currentWave._enemies.Count)]);
        }
        Debug.Log("Новая Волна");
    }

}

[Serializable] public class Wave
{
    [SerializeField] public List<EnemyHealth> _enemies = new List<EnemyHealth>();
    [SerializeField] public float _spawnOffset;
    [SerializeField] public int _count;
}