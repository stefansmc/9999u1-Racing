using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //da se automobili i drvece koji izadju sa ekrana ne bi gomilali u memoriji, napravili smo
        //nevidljivi hitbox koji kada dotaknu - brisu se iz memorije
        if(col.gameObject.tag == "EnemyCar")
        {
            Destroy(col.gameObject);
        }
    }
}
