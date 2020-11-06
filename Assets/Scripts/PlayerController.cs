using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    void Start()
    {
        
    }


    void dash() //doskok jaki postać wykonuje na spacje
    {
        if (Input.GetKeyDown("space"))
        {
            float speed_dash = 2000.0f; // predkosc/odleglosc doskoku
            var move_dash = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move_dash * speed_dash * Time.deltaTime;
        }
        
    }

    float speed = 13.0f; // predkosc postaci

    ///// te dwie zmienne są do tego aby dashować można było tylko co sekundę
  //  private float time = 0.0f;
  //  public float interpolationPeriod = 0.01f;
    //////////////////

    void Update()
    {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

   //     time += Time.deltaTime;

      //  if (time >= interpolationPeriod)
       /// {
       //     time = time - interpolationPeriod;
            dash();

            
     //   }

    }


}