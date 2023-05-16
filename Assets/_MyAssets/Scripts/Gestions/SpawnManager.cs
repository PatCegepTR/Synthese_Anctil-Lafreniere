using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemie = default;
    [SerializeField] private GameObject _prefabBoss = default;
    [SerializeField] private GameObject[] _listePUs = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private float _tempsSpawn = 5.0f;

    private bool _isSpawning = false;
    private bool _bossISSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBossRoutine());
        StartCoroutine(SpawnPURoutine());
    }


    IEnumerator SpawnPURoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_isSpawning)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-35f, 35f), 7f, 0);
            int randomPU = Random.Range(0, _listePUs.Length);
            GameObject newPU = Instantiate(_listePUs[randomPU], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
    

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_isSpawning)
        {
            Vector3 posSpawn = new Vector3(40, Random.Range(-0.44f, -2f), 0);
            GameObject newEnemy = Instantiate(_prefabEnemie, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_tempsSpawn);
        }
        
    }

    IEnumerator SpawnBossRoutine()
    {
        yield return new WaitForSeconds(120f);
        while (!_bossISSpawning)
        {
            Vector3 posSpawn = new Vector3(40, 0, 0);
            GameObject newEnemy = Instantiate(_prefabBoss, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(120f);
        }

    }

    public void setBoss()
    {
        _bossISSpawning = false;
 
    }

    public void LvlHarder()
    {
        _tempsSpawn = _tempsSpawn * 0.8f;
    }


    public void FinPartie()
    {
        _isSpawning = true;
        _bossISSpawning = true;
    }
}
