using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Enemy_Health zombieHealth;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        zombieHealth = GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth.getHealth() > 0)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.speed = 0;
        }
        
    }

}
