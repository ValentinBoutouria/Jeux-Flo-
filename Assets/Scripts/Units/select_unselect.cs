using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_unselect : MonoBehaviour
{
    public GameObject imageSelection;

    private void Start()
    {
        UnSelect();
    }

    public void Select()
    {
        //imageSelection.SetActive(true);
        imageSelection.GetComponent<Outline>().enabled = true;
    }

    public void UnSelect()
    {
        imageSelection.GetComponent<Outline>().enabled = false;
        //imageSelection.SetActive(false);
    }
}