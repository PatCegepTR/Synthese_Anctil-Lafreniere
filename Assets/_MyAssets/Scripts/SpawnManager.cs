using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy = default;
    [SerializeField] private GameObject[] _listePUPrefabs = default;
    [SerializeField] private GameObject _enemyContainer = default;
    private bool _stopSpawn = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPURoutine());
    }

    IEnumerator SpawnPURoutine()
    {
        yield return new WaitForSeconds(Random.Range(5.0f,9.0f));
        while (!_stopSpawn)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.3f, 8.3f), 7f, 0f);
            int randomPU = Random.Range(0, _listePUPrefabs.Length);
            Instantiate(_listePUPrefabs[randomPU], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(8.0f, 15.0f));
        }

    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(!_stopSpawn)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.3f, 8.3f), 7f, 0f);
            GameObject newEnemy = Instantiate(_prefabEnemy, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(4f);
        }
        
    }
    public void FinJeu()
    {
        _stopSpawn = true;
    }

}
