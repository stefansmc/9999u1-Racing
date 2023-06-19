using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class DrvoMovement : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = carSteering.speed; //vuce brzinu igraca
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime); //pomera se za jedan piksel unazad * brzina
    }
}
