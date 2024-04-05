using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    private GameObject carac;
    public GameObject healthBar;

    private int maxHealth;
    private int currenthealth;
    private Color healthColor;

    // Start is called before the first frame update
    void Start()
    {
        carac = gameObject.GetComponent<Transform>().parent.parent.GetChild(0).gameObject;
        maxHealth = carac.GetComponent<caracteristique>().getVie();
        currenthealth = maxHealth;
        healthColor = Color.green;

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
            Debug.Log("DESTRUCTION : ----------- " + GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>().availableWarriorList.Remove(this.gameObject.GetComponent<Transform>().GetChild(0).gameObject));
            Destroy(carac.GetComponent<Transform>().parent.gameObject);
        }
        majHealthBar();
    }

    private void majHealthBar()
    {
        float rate = (float)((float)currenthealth / (float)maxHealth);
        healthColor.g -= rate*300;
        healthColor.r += rate * 200;
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(2*rate, healthBar.GetComponent<RectTransform>().sizeDelta.y);
        healthBar.GetComponent<Image>().color = healthColor;
    }

}
