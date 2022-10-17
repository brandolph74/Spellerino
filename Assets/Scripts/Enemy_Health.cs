using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    

    [SerializeField] private Slider healthBar;
    
        

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        
    }

    public float getHealth()
    {
        return currentHealth;
    }



    private void LateUpdate()
    {
        healthBar.value = currentHealth;
        
    }

    public bool takeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            try
            {
               var anim = GetComponent<Animator>();
                anim.Play("Z_FallingBack");
            }
            catch
            {
                Debug.Log("Animator not found");
                Destroy(gameObject);
            }
            return true;
        }
           
        
            
        
        else
        {
            return false;
        }
    }
    
    public void destroyThis()
    {
        Destroy(gameObject);
    }

    public void magicBurstDamage(GameObject magicBurst)
    {
        StartCoroutine(mbDamage(magicBurst));
    }

    IEnumerator mbDamage(GameObject magicBurst)
    {
        while (magicBurst != null)
        {
            takeDamage(2.5f);
            yield return new WaitForSeconds(0.05f);
        }
    }

}

