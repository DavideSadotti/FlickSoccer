using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortiereScript : MonoBehaviour
{
    Rigidbody rb;
    float mouseStart;
    float mouseEnd;
    bool right;
    float movingFloat;
    float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = rb.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))//considero un tocco con il mouse oppure un tap con il dito
        {
            //mouseStart = Input.GetTouch(0).position.x; // ---------------->> Da riattivare prima di creare l'apk
            mouseStart = Input.mousePosition.x; // Da usare solo quando si testa da PC
        }

        if((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && GameManager.instance.ballInstance != null)
        {
            //mouseEnd = Input.GetTouch(0).position.x; // ---------------->> Da riattivare prima di creare l'apk
            mouseEnd = Input.mousePosition.x; // Da usare solo quando si testa da PC

            if(mouseStart > mouseEnd)
            {
                right = true;
                movingFloat = mouseStart - mouseEnd;
            }
            else
            {
                right = false;
                movingFloat = mouseEnd - mouseStart;
            }

            Debug.Log("movingFloat = " + movingFloat);

            if(movingFloat > 150)
            {
                movingFloat = 150;
            }

            if(right == true)
            {
                //quando siamo dentro la void update dobbiamo assestarli sempre con "Time.deltaTime", sennò vengono fuori valori sballati
                rb.transform.Translate(Vector3.right * movingFloat * Time.deltaTime);
            }
            else
            {
                rb.transform.Translate(Vector3.right * -movingFloat * Time.deltaTime);
            }

            Invoke("resetPosition", 3f);
        }
    }

    public void resetPosition()
    {
        rb.transform.position = new Vector3(initialPos, transform.position.y, transform.position.z);
    }
}
