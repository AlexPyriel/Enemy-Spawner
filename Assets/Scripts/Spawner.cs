using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;

    private SpawnSpot[] _spawnSpots;
    private float _spawnDelay = 2f;

    private void Awake()
    {
        _spawnSpots = GetComponentsInChildren<SpawnSpot>();
        if (_spawnSpots.Length == 0)
        {
            Debug.LogError("Spawn spots game objects missing");
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (_spawnSpots.Length != 0)
        {
            int randomIndex = Random.Range(0, _spawnSpots.Length);
            Vector3 spawnPosition = _spawnSpots[randomIndex].transform.position;
            Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemy.Init(_target);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
