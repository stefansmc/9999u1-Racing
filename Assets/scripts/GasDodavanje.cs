using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDodavanje : MonoBehaviour
{
    public Sprite aktivan, neaktivan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dugme za dodavanje gasa menja izgled na osnovu toga da li je pritisnuto ili ne
        if (Input.GetKey(KeyCode.Space) && carSteering.moving){
            GetComponent<SpriteRenderer>().sprite = aktivan;
        }else{
            GetComponent<SpriteRenderer>().sprite = neaktivan;
        }
    }
}
