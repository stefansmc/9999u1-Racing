using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSound : MonoBehaviour
{
    //imaju 2 moda zvuka motora - kada se normalno krece, i kada ubrzava
    public AudioSource normal;
    public AudioSource acceleration;
    public AudioSource crash; //zvucni efekat kada se sudari tjst igrac pogine
    // Start is called before the first frame update
    void Start()
    {
        //pocetna podesavanja - cuje se normalni mod motora 
        normal.enabled = true;
        normal.loop = true;

        acceleration.enabled = false;
        acceleration.loop = true;

        crash.enabled = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && carSteering.moving)
        {
            normal.enabled = false;
            acceleration.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) && carSteering.moving)
        {
            acceleration.enabled = false;
            normal.enabled = true;
        }
        if (!carSteering.moving)
        {
            acceleration.enabled = false;
            normal.enabled = false;
            crash.enabled = true;
        }
    }
}
