using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class badGuysAttacks : MonoBehaviour
{
    private float timer;
    private int vitesseAtt;
    private int portee;
    private int attaque;


    public List<GameObject> availableWarriorList;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        vitesseAtt = gameObject.GetComponent<caracEnnemie>().getVitesseAttaque();
        portee = gameObject.GetComponent<caracEnnemie>().getPortee();
        attaque = gameObject.GetComponent<caracEnnemie>().getAttaque();

        availableWarriorList = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>().availableWarriorList;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            foreach (var warrior in availableWarriorList)
            {
                if (Vector3.Distance(warrior.transform.position, gameObject.transform.position) < portee)
                {
                    attack(warrior);
                }
            }
        }
        catch { timer = 0; }

    }

    private void attack(GameObject warrior)
    {
        if(gameObject.name == "spinner")
        {
            timer += Time.deltaTime;

            if (timer > vitesseAtt)
            {
                timer = 0;
                warrior.GetComponent<Transform>().parent.GetComponent<health>().getDamages(attaque);
            }
        }
    }
}
