using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workersRecolt : MonoBehaviour
{

    public bool autoRecolt;
    public bool isCharged;
    public bool selected;
    private listCorpses listCorpsesScript;
    GameObject closestCorpse = null;

    // Start is called before the first frame update
    void Start()
    {
        autoRecolt = true;
        selected = false;
        isCharged = false;
        listCorpsesScript = GameObject.Find("Cadavres").GetComponent<listCorpses>();

    }

    // Update is called once per frame
    void Update()
    {
        if(selected && Input.GetKeyDown(KeyCode.A))
        {
            autoRecolt = !autoRecolt;
        }
        if(autoRecolt)
        {
            if(!isCharged)
            {
                goFindClosestCorpse();
            }
            else
            {
                goToClosestStorage();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCharged && other.gameObject.tag == "deadBody")
        {
            other.transform.parent = this.transform;
            isCharged = true;
        }
    }
    

    private void goFindClosestCorpse()
    {
        //go to closest corpse
        closestCorpse = null;
        //recolt
        foreach (var corpse in listCorpsesScript.corpses)
        {
            if (corpse != null && (closestCorpse == null || Vector3.Distance(corpse.transform.position, this.transform.position) < Vector3.Distance(closestCorpse.transform.position, this.transform.position)))
            {
                closestCorpse = corpse;
            }
        }
        if (closestCorpse != null)
        {
            GetComponent<setMovement>().setMovementDest(closestCorpse.transform.position);
        }
    }

    private void goToClosestStorage()
    {
        //go to closest storage
        GameObject closestStorage = null;
        foreach (var storage in listCorpsesScript.storages)
        {
            if (storage != null && (closestStorage == null || Vector3.Distance(storage.transform.position, this.transform.position) < Vector3.Distance(closestStorage.transform.position, this.transform.position)))
            {
                closestStorage = storage;
            }
        }
        if (closestStorage != null)
        {
            GetComponent<setMovement>().setMovementDest(closestStorage.transform.position);
        }
    }
    
}
