using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    int score;

    public Text speedText;
    int speed;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //skor se povecava na osnovu predjenog puta ako se auto krece
        if (carSteering.moving)
            score += (int)(Time.fixedDeltaTime  * speed);

        scoreText.text = "" + score; //ispisivanje skora

        if (carSteering.moving)
        {
            //brzina se povecava ako se auto krece
            speed = (int)carSteering.speed * 11;
            speedText.text = speed + " km/h"; //ispisivanje brzine
        }else speedText.text = "0 km/h";
    }

    public void Play()
    {
        Application.LoadLevel("Scene1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
