using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab = default;
    [SerializeField] private float _timeBetweenSpawn = default;


    void Start()
    {
        StartCoroutine(SpawnProjectileCoroutine());
    }

    IEnumerator SpawnProjectileCoroutine()
    {
        Instantiate(_projectilePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(_timeBetweenSpawn);
        StartCoroutine(SpawnProjectileCoroutine());
    }
}
