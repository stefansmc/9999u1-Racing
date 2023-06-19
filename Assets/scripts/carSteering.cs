using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSteering : MonoBehaviour
{
    Vector3 CarPosition, StartPosition;
    public static float speed = 5f;
    public float minSpeed = 5f; //min brzina
    public float maxSpeed = 20f; //max brzina


    //pocetno i max ubrzanje
    public static float acceleration = 4;
    public float maxAcceleration = 4;

    //tajmer za spawnovanje automobila i drveca (drvece je kozmeticko ali vuce isti tajmer)
    public static float timer = 1.375f;
    float minTimer = 0.5f;
    float maxTimer = 1.375f;

    //zaustavljanje kretanja kada poginemo
    public static bool moving;
    public Sprite normalan, slupan;

    void UbrzavanjeKrozVreme()
    {
        //povecavamo brzinu kretanja igraca, i ubrzavamo tajmer spawnovanja automobila
        minSpeed += 0.5f;
        //maxTimer -= maxAcceleration * (1 - speed/maxSpeed); //formula za tajmer, kasnije se koristi i vise je objasnjena
    }

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        GetComponent<SpriteRenderer>().sprite = normalan;
        CarPosition = transform.position;
        StartPosition = transform.position;
        InvokeRepeating("UbrzavanjeKrozVreme", 2.0f, 3.0f); //pozivamo ubrzavanje kroz vreme nakon 2sec, i posle toga na svakih 3 sec
    }

    // Update is called once per frame
    void Update()
    {
        //skretanje levo
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (CarPosition.x > -0.5f) && moving)
        {
            CarPosition.x -= 2.14f;
            transform.position = CarPosition;
        }
        //skretanje desno
        if (Input.GetKeyDown(KeyCode.RightArrow) && (CarPosition.x < 3.77f) && moving)
        {
            CarPosition.x += 2.14f;
            transform.position = CarPosition;
        }


        //dodavanje i pustanje gasa
        float speedRatio;
       
        if (Input.GetKey(KeyCode.Space) && moving)
        {
            //nelinearno ubrzanje
            //sto je auto brzi, to sporije ubrzava
            speedRatio = speed / maxSpeed;
            acceleration = maxAcceleration * (1 - speedRatio);
            speed += acceleration * Time.fixedDeltaTime;
            if (speed >= maxSpeed) speed = maxSpeed;

            //ubrzavamo spawnovanje novih automobila
            timer -= acceleration / 6;
            if (timer <= minTimer) timer = minTimer;
        }
        else
        {
            //nelinearno negativno ubrzanje (usporavanje kada pustimo gas)
            //sto je auto brzi, to brze usporava
            speedRatio = minSpeed / speed;
            acceleration = maxAcceleration * (1 - speedRatio);
            speed -= acceleration * Time.fixedDeltaTime;
            if (speed <= minSpeed) speed = minSpeed;

            //usporavamo spawnovanje novih automobila
            timer += acceleration / 6;
            if (timer >= maxTimer) timer = maxTimer;
        }





    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //sudaranje
        if (col.gameObject.tag == "EnemyCar")
        {
            moving = false;
            GetComponent<SpriteRenderer>().sprite = slupan; //eksplozija
            Time.timeScale = 0; //puziramo vreme
        }
    }
}
