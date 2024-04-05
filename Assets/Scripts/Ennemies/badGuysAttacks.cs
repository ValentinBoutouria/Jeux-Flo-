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

    private int RayonExplosion = 5;
    public GameObject effet;

    public GameObject plus_proche;
    float min_dist = -1;

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
                if(min_dist == -1)
                    plus_proche = warrior;
                var dist = Vector3.Distance(warrior.transform.position, gameObject.transform.position);
                if ( dist < portee)
                {
                    if(dist < min_dist)
                    {
                        min_dist = dist;
                        plus_proche = warrior;
                    }
                    attack(plus_proche);
                }
            }
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
        var tmp = GameObject.Instantiate<GameObject>(effet, warrior.transform);
        Debug.Log("Particle sys ---------- " + tmp.activeSelf);
        tmp.SetActive(true);
        foreach(var unit in availableWarriorList)
        {
            var dist = Vector3.Distance(warrior.GetComponent<Transform>().position, unit.transform.position);
            if (dist < RayonExplosion)
            {
                Debug.Log("BOUUUUUUUUUUUUUUUUUUUM : " + warrior);
                warrior.GetComponent<Transform>().parent.GetComponent<health>().getDamages((int)((float)attaque/(float)(dist+1)));
            }
        }
    }
}
