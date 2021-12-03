using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;

    private Spot[] _spots;
    private float _spawnDelay = 2f;

    private void Awake()
    {
        _spots = GetComponentsInChildren<Spot>();
        if (_spots.Length == 0)
        {
            Debug.LogError("Spawn spots game objects missing");
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_spots.Length != 0)
        {
            var waitForSeconds = new WaitForSeconds(_spawnDelay);
            int randomIndex = Random.Range(0, _spots.Length);
            Vector3 spawnPosition = _spots[randomIndex].transform.position;
            Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemy.Init(_target);
            yield return waitForSeconds;
        }
    }
}
