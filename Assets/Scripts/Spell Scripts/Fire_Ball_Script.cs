using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Ball_Script : MonoBehaviour
{

    public GameObject camera;

    public Rigidbody fireballRB;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("player camera");
        fireballRB = GetComponent<Rigidbody>();

        fireballRB.AddRelativeForce(Vector3.forward * 3000);

        StartCoroutine(spawnTimer());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().takeDamage(50f);
            Destroy(gameObject);
        }
    }
}

