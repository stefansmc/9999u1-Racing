using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //na startu se game over ekran ne vidi
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!carSteering.moving)
        {
            //ako se slupamo, prikazujemo ga
            gameObject.GetComponent<Renderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //kada igrac pritisne space, vraca se na pocetni ekran i vreme se ponovo pokrece
                Time.timeScale = 1;
                Application.LoadLevel("StartniEkran");
            }
                
        }
    }
}
