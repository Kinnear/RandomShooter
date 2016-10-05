using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMgr : MonoBehaviour {

    List<Enemy> listOfEnemies;
    public Enemy enemyPrefab;
    public int maxEnemies;

    [SerializeField]
    int startingEnemySpeed;

    public Vector3 spawnDir;

    int enemySpeed;
    public int EnemySpeed
    {
        set { enemySpeed = value; }
        get { return enemySpeed; }
    }


    // Use this for initialization
    void Start () {
        listOfEnemies = new List<Enemy>();

        // TEMPORARY
        enemySpeed = startingEnemySpeed;

        Enemy newEnemy = null;
        for (int i = 0; i < maxEnemies; i++)
        {
            newEnemy = Instantiate(enemyPrefab) as Enemy;
            listOfEnemies.Add(newEnemy);

            newEnemy.Teleport();
            newEnemy.gameObject.SetActive(false);
        }

        StartCoroutine(StartSpawningEnemies()); 
	}
	
    IEnumerator StartSpawningEnemies ()
    {
        while (true)
        {
            for (int i = 0; i < maxEnemies; ++i)
            {
                if (listOfEnemies[i].gameObject.activeSelf == false)
                {
                    listOfEnemies[i].gameObject.SetActive(true);
                    StartCoroutine(listOfEnemies[i].UpdateMovement(transform.position, enemySpeed, spawnDir));
                    break;
                }
            }

            yield return new WaitForSeconds(2.0f);
            yield return null;
        }
    }
}
