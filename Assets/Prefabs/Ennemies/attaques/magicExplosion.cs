using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicExplosion : MonoBehaviour
{
    private GameObject selectionController;
    public GameObject carac;
    // Start is called before the first frame update
    void Start()
    {
        selectionController = GameObject.FindGameObjectWithTag("selectionController");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().isStopped)
        {
            Destroy(gameObject);
        }
        else
        {
            foreach(var warrior in selectionController.GetComponent<SelectionController>().availableWarriorList) 
            {
                var dist = Vector3.Distance(gameObject.transform.position, warrior.transform.position);
                if( dist < GetComponent<ParticleSystem>().main.startSpeedMultiplier)
                {
                    warrior.GetComponent<health>().getDamages((int)(carac.GetComponent<caracEnnemie>().getAttaque()/ dist));
                }
            }
        }
    }
}
