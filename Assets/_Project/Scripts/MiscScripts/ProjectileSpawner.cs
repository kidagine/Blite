using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab = default;


    void Start()
    {
        StartCoroutine(SpawnProjectileCoroutine());
    }

    IEnumerator SpawnProjectileCoroutine()
    {
        Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        StartCoroutine(SpawnProjectileCoroutine());
    }
}
