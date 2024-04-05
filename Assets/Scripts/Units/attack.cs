using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private GameObject carac;

    private int attaque;
    private int vitesseAttaque;
    private int portee;
    public GameObject target = null;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        carac = gameObject.GetComponent<Transform>().parent.parent.parent.GetChild(0).gameObject;
        attaque = carac.GetComponent<caracteristique>().getAttaque();
        vitesseAttaque = carac.GetComponent<caracteristique>().getVitesseAttaque();
        portee = carac.GetComponent<caracteristique>().getPortee();

        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(GetComponent<Transform>().position, target.GetComponent<Transform>().position));
        if (target != null && Vector3.Distance(GetComponent<Transform>().position, target.GetComponent<Transform>().position) <= portee+0.5)
        {
            timer += Time.deltaTime;
            if(timer > vitesseAttaque) 
            {
                timer = 0;
                target.GetComponent<targeted>().getDamages(attaque);
            }
        }
    }

    public void setEnnemie(GameObject e) 
    {
        target = e;
    }
}


