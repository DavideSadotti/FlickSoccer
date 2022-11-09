using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballInstance;

    [SerializeField]
    GameObject ball;

    private void Awake()
    {
        //rendo lo script pubblico, quindi gestibile dall'esterno del file
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Spawn()
    {
        //istanzio l'oggetto ball, la posizione della palla iniziale, e blocco la rotazione
        ballInstance = Instantiate(ball, ball.transform.position, Quaternion.identity); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
