using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegnaPuntiScript : MonoBehaviour
{
    int goalDone;
    int goalMissed;
    public Text goalDoneTxt;
    public Text goalMiseedTxt;

    // Start is called before the first frame update
    void Start()
    {
        goalDone = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            goalDone++;
            goalDoneTxt.text = "Goals: " + goalDone;
        }
    }

    //creare metodo per conteggiare i goal sbagliati
}
