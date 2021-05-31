using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monstersReferences;
    [SerializeField] private Transform leftPosition, rightPosition;
    private GameObject _spawnedMonster;
    private int _randomIndex;
    private int _randomSide;


    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            _randomIndex = Random.Range(0, monstersReferences.Length);
            _randomSide = Random.Range(0, 2);
            _spawnedMonster = Instantiate(monstersReferences[_randomIndex]);

            if (_randomSide == 0)
            {
                _spawnedMonster.transform.position = new Vector3(leftPosition.position.x,leftPosition.position.y,0);
                _spawnedMonster.GetComponent<EnemiesController>().speed = Random.Range(4, 10);
            }
            else
            {
                _spawnedMonster.transform.position = new Vector3(rightPosition.position.x,rightPosition.position.y,0);
                _spawnedMonster.GetComponent<EnemiesController>().speed = -Random.Range(4, 10);
                _spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            
        }
    }
    
}
