using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class select_unselect : MonoBehaviour
{
    public GameObject imageSelection;
    public isWorkerSelected workerSelectedScript;

    public bool isSelected = false;


    private void Start()
    {
        workerSelectedScript = GameObject.FindObjectOfType<isWorkerSelected>();

        UnSelect();
    }

    public void Select()
    {
        imageSelection.GetComponent<Outline>().enabled = true;
        isSelected = true;
        if (this.transform.parent.parent.parent.tag == "Worker")
        {
            this.GetComponent<workersRecolt>().selected = true;
            workerSelectedScript.nbWorkerSelected++;
        }
    }

    public void UnSelect()
    {
        imageSelection.GetComponent<Outline>().enabled = false;
        isSelected = false;
        if (this.transform.parent.parent.parent.tag == "Worker")
        {
            this.GetComponent<workersRecolt>().selected = false;
            workerSelectedScript.nbWorkerSelected--;
        }
    }
}