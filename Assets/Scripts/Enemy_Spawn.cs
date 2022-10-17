using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    List<Transform> children = new List<Transform>();
    

    public GameObject zombiePrefab;
    public GameObject flyingPrefab;

    public GameObject[] enemies;

    public int enemySpawnCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //get list of children
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            children.Add(g);
        }

        


        
        StartCoroutine(Enemy_Spawner());
    }

    


    IEnumerator Enemy_Spawner()
    {
        while (true)
        {
 
            if (enemies.Length <= 10)
            {
                //get random number between 1 and 2
                int rand = Random.Range(1, 3);

                switch (rand)
                {
                    case 1:
                        //spawn enemy at random child
                        Instantiate(zombiePrefab, children[Random.Range(0, children.Count)].transform.position, Quaternion.identity);
                        break;

                    case 2:
                        Instantiate(flyingPrefab, children[Random.Range(0, children.Count)].transform.position, Quaternion.identity);
                        break;
                }
                enemySpawnCount++;
            }
            
            enemies = GameObject.FindGameObjectsWithTag("Enemy");  //get list of enemies


            //spawn enemy every 5 seconds
            yield return new WaitForSeconds(10/enemySpawnCount);
        }
    }
}
    

