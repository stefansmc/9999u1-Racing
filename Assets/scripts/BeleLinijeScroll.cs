using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeleLinijeScroll : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 StartPostition;
    float speed;
    void Start()
    {
        StartPostition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = carSteering.speed; //vuku brzinu od igraca
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);

        //kada dodju do kraja ekrana, vratimo ih na pocetnu poziciju "iznad" i tako loopujemo
        if(transform.position.y < -9.904683f)
        {
            transform.position = StartPostition;
        }
    }
}
