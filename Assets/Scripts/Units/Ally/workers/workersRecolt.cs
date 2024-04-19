using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workersRecolt : MonoBehaviour
{

    public bool autoRecolt;
    public bool isCharged;
    public bool selected;
    private listCorpses listCorpsesScript;
    private Selection autresRessourcesScript;
    private List<GameObject> stoneList;
    private List<GameObject> woodList;
    private List<GameObject> goldList;
    public string ressourceType;
    GameObject closestRessource = null;

    // Start is called before the first frame update
    void Start()
    {
        autoRecolt = false;
        selected = false;
        isCharged = false;
        listCorpsesScript = GameObject.Find("Cadavres").GetComponent<listCorpses>();
        autresRessourcesScript = GameObject.Find("Action/Liste Manager").GetComponent<Selection>();
        woodList = autresRessourcesScript.listeGameObjectWOOD;
        stoneList = autresRessourcesScript.listeGameObjectStone;
        goldList = autresRessourcesScript.listeGameObjectGold;

        ressourceType = "all";
    }

    // Update is called once per frame
    void Update()
    {
        changeMode();
        if(autoRecolt)
        {
            if(!isCharged)
            {
                goFindClosestRessource(ressourceType);
            }
            else
            {
                goToClosestStorage();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCharged && other.gameObject.tag == "ressourceTag")
        {
            other.transform.parent = this.transform;
            isCharged = true;
        }
    }
    

    private void goFindClosestRessource(string ressourceType = "all")
    {
        //go to closest corpse
        closestRessource = null;
        //recolt
        switch (ressourceType)
        {
            case "corpse":
                closestCorpse();
                break;
            case "wood":
                closestNotCorpse(woodList);
                break;
            case "stone":
                closestNotCorpse(stoneList);
                break;
            case "gold":
                closestNotCorpse(goldList);
                break;

            case "all":
                closestCorpse();
                closestNotCorpse(woodList);
                closestNotCorpse(stoneList);
                closestNotCorpse(goldList);
                break;
        }
        if (    closestRessource != null)
        {
            GetComponent<setMovement>().setMovementDest(closestRessource.transform.position);
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

    private void closestNotCorpse(List<GameObject> li)
    {
        foreach (var wood in li)
        {
            if (wood != null && (closestRessource == null || Vector3.Distance(wood.transform.position, this.transform.position) < Vector3.Distance(closestRessource.transform.position, this.transform.position)))
            {
                closestRessource = wood;
            }
        }
    }

    private void closestCorpse()
    {
        foreach (var corpse in listCorpsesScript.corpses)
        {
            if (corpse != null && (closestRessource == null || Vector3.Distance(corpse.transform.position, this.transform.position) < Vector3.Distance(closestRessource.transform.position, this.transform.position)))
            {
                closestRessource = corpse;
            }
        }
    }

    private void changeMode()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            { 
                autoRecolt = !autoRecolt;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                ressourceType = "corpse";
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                ressourceType = "wood";
            }   
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                ressourceType = "stone";
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                ressourceType = "gold";
            }
        }
    }
    
}
