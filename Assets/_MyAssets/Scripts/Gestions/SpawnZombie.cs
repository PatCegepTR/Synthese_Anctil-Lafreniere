using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemie = default;
    //[SerializeField] private GameObject[] _listePUs = default;
    [SerializeField] private GameObject _enemyContainer = default;
    private bool _isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        //StartCoroutine(SpawnPURoutine());
    }
    /*
    IEnumerator SpawnPURoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_isSpawning)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0);
            int randomPU = Random.Range(0, _listePUs.Length);
            GameObject newPU = Instantiate(_listePUs[randomPU], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(40f);
        }
    }
    */

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_isSpawning)
        {
            Vector3 posSpawn = new Vector3( 73, Random.Range(-0.44f, -2f), 0);
            GameObject newEnemy = Instantiate(_prefabEnemie, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }

    }

    public void FinPartie()
    {
        _isSpawning = true;
    }
}
