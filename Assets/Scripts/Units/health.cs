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
    private squad squadScript = null; // Ajouter une référence au script squad

    private int maxHealth;
    private int currenthealth;
    private Color healthColor;

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir une référence au script squad
        try
        {
            squadScript = GetComponentInParent<squad>();
        }
        catch { }

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
        if (gameObject.name == "Unit")
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
            if(gameObject.name == "Unit")
            {
                selectionController.GetComponent<SelectionController>().availableWarriorList.Remove(GetComponent<Transform>().GetChild(0).gameObject);
                selectionController.GetComponent<SelectionController>().selectedWarriorList.Remove(GetComponent<Transform>().GetChild(0).gameObject);
            }
            else
            {
                GameObject original = GameObject.Find("body");
                GameObject cadavre = Instantiate(original);
                cadavre.SetActive(true);
                cadavre.transform.parent = GameObject.Find("Cadavres").transform;
            }
            // Supprimer l'unité de l'escouade
            if (squadScript != null)
            {
                squadScript.units.Remove(gameObject.transform.parent.gameObject);
                squadScript.slowestSpeed = squadScript.setSlowestSpeed();
                if (squadScript.units.Count == 0)
                {
                    Destroy(gameObject.transform.parent.parent.gameObject);
                    return;
                }
            }
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
