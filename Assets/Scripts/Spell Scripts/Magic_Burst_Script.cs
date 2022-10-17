using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Burst_Script : MonoBehaviour
{
    public GameObject playerBody;

    bool isColliding = false;

    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
        playerBody = GameObject.Find("Player Body");
        StartCoroutine(mbTimer());
        StartCoroutine(mbGrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator mbTimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator mbGrow()
    {
        while(true)
        {
            Vector3 currentScale = transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x + 0.25f, currentScale.y + 0.25f, currentScale.z + 0.25f);
            transform.localScale = newScale;
            yield return new WaitForSeconds(.01f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().magicBurstDamage(this.gameObject);
        }
    }

}
