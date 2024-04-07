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

    public GameObject effet;

    public GameObject plus_proche;
    public float min_dist = -1;
    public float dist;

    private string classe;

    public List<GameObject> availableWarriorList;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        vitesseAtt = gameObject.GetComponent<caracEnnemie>().getVitesseAttaque();
        portee = gameObject.GetComponent<caracEnnemie>().getPortee();
        attaque = gameObject.GetComponent<caracEnnemie>().getAttaque();

        availableWarriorList = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>().availableWarriorList;
        classe = gameObject.GetComponent<caracEnnemie>().getClasse();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            plus_proche = null;
            min_dist = -1;
            foreach (var warrior in availableWarriorList)
            {
                dist = Vector3.Distance(warrior.transform.position, gameObject.transform.position);

                if (min_dist == -1)
                {
                    plus_proche = warrior;
                    min_dist = dist;
                }

                if (dist < min_dist)
                {
                    if (dist < portee)
                    {
                        min_dist = dist;
                        plus_proche = warrior;
                    }
                }
            }
            if (Vector3.Distance(plus_proche.transform.position, gameObject.transform.position) > portee)
            {
                plus_proche = null;
            }

            attack(plus_proche);

        }
        catch { timer = 0; }

    }

    private void attack(GameObject warrior)
    {
        if (warrior == null)
            return;

        timer += Time.deltaTime;

        if (timer > vitesseAtt)
        {
            timer = 0;
            switch(classe)
            {
                case "spinne":
                    warrior.GetComponent<Transform>().parent.GetComponent<health>().getDamages(attaque);
                    break;

                case "mage__":
                    explosion(warrior);
                    break;
            }

        }
    }


    public void explosion(GameObject warrior)
    {
        var tmp = GameObject.Instantiate<GameObject>(effet, warrior.transform.position, warrior.transform.rotation);
        tmp.SetActive(true);
        tmp.GetComponent<ParticleSystem>().Play();

    }
}
