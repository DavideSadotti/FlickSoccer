using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    public void Spawn()
    {
        //istanzio l'oggetto ball, la posizione della palla iniziale, e blocco la rotazione
        Instantiate(ball, ball.transform.position, Quaternion.identity); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void daiazzo(){
        
    }
}
