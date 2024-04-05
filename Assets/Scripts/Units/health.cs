using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public GameObject carac;
    public GameObject healthBar;
    private GameObject Master;
    private GameObject selectionController;

    private int maxHealth;
    private int currenthealth;
    private Color healthColor;

    // Start is called before the first frame update
    void Start()
    {
        selectionController = GameObject.FindGameObjectWithTag("selectionController");
        try
        {
            maxHealth = carac.GetComponent<caracteristique>().getVie();
        }
        catch
        {
            maxHealth = carac.GetComponent<caracEnnemie>().getVie();
        }
        currenthealth = maxHealth;
        healthColor = Color.green;
        if (gameObject.tag == "unit")
            Master = GetComponent<Transform>().parent.parent.gameObject;
        else
            Master = GetComponent<Transform>().parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void getDamages(int dgt)
    {
        currenthealth -= dgt;

        if (currenthealth <= 0) 
        {
            Debug.Log(selectionController.GetComponent<SelectionController>().availableWarriorList.Remove(GetComponent<Transform>().GetChild(0).gameObject));
            Debug.Log(selectionController.GetComponent<SelectionController>().selectedWarriorList.Remove(GetComponent<Transform>().GetChild(0).gameObject));

            Destroy(Master);
        }
        majHealthBar();
    }

    private void majHealthBar()
    {
        float rate = (float)((float)currenthealth / (float)maxHealth);
        healthColor.g = rate;
        healthColor.r = 1-rate;
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(2*rate, healthBar.GetComponent<RectTransform>().sizeDelta.y);
        healthBar.GetComponent<Image>().color = healthColor;
    }

}
