using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooterino : MonoBehaviour
{
    PlayerControls controls;
    
    public GameObject camera;
    public GameObject fireBall;
    public GameObject MagicBurst;
    public GameObject triProjectile;

    int currentSpell = 1;

    public Coroutine magicBurstDelay;

    Vector2 scrollWheel;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();

        camera = GameObject.Find("player camera");

    }

    // Update is called once per frame
    void Update()
    {
        scrollWheel = controls.Gameplay.SwitchSpell.ReadValue<Vector2>();

        if (scrollWheel.y < 0)
        {
            currentSpell = currentSpell - 1;
        }
        if (scrollWheel.y > 0)
        {
            currentSpell = currentSpell + 1;
        }

        Debug.Log(currentSpell);
        
        if (currentSpell > 3)     //upper bound
        {
            currentSpell = 1;
        }
        if (currentSpell < 1)     //lower bound
        {
            currentSpell = 3;
        }
        


        if (controls.Gameplay.Cast.triggered)
        {
            switch (currentSpell)
            {
                
                case 1:  //Fire Ball
                   
                    Instantiate(fireBall, camera.transform.position, camera.transform.rotation);
                    break;
                
                case 2: //Magic Burst
                    
                    if (magicBurstDelay == null)
                    {
                        Instantiate(MagicBurst, camera.transform.position, camera.transform.rotation);
                        magicBurstDelay = StartCoroutine(mbDelay());
                    }
                    break;
                    
                case 3: //Tri-Shot

                    var leftGuide = GameObject.Find("left shot");
                    var rightGuide = GameObject.Find("right shot");
                    Vector3 dir;

                    //left
                    var leftShot = Instantiate(triProjectile, camera.transform.position, camera.transform.rotation);
                    var leftRb = leftShot.GetComponent<Rigidbody>();
                    dir = leftGuide.transform.position - camera.transform.position;
                    leftRb.AddForce(dir * 1000);  //dont need to multiply by time.deltatime because AddForce already does that
                    

                    //right
                    var rightShot = Instantiate(triProjectile, camera.transform.position, camera.transform.rotation);
                    var rightRb = rightShot.GetComponent<Rigidbody>();
                    dir = rightGuide.transform.position - camera.transform.position;
                    rightRb.AddForce(dir * 1000);  //dont need to multiply by time.deltatime because AddForce already does that

                    //center
                    var centerShot = Instantiate(triProjectile, camera.transform.position, camera.transform.rotation);
                    var centerRb = centerShot.GetComponent<Rigidbody>();
                    centerRb.AddForce(camera.transform.forward * 2750);  //dont need to multiply by time.deltatime because AddForce already does that
                    
                    break;
            }
        }

        
    }

    /// <summary>
    /// Delay to prevent spamming magic burst
    /// </summary>
    /// <returns></returns>
    IEnumerator mbDelay()
    {
        yield return new WaitForSeconds(3f);
        magicBurstDelay = null;
    }

}
    

