using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrvoSpawner : MonoBehaviour
{
    public GameObject drvo;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = carSteering.timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //spawnujemo  drvece levo i desno u okvirima gde je trava
            Vector3 drveceDesno = new Vector3(Random.Range(5.55f, 7.15f), transform.position.y + Random.Range(-2,2), transform.position.z);
            Vector3 drveceLevo = new Vector3(Random.Range(-4.7f, -2.4f), transform.position.y + Random.Range(-2, 2), transform.position.z);
            Instantiate(drvo, drveceDesno, transform.rotation);
            Instantiate(drvo, drveceLevo, transform.rotation);
            timer = carSteering.timer; //vuce brzinu spawnovanja na osnovu brzine igraca
        }
    }
}
