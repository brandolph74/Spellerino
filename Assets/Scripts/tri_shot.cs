using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tri_shot : MonoBehaviour
{

    public GameObject camera;
    public GameObject triProjectile;
    //public static List<GameObject> triShot;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().takeDamage(25f);
            Destroy(gameObject);
        }
    }

}
