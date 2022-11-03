using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval; //per calcolare la forza da dare in direzione Z

    [SerializeField]//Impostare valore nella schermata di Unity senza creare una public(le public meglio non utilizzarle perché sono più pesanti)
    float forceXY = 1f;
    [SerializeField]
    float forceZ = 50f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))//considero un tocco con il mouse oppure un tap con il dito
        {
            //prendo il tempo del primo tocco sullo schermo
            touchTimeStart = Time.time;

            //startPos = Input.GetTouch(0).position; // ---------------->> Da riattivare prima di creare l'apk
            startPos = Input.mousePosition; // Da usare solo quando si testa da PC
        }

        if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            touchTimeFinish = Time.time;

            //Calcolo l'intervallo di tempo passato
            timeInterval = touchTimeFinish - touchTimeStart;

            //endPos = Input.GetTouch(0).position; // ---------------->> Da riattivare prima di creare l'apk
            endPos = Input.mousePosition; // Da usare solo quando si testa da PC

            //calcolo pa posizione
            direction = startPos - endPos;

            rb.isKinematic = false;
            //aggiungiamo una forza alla palla
            //se imposto direction senza meno la palla andrebbe dal lato opposto
            rb.AddForce(-direction.x * forceXY, -direction.y * forceXY, forceZ / timeInterval);

            //distruggo l'oggetto palla dopo 3 secondi
            Destroy(gameObject, 3f);
        }
    }
}
