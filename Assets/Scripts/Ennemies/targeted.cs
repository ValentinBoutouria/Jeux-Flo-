using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeted : MonoBehaviour
{

    public GameObject selectionController;
    public GameObject generalScript;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
        generalScript = GameObject.FindGameObjectWithTag("empty");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        generalScript.GetComponent<mouseOversomething>().ennemi = 1;

        this.gameObject.GetComponent<Outline>().enabled = true;
        if(Input.GetMouseButtonUp(1))
        { 
            foreach(var warrior in selectionController.GetComponent<SelectionController>().selectedWarriorList)
            {
                warrior.GetComponent<setMovement>().setMovementDest(this.GetComponent<Transform>().position, true, this.gameObject);
            }
        }
    }

    public void OnMouseExit()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
        generalScript.GetComponent<mouseOversomething>().ennemi = 0 ;

    }

    public void getDamages(int dgt)
    {
        gameObject.GetComponent<Transform>().GetChild(0).GetComponent<health>().getDamages(dgt);
    }
}
