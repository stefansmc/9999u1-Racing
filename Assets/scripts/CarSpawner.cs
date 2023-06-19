using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    //fiksne pozicije gde se mogu pojaviti automobili - leva, desna, i srednja traka
    public static float posM = 1.59f; //srednja traka
    public static float posL = posM - 2.11f; //leva traka
    public static float posR = posM + 2.11f; //desna traka
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = carSteering.timer; //vuce brzinu spawnovanja na osnovu brzine igraca
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime; //inkrementujemo tajmer
        if(timer <= 0) { //kada tajmer dodje do 0
            float[] xPositions = new float[] { posM, posL, posR }; //dajemo mu 3 niz od 3 moguce pozicije
            int index = Random.Range(0, 3); //bira izmedju njih (ne znam zasto ali kad je islo 0 do 2 nije htelo, niti 1 do 3; ovako jedino radi)
            Vector3 carPos = new Vector3(xPositions[index], transform.position.y, transform.position.z);
            Instantiate(car, carPos, transform.rotation);
            timer = carSteering.timer; //restartujemo tajmer
        }
    }


}
